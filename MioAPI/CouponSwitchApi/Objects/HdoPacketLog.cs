using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MioAPI
{
    [DataContract]
    public class HdoPacketLog
    {
        [DataMember(Name = "hdoServiceCode")]
        public string HdoServiceCode { get; set; }

        [DataMember(Name = "packetLog")]
        public PacketLog[] PacketLog { get; set; }
    }
}
