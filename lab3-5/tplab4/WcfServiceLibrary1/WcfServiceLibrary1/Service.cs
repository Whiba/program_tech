using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    //++
    [ServiceContract]
    public interface SProduction_Journal
    {

        string Production_Journal_Factory
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        string Production_Journal_Product
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }
        string Production_Journal_Number
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        [OperationContract]
        void Insert();

        [OperationContract]
        void Update(string id);

        [OperationContract]
        void Delete(string id);

        [OperationContract]
        string toString();

        [OperationContract]
        string get();

        [OperationContract]
        string getByName(string id);
    }
    //++
    [ServiceContract]
    public interface SCost
    {
        string Cost_Product
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        string Cost_Old_cost
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }
        string Cost_New_cost
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }
        string Cost_Date_C
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }        

        [OperationContract]
        string toString();

        [OperationContract]
        string get();

        [OperationContract]
        string getByName(string product);
    }
    //++
    [ServiceContract]
    public interface SSup_Journal
    {
        string Sup_Journal_Product
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        string Sup_Journal_Shop
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        string Sup_Journal_Date
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        [OperationContract]
        void Insert();

        [OperationContract]
        void Update(string id);

        [OperationContract]
        void Delete(string id);

        [OperationContract]
        string toString();

        [OperationContract]
        string get();

        [OperationContract]
        string getByName(string id);
    }
    //++
    [ServiceContract]
    public interface SFactory
    {

        string Factory_Name
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        string Factory_Address
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        string Factory_Country
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        [OperationContract]
        void Insert();

        [OperationContract]
        void Update(string newname, string name, string address);

        [OperationContract]
        void Delete(string name);

        [OperationContract]
        string toString();

        [OperationContract]
        string get();
        [OperationContract]
        string get_name();

        [OperationContract]
        string getByName(string name);
    }
    //++
    [ServiceContract]
    public interface SCountry
    {

        string Country_Name
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        string Country_Continent
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        string Country_Square
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        [OperationContract]
        void Insert();

        [OperationContract]
        void Update(string newname, string name, string continent, string square);

        [OperationContract]
        void Delete(string name);

        [OperationContract]
        string toString();

        [OperationContract]
        string get();

        [OperationContract]
        string get_name();

        [OperationContract]
        string getByName(string name);
    }
    //++
    [ServiceContract]
    public interface SEmployee
    {

        string Employee_Name
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        string Employee_Factory
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }
        string Employee_Position
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        [OperationContract]
        void Insert();

        [OperationContract]
        void Update(string newname);

        [OperationContract]
        void Delete(string name);

        [OperationContract]
        string toString();

        [OperationContract]
        string get();

        [OperationContract]
        string getByName(string name);
    }
    //++
    [ServiceContract]
    public interface SShop
    {
        string Shop_Name
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        string Shop_Profile
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        string Shop_Address
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        [OperationContract]
        void Insert();

        [OperationContract]
        void Update(string newname, string name, string address);

        [OperationContract]
        void Delete(string name);

        [OperationContract]
        string toString();

        [OperationContract]
        string get();

        [OperationContract]
        string getByName(string name);
    }
    //++
    [ServiceContract]
    public interface SProfile
    {
        string Profile_Name
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        [OperationContract]
        void Insert();

        [OperationContract]
        void Update(string name, string newname);

        [OperationContract]
        void Delete(string name);

        [OperationContract]
        string toString();

        [OperationContract]
        string get();

        [OperationContract]
        string getByName(string name);
    }
    //++
    [ServiceContract]
    public interface SProduct
    {
        string Product_Name
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        string Product_Cost
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }
        [OperationContract]
        void Insert();

        [OperationContract]
        void Update(string newname, string name, string cost);

        [OperationContract]
        void Delete(string name);

        [OperationContract]
        string toString();

        [OperationContract]
        string get();

        [OperationContract]
        string getByName(string name);
    }
    //++
    [ServiceContract]
    public interface SPosition
    {

        [OperationContract]
        void Update(string newname, string newsalary, string name);

        [OperationContract]
        void Insert();

        string P_Name
        {
            [OperationContract]
            get;
            [OperationContract]
            set;            
        }
        string P_Salary
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        [OperationContract]
        void Delete(string name);

        [OperationContract]
        string toString();

        [OperationContract]
        string get(int page);
        [OperationContract]
        string get_s();

        [OperationContract]
        string getByName(string name);
    }
}
