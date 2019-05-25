using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MioAPI
{
    [DataContract]
    public class Coupon
    {
        [DataMember(Name = "volume")]
        public int Volume { get; set; }

        [DataMember(Name = "expire")]
        public string Expire { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }
    }
}
