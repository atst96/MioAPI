using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MioAPI
{
    [DataContract]
    public class PacketLogInfo
    {
        [DataMember(Name = "hddServiceCode")]
        public string HddServiceCode { get; set; }

        [DataMember(Name = "plan")]
        public string Plan { get; set; }

        [DataMember(Name = "hdoInfo")]
        public HdoPacketLog[] HdoInfo { get; set; }

        [DataMember(Name = "hduInfo")]
        public HduPacketLog[] HduInfo { get; set; }
    }
}
