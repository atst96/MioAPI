using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MioAPI
{
    [DataContract]
    public class CouponInfo
    {
        [DataMember(Name = "hddServiceCode")]
        public string HddServiceCode { get; set; }

        [DataMember(Name = "plan")]
        public string Plan { get; set; }

        [DataMember(Name = "hdoInfo")]
        public HdoInfo[] HdoInfo { get; set; }

        [DataMember(Name = "hduInfo")]
        public HduInfo[] HduInfo { get; set; }

        [DataMember(Name = "coupon")]
        public Coupon[] Coupon { get; set; }

        [DataMember(Name = "history")]
        public History[] History { get; set; }

        [DataMember(Name = "remains")]
        public int Remains { get; set; }
    }
}
