﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryClient.Sup_Journal {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Sup_Journal.SSup_Journal")]
    public interface SSup_Journal {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SSup_Journal/get_Sup_Journal_Product", ReplyAction="http://tempuri.org/SSup_Journal/get_Sup_Journal_ProductResponse")]
        string get_Sup_Journal_Product();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SSup_Journal/get_Sup_Journal_Product", ReplyAction="http://tempuri.org/SSup_Journal/get_Sup_Journal_ProductResponse")]
        System.Threading.Tasks.Task<string> get_Sup_Journal_ProductAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SSup_Journal/set_Sup_Journal_Product", ReplyAction="http://tempuri.org/SSup_Journal/set_Sup_Journal_ProductResponse")]
        void set_Sup_Journal_Product(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SSup_Journal/set_Sup_Journal_Product", ReplyAction="http://tempuri.org/SSup_Journal/set_Sup_Journal_ProductResponse")]
        System.Threading.Tasks.Task set_Sup_Journal_ProductAsync(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SSup_Journal/get_Sup_Journal_Shop", ReplyAction="http://tempuri.org/SSup_Journal/get_Sup_Journal_ShopResponse")]
        string get_Sup_Journal_Shop();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SSup_Journal/get_Sup_Journal_Shop", ReplyAction="http://tempuri.org/SSup_Journal/get_Sup_Journal_ShopResponse")]
        System.Threading.Tasks.Task<string> get_Sup_Journal_ShopAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SSup_Journal/set_Sup_Journal_Shop", ReplyAction="http://tempuri.org/SSup_Journal/set_Sup_Journal_ShopResponse")]
        void set_Sup_Journal_Shop(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SSup_Journal/set_Sup_Journal_Shop", ReplyAction="http://tempuri.org/SSup_Journal/set_Sup_Journal_ShopResponse")]
        System.Threading.Tasks.Task set_Sup_Journal_ShopAsync(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SSup_Journal/get_Sup_Journal_Date", ReplyAction="http://tempuri.org/SSup_Journal/get_Sup_Journal_DateResponse")]
        string get_Sup_Journal_Date();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SSup_Journal/get_Sup_Journal_Date", ReplyAction="http://tempuri.org/SSup_Journal/get_Sup_Journal_DateResponse")]
        System.Threading.Tasks.Task<string> get_Sup_Journal_DateAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SSup_Journal/set_Sup_Journal_Date", ReplyAction="http://tempuri.org/SSup_Journal/set_Sup_Journal_DateResponse")]
        void set_Sup_Journal_Date(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SSup_Journal/set_Sup_Journal_Date", ReplyAction="http://tempuri.org/SSup_Journal/set_Sup_Journal_DateResponse")]
        System.Threading.Tasks.Task set_Sup_Journal_DateAsync(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SSup_Journal/Insert", ReplyAction="http://tempuri.org/SSup_Journal/InsertResponse")]
        void Insert();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SSup_Journal/Insert", ReplyAction="http://tempuri.org/SSup_Journal/InsertResponse")]
        System.Threading.Tasks.Task InsertAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SSup_Journal/Update", ReplyAction="http://tempuri.org/SSup_Journal/UpdateResponse")]
        void Update(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SSup_Journal/Update", ReplyAction="http://tempuri.org/SSup_Journal/UpdateResponse")]
        System.Threading.Tasks.Task UpdateAsync(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SSup_Journal/Delete", ReplyAction="http://tempuri.org/SSup_Journal/DeleteResponse")]
        void Delete(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SSup_Journal/Delete", ReplyAction="http://tempuri.org/SSup_Journal/DeleteResponse")]
        System.Threading.Tasks.Task DeleteAsync(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SSup_Journal/toString", ReplyAction="http://tempuri.org/SSup_Journal/toStringResponse")]
        string toString();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SSup_Journal/toString", ReplyAction="http://tempuri.org/SSup_Journal/toStringResponse")]
        System.Threading.Tasks.Task<string> toStringAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SSup_Journal/get", ReplyAction="http://tempuri.org/SSup_Journal/getResponse")]
        string get();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SSup_Journal/get", ReplyAction="http://tempuri.org/SSup_Journal/getResponse")]
        System.Threading.Tasks.Task<string> getAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SSup_Journal/getByName", ReplyAction="http://tempuri.org/SSup_Journal/getByNameResponse")]
        string getByName(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SSup_Journal/getByName", ReplyAction="http://tempuri.org/SSup_Journal/getByNameResponse")]
        System.Threading.Tasks.Task<string> getByNameAsync(string id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface SSup_JournalChannel : LibraryClient.Sup_Journal.SSup_Journal, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SSup_JournalClient : System.ServiceModel.ClientBase<LibraryClient.Sup_Journal.SSup_Journal>, LibraryClient.Sup_Journal.SSup_Journal {
        
        public SSup_JournalClient() {
        }
        
        public SSup_JournalClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SSup_JournalClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SSup_JournalClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SSup_JournalClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string get_Sup_Journal_Product() {
            return base.Channel.get_Sup_Journal_Product();
        }
        
        public System.Threading.Tasks.Task<string> get_Sup_Journal_ProductAsync() {
            return base.Channel.get_Sup_Journal_ProductAsync();
        }
        
        public void set_Sup_Journal_Product(string value) {
            base.Channel.set_Sup_Journal_Product(value);
        }
        
        public System.Threading.Tasks.Task set_Sup_Journal_ProductAsync(string value) {
            return base.Channel.set_Sup_Journal_ProductAsync(value);
        }
        
        public string get_Sup_Journal_Shop() {
            return base.Channel.get_Sup_Journal_Shop();
        }
        
        public System.Threading.Tasks.Task<string> get_Sup_Journal_ShopAsync() {
            return base.Channel.get_Sup_Journal_ShopAsync();
        }
        
        public void set_Sup_Journal_Shop(string value) {
            base.Channel.set_Sup_Journal_Shop(value);
        }
        
        public System.Threading.Tasks.Task set_Sup_Journal_ShopAsync(string value) {
            return base.Channel.set_Sup_Journal_ShopAsync(value);
        }
        
        public string get_Sup_Journal_Date() {
            return base.Channel.get_Sup_Journal_Date();
        }
        
        public System.Threading.Tasks.Task<string> get_Sup_Journal_DateAsync() {
            return base.Channel.get_Sup_Journal_DateAsync();
        }
        
        public void set_Sup_Journal_Date(string value) {
            base.Channel.set_Sup_Journal_Date(value);
        }
        
        public System.Threading.Tasks.Task set_Sup_Journal_DateAsync(string value) {
            return base.Channel.set_Sup_Journal_DateAsync(value);
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
