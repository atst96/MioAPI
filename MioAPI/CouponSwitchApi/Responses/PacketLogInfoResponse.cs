using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MioAPI
{
    [DataContract]
    public class PacketLogInfoResponse : CouponSwitchResponse
    {
        [DataMember(Name = "packetLogInfo")]
        public PacketLogInfo[] PacketLogInfo { get; set; }
    }
}
