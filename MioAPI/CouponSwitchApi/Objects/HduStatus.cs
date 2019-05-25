using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MioAPI
{
    [DataContract]
    public class HduStatus
    {
        [DataMember(Name = "hduServiceCode")]
        public string HduServiceCode { get; set; }

        [DataMember(Name = "couponUse")]
        public bool CouponUse { get; set; }
    }
}
