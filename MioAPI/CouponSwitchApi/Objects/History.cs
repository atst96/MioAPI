using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MioAPI
{
    [DataContract]
    public class History
    {
        [DataMember(Name = "date")]
        public string Date { get; set; }

        [DataMember(Name = "event")]
        public string Event { get; set; }

        [DataMember(Name = "volume")]
        public int Volume { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }
    }
}
