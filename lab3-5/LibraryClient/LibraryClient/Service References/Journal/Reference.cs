﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryClient.Journal {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Journal.ServJournal")]
    public interface ServJournal {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServJournal/get_MyLibrarian", ReplyAction="http://tempuri.org/ServJournal/get_MyLibrarianResponse")]
        string get_MyLibrarian();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServJournal/get_MyLibrarian", ReplyAction="http://tempuri.org/ServJournal/get_MyLibrarianResponse")]
        System.Threading.Tasks.Task<string> get_MyLibrarianAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServJournal/set_MyLibrarian", ReplyAction="http://tempuri.org/ServJournal/set_MyLibrarianResponse")]
        void set_MyLibrarian(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServJournal/set_MyLibrarian", ReplyAction="http://tempuri.org/ServJournal/set_MyLibrarianResponse")]
        System.Threading.Tasks.Task set_MyLibrarianAsync(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServJournal/get_MyReader", ReplyAction="http://tempuri.org/ServJournal/get_MyReaderResponse")]
        string get_MyReader();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServJournal/get_MyReader", ReplyAction="http://tempuri.org/ServJournal/get_MyReaderResponse")]
        System.Threading.Tasks.Task<string> get_MyReaderAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServJournal/set_MyReader", ReplyAction="http://tempuri.org/ServJournal/set_MyReaderResponse")]
        void set_MyReader(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServJournal/set_MyReader", ReplyAction="http://tempuri.org/ServJournal/set_MyReaderResponse")]
        System.Threading.Tasks.Task set_MyReaderAsync(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServJournal/get_MyBook", ReplyAction="http://tempuri.org/ServJournal/get_MyBookResponse")]
        string get_MyBook();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServJournal/get_MyBook", ReplyAction="http://tempuri.org/ServJournal/get_MyBookResponse")]
        System.Threading.Tasks.Task<string> get_MyBookAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServJournal/set_MyBook", ReplyAction="http://tempuri.org/ServJournal/set_MyBookResponse")]
        void set_MyBook(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServJournal/set_MyBook", ReplyAction="http://tempuri.org/ServJournal/set_MyBookResponse")]
        System.Threading.Tasks.Task set_MyBookAsync(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServJournal/get_Number_of_book", ReplyAction="http://tempuri.org/ServJournal/get_Number_of_bookResponse")]
        string get_Number_of_book();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServJournal/get_Number_of_book", ReplyAction="http://tempuri.org/ServJournal/get_Number_of_bookResponse")]
        System.Threading.Tasks.Task<string> get_Number_of_bookAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServJournal/set_Number_of_book", ReplyAction="http://tempuri.org/ServJournal/set_Number_of_bookResponse")]
        void set_Number_of_book(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServJournal/set_Number_of_book", ReplyAction="http://tempuri.org/ServJournal/set_Number_of_bookResponse")]
        System.Threading.Tasks.Task set_Number_of_bookAsync(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServJournal/get_Date_of_issue", ReplyAction="http://tempuri.org/ServJournal/get_Date_of_issueResponse")]
        string get_Date_of_issue();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServJournal/get_Date_of_issue", ReplyAction="http://tempuri.org/ServJournal/get_Date_of_issueResponse")]
        System.Threading.Tasks.Task<string> get_Date_of_issueAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServJournal/set_Date_of_issue", ReplyAction="http://tempuri.org/ServJournal/set_Date_of_issueResponse")]
        void set_Date_of_issue(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServJournal/set_Date_of_issue", ReplyAction="http://tempuri.org/ServJournal/set_Date_of_issueResponse")]
        System.Threading.Tasks.Task set_Date_of_issueAsync(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServJournal/getAllJournals", ReplyAction="http://tempuri.org/ServJournal/getAllJournalsResponse")]
        string getAllJournals(string num);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServJournal/getAllJournals", ReplyAction="http://tempuri.org/ServJournal/getAllJournalsResponse")]
        System.Threading.Tasks.Task<string> getAllJournalsAsync(string num);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServJournal/SaveJournal", ReplyAction="http://tempuri.org/ServJournal/SaveJournalResponse")]
        void SaveJournal();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServJournal/SaveJournal", ReplyAction="http://tempuri.org/ServJournal/SaveJournalResponse")]
        System.Threading.Tasks.Task SaveJournalAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServJournal/DeleteJournal", ReplyAction="http://tempuri.org/ServJournal/DeleteJournalResponse")]
        void DeleteJournal(string index);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServJournal/DeleteJournal", ReplyAction="http://tempuri.org/ServJournal/DeleteJournalResponse")]
        System.Threading.Tasks.Task DeleteJournalAsync(string index);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServJournal/UpdateJournal", ReplyAction="http://tempuri.org/ServJournal/UpdateJournalResponse")]
        void UpdateJournal(string index);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServJournal/UpdateJournal", ReplyAction="http://tempuri.org/ServJournal/UpdateJournalResponse")]
        System.Threading.Tasks.Task UpdateJournalAsync(string index);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ServJournalChannel : LibraryClient.Journal.ServJournal, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServJournalClient : System.ServiceModel.ClientBase<LibraryClient.Journal.ServJournal>, LibraryClient.Journal.ServJournal {
        
        public ServJournalClient() {
        }
        
        public ServJournalClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServJournalClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServJournalClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServJournalClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string get_MyLibrarian() {
            return base.Channel.get_MyLibrarian();
        }
        
        public System.Threading.Tasks.Task<string> get_MyLibrarianAsync() {
            return base.Channel.get_MyLibrarianAsync();
        }
        
        public void set_MyLibrarian(string value) {
            base.Channel.set_MyLibrarian(value);
        }
        
        public System.Threading.Tasks.Task set_MyLibrarianAsync(string value) {
            return base.Channel.set_MyLibrarianAsync(value);
        }
        
        public string get_MyReader() {
            return base.Channel.get_MyReader();
        }
        
        public System.Threading.Tasks.Task<string> get_MyReaderAsync() {
            return base.Channel.get_MyReaderAsync();
        }
        
        public void set_MyReader(string value) {
            base.Channel.set_MyReader(value);
        }
        
        public System.Threading.Tasks.Task set_MyReaderAsync(string value) {
            return base.Channel.set_MyReaderAsync(value);
        }
        
        public string get_MyBook() {
            return base.Channel.get_MyBook();
        }
        
        public System.Threading.Tasks.Task<string> get_MyBookAsync() {
            return base.Channel.get_MyBookAsync();
        }
        
        public void set_MyBook(string value) {
            base.Channel.set_MyBook(value);
        }
        
        public System.Threading.Tasks.Task set_MyBookAsync(string value) {
            return base.Channel.set_MyBookAsync(value);
        }
        
        public string get_Number_of_book() {
            return base.Channel.get_Number_of_book();
        }
        
        public System.Threading.Tasks.Task<string> get_Number_of_bookAsync() {
            return base.Channel.get_Number_of_bookAsync();
        }
        
        public void set_Number_of_book(string value) {
            base.Channel.set_Number_of_book(value);
        }
        
        public System.Threading.Tasks.Task set_Number_of_bookAsync(string value) {
            return base.Channel.set_Number_of_bookAsync(value);
        }
        
        public string get_Date_of_issue() {
            return base.Channel.get_Date_of_issue();
        }
        
        public System.Threading.Tasks.Task<string> get_Date_of_issueAsync() {
            return base.Channel.get_Date_of_issueAsync();
        }
        
        public void set_Date_of_issue(string value) {
            base.Channel.set_Date_of_issue(value);
        }
        
        public System.Threading.Tasks.Task set_Date_of_issueAsync(string value) {
            return base.Channel.set_Date_of_issueAsync(value);
        }
        
        public string getAllJournals(string num) {
            return base.Channel.getAllJournals(num);
        }
        
        public System.Threading.Tasks.Task<string> getAllJournalsAsync(string num) {
            return base.Channel.getAllJournalsAsync(num);
        }
        
        public void SaveJournal() {
            base.Channel.SaveJournal();
        }
        
        public System.Threading.Tasks.Task SaveJournalAsync() {
            return base.Channel.SaveJournalAsync();
        }
        
        public void DeleteJournal(string index) {
            base.Channel.DeleteJournal(index);
        }
        
        public System.Threading.Tasks.Task DeleteJournalAsync(string index) {
            return base.Channel.DeleteJournalAsync(index);
        }
        
        public void UpdateJournal(string index) {
            base.Channel.UpdateJournal(index);
        }
        
        public System.Threading.Tasks.Task UpdateJournalAsync(string index) {
            return base.Channel.UpdateJournalAsync(index);
        }
    }
}