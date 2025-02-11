﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CricketApp.PlayerServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Player", Namespace="http://schemas.datacontract.org/2004/07/PlayerService")]
    [System.SerializableAttribute()]
    public partial class Player : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int MatchesPlayedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PlayerIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PlayerNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TotalRunsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TotalWicketsField;
        
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
        public int MatchesPlayed {
            get {
                return this.MatchesPlayedField;
            }
            set {
                if ((this.MatchesPlayedField.Equals(value) != true)) {
                    this.MatchesPlayedField = value;
                    this.RaisePropertyChanged("MatchesPlayed");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PlayerID {
            get {
                return this.PlayerIDField;
            }
            set {
                if ((this.PlayerIDField.Equals(value) != true)) {
                    this.PlayerIDField = value;
                    this.RaisePropertyChanged("PlayerID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PlayerName {
            get {
                return this.PlayerNameField;
            }
            set {
                if ((object.ReferenceEquals(this.PlayerNameField, value) != true)) {
                    this.PlayerNameField = value;
                    this.RaisePropertyChanged("PlayerName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TotalRuns {
            get {
                return this.TotalRunsField;
            }
            set {
                if ((this.TotalRunsField.Equals(value) != true)) {
                    this.TotalRunsField = value;
                    this.RaisePropertyChanged("TotalRuns");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TotalWickets {
            get {
                return this.TotalWicketsField;
            }
            set {
                if ((this.TotalWicketsField.Equals(value) != true)) {
                    this.TotalWicketsField = value;
                    this.RaisePropertyChanged("TotalWickets");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PlayerServiceReference.PlayerInterface")]
    public interface PlayerInterface {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/PlayerInterface/GetPlayers", ReplyAction="http://tempuri.org/PlayerInterface/GetPlayersResponse")]
        System.Data.DataSet GetPlayers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/PlayerInterface/GetPlayers", ReplyAction="http://tempuri.org/PlayerInterface/GetPlayersResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> GetPlayersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/PlayerInterface/GetPlayer", ReplyAction="http://tempuri.org/PlayerInterface/GetPlayerResponse")]
        CricketApp.PlayerServiceReference.Player GetPlayer(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/PlayerInterface/GetPlayer", ReplyAction="http://tempuri.org/PlayerInterface/GetPlayerResponse")]
        System.Threading.Tasks.Task<CricketApp.PlayerServiceReference.Player> GetPlayerAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/PlayerInterface/GetPlayersByTeam", ReplyAction="http://tempuri.org/PlayerInterface/GetPlayersByTeamResponse")]
        System.Data.DataSet GetPlayersByTeam(int team_id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/PlayerInterface/GetPlayersByTeam", ReplyAction="http://tempuri.org/PlayerInterface/GetPlayersByTeamResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> GetPlayersByTeamAsync(int team_id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/PlayerInterface/AddPlayer", ReplyAction="http://tempuri.org/PlayerInterface/AddPlayerResponse")]
        void AddPlayer(CricketApp.PlayerServiceReference.Player player, int team_id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/PlayerInterface/AddPlayer", ReplyAction="http://tempuri.org/PlayerInterface/AddPlayerResponse")]
        System.Threading.Tasks.Task AddPlayerAsync(CricketApp.PlayerServiceReference.Player player, int team_id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/PlayerInterface/UpdatePlayerDetails", ReplyAction="http://tempuri.org/PlayerInterface/UpdatePlayerDetailsResponse")]
        void UpdatePlayerDetails(int id, int runs, int wickets);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/PlayerInterface/UpdatePlayerDetails", ReplyAction="http://tempuri.org/PlayerInterface/UpdatePlayerDetailsResponse")]
        System.Threading.Tasks.Task UpdatePlayerDetailsAsync(int id, int runs, int wickets);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/PlayerInterface/RemovePlayer", ReplyAction="http://tempuri.org/PlayerInterface/RemovePlayerResponse")]
        void RemovePlayer(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/PlayerInterface/RemovePlayer", ReplyAction="http://tempuri.org/PlayerInterface/RemovePlayerResponse")]
        System.Threading.Tasks.Task RemovePlayerAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface PlayerInterfaceChannel : CricketApp.PlayerServiceReference.PlayerInterface, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PlayerInterfaceClient : System.ServiceModel.ClientBase<CricketApp.PlayerServiceReference.PlayerInterface>, CricketApp.PlayerServiceReference.PlayerInterface {
        
        public PlayerInterfaceClient() {
        }
        
        public PlayerInterfaceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PlayerInterfaceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PlayerInterfaceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PlayerInterfaceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataSet GetPlayers() {
            return base.Channel.GetPlayers();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> GetPlayersAsync() {
            return base.Channel.GetPlayersAsync();
        }
        
        public CricketApp.PlayerServiceReference.Player GetPlayer(int id) {
            return base.Channel.GetPlayer(id);
        }
        
        public System.Threading.Tasks.Task<CricketApp.PlayerServiceReference.Player> GetPlayerAsync(int id) {
            return base.Channel.GetPlayerAsync(id);
        }
        
        public System.Data.DataSet GetPlayersByTeam(int team_id) {
            return base.Channel.GetPlayersByTeam(team_id);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> GetPlayersByTeamAsync(int team_id) {
            return base.Channel.GetPlayersByTeamAsync(team_id);
        }
        
        public void AddPlayer(CricketApp.PlayerServiceReference.Player player, int team_id) {
            base.Channel.AddPlayer(player, team_id);
        }
        
        public System.Threading.Tasks.Task AddPlayerAsync(CricketApp.PlayerServiceReference.Player player, int team_id) {
            return base.Channel.AddPlayerAsync(player, team_id);
        }
        
        public void UpdatePlayerDetails(int id, int runs, int wickets) {
            base.Channel.UpdatePlayerDetails(id, runs, wickets);
        }
        
        public System.Threading.Tasks.Task UpdatePlayerDetailsAsync(int id, int runs, int wickets) {
            return base.Channel.UpdatePlayerDetailsAsync(id, runs, wickets);
        }
        
        public void RemovePlayer(int id) {
            base.Channel.RemovePlayer(id);
        }
        
        public System.Threading.Tasks.Task RemovePlayerAsync(int id) {
            return base.Channel.RemovePlayerAsync(id);
        }
    }
}
