using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MioAPI
{
    [DataContract]
    internal class CouponSwitchInfoRequest
    {
        [DataMember(Name = "hdoInfo")]
        public HdoStatus[] HdoInfo { get; set; }

        [DataMember(Name = "hduInfo")]
        public HduStatus[] HduInfo { get; set; }
    }
}
