﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryClient.Production_Journal {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Production_Journal.SProduction_Journal")]
    public interface SProduction_Journal {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SProduction_Journal/get_Production_Journal_Factory", ReplyAction="http://tempuri.org/SProduction_Journal/get_Production_Journal_FactoryResponse")]
        string get_Production_Journal_Factory();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SProduction_Journal/get_Production_Journal_Factory", ReplyAction="http://tempuri.org/SProduction_Journal/get_Production_Journal_FactoryResponse")]
        System.Threading.Tasks.Task<string> get_Production_Journal_FactoryAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SProduction_Journal/set_Production_Journal_Factory", ReplyAction="http://tempuri.org/SProduction_Journal/set_Production_Journal_FactoryResponse")]
        void set_Production_Journal_Factory(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SProduction_Journal/set_Production_Journal_Factory", ReplyAction="http://tempuri.org/SProduction_Journal/set_Production_Journal_FactoryResponse")]
        System.Threading.Tasks.Task set_Production_Journal_FactoryAsync(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SProduction_Journal/get_Production_Journal_Product", ReplyAction="http://tempuri.org/SProduction_Journal/get_Production_Journal_ProductResponse")]
        string get_Production_Journal_Product();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SProduction_Journal/get_Production_Journal_Product", ReplyAction="http://tempuri.org/SProduction_Journal/get_Production_Journal_ProductResponse")]
        System.Threading.Tasks.Task<string> get_Production_Journal_ProductAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SProduction_Journal/set_Production_Journal_Product", ReplyAction="http://tempuri.org/SProduction_Journal/set_Production_Journal_ProductResponse")]
        void set_Production_Journal_Product(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SProduction_Journal/set_Production_Journal_Product", ReplyAction="http://tempuri.org/SProduction_Journal/set_Production_Journal_ProductResponse")]
        System.Threading.Tasks.Task set_Production_Journal_ProductAsync(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SProduction_Journal/get_Production_Journal_Number", ReplyAction="http://tempuri.org/SProduction_Journal/get_Production_Journal_NumberResponse")]
        string get_Production_Journal_Number();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SProduction_Journal/get_Production_Journal_Number", ReplyAction="http://tempuri.org/SProduction_Journal/get_Production_Journal_NumberResponse")]
        System.Threading.Tasks.Task<string> get_Production_Journal_NumberAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SProduction_Journal/set_Production_Journal_Number", ReplyAction="http://tempuri.org/SProduction_Journal/set_Production_Journal_NumberResponse")]
        void set_Production_Journal_Number(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SProduction_Journal/set_Production_Journal_Number", ReplyAction="http://tempuri.org/SProduction_Journal/set_Production_Journal_NumberResponse")]
        System.Threading.Tasks.Task set_Production_Journal_NumberAsync(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SProduction_Journal/Insert", ReplyAction="http://tempuri.org/SProduction_Journal/InsertResponse")]
        void Insert();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SProduction_Journal/Insert", ReplyAction="http://tempuri.org/SProduction_Journal/InsertResponse")]
        System.Threading.Tasks.Task InsertAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SProduction_Journal/Update", ReplyAction="http://tempuri.org/SProduction_Journal/UpdateResponse")]
        void Update(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SProduction_Journal/Update", ReplyAction="http://tempuri.org/SProduction_Journal/UpdateResponse")]
        System.Threading.Tasks.Task UpdateAsync(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SProduction_Journal/Delete", ReplyAction="http://tempuri.org/SProduction_Journal/DeleteResponse")]
        void Delete(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SProduction_Journal/Delete", ReplyAction="http://tempuri.org/SProduction_Journal/DeleteResponse")]
        System.Threading.Tasks.Task DeleteAsync(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SProduction_Journal/toString", ReplyAction="http://tempuri.org/SProduction_Journal/toStringResponse")]
        string toString();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SProduction_Journal/toString", ReplyAction="http://tempuri.org/SProduction_Journal/toStringResponse")]
        System.Threading.Tasks.Task<string> toStringAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SProduction_Journal/get", ReplyAction="http://tempuri.org/SProduction_Journal/getResponse")]
        string get();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SProduction_Journal/get", ReplyAction="http://tempuri.org/SProduction_Journal/getResponse")]
        System.Threading.Tasks.Task<string> getAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SProduction_Journal/getByName", ReplyAction="http://tempuri.org/SProduction_Journal/getByNameResponse")]
        string getByName(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SProduction_Journal/getByName", ReplyAction="http://tempuri.org/SProduction_Journal/getByNameResponse")]
        System.Threading.Tasks.Task<string> getByNameAsync(string id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface SProduction_JournalChannel : LibraryClient.Production_Journal.SProduction_Journal, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SProduction_JournalClient : System.ServiceModel.ClientBase<LibraryClient.Production_Journal.SProduction_Journal>, LibraryClient.Production_Journal.SProduction_Journal {
        
        public SProduction_JournalClient() {
        }
        
        public SProduction_JournalClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SProduction_JournalClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SProduction_JournalClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SProduction_JournalClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string get_Production_Journal_Factory() {
            return base.Channel.get_Production_Journal_Factory();
        }
        
        public System.Threading.Tasks.Task<string> get_Production_Journal_FactoryAsync() {
            return base.Channel.get_Production_Journal_FactoryAsync();
        }
        
        public void set_Production_Journal_Factory(string value) {
            base.Channel.set_Production_Journal_Factory(value);
        }
        
        public System.Threading.Tasks.Task set_Production_Journal_FactoryAsync(string value) {
            return base.Channel.set_Production_Journal_FactoryAsync(value);
        }
        
        public string get_Production_Journal_Product() {
            return base.Channel.get_Production_Journal_Product();
        }
        
        public System.Threading.Tasks.Task<string> get_Production_Journal_ProductAsync() {
            return base.Channel.get_Production_Journal_ProductAsync();
        }
        
        public void set_Production_Journal_Product(string value) {
            base.Channel.set_Production_Journal_Product(value);
        }
        
        public System.Threading.Tasks.Task set_Production_Journal_ProductAsync(string value) {
            return base.Channel.set_Production_Journal_ProductAsync(value);
        }
        
        public string get_Production_Journal_Number() {
            return base.Channel.get_Production_Journal_Number();
        }
        
        public System.Threading.Tasks.Task<string> get_Production_Journal_NumberAsync() {
            return base.Channel.get_Production_Journal_NumberAsync();
        }
        
        public void set_Production_Journal_Number(string value) {
            base.Channel.set_Production_Journal_Number(value);
        }
        
        public System.Threading.Tasks.Task set_Production_Journal_NumberAsync(string value) {
            return base.Channel.set_Production_Journal_NumberAsync(value);
        }
        
        public void Insert() {
            base.Channel.Insert();
        }
        
        public System.Threading.Tasks.Task InsertAsync() {
            return base.Channel.InsertAsync();
        }
        
        public void Update(string id) {
            base.Channel.Update(id);
        }
        
        public System.Threading.Tasks.Task UpdateAsync(string id) {
            return base.Channel.UpdateAsync(id);
        }
        
        public void Delete(string id) {
            base.Channel.Delete(id);
        }
        
        public System.Threading.Tasks.Task DeleteAsync(string id) {
            return base.Channel.DeleteAsync(id);
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
        
        public string getByName(string id) {
            return base.Channel.getByName(id);
        }
        
        public System.Threading.Tasks.Task<string> getByNameAsync(string id) {
            return base.Channel.getByNameAsync(id);
        }
    }
}