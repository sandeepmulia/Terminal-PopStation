using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TerminalLayoutService
{
    [DataContract]
    public class FaultInfo
    {
        [DataMember]
        public string Description { get; set; }
    }
}