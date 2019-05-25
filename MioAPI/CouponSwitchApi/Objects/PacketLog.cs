using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MioAPI
{
    [DataContract]
    public class PacketLog
    {
        [DataMember(Name = "date")]
        public string Date { get; set; }

        [DataMember(Name = "withCoupon")]
        public int WithCoupon { get; set; }

        [DataMember(Name = "withoutCoupon")]
        public int WithoutCoupon { get; set; }
    }
}
