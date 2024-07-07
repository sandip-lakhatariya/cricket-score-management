﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NewCricketHost.ServiceReference2 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Team", Namespace="http://schemas.datacontract.org/2004/07/TeamService")]
    [System.SerializableAttribute()]
    public partial class Team : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TeamIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TeamNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TeamID {
            get {
                return this.TeamIDField;
            }
            set {
                if ((this.TeamIDField.Equals(value) != true)) {
                    this.TeamIDField = value;
                    this.RaisePropertyChanged("TeamID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TeamName {
            get {
                return this.TeamNameField;
            }
            set {
                if ((object.ReferenceEquals(this.TeamNameField, value) != true)) {
                    this.TeamNameField = value;
                    this.RaisePropertyChanged("TeamName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference2.ITeamService")]
    public interface ITeamService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITeamService/GetTeams", ReplyAction="http://tempuri.org/ITeamService/GetTeamsResponse")]
        System.Data.DataSet GetTeams();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITeamService/GetTeams", ReplyAction="http://tempuri.org/ITeamService/GetTeamsResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> GetTeamsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITeamService/CreateTeam", ReplyAction="http://tempuri.org/ITeamService/CreateTeamResponse")]
        void CreateTeam(NewCricketHost.ServiceReference2.Team team);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITeamService/CreateTeam", ReplyAction="http://tempuri.org/ITeamService/CreateTeamResponse")]
        System.Threading.Tasks.Task CreateTeamAsync(NewCricketHost.ServiceReference2.Team team);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITeamServiceChannel : NewCricketHost.ServiceReference2.ITeamService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TeamServiceClient : System.ServiceModel.ClientBase<NewCricketHost.ServiceReference2.ITeamService>, NewCricketHost.ServiceReference2.ITeamService {
        
        public TeamServiceClient() {
        }
        
        public TeamServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TeamServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TeamServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TeamServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataSet GetTeams() {
            return base.Channel.GetTeams();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> GetTeamsAsync() {
            return base.Channel.GetTeamsAsync();
        }
        
        public void CreateTeam(NewCricketHost.ServiceReference2.Team team) {
            base.Channel.CreateTeam(team);
        }
        
        public System.Threading.Tasks.Task CreateTeamAsync(NewCricketHost.ServiceReference2.Team team) {
            return base.Channel.CreateTeamAsync(team);
        }
    }
}
