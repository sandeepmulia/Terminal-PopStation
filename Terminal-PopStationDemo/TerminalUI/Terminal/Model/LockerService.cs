﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TerminalLayoutService.Model
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="LockerInfo", Namespace="http://schemas.datacontract.org/2004/07/TerminalLayoutService.Model")]
    public partial class LockerInfo : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int ColumnNoField;
        
        private bool IsTerminalField;
        
        private string NameField;
        
        private string SizeField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ColumnNo
        {
            get
            {
                return this.ColumnNoField;
            }
            set
            {
                this.ColumnNoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsTerminal
        {
            get
            {
                return this.IsTerminalField;
            }
            set
            {
                this.IsTerminalField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name
        {
            get
            {
                return this.NameField;
            }
            set
            {
                this.NameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Size
        {
            get
            {
                return this.SizeField;
            }
            set
            {
                this.SizeField = value;
            }
        }
    }
}
namespace TerminalLayoutService
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FaultInfo", Namespace="http://schemas.datacontract.org/2004/07/TerminalLayoutService")]
    public partial class FaultInfo : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string DescriptionField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description
        {
            get
            {
                return this.DescriptionField;
            }
            set
            {
                this.DescriptionField = value;
            }
        }
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="LockerKiosk")]
public interface LockerKiosk
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/LockerKiosk/GetLockers", ReplyAction="http://tempuri.org/LockerKiosk/GetLockersResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(TerminalLayoutService.FaultInfo), Action="http://tempuri.org/LockerKiosk/GetLockersFaultInfoFault", Name="FaultInfo", Namespace="http://schemas.datacontract.org/2004/07/TerminalLayoutService")]
    TerminalLayoutService.Model.LockerInfo[] GetLockers();
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/LockerKiosk/GetLockers", ReplyAction="http://tempuri.org/LockerKiosk/GetLockersResponse")]
    System.Threading.Tasks.Task<TerminalLayoutService.Model.LockerInfo[]> GetLockersAsync();
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface LockerKioskChannel : LockerKiosk, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class LockerKioskClient : System.ServiceModel.ClientBase<LockerKiosk>, LockerKiosk
{
    
    public LockerKioskClient()
    {
    }
    
    public LockerKioskClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public LockerKioskClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public LockerKioskClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public LockerKioskClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public TerminalLayoutService.Model.LockerInfo[] GetLockers()
    {
        return base.Channel.GetLockers();
    }
    
    public System.Threading.Tasks.Task<TerminalLayoutService.Model.LockerInfo[]> GetLockersAsync()
    {
        return base.Channel.GetLockersAsync();
    }
}
