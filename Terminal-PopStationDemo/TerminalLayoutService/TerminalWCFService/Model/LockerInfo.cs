using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TerminalLayoutService.Model
{
    [DataContract]
    [Serializable]
    public class LockerInfo
    {
        [DataMember] public string Name { get; set; }
        [DataMember] public string Size { get; set; }
        [DataMember] public bool IsTerminal { get; set; }
        [DataMember] public int ColumnNo { get; set; }
    }
}
