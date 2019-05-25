using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MioAPI
{
    [DataContract]
    public class CouponInfoResponse : CouponSwitchResponse
    {
        [DataMember(Name = "couponInfo")]
        public CouponInfo[] CouponInfo { get; set; }
    }
}
