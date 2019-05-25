using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MioAPI
{
    [DataContract]
    public class HduInfo : HduStatus
    {
        [DataMember(Name = "number")]
        public string Number { get; set; }

        [DataMember(Name = "iccid")]
        public string IccId { get; set; }

        [DataMember(Name = "regulation")]
        public bool Regulation { get; set; }

        [DataMember(Name = "sms")]
        public bool Sms { get; set; }

        [DataMember(Name = "voice")]
        public bool Voice { get; set; }

        [DataMember(Name = "coupon")]
        public Coupon[] Coupon { get; set; }
    }
}
