using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MioAPI
{
    [DataContract]
    internal class CouponSwitchRequest
    {
        [DataMember(Name = "couponInfo")]
        public CouponSwitchInfoRequest[] CouponInfo { get; set; }
    }
}
