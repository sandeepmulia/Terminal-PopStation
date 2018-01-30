using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TerminalLayoutService.Model;

namespace TerminalLayoutService
{
    [ServiceContract(Name="LockerKiosk")]
    public interface ILockerService
    {
        [OperationContract]
        [FaultContract(typeof(FaultInfo))]
        List<LockerInfo> GetLockers();
    }
}
