using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using TerminalLayoutService.Model;
using TerminalLayoutService;

namespace TerminalLayoutService.Helper
{
    /// <summary>
    /// The Main XML parser class which is a Thread Safe Singleton which uses LINQ to XML to
    /// parse the xml file and provide output
    /// </summary>
    public class XmlFileHelper
    {
        private static readonly Lazy<XmlFileHelper> _instance = new Lazy<XmlFileHelper>(()=>new XmlFileHelper(),true);

        private XmlFileHelper() { }

        public static XmlFileHelper Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public List<LockerInfo> ReadXml(string fileName)
        {
            var lockerInfoRet = new List<LockerInfo>();
            XElement element = XElement.Load(fileName);
            int count = 0;

            var res = from p in element.Descendants("LockersColumn")
                        let col = p
                        let columnno = count++
                        from locklist in col.Descendants("LockersList")
                        let lockerlist = locklist
                        from info in lockerlist.Descendants("LockerInfo")
                        let name = info.Element("Name")
                        let size = info.Element("Size")
                        let terminal = info.Element("Terminal")
                        select new LockerInfo() { Name = name.Value, Size = size.Value, IsTerminal = Boolean.Parse(terminal.Value.ToString()), ColumnNo = columnno };

            res.ToList().ForEach((item) =>
            {
                Debug.WriteLine(String.Format("{0},{1},{2},{3}", item.Name, item.Size, item.IsTerminal, item.ColumnNo));
                lockerInfoRet.Add(item);
            });

            return lockerInfoRet;
        }
    }
}
