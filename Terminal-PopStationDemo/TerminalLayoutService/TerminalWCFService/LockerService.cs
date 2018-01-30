using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Hosting;
using TerminalLayoutService.Helper;
using TerminalLayoutService.Model;

namespace TerminalLayoutService
{
    /// <summary>
    /// The LockerService Core class which provides the layout to the WPF UI 
    /// </summary>
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerSession)]
    public class LockerService : ILockerService
    {
        #region ILockerService Members

        public List<TerminalLayoutService.Model.LockerInfo> GetLockers()
        {
            try
            {
                var fullPath = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "LockerBank.xml");
                return XmlFileHelper.Instance.ReadXml(fullPath);
            }
            catch (Exception ex)
            {
                FaultInfo fi = new FaultInfo() { Description = String.Format("Caught an Exception while reading XML File{0}") };
                throw new FaultException<FaultInfo>(fi);
            }
        }

        #endregion
    }
}