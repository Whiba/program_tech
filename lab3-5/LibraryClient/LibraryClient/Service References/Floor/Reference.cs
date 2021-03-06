﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryClient.Floor {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Floor.ServFloor")]
    public interface ServFloor {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServFloor/get_Name", ReplyAction="http://tempuri.org/ServFloor/get_NameResponse")]
        string get_Name();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServFloor/get_Name", ReplyAction="http://tempuri.org/ServFloor/get_NameResponse")]
        System.Threading.Tasks.Task<string> get_NameAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServFloor/set_Name", ReplyAction="http://tempuri.org/ServFloor/set_NameResponse")]
        void set_Name(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServFloor/set_Name", ReplyAction="http://tempuri.org/ServFloor/set_NameResponse")]
        System.Threading.Tasks.Task set_NameAsync(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServFloor/getAllFloors", ReplyAction="http://tempuri.org/ServFloor/getAllFloorsResponse")]
        string getAllFloors(string num);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServFloor/getAllFloors", ReplyAction="http://tempuri.org/ServFloor/getAllFloorsResponse")]
        System.Threading.Tasks.Task<string> getAllFloorsAsync(string num);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServFloor/SaveFloor", ReplyAction="http://tempuri.org/ServFloor/SaveFloorResponse")]
        void SaveFloor();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServFloor/SaveFloor", ReplyAction="http://tempuri.org/ServFloor/SaveFloorResponse")]
        System.Threading.Tasks.Task SaveFloorAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServFloor/DeleteFloor", ReplyAction="http://tempuri.org/ServFloor/DeleteFloorResponse")]
        void DeleteFloor(string index);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServFloor/DeleteFloor", ReplyAction="http://tempuri.org/ServFloor/DeleteFloorResponse")]
        System.Threading.Tasks.Task DeleteFloorAsync(string index);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServFloor/UpdateFloor", ReplyAction="http://tempuri.org/ServFloor/UpdateFloorResponse")]
        void UpdateFloor(string index);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServFloor/UpdateFloor", ReplyAction="http://tempuri.org/ServFloor/UpdateFloorResponse")]
        System.Threading.Tasks.Task UpdateFloorAsync(string index);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ServFloorChannel : LibraryClient.Floor.ServFloor, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServFloorClient : System.ServiceModel.ClientBase<LibraryClient.Floor.ServFloor>, LibraryClient.Floor.ServFloor {
        
        public ServFloorClient() {
        }
        
        public ServFloorClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServFloorClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServFloorClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServFloorClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string get_Name() {
            return base.Channel.get_Name();
        }
        
        public System.Threading.Tasks.Task<string> get_NameAsync() {
            return base.Channel.get_NameAsync();
        }
        
        public void set_Name(string value) {
            base.Channel.set_Name(value);
        }
        
        public System.Threading.Tasks.Task set_NameAsync(string value) {
            return base.Channel.set_NameAsync(value);
        }
        
        public string getAllFloors(string num) {
            return base.Channel.getAllFloors(num);
        }
        
        public System.Threading.Tasks.Task<string> getAllFloorsAsync(string num) {
            return base.Channel.getAllFloorsAsync(num);
        }
        
        public void SaveFloor() {
            base.Channel.SaveFloor();
        }
        
        public System.Threading.Tasks.Task SaveFloorAsync() {
            return base.Channel.SaveFloorAsync();
        }
        
        public void DeleteFloor(string index) {
            base.Channel.DeleteFloor(index);
        }
        
        public System.Threading.Tasks.Task DeleteFloorAsync(string index) {
            return base.Channel.DeleteFloorAsync(index);
        }
        
        public void UpdateFloor(string index) {
            base.Channel.UpdateFloor(index);
        }
        
        public System.Threading.Tasks.Task UpdateFloorAsync(string index) {
            return base.Channel.UpdateFloorAsync(index);
        }
    }
}
