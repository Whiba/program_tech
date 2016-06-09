using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LibraryServer
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface ServBook
    {
        string MyAuthor
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        string MyGenre
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        string Name
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        string Year
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        string Publishing
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        string Paper_number
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        string Book_number
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        [OperationContract]
        string getAllBooks(string num);

        [OperationContract]
        string getBookByName(string n);

        [OperationContract]
        void SaveBook();

        [OperationContract]
        void DeleteBook(string index);

        [OperationContract]
        void UpdateBook(string index);

        [OperationContract]
        string BookToString();

        [OperationContract]
        string getBookList();
    }

    [ServiceContract]
    public interface ServArrangement
    {
        string Place
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        [OperationContract]
        string getAllArrangements(string num);

        [OperationContract]
        void SaveArrangement();

        [OperationContract]
        void DeleteArrangement(string index);

        [OperationContract]
        void UpdateArrangement(string index);

        [OperationContract]
        string getAll();
    }

    [ServiceContract]
    public interface ServAuthor
    {
        string MyHuman
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        string Date_of_birdth
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        string Information
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        [OperationContract]
        string getAllAuthors(string num);

        [OperationContract]
        void SaveAuthor();

        [OperationContract]
        void DeleteAuthor(string index);

        [OperationContract]
        void UpdateAuthor(string index);
    }

    [ServiceContract]
    public interface ServFloor
    {
        string Name
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        [OperationContract]
        string getAllFloors(string num);

        [OperationContract]
        void SaveFloor();

        [OperationContract]
        void DeleteFloor(string index);

        [OperationContract]
        void UpdateFloor(string index);
    }

    [ServiceContract]
    public interface ServGenre
    {
        string Name
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        string Discription
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        [OperationContract]
        string getAllGenres(string num);

        [OperationContract]
        void SaveGenre();

        [OperationContract]
        void DeleteGenre(string index);

        [OperationContract]
        void UpdateGenre(string index);
    }

    [ServiceContract]
    public interface ServLibrarian
    {
        string MyHuman
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        string Date_of_employment
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        string Telephone
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        [OperationContract]
        string getAllLibrarians(string num);

        [OperationContract]
        void SaveLibrarian();

        [OperationContract]
        void DeleteLibrarian(string index);

        [OperationContract]
        void UpdateLibrarian(string index);
    }

    [ServiceContract]
    public interface ServLocation
    {
        string MyBook
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        string MyFloor
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        string MyArrangement
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        string Sector
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        [OperationContract]
        string getAllLocations(string num);

        [OperationContract]
        void SaveLocation();

        [OperationContract]
        void DeleteLocation(string index);

        [OperationContract]
        void UpdateLocation(string index);
    }

    [ServiceContract]
    public interface ServReader
    {
        string MyHuman
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        string Address
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        string Telephone
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        string Date_of_registration
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        string MyStatus
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        string Penalties
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        [OperationContract]
        string getAllReaders(string num);

        [OperationContract]
        void SaveReader();

        [OperationContract]
        void DeleteReader(string index);

        [OperationContract]
        void UpdateReader(string index);
    }

    [ServiceContract]
    public interface ServStatus
    {
        string Name
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        string Discription
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        [OperationContract]
        string getAllStatuses(string num);

        [OperationContract]
        void SaveStatus();

        [OperationContract]
        void DeleteStatus(string index);

        [OperationContract]
        void UpdateStatus(string index);
    }

    [ServiceContract]
    public interface ServJournal
    {
        string MyLibrarian
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        string MyReader
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        string MyBook
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        string Number_of_book
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        string Date_of_issue
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        [OperationContract]
        string getAllJournals(string num);

        [OperationContract]
        void SaveJournal();

        [OperationContract]
        void DeleteJournal(string index);

        [OperationContract]
        void UpdateJournal(string index);
    }
}
