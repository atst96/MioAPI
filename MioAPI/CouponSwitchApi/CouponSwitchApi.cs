using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MioAPI
{
    public class CouponSwitchApi
    {
        private const string ApiBaseUrl = "https://api.iijmio.jp/mobile/d/v2/";

        private string _tempAuthState;

        public string DeveloperId { get; }
        public string AccessToken { get; private set; }
        public string ExpiresIn { get; private set; }

        public CouponSwitchApi(string developerId)
        {
            this.DeveloperId = developerId;
        }

        public CouponSwitchApi(string developerId, string accessToken)
        {
            this.DeveloperId = developerId;
            this.AccessToken = accessToken;
        }

        private static HttpWebRequest CreateRequest(string method, string url)
        {
            var request = WebRequest.CreateHttp(url);
            request.Method = method;

            return request;
        }

        private HttpWebRequest CreateApiRequest(string method, string path)
        {
            var request = CreateRequest(method, ApiBaseUrl + path);

            var headers = request.Headers;
            headers.Add("X-IIJmio-Developer", this.DeveloperId);
            headers.Add("X-IIJmio-Authorization", this.AccessToken);

            return request;
        }

        private static async Task<T> ParseResponse<T>(WebResponse response)
        {
            using (var stream = response.GetResponseStream())
            {
                return await JsonUtils.DeserializeAsync<T>(stream).ConfigureAwait(false);
            }
        }

        private async Task<T> SendRequest<T>(HttpWebRequest request)
        {
            try
            {
                using (var response = await request.GetResponseAsync().ConfigureAwait(false))
                {
                    return await ParseResponse<T>(response).ConfigureAwait(false);
                }
            }
            catch (WebException wex) when (string.Equals(wex.Response?.ContentType, ContentTypes.Json, StringComparison.OrdinalIgnoreCase))
            {
                using (var response = wex.Response)
                {
                    var res = await ParseResponse<CouponSwitchResponse>(response).ConfigureAwait(false);

                    throw new CouponSwitchException(res, wex);
                }
            }
        }

        private Task<T> SendApiRequest<T>(string method, string path)
        {
            var request = this.CreateApiRequest(method, path);

            return this.SendRequest<T>(request);
        }

        public string GetAuthorizationUrl(string redirectUrl)
        {
            const string AuthBaseUrl = "https://api.iijmio.jp/mobile/d/v1/authorization/";

            var state = "state++" + Guid.NewGuid().ToString("N");
            this._tempAuthState = state;

            var parameters = new Dictionary<string, string>
            {
                ["response_type"] = TokenTypes.Token,
                ["client_id"] = this.DeveloperId,
                ["redirect_uri"] = redirectUrl,
                ["state"] = state,
            };

            return string.Join("?", AuthBaseUrl, UrlUtils.BuildParameters(parameters));
        }

        public void Authorize(string oauthResponse)
        {
            this.Authorize(UrlUtils.ParseQueryParameters(oauthResponse));
        }

        public void Authorize(IDictionary<string, string> parameters)
        {
            var accessToken = parameters["access_token"];
            var tokenType = parameters["token_type"];
            var expiresIn = parameters["expires_in"];
            var state = parameters["state"];

            if (tokenType != TokenTypes.Bearer)
            {
                throw new ArgumentException("Invalid token_type.");
            }

            if (state != this._tempAuthState)
            {
                throw new ArgumentException("Invalid state.");
            }

            this.AccessToken = accessToken;
            this.ExpiresIn = expiresIn;
            this._tempAuthState = null;
        }

        public Task<CouponInfoResponse> GetCouponInfoAsync()
        {
            return this.SendApiRequest<CouponInfoResponse>(HttpMethods.GET, "coupon/");
        }

        public async Task<CouponInfo> SetCouponInfoAsync(HdoStatus[] hdoInfo, HduStatus[] hduInfo)
        {
            var request = this.CreateApiRequest(HttpMethods.PUT, "coupon/");
            request.ContentType = ContentTypes.Json;

            var contentObject = new CouponSwitchRequest
            {
                CouponInfo = new[]
                {
                    new CouponSwitchInfoRequest
                    {
                        HdoInfo = hdoInfo ?? new HdoInfo[0],
                        HduInfo = hduInfo ?? new HduInfo[0],
                    }
                }
            };

            using (var requestStream = request.GetRequestStream())
            {
                await JsonUtils.SerializeAsync(contentObject, requestStream).ConfigureAwait(false);
            }

            return await this.SendRequest<CouponInfo>(request).ConfigureAwait(false);
        }

        public Task<PacketLogInfoResponse> GetPacketLog()
        {
            return this.SendApiRequest<PacketLogInfoResponse>(HttpMethods.GET, "log/packet/");
        }
    }
}
