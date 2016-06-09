﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryClient.Employee {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Employee.SEmployee")]
    public interface SEmployee {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SEmployee/get_Employee_Name", ReplyAction="http://tempuri.org/SEmployee/get_Employee_NameResponse")]
        string get_Employee_Name();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SEmployee/get_Employee_Name", ReplyAction="http://tempuri.org/SEmployee/get_Employee_NameResponse")]
        System.Threading.Tasks.Task<string> get_Employee_NameAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SEmployee/set_Employee_Name", ReplyAction="http://tempuri.org/SEmployee/set_Employee_NameResponse")]
        void set_Employee_Name(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SEmployee/set_Employee_Name", ReplyAction="http://tempuri.org/SEmployee/set_Employee_NameResponse")]
        System.Threading.Tasks.Task set_Employee_NameAsync(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SEmployee/get_Employee_Factory", ReplyAction="http://tempuri.org/SEmployee/get_Employee_FactoryResponse")]
        string get_Employee_Factory();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SEmployee/get_Employee_Factory", ReplyAction="http://tempuri.org/SEmployee/get_Employee_FactoryResponse")]
        System.Threading.Tasks.Task<string> get_Employee_FactoryAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SEmployee/set_Employee_Factory", ReplyAction="http://tempuri.org/SEmployee/set_Employee_FactoryResponse")]
        void set_Employee_Factory(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SEmployee/set_Employee_Factory", ReplyAction="http://tempuri.org/SEmployee/set_Employee_FactoryResponse")]
        System.Threading.Tasks.Task set_Employee_FactoryAsync(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SEmployee/get_Employee_Position", ReplyAction="http://tempuri.org/SEmployee/get_Employee_PositionResponse")]
        string get_Employee_Position();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SEmployee/get_Employee_Position", ReplyAction="http://tempuri.org/SEmployee/get_Employee_PositionResponse")]
        System.Threading.Tasks.Task<string> get_Employee_PositionAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SEmployee/set_Employee_Position", ReplyAction="http://tempuri.org/SEmployee/set_Employee_PositionResponse")]
        void set_Employee_Position(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SEmployee/set_Employee_Position", ReplyAction="http://tempuri.org/SEmployee/set_Employee_PositionResponse")]
        System.Threading.Tasks.Task set_Employee_PositionAsync(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SEmployee/Insert", ReplyAction="http://tempuri.org/SEmployee/InsertResponse")]
        void Insert();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SEmployee/Insert", ReplyAction="http://tempuri.org/SEmployee/InsertResponse")]
        System.Threading.Tasks.Task InsertAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SEmployee/Update", ReplyAction="http://tempuri.org/SEmployee/UpdateResponse")]
        void Update(string newname);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SEmployee/Update", ReplyAction="http://tempuri.org/SEmployee/UpdateResponse")]
        System.Threading.Tasks.Task UpdateAsync(string newname);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SEmployee/Delete", ReplyAction="http://tempuri.org/SEmployee/DeleteResponse")]
        void Delete(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SEmployee/Delete", ReplyAction="http://tempuri.org/SEmployee/DeleteResponse")]
        System.Threading.Tasks.Task DeleteAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SEmployee/toString", ReplyAction="http://tempuri.org/SEmployee/toStringResponse")]
        string toString();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SEmployee/toString", ReplyAction="http://tempuri.org/SEmployee/toStringResponse")]
        System.Threading.Tasks.Task<string> toStringAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SEmployee/get", ReplyAction="http://tempuri.org/SEmployee/getResponse")]
        string get();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SEmployee/get", ReplyAction="http://tempuri.org/SEmployee/getResponse")]
        System.Threading.Tasks.Task<string> getAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SEmployee/getByName", ReplyAction="http://tempuri.org/SEmployee/getByNameResponse")]
        string getByName(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SEmployee/getByName", ReplyAction="http://tempuri.org/SEmployee/getByNameResponse")]
        System.Threading.Tasks.Task<string> getByNameAsync(string name);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface SEmployeeChannel : LibraryClient.Employee.SEmployee, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SEmployeeClient : System.ServiceModel.ClientBase<LibraryClient.Employee.SEmployee>, LibraryClient.Employee.SEmployee {
        
        public SEmployeeClient() {
        }
        
        public SEmployeeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SEmployeeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SEmployeeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SEmployeeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string get_Employee_Name() {
            return base.Channel.get_Employee_Name();
        }
        
        public System.Threading.Tasks.Task<string> get_Employee_NameAsync() {
            return base.Channel.get_Employee_NameAsync();
        }
        
        public void set_Employee_Name(string value) {
            base.Channel.set_Employee_Name(value);
        }
        
        public System.Threading.Tasks.Task set_Employee_NameAsync(string value) {
            return base.Channel.set_Employee_NameAsync(value);
        }
        
        public string get_Employee_Factory() {
            return base.Channel.get_Employee_Factory();
        }
        
        public System.Threading.Tasks.Task<string> get_Employee_FactoryAsync() {
            return base.Channel.get_Employee_FactoryAsync();
        }
        
        public void set_Employee_Factory(string value) {
            base.Channel.set_Employee_Factory(value);
        }
        
        public System.Threading.Tasks.Task set_Employee_FactoryAsync(string value) {
            return base.Channel.set_Employee_FactoryAsync(value);
        }
        
        public string get_Employee_Position() {
            return base.Channel.get_Employee_Position();
        }
        
        public System.Threading.Tasks.Task<string> get_Employee_PositionAsync() {
            return base.Channel.get_Employee_PositionAsync();
        }
        
        public void set_Employee_Position(string value) {
            base.Channel.set_Employee_Position(value);
        }
        
        public System.Threading.Tasks.Task set_Employee_PositionAsync(string value) {
            return base.Channel.set_Employee_PositionAsync(value);
        }
        
        public void Insert() {
            base.Channel.Insert();
        }
        
        public System.Threading.Tasks.Task InsertAsync() {
            return base.Channel.InsertAsync();
        }
        
        public void Update(string newname) {
            base.Channel.Update(newname);
        }
        
        public System.Threading.Tasks.Task UpdateAsync(string newname) {
            return base.Channel.UpdateAsync(newname);
        }
        
        public void Delete(string name) {
            base.Channel.Delete(name);
        }
        
        public System.Threading.Tasks.Task DeleteAsync(string name) {
            return base.Channel.DeleteAsync(name);
        }
        
        public string toString() {
            return base.Channel.toString();
        }
        
        public System.Threading.Tasks.Task<string> toStringAsync() {
            return base.Channel.toStringAsync();
        }
        
        public string get() {
            return base.Channel.get();
        }
        
        public System.Threading.Tasks.Task<string> getAsync() {
            return base.Channel.getAsync();
        }
        
        public string getByName(string name) {
            return base.Channel.getByName(name);
        }
        
        public System.Threading.Tasks.Task<string> getByNameAsync(string name) {
            return base.Channel.getByNameAsync(name);
        }
    }
}
