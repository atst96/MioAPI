using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace MioAPI
{
    internal static class UrlUtils
    {
        public static string BuildParameters(IEnumerable<KeyValuePair<string, string>> parameters)
        {
            var pairs = parameters
                .Select(p => $"{p.Key}={WebUtility.UrlEncode(p.Value)}");

            return string.Join("&", pairs);
        }

        public static IDictionary<string, string> ParseQueryParameters(string value)
        {
            return value
                .Split('&')
                .Select(p => p.Split(new char[] { '=' }, 2))
                .ToDictionary(e => e[0], e => WebUtility.UrlDecode(e[1]));
        }
    }
}
