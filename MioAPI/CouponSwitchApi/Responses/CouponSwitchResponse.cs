using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MioAPI
{
    [DataContract]
    public class CouponSwitchResponse
    {
        [DataMember(Name = "returnCode")]
        public string ReturnCode { get; set; }
    }
}
