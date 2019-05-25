using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MioAPI
{
    [DataContract]
    public class HdoStatus
    {
        [DataMember(Name = "hdoServiceCode")]
        public string HdoServiceCode { get; set; }

        [DataMember(Name = "couponUse")]
        public bool CouponUse { get; set; }
    }
}
