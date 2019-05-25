using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MioAPI
{
    [DataContract]
    public class HduPacketLog
    {
        [DataMember(Name = "hduServiceCode")]
        public string HduServiceCode { get; set; }

        [DataMember(Name = "packetLog")]
        public PacketLog[] PacketLog { get; set; }
    }
}
