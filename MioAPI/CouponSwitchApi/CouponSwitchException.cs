using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MioAPI
{
    internal class CouponSwitchException : WebException
    {
        public string ReturnCode { get; }

        public CouponSwitchException(CouponSwitchResponse response, WebException wex)
            : base(response?.ReturnCode, wex, wex.Status, wex.Response)
        {
            this.ReturnCode = response?.ReturnCode;
        }
    }
}
