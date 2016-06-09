using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Reflection;
using OfficeOpenXml;
using System.IO;
using System.Threading;

namespace LibraryClient
{
    public partial class MainForm : Form
    {
        bool sw;
        int friend_page = 1;
        int my_page;

        public MainForm()
        {
            InitializeComponent();
            /*
            Книги
            Жанры
            Виды расстановки
            Авторы
            Виды полок
            Журнал
            Библиотекари
            Местоположения
            Читатели
            Виды статусов читателя
            */
            my_page = 0;
            LoadBook();
            sw = true;
            my_groupBox.Enabled = true;
            friend_groupBox.Enabled = false;
            table_comboBox.SelectedIndex = 0;
            friend_table_comboBox.SelectedIndex = 0;
        }

        private void LoadBook()
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
            var myBinding = new System.ServiceModel.BasicHttpBinding();
            var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/LibraryServer/Book/");
            var myChannelFactory = new ChannelFactory<Book.ServBook>(myBinding, myEndpoint);

            Book.ServBook client = null;
            string s = "";
            try
            {
                client = myChannelFactory.CreateChannel();
                s = client.getAllBooks("0");
                ((ICommunicationObject)client).Close();
            }
            catch
            {
                if (client != null)
                {
                    ((ICommunicationObject)client).Abort();
                }
            }

            try
            {
                string[,] array = JsonConvert.DeserializeObject<string[,]>(s);

                for (int l = 0; l < array.GetLength(1); l++)
                    if (array[0, l] != null)
                        dataGridView.Columns.Add(array[0, l], array[0, l]);
                int row = 0;
                for (int i = 1; i < array.GetLength(0); i++)
                {
                    if (array[i, 0] != null)
                    {
                        dataGridView.Rows.Add();
                        for (int cell = 0; cell < array.GetLength(1); cell++)
                            if (array[i,cell] != null)
                                dataGridView.Rows[row].Cells[cell].Value = (array[i, cell]);
                        row++;
                    }
                }
                dataGridView.Columns[0].Visible = false;
            }
            catch
            {
                MessageBox.Show("Упс! Сервер недоступен!");
            }
        }

        private void LoadAuthor()
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
            var myBinding = new System.ServiceModel.BasicHttpBinding();
            var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/LibraryServer/Author/");
            var myChannelFactory = new ChannelFactory<Author.ServAuthor>(myBinding, myEndpoint);

            Author.ServAuthor client = null;
            string s = "";
            try
            {
                client = myChannelFactory.CreateChannel();
                s = client.getAllAuthors("0");
                ((ICommunicationObject)client).Close();
            }
            catch
            {
                if (client != null)
                {
                    ((ICommunicationObject)client).Abort();
                }
            }

            try
            {
                string[,] array = JsonConvert.DeserializeObject<string[,]>(s);

                for (int l = 0; l < array.GetLength(1); l++)
                    if (array[0, l] != null)
                        dataGridView.Columns.Add(array[0, l], array[0, l]);
                int row = 0;
                for (int i = 1; i < array.GetLength(0); i++)
                {
                    if (array[i, 0] != null)
                    {
                        dataGridView.Rows.Add();
                        for (int cell = 0; cell < array.GetLength(1); cell++)
                            if (array[i, cell] != null)
                                dataGridView.Rows[row].Cells[cell].Value = (array[i, cell]);
                        row++;
                    }
                }
                dataGridView.Columns[0].Visible = false;
            }
            catch
            {
                MessageBox.Show("Упс! Сервер недоступен!");
            }
        }

        private void LoadGenre()
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
            var myBinding = new System.ServiceModel.BasicHttpBinding();
            var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/LibraryServer/Genre/");
            var myChannelFactory = new ChannelFactory<Genre.ServGenre>(myBinding, myEndpoint);

            Genre.ServGenre client = null;
            string s = "";
            try
            {
                client = myChannelFactory.CreateChannel();
                s = client.getAllGenres("0");
                ((ICommunicationObject)client).Close();
            }
            catch
            {
                if (client != null)
                {
                    ((ICommunicationObject)client).Abort();
                }
            }

            try
            {
                string[,] array = JsonConvert.DeserializeObject<string[,]>(s);

                for (int l = 0; l < array.GetLength(1); l++)
                    if (array[0, l] != null)
                        dataGridView.Columns.Add(array[0, l], array[0, l]);
                int row = 0;
                for (int i = 1; i < array.GetLength(0); i++)
                {
                    if (array[i, 0] != null)
                    {
                        dataGridView.Rows.Add();
                        for (int cell = 0; cell < array.GetLength(1); cell++)
                            if (array[i, cell] != null)
                                dataGridView.Rows[row].Cells[cell].Value = (array[i, cell]);
                        row++;
                    }
                }
                dataGridView.Columns[0].Visible = false;
            }
            catch
            {
                MessageBox.Show("Упс! Сервер недоступен!");
            }
        }

        private void LoadArrangement()
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
            var myBinding = new System.ServiceModel.BasicHttpBinding();
            var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/LibraryServer/Arrangement/");
            var myChannelFactory = new ChannelFactory<Arrangement.ServArrangement>(myBinding, myEndpoint);

            Arrangement.ServArrangement client = null;
            string s = "";
            try
            {
                client = myChannelFactory.CreateChannel();
                s = client.getAllArrangements("0");
                ((ICommunicationObject)client).Close();
            }
            catch
            {
                if (client != null)
                {
                    ((ICommunicationObject)client).Abort();
                }
            }

            try
            {
                string[,] array = JsonConvert.DeserializeObject<string[,]>(s);

                for (int l = 0; l < array.GetLength(1); l++)
                    if (array[0, l] != null)
                        dataGridView.Columns.Add(array[0, l], array[0, l]);
                int row = 0;
                for (int i = 1; i < array.GetLength(0); i++)
                {
                    if (array[i, 0] != null)
                    {
                        dataGridView.Rows.Add();
                        for (int cell = 0; cell < array.GetLength(1); cell++)
                            if (array[i, cell] != null)
                                dataGridView.Rows[row].Cells[cell].Value = (array[i, cell]);
                        row++;
                    }
                }
                dataGridView.Columns[0].Visible = false;
            }
            catch
            {
                MessageBox.Show("Упс! Сервер недоступен!");
            }
        }

        private void LoadFloor()
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
            var myBinding = new System.ServiceModel.BasicHttpBinding();
            var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/LibraryServer/Floor/");
            var myChannelFactory = new ChannelFactory<Floor.ServFloor>(myBinding, myEndpoint);

            Floor.ServFloor client = null;
            string s = "";
            try
            {
                client = myChannelFactory.CreateChannel();
                s = client.getAllFloors("0");
                ((ICommunicationObject)client).Close();
            }
            catch
            {
                if (client != null)
                {
                    ((ICommunicationObject)client).Abort();
                }
            }

            try
            {
                string[,] array = JsonConvert.DeserializeObject<string[,]>(s);

                for (int l = 0; l < array.GetLength(1); l++)
                    if (array[0, l] != null)
                        dataGridView.Columns.Add(array[0, l], array[0, l]);
                int row = 0;
                for (int i = 1; i < array.GetLength(0); i++)
                {
                    if (array[i, 0] != null)
                    {
                        dataGridView.Rows.Add();
                        for (int cell = 0; cell < array.GetLength(1); cell++)
                            if (array[i, cell] != null)
                                dataGridView.Rows[row].Cells[cell].Value = (array[i, cell]);
                        row++;
                    }
                }
                dataGridView.Columns[0].Visible = false;
            }
            catch
            {
                MessageBox.Show("Упс! Сервер недоступен!");
            }
        }

        private void LoadLibrarian()
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
            var myBinding = new System.ServiceModel.BasicHttpBinding();
            var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/LibraryServer/Librarian/");
            var myChannelFactory = new ChannelFactory<Librarian.ServLibrarian>(myBinding, myEndpoint);

            Librarian.ServLibrarian client = null;
            string s = "";
            try
            {
                client = myChannelFactory.CreateChannel();
                s = client.getAllLibrarians("0");
                ((ICommunicationObject)client).Close();
            }
            catch
            {
                if (client != null)
                {
                    ((ICommunicationObject)client).Abort();
                }
            }

            try
            {
                string[,] array = JsonConvert.DeserializeObject<string[,]>(s);

                for (int l = 0; l < array.GetLength(1); l++)
                    if (array[0, l] != null)
                        dataGridView.Columns.Add(array[0, l], array[0, l]);
                int row = 0;
                for (int i = 1; i < array.GetLength(0); i++)
                {
                    if (array[i, 0] != null)
                    {
                        dataGridView.Rows.Add();
                        for (int cell = 0; cell < array.GetLength(1); cell++)
                            if (array[i, cell] != null)
                                dataGridView.Rows[row].Cells[cell].Value = (array[i, cell]);
                        row++;
                    }
                }
                dataGridView.Columns[0].Visible = false;
            }
            catch
            {
                MessageBox.Show("Упс! Сервер недоступен!");
            }
        }

        private void LoadLocation()
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
            var myBinding = new System.ServiceModel.BasicHttpBinding();
            var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/LibraryServer/Location/");
            var myChannelFactory = new ChannelFactory<Location.ServLocation>(myBinding, myEndpoint);

            Location.ServLocation client = null;
            string s = "";
            try
            {
                client = myChannelFactory.CreateChannel();
                s = client.getAllLocations("0");
                ((ICommunicationObject)client).Close();
            }
            catch
            {
                if (client != null)
                {
                    ((ICommunicationObject)client).Abort();
                }
            }

            try
            {
                string[,] array = JsonConvert.DeserializeObject<string[,]>(s);

                for (int l = 0; l < array.GetLength(1); l++)
                    if (array[0, l] != null)
                        dataGridView.Columns.Add(array[0, l], array[0, l]);
                int row = 0;
                for (int i = 1; i < array.GetLength(0); i++)
                {
                    if (array[i, 0] != null)
                    {
                        dataGridView.Rows.Add();
                        for (int cell = 0; cell < array.GetLength(1); cell++)
                            if (array[i, cell] != null)
                                dataGridView.Rows[row].Cells[cell].Value = (array[i, cell]);
                        row++;
                    }
                }
                dataGridView.Columns[0].Visible = false;
            }
            catch
            {
                MessageBox.Show("Упс! Сервер недоступен!");
            }
        }

        private void LoadReader()
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
            var myBinding = new System.ServiceModel.BasicHttpBinding();
            var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/LibraryServer/Reader/");
            var myChannelFactory = new ChannelFactory<Reader.ServReader>(myBinding, myEndpoint);

            Reader.ServReader client = null;
            string s = "";
            try
            {
                client = myChannelFactory.CreateChannel();
                s = client.getAllReaders("0");
                ((ICommunicationObject)client).Close();
            }
            catch
            {
                if (client != null)
                {
                    ((ICommunicationObject)client).Abort();
                }
            }

            try
            {
                string[,] array = JsonConvert.DeserializeObject<string[,]>(s);

                for (int l = 0; l < array.GetLength(1); l++)
                    if (array[0, l] != null)
                        dataGridView.Columns.Add(array[0, l], array[0, l]);
                int row = 0;
                for (int i = 1; i < array.GetLength(0); i++)
                {
                    if (array[i, 0] != null)
                    {
                        dataGridView.Rows.Add();
                        for (int cell = 0; cell < array.GetLength(1); cell++)
                            if (array[i, cell] != null)
                                dataGridView.Rows[row].Cells[cell].Value = (array[i, cell]);
                        row++;
                    }
                }
                dataGridView.Columns[0].Visible = false;
            }
            catch
            {
                MessageBox.Show("Упс! Сервер недоступен!");
            }
        }

        private void LoadStatus()
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
            var myBinding = new System.ServiceModel.BasicHttpBinding();
            var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/LibraryServer/Status/");
            var myChannelFactory = new ChannelFactory<Status.ServStatus>(myBinding, myEndpoint);

            Status.ServStatus client = null;
            string s = "";
            try
            {
                client = myChannelFactory.CreateChannel();
                s = client.getAllStatuses("0");
                ((ICommunicationObject)client).Close();
            }
            catch
            {
                if (client != null)
                {
                    ((ICommunicationObject)client).Abort();
                }
            }

            try
            {
                string[,] array = JsonConvert.DeserializeObject<string[,]>(s);

                for (int l = 0; l < array.GetLength(1); l++)
                    if (array[0, l] != null)
                        dataGridView.Columns.Add(array[0, l], array[0, l]);
                int row = 0;
                for (int i = 1; i < array.GetLength(0); i++)
                {
                    if (array[i, 0] != null)
                    {
                        dataGridView.Rows.Add();
                        for (int cell = 0; cell < array.GetLength(1); cell++)
                            if (array[i, cell] != null)
                                dataGridView.Rows[row].Cells[cell].Value = (array[i, cell]);
                        row++;
                    }
                }
                dataGridView.Columns[0].Visible = false;
            }
            catch
            {
                MessageBox.Show("Упс! Сервер недоступен!");
            }
        }

        private void LoadJournal()
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
            var myBinding = new System.ServiceModel.BasicHttpBinding();
            var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/LibraryServer/Journal/");
            var myChannelFactory = new ChannelFactory<Journal.ServJournal>(myBinding, myEndpoint);

            Journal.ServJournal client = null;
            string s = "";
            try
            {
                client = myChannelFactory.CreateChannel();
                s = client.getAllJournals("0");
                ((ICommunicationObject)client).Close();
            }
            catch
            {
                if (client != null)
                {
                    ((ICommunicationObject)client).Abort();
                }
            }

            try
            {
                string[,] array = JsonConvert.DeserializeObject<string[,]>(s);

                for (int l = 0; l < array.GetLength(1); l++)
                    if (array[0, l] != null)
                        dataGridView.Columns.Add(array[0, l], array[0, l]);
                int row = 0;
                for (int i = 1; i < array.GetLength(0); i++)
                {
                    if (array[i, 0] != null)
                    {
                        dataGridView.Rows.Add();
                        for (int cell = 0; cell < array.GetLength(1); cell++)
                            if (array[i, cell] != null)
                                dataGridView.Rows[row].Cells[cell].Value = (array[i, cell]);
                        row++;
                    }
                }
                dataGridView.Columns[0].Visible = false;
            }
            catch
            {
                MessageBox.Show("Упс! Сервер недоступен!");
            }
        }

        public void loadCost()
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
            var myBinding = new BasicHttpBinding();
            var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Cost/");
            var myChannelFactory = new ChannelFactory<Cost.SCost>(myBinding, myEndpoint);

            Cost.SCost client = null;
            string s = "";
            try
            {
                client = myChannelFactory.CreateChannel();
                s = client.get();
                ((ICommunicationObject)client).Close();
            }
            catch
            {
                if (client != null)
                {
                    ((ICommunicationObject)client).Abort();
                }
            }
            try
            {
                string[,] array = JsonConvert.DeserializeObject<string[,]>(s);

                for (int l = 0; l < array.GetLength(0); l++)
                    if (array[l, 0] != null)
                        dataGridView.Columns.Add(array[l, 0], array[l, 0]);
                int row = 0;
                for (int i = 1; i < array.GetLength(1); i++)
                {
                    if (array[0, i] != null)
                    {
                        dataGridView.Rows.Add();
                        for (int cell = 0; cell < array.GetLength(0); cell++)
                            if (array[cell, i] != null)
                                dataGridView.Rows[row].Cells[cell].Value = (array[cell, i]);
                        row++;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Упс! Сервер недоступен!");
            }
        }

        public void loadProfile()
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
            var myBinding = new BasicHttpBinding();
            var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Profile/");
            var myChannelFactory = new ChannelFactory<Profile.SProfile>(myBinding, myEndpoint);

            Profile.SProfile client = null;
            string s = "";
            try
            {
                client = myChannelFactory.CreateChannel();
                s = client.get();
                ((ICommunicationObject)client).Close();
            }
            catch
            {
                if (client != null)
                {
                    ((ICommunicationObject)client).Abort();
                }
            }

            try
            {
                string[,] array = JsonConvert.DeserializeObject<string[,]>(s);

                for (int l = 0; l < array.GetLength(0); l++)
                    if (array[l, 0] != null)
                        dataGridView.Columns.Add(array[l, 0], array[l, 0]);
                int row = 0;
                for (int i = 1; i < array.GetLength(1); i++)
                {
                    if (array[0, i] != null)
                    {
                        dataGridView.Rows.Add();
                        for (int cell = 0; cell < array.GetLength(0); cell++)
                            if (array[cell, i] != null)
                                dataGridView.Rows[row].Cells[cell].Value = (array[cell, i]);
                        row++;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Упс! Сервер недоступен!");
            }
        }

        public void loadShop()
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
            var myBinding = new BasicHttpBinding();
            var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Shop/");
            var myChannelFactory = new ChannelFactory<Shop.SShop>(myBinding, myEndpoint);

            Shop.SShop client = null;
            string s = "";
            try
            {
                client = myChannelFactory.CreateChannel();
                s = client.get();
                ((ICommunicationObject)client).Close();
            }
            catch
            {
                if (client != null)
                {
                    ((ICommunicationObject)client).Abort();
                }
            }

            try
            {
                string[,] array = JsonConvert.DeserializeObject<string[,]>(s);

                for (int l = 0; l < array.GetLength(0); l++)
                    if (array[l, 0] != null)
                        dataGridView.Columns.Add(array[l, 0], array[l, 0]);
                int row = 0;
                for (int i = 1; i < array.GetLength(1); i++)
                {
                    if (array[0, i] != null)
                    {
                        dataGridView.Rows.Add();
                        for (int cell = 0; cell < array.GetLength(0); cell++)
                            if (array[cell, i] != null)
                                dataGridView.Rows[row].Cells[cell].Value = (array[cell, i]);
                        row++;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Упс! Сервер недоступен!");
            }
        }

        public void loadSupJournal()
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
            var myBinding = new BasicHttpBinding();
            var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Sup_Journal/");
            var myChannelFactory = new ChannelFactory<Sup_Journal.SSup_Journal>(myBinding, myEndpoint);

            Sup_Journal.SSup_Journal client = null;
            string s = "";
            try
            {
                client = myChannelFactory.CreateChannel();
                s = client.get();
                ((ICommunicationObject)client).Close();
            }
            catch
            {
                if (client != null)
                {
                    ((ICommunicationObject)client).Abort();
                }
            }

            try
            {
                string[,] array = JsonConvert.DeserializeObject<string[,]>(s);

                for (int l = 0; l < array.GetLength(0); l++)
                    if (array[l, 0] != null)
                        dataGridView.Columns.Add(array[l, 0], array[l, 0]);
                int row = 0;
                for (int i = 1; i < array.GetLength(1); i++)
                {
                    if (array[0, i] != null)
                    {
                        dataGridView.Rows.Add();
                        for (int cell = 0; cell < array.GetLength(0); cell++)
                            if (array[cell, i] != null)
                                dataGridView.Rows[row].Cells[cell].Value = (array[cell, i]);
                        row++;
                    }
                    dataGridView.Columns[0].Visible = false;
                }
            }
            catch
            {
                MessageBox.Show("Упс! Сервер недоступен!");
            }
        }

        public void loadProduct()
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
            var myBinding = new BasicHttpBinding();
            var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Product/");
            var myChannelFactory = new ChannelFactory<Product.SProduct>(myBinding, myEndpoint);

            Product.SProduct client = null;
            string s = "";
            try
            {
                client = myChannelFactory.CreateChannel();
                s = client.get();
                ((ICommunicationObject)client).Close();
            }
            catch
            {
                if (client != null)
                {
                    ((ICommunicationObject)client).Abort();
                }
            }

            try
            {
                string[,] array = JsonConvert.DeserializeObject<string[,]>(s);

                for (int l = 0; l < array.GetLength(0); l++)
                    if (array[l, 0] != null)
                        dataGridView.Columns.Add(array[l, 0], array[l, 0]);
                int row = 0;
                for (int i = 1; i < array.GetLength(1); i++)
                {
                    if (array[0, i] != null)
                    {
                        dataGridView.Rows.Add();
                        for (int cell = 0; cell < array.GetLength(0); cell++)
                            if (array[cell, i] != null)
                                dataGridView.Rows[row].Cells[cell].Value = (array[cell, i]);
                        row++;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Упс! Сервер недоступен!");
            }
        }

        public void loadProduction_Journal()
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
            var myBinding = new BasicHttpBinding();
            var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Production_Journal/");
            var myChannelFactory = new ChannelFactory<Production_Journal.SProduction_Journal>(myBinding, myEndpoint);

            Production_Journal.SProduction_Journal client = null;
            string s = "";
            try
            {
                client = myChannelFactory.CreateChannel();
                s = client.get();
                ((ICommunicationObject)client).Close();
            }
            catch
            {
                if (client != null)
                {
                    ((ICommunicationObject)client).Abort();
                }
            }

            try
            {
                string[,] array = JsonConvert.DeserializeObject<string[,]>(s);

                for (int l = 0; l < array.GetLength(0); l++)
                    if (array[l, 0] != null)
                        dataGridView.Columns.Add(array[l, 0], array[l, 0]);
                int row = 0;
                for (int i = 1; i < array.GetLength(1); i++)
                {
                    if (array[0, i] != null)
                    {
                        dataGridView.Rows.Add();
                        for (int cell = 0; cell < array.GetLength(0); cell++)
                            if (array[cell, i] != null)
                                dataGridView.Rows[row].Cells[cell].Value = (array[cell, i]);
                        row++;
                    }
                    dataGridView.Columns[0].Visible = false;
                }
            }
            catch
            {
                MessageBox.Show("Упс! Сервер недоступен!");
            }
        }

        public void loadFactory()
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
            var myBinding = new BasicHttpBinding();
            var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Factory/");
            var myChannelFactory = new ChannelFactory<Factory.SFactory>(myBinding, myEndpoint);

            Factory.SFactory client = null;
            string s = "";
            try
            {
                client = myChannelFactory.CreateChannel();
                s = client.get();
                ((ICommunicationObject)client).Close();
            }
            catch
            {
                if (client != null)
                {
                    ((ICommunicationObject)client).Abort();
                }
            }

            try
            {
                string[,] array = JsonConvert.DeserializeObject<string[,]>(s);

                for (int l = 0; l < array.GetLength(0); l++)
                    if (array[l, 0] != null)
                        dataGridView.Columns.Add(array[l, 0], array[l, 0]);
                int row = 0;
                for (int i = 1; i < array.GetLength(1); i++)
                {
                    if (array[0, i] != null)
                    {
                        dataGridView.Rows.Add();
                        for (int cell = 0; cell < array.GetLength(0); cell++)
                            if (array[cell, i] != null)
                                dataGridView.Rows[row].Cells[cell].Value = (array[cell, i]);
                        row++;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Упс! Сервер недоступен!");
            }
        }
        public void loadCountry()
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
            var myBinding = new BasicHttpBinding();
            var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Country/");
            var myChannelFactory = new ChannelFactory<Country.SCountry>(myBinding, myEndpoint);

            Country.SCountry client = null;
            string s = "";
            try
            {
                client = myChannelFactory.CreateChannel();
                s = client.get();
                ((ICommunicationObject)client).Close();
            }
            catch
            {
                if (client != null)
                {
                    ((ICommunicationObject)client).Abort();
                }
            }

            try
            {
                string[,] array = JsonConvert.DeserializeObject<string[,]>(s);

                for (int l = 0; l < array.GetLength(0); l++)
                    if (array[l, 0] != null)
                        dataGridView.Columns.Add(array[l, 0], array[l, 0]);
                int row = 0;
                for (int i = 1; i < array.GetLength(1); i++)
                {
                    if (array[0, i] != null)
                    {
                        dataGridView.Rows.Add();
                        for (int cell = 0; cell < array.GetLength(0); cell++)
                            if (array[cell, i] != null)
                                dataGridView.Rows[row].Cells[cell].Value = (array[cell, i]);
                        row++;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Упс! Сервер недоступен!");
            }
        }

        public void loadEmployee()
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
            var myBinding = new BasicHttpBinding();
            var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Employee/");
            var myChannelFactory = new ChannelFactory<Employee.SEmployee>(myBinding, myEndpoint);

            Employee.SEmployee client = null;
            string s = "";
            try
            {
                client = myChannelFactory.CreateChannel();
                s = client.get();
                ((ICommunicationObject)client).Close();
            }
            catch
            {
                if (client != null)
                {
                    ((ICommunicationObject)client).Abort();
                }
            }

            try
            {
                string[,] array = JsonConvert.DeserializeObject<string[,]>(s);

                for (int l = 0; l < array.GetLength(0); l++)
                    if (array[l, 0] != null)
                        dataGridView.Columns.Add(array[l, 0], array[l, 0]);
                int row = 0;
                for (int i = 1; i < array.GetLength(1); i++)
                {
                    if (array[0, i] != null)
                    {
                        dataGridView.Rows.Add();
                        for (int cell = 0; cell < array.GetLength(0); cell++)
                            if (array[cell, i] != null)
                                dataGridView.Rows[row].Cells[cell].Value = (array[cell, i]);
                        row++;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Упс! Сервер недоступен!");
            }
        }

        public void loadPosition()
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
            var myBinding = new BasicHttpBinding();
            myBinding.MaxReceivedMessageSize = 70000000;
            var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Position/");
            var myChannelFactory = new ChannelFactory<Position.SPosition>(myBinding, myEndpoint);

            Position.SPosition client = null;
            string s = "";
            try
            {
                client = myChannelFactory.CreateChannel();
                s = client.get(friend_page);
                ((ICommunicationObject)client).Close();
            }
            catch (Exception y)
            {
                MessageBox.Show(y.Message);
                if (client != null)
                {
                    ((ICommunicationObject)client).Abort();
                }
            }

            try
            {
                string[,] array = JsonConvert.DeserializeObject<string[,]>(s);
                int row = 0;
                {
                    for (int l = 0; l < array.GetLength(0); l++)
                        if (array[l, 0] != null)
                            dataGridView.Columns.Add(array[l, 0], array[l, 0]);
                    for (int i = 1; i < array.GetLength(1); i++)
                    {
                        if (array[0, i] != null)
                        {
                            dataGridView.Rows.Add();
                            for (int cell = 0; cell < array.GetLength(0); cell++)
                                if (array[cell, i] != null)
                                    dataGridView.Rows[row].Cells[cell].Value = (array[cell, i]);
                            row++;
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Упс! Сервер недоступен!");
            }
        }

        private void table_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sw == true)
            {
                switch (table_comboBox.SelectedIndex + 1)
                {
                    case 1: // Книги
                        {
                            LoadBook();
                            break;
                        }
                    case 2: // Жанры
                        {
                            LoadGenre();
                            break;
                        }
                    case 3: // Расстановка
                        {
                            LoadArrangement();
                            break;
                        }
                    case 4: // Авторы
                        {
                            LoadAuthor();
                            break;
                        }
                    case 5: // Полки
                        {
                            LoadFloor();
                            break;
                        }
                    case 6: // Журнал
                        {
                            LoadJournal();
                            break;
                        }
                    case 7: // Библиотекарь
                        {
                            LoadLibrarian();
                            break;
                        }
                    case 8: // Местоположение
                        {
                            LoadLocation();
                            break;
                        }
                    case 9: // Читатель
                        {
                            LoadReader();
                            break;
                        }
                    case 10: // Статус
                        {
                            LoadStatus();
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            
            switch (table_comboBox.SelectedIndex + 1)
            {
                case 1: // Книги
                    {
                        Add_Book myAdd = new Add_Book(list);
                        myAdd.ShowDialog();
                        if (myAdd.DialogResult == DialogResult.OK)
                        {
                            MessageBox.Show("Добавление прошло успешно!");
                        }
                        LoadBook();
                        break;
                    }
                case 2: // Жанры
                    {
                        Add_Genre myAdd = new Add_Genre(list);
                        myAdd.ShowDialog();
                        if (myAdd.DialogResult == DialogResult.OK)
                        {
                            MessageBox.Show("Добавление прошло успешно!");
                        }
                        LoadGenre();
                        break;
                    }
                case 3: // Расстановка
                    {
                        Add_Arrangement myAdd = new Add_Arrangement(list);
                        myAdd.ShowDialog();
                        if (myAdd.DialogResult == DialogResult.OK)
                        {
                            MessageBox.Show("Добавление прошло успешно!");
                        }
                        LoadArrangement();
                        break;
                    }
                case 4: // Авторы
                    {
                        Add_Author myAdd = new Add_Author(list);
                        myAdd.ShowDialog();
                        if (myAdd.DialogResult == DialogResult.OK)
                        {
                            MessageBox.Show("Добавление прошло успешно!");
                        }
                        LoadAuthor();
                        break;
                    }
                case 5: // Полки
                    {
                        Add_Floor myAdd = new Add_Floor(list);
                        myAdd.ShowDialog();
                        if (myAdd.DialogResult == DialogResult.OK)
                        {
                            MessageBox.Show("Добавление прошло успешно!");
                        }
                        LoadFloor();
                        break;
                    }
                case 6: // Журнал
                    {
                        Add_Journal myAdd = new Add_Journal(list);
                        myAdd.ShowDialog();
                        if (myAdd.DialogResult == DialogResult.OK)
                        {
                            MessageBox.Show("Добавление прошло успешно!");
                        }
                        LoadJournal();
                        break;
                    }
                case 7: // Библиотекарь
                    {
                        Add_Librarian myAdd = new Add_Librarian(list);
                        myAdd.ShowDialog();
                        if (myAdd.DialogResult == DialogResult.OK)
                        {
                            MessageBox.Show("Добавление прошло успешно!");
                        }
                        LoadLibrarian();
                        break;
                    }
                case 8: // Местоположение
                    {
                        Add_Location myAdd = new Add_Location(list);
                        myAdd.ShowDialog();
                        if (myAdd.DialogResult == DialogResult.OK)
                        {
                            MessageBox.Show("Добавление прошло успешно!");
                        }
                        LoadLocation();
                        break;
                    }
                case 9: // Читатель
                    {
                        Add_Reader myAdd = new Add_Reader(list);
                        myAdd.ShowDialog();
                        if (myAdd.DialogResult == DialogResult.OK)
                        {
                            MessageBox.Show("Добавление прошло успешно!");
                        }
                        LoadReader();
                        break;
                    }
                case 10: // Статус
                    {
                        Add_Status myAdd = new Add_Status(list);
                        myAdd.ShowDialog();
                        if (myAdd.DialogResult == DialogResult.OK)
                        {
                            MessageBox.Show("Добавление прошло успешно!");
                        }
                        LoadStatus();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void update_button_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            if (dataGridView.SelectedCells.Count >= dataGridView.ColumnCount)
            {
                for (int i = 0; i < dataGridView.ColumnCount; i++)
                {
                    list.Add(dataGridView.SelectedRows[0].Cells[i].Value.ToString());
                }


                switch (table_comboBox.SelectedIndex + 1)
                {
                    case 1: // Книги
                        {
                            Add_Book myUpd = new Add_Book(list);
                            myUpd.ShowDialog();
                            if (myUpd.DialogResult == DialogResult.OK)
                            {
                                MessageBox.Show("Обновление прошло успешно!");
                            }
                            LoadBook();
                            break;
                        }
                    case 2: // Жанры
                        {
                            Add_Genre myUpd = new Add_Genre(list);
                            myUpd.ShowDialog();
                            if (myUpd.DialogResult == DialogResult.OK)
                            {
                                MessageBox.Show("Обновление прошло успешно!");
                            }
                            LoadGenre();
                            break;
                        }
                    case 3: // Расстановка
                        {
                            Add_Arrangement myUpd = new Add_Arrangement(list);
                            myUpd.ShowDialog();
                            if (myUpd.DialogResult == DialogResult.OK)
                            {
                                MessageBox.Show("Обновление прошло успешно!");
                            }
                            LoadArrangement();
                            break;
                        }
                    case 4: // Авторы
                        {
                            Add_Author myUpd = new Add_Author(list);
                            myUpd.ShowDialog();
                            if (myUpd.DialogResult == DialogResult.OK)
                            {
                                MessageBox.Show("Обновление прошло успешно!");
                            }
                            LoadAuthor();
                            break;
                        }
                    case 5: // Полки
                        {
                            Add_Floor myUpd = new Add_Floor(list);
                            myUpd.ShowDialog();
                            if (myUpd.DialogResult == DialogResult.OK)
                            {
                                MessageBox.Show("Обновление прошло успешно!");
                            }
                            LoadFloor();
                            break;
                        }
                    case 6: // Журнал
                        {
                            Add_Journal myUpd = new Add_Journal(list);
                            myUpd.ShowDialog();
                            if (myUpd.DialogResult == DialogResult.OK)
                            {
                                MessageBox.Show("Обновление прошло успешно!");
                            }
                            LoadJournal();
                            break;
                        }
                    case 7: // Библиотекарь
                        {
                            Add_Librarian myUpd = new Add_Librarian(list);
                            myUpd.ShowDialog();
                            if (myUpd.DialogResult == DialogResult.OK)
                            {
                                MessageBox.Show("Обновление прошло успешно!");
                            }
                            LoadLibrarian();
                            break;
                        }
                    case 8: // Местоположение
                        {
                            Add_Location myUpd = new Add_Location(list);
                            myUpd.ShowDialog();
                            if (myUpd.DialogResult == DialogResult.OK)
                            {
                                MessageBox.Show("Обновление прошло успешно!");
                            }
                            LoadLocation();
                            break;
                        }
                    case 9: // Читатель
                        {
                            Add_Reader myUpd = new Add_Reader(list);
                            myUpd.ShowDialog();
                            if (myUpd.DialogResult == DialogResult.OK)
                            {
                                MessageBox.Show("Обновление прошло успешно!");
                            }
                            LoadReader();
                            break;
                        }
                    case 10: // Статус
                        {
                            Add_Status myUpd = new Add_Status(list);
                            myUpd.ShowDialog();
                            if (myUpd.DialogResult == DialogResult.OK)
                            {
                                MessageBox.Show("Обновление прошло успешно!");
                            }
                            LoadStatus();
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            else
            {
                MessageBox.Show("Выберите целую строку!");
            }
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedCells.Count >= dataGridView.ColumnCount)
            {
                string index = dataGridView.SelectedRows[0].Cells[0].Value.ToString();
                
                switch (table_comboBox.SelectedIndex + 1)
                {
                    case 1: // Книги
                        {
                            var myBinding = new System.ServiceModel.BasicHttpBinding();
                            var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/LibraryServer/Book/");
                            var myChannelFactory = new ChannelFactory<Book.ServBook>(myBinding, myEndpoint);

                            Book.ServBook client = null;
                            string s = "";
                            try
                            {
                                client = myChannelFactory.CreateChannel();
                                client.DeleteBook(index);
                                ((ICommunicationObject)client).Close();
                                MessageBox.Show("Удаление прошло успешно!");
                            }
                            catch
                            {
                                if (client != null)
                                {
                                    ((ICommunicationObject)client).Abort();
                                }
                            }
                            LoadBook();
                            break;
                        }
                    case 2: // Жанры
                        {
                            var myBinding = new System.ServiceModel.BasicHttpBinding();
                            var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/LibraryServer/Genre/");
                            var myChannelFactory = new ChannelFactory<Genre.ServGenre>(myBinding, myEndpoint);

                            Genre.ServGenre client = null;
                            string s = "";
                            try
                            {
                                client = myChannelFactory.CreateChannel();
                                client.DeleteGenre(index);
                                ((ICommunicationObject)client).Close();
                                MessageBox.Show("Удаление прошло успешно!");
                            }
                            catch
                            {
                                if (client != null)
                                {
                                    ((ICommunicationObject)client).Abort();
                                }
                            }
                            LoadGenre();
                            break;
                        }
                    case 3: // Расстановка
                        {
                            var myBinding = new System.ServiceModel.BasicHttpBinding();
                            var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/LibraryServer/Arrangement/");
                            var myChannelFactory = new ChannelFactory<Arrangement.ServArrangement>(myBinding, myEndpoint);

                            Arrangement.ServArrangement client = null;
                            string s = "";
                            try
                            {
                                client = myChannelFactory.CreateChannel();
                                client.DeleteArrangement(index);
                                ((ICommunicationObject)client).Close();
                                MessageBox.Show("Удаление прошло успешно!");
                            }
                            catch
                            {
                                if (client != null)
                                {
                                    ((ICommunicationObject)client).Abort();
                                }
                            }
                            LoadArrangement();
                            break;
                        }
                    case 4: // Авторы
                        {
                            var myBinding = new System.ServiceModel.BasicHttpBinding();
                            var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/LibraryServer/Author/");
                            var myChannelFactory = new ChannelFactory<Author.ServAuthor>(myBinding, myEndpoint);

                            Author.ServAuthor client = null;
                            string s = "";
                            try
                            {
                                client = myChannelFactory.CreateChannel();
                                client.DeleteAuthor(index);
                                ((ICommunicationObject)client).Close();
                                MessageBox.Show("Удаление прошло успешно!");
                            }
                            catch
                            {
                                if (client != null)
                                {
                                    ((ICommunicationObject)client).Abort();
                                }
                            }
                            LoadAuthor();
                            break;
                        }
                    case 5: // Полки
                        {
                            var myBinding = new System.ServiceModel.BasicHttpBinding();
                            var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/LibraryServer/Floor/");
                            var myChannelFactory = new ChannelFactory<Floor.ServFloor>(myBinding, myEndpoint);

                            Floor.ServFloor client = null;
                            string s = "";
                            try
                            {
                                client = myChannelFactory.CreateChannel();
                                client.DeleteFloor(index);
                                ((ICommunicationObject)client).Close();
                                MessageBox.Show("Удаление прошло успешно!");
                            }
                            catch
                            {
                                if (client != null)
                                {
                                    ((ICommunicationObject)client).Abort();
                                }
                            }
                            LoadFloor();
                            break;
                        }
                    case 6: // Журнал
                        {
                            var myBinding = new System.ServiceModel.BasicHttpBinding();
                            var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/LibraryServer/Journal/");
                            var myChannelFactory = new ChannelFactory<Journal.ServJournal>(myBinding, myEndpoint);

                            Journal.ServJournal client = null;
                            string s = "";
                            try
                            {
                                client = myChannelFactory.CreateChannel();
                                client.DeleteJournal(index);
                                ((ICommunicationObject)client).Close();
                                MessageBox.Show("Удаление прошло успешно!");
                            }
                            catch
                            {
                                if (client != null)
                                {
                                    ((ICommunicationObject)client).Abort();
                                }
                            }
                            LoadJournal();
                            break;
                        }
                    case 7: // Библиотекарь
                        {
                            var myBinding = new System.ServiceModel.BasicHttpBinding();
                            var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/LibraryServer/Librarian/");
                            var myChannelFactory = new ChannelFactory<Librarian.ServLibrarian>(myBinding, myEndpoint);

                            Librarian.ServLibrarian client = null;
                            string s = "";
                            try
                            {
                                client = myChannelFactory.CreateChannel();
                                client.DeleteLibrarian(index);
                                ((ICommunicationObject)client).Close();
                                MessageBox.Show("Удаление прошло успешно!");
                            }
                            catch
                            {
                                if (client != null)
                                {
                                    ((ICommunicationObject)client).Abort();
                                }
                            }
                            LoadLibrarian();
                            break;
                        }
                    case 8: // Местоположение
                        {
                            var myBinding = new System.ServiceModel.BasicHttpBinding();
                            var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/LibraryServer/Location/");
                            var myChannelFactory = new ChannelFactory<Location.ServLocation>(myBinding, myEndpoint);

                            Location.ServLocation client = null;
                            string s = "";
                            try
                            {
                                client = myChannelFactory.CreateChannel();
                                client.DeleteLocation(index);
                                ((ICommunicationObject)client).Close();
                                MessageBox.Show("Удаление прошло успешно!");
                            }
                            catch
                            {
                                if (client != null)
                                {
                                    ((ICommunicationObject)client).Abort();
                                }
                            }
                            LoadLocation();
                            break;
                        }
                    case 9: // Читатель
                        {
                            var myBinding = new System.ServiceModel.BasicHttpBinding();
                            var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/LibraryServer/Reader/");
                            var myChannelFactory = new ChannelFactory<Reader.ServReader>(myBinding, myEndpoint);

                            Reader.ServReader client = null;
                            string s = "";
                            try
                            {
                                client = myChannelFactory.CreateChannel();
                                client.DeleteReader(index);
                                ((ICommunicationObject)client).Close();
                                MessageBox.Show("Удаление прошло успешно!");
                            }
                            catch
                            {
                                if (client != null)
                                {
                                    ((ICommunicationObject)client).Abort();
                                }
                            }
                            LoadReader();
                            break;
                        }
                    case 10: // Статус
                        {
                            var myBinding = new System.ServiceModel.BasicHttpBinding();
                            var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/LibraryServer/Status/");
                            var myChannelFactory = new ChannelFactory<Status.ServStatus>(myBinding, myEndpoint);

                            Status.ServStatus client = null;
                            string s = "";
                            try
                            {
                                client = myChannelFactory.CreateChannel();
                                client.DeleteStatus(index);
                                ((ICommunicationObject)client).Close();
                                MessageBox.Show("Удаление прошло успешно!");
                            }
                            catch
                            {
                                if (client != null)
                                {
                                    ((ICommunicationObject)client).Abort();
                                }
                            }
                            LoadStatus();
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            else
            {
                MessageBox.Show("Выберите целую строку!");
            }
        }

        private void switch_button_Click(object sender, EventArgs e)
        {
            sw = !sw;
            if (sw == true) // my
            {
                my_groupBox.Enabled = true;
                friend_groupBox.Enabled = false;
                table_comboBox.SelectedIndex = 0;
                LoadBook();
            }
            if (sw == false) // friend
            {
                my_groupBox.Enabled = false;
                friend_groupBox.Enabled = true;
                friend_table_comboBox.SelectedIndex = 0;
                loadPosition();
            }
        }

        private void friend_table_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sw == false)
            {
                switch (friend_table_comboBox.SelectedIndex + 1)
                {
                    case 1: // Должность
                        {
                            loadPosition();
                            break;
                        }
                    case 2: // Сотрудник
                        {
                            loadEmployee();
                            break;
                        }
                    case 3: // Страна
                        {
                            loadCountry();
                            break;
                        }
                    case 4: // Производитель
                        {
                            loadFactory();
                            break;
                        }
                    case 5: // Журнал производства
                        {
                            loadProduction_Journal();
                            break;
                        }
                    case 6: // Продукция
                        {
                            loadProduct();
                            break;
                        }
                    case 7: // Журнал поставок
                        {
                            loadSupJournal();
                            break;
                        }
                    case 8: // Стоимость
                        {
                            loadCost();
                            break;
                        }
                    case 9: // Магазин
                        {
                            loadShop();
                            break;
                        }
                    case 10: // Профиль
                        {
                            loadProfile();
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }

        private void friend_add_button_Click(object sender, EventArgs e)
        {
            switch (friend_table_comboBox.SelectedIndex + 1)
            {
                case 1: // Должность
                    {
                        AddPosition MyForm = new AddPosition(true, "", "", this);
                        MyForm.ShowDialog();
                        if (MyForm.DialogResult == DialogResult.OK)
                        {
                            MessageBox.Show("Добавление прошло успешно!");
                        }
                        loadPosition();
                        break;
                    }
                case 2: // Сотрудник
                    {
                        AddEmp MyForm = new AddEmp(true, "", "", "", this);
                        MyForm.ShowDialog();
                        if (MyForm.DialogResult == DialogResult.OK)
                        {
                            MessageBox.Show("Добавление прошло успешно!");
                        }
                        loadEmployee();
                        break;
                    }
                case 3: // Страна
                    {
                        AddCountry MyForm = new AddCountry(true, "", "", "", this);
                        MyForm.ShowDialog();
                        if (MyForm.DialogResult == DialogResult.OK)
                        {
                            MessageBox.Show("Добавление прошло успешно!");
                        }
                        loadCountry();
                        break;
                    }
                case 4: // Производитель
                    {
                        AddFactory MyForm = new AddFactory(true, "", "", "", this);
                        MyForm.ShowDialog();
                        if (MyForm.DialogResult == DialogResult.OK)
                        {
                            MessageBox.Show("Добавление прошло успешно!");
                        }
                        loadFactory();
                        break;
                    }
                case 5: // Журнал производства
                    {
                        AddJP MyForm = new AddJP(true, "", "", "", "", this);
                        MyForm.ShowDialog();
                        if (MyForm.DialogResult == DialogResult.OK)
                        {
                            MessageBox.Show("Добавление прошло успешно!");
                        }
                        loadProduction_Journal();
                        break;
                    }
                case 6: // Продукция
                    {
                        AddProduct MyForm = new AddProduct(true, "", "", this);
                        MyForm.ShowDialog();
                        if (MyForm.DialogResult == DialogResult.OK)
                        {
                            MessageBox.Show("Добавление прошло успешно!");
                        }
                        loadProduct();
                        break;
                    }
                case 7: // Журнал поставок
                    {
                        AddJS MyForm = new AddJS(true, "", "", "", "", this);
                        MyForm.ShowDialog();
                        if (MyForm.DialogResult == DialogResult.OK)
                        {
                            MessageBox.Show("Добавление прошло успешно!");
                        }
                        loadSupJournal();
                        break;
                    }
                case 8: // Стоимость
                    {
                        loadCost();
                        break;
                    }
                case 9: // Магазин
                    {
                        AddShop MyForm = new AddShop(true, "", "", "", this);
                        MyForm.ShowDialog();
                        if (MyForm.DialogResult == DialogResult.OK)
                        {
                            MessageBox.Show("Добавление прошло успешно!");
                        }
                        loadShop();
                        break;
                    }
                case 10: // Профиль
                    {
                        AddProfile MyForm = new AddProfile(true, "", this);
                        MyForm.ShowDialog();
                        if (MyForm.DialogResult == DialogResult.OK)
                        {
                            MessageBox.Show("Добавление прошло успешно!");
                        }
                        loadProfile();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void friend_update_button_Click(object sender, EventArgs e)
        {
            switch (friend_table_comboBox.SelectedIndex + 1)
            {
                case 1: // Должность
                    {
                        try
                        {
                            int row = dataGridView.CurrentCell.RowIndex;
                            string t = dataGridView[0, row].Value.ToString();
                            string p = dataGridView[1, row].Value.ToString();
                            AddPosition MyForm = new AddPosition(false, t, p, this);
                            MyForm.ShowDialog();
                            if (MyForm.DialogResult == DialogResult.OK)
                            {
                                MessageBox.Show("Обновление прошло успешно!");
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Таблица имеет неверный формат!");
                            return;
                        }
                        loadPosition();
                        break;
                    }
                case 2: // Сотрудник
                    {
                        try
                        {
                            int row = dataGridView.CurrentCell.RowIndex;
                            string t = dataGridView[0, row].Value.ToString();
                            string p = dataGridView[1, row].Value.ToString();
                            string u = dataGridView[2, row].Value.ToString();
                            AddEmp MyForm = new AddEmp(false, t, p, u, this);
                            MyForm.ShowDialog();
                            if (MyForm.DialogResult == DialogResult.OK)
                            {
                                MessageBox.Show("Обновление прошло успешно!");
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Таблица имеет неверный формат!");
                            return;
                        }
                        loadEmployee();
                        break;
                    }
                case 3: // Страна
                    {
                        try
                        {
                            int row = dataGridView.CurrentCell.RowIndex;
                            string t = dataGridView[0, row].Value.ToString();
                            string p = dataGridView[1, row].Value.ToString();
                            string u = dataGridView[2, row].Value.ToString();
                            AddCountry MyForm = new AddCountry(false, t, p, u, this);
                            MyForm.ShowDialog();
                            if (MyForm.DialogResult == DialogResult.OK)
                            {
                                MessageBox.Show("Обновление прошло успешно!");
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Таблица имеет неверный формат!");
                            return;
                        }
                        loadCountry();
                        break;
                    }
                case 4: // Производитель
                    {
                        try
                        {
                            int row = dataGridView.CurrentCell.RowIndex;
                            string t = dataGridView[0, row].Value.ToString();
                            string p = dataGridView[1, row].Value.ToString();
                            string u = dataGridView[2, row].Value.ToString();
                            AddFactory MyForm = new AddFactory(false, t, p, u, this);
                            MyForm.ShowDialog();
                            if (MyForm.DialogResult == DialogResult.OK)
                            {
                                MessageBox.Show("Обновление прошло успешно!");
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Таблица имеет неверный формат!");
                            return;
                        }
                        loadFactory();
                        break;
                    }
                case 5: // Журнал производства
                    {
                        try
                        {
                            int row = dataGridView.CurrentCell.RowIndex;
                            string t = dataGridView[0, row].Value.ToString();
                            string p = dataGridView[1, row].Value.ToString();
                            string u = dataGridView[2, row].Value.ToString();
                            string s = dataGridView[3, row].Value.ToString();
                            AddJP MyForm = new AddJP(false, t, p, u, s, this);
                            MyForm.ShowDialog();
                            if (MyForm.DialogResult == DialogResult.OK)
                            {
                                MessageBox.Show("Обновление прошло успешно!");
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Таблица имеет неверный формат!");
                            return;
                        }
                        loadProduction_Journal();
                        break;
                    }
                case 6: // Продукция
                    {
                        try
                        {
                            int row = dataGridView.CurrentCell.RowIndex;
                            string t = dataGridView[0, row].Value.ToString();
                            string p = dataGridView[1, row].Value.ToString();
                            AddProduct MyForm = new AddProduct(false, t, p, this);
                            MyForm.ShowDialog();
                            if (MyForm.DialogResult == DialogResult.OK)
                            {
                                MessageBox.Show("Обновление прошло успешно!");
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Таблица имеет неверный формат!");
                            return;
                        }
                        loadProduct();
                        break;
                    }
                case 7: // Журнал поставок
                    {
                        try
                        {
                            int row = dataGridView.CurrentCell.RowIndex;
                            string t = dataGridView[0, row].Value.ToString();
                            string p = dataGridView[1, row].Value.ToString();
                            string u = dataGridView[2, row].Value.ToString();
                            string s = dataGridView[3, row].Value.ToString();
                            AddJS MyForm = new AddJS(false, t, p, u, s, this);
                            MyForm.ShowDialog();
                            if (MyForm.DialogResult == DialogResult.OK)
                            {
                                MessageBox.Show("Обновление прошло успешно!");
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Таблица имеет неверный формат!");
                            return;
                        }
                        loadSupJournal();
                        break;
                    }
                case 8: // Стоимость
                    {
                        loadCost();
                        break;
                    }
                case 9: // Магазин
                    {
                        try
                        {
                            int row = dataGridView.CurrentCell.RowIndex;
                            string t = dataGridView[0, row].Value.ToString();
                            string p = dataGridView[1, row].Value.ToString();
                            string u = dataGridView[2, row].Value.ToString();
                            AddShop MyForm = new AddShop(false, t, p, u, this);
                            MyForm.ShowDialog();
                            if (MyForm.DialogResult == DialogResult.OK)
                            {
                                MessageBox.Show("Обновление прошло успешно!");
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Таблица имеет неверный формат!");
                            return;
                        }
                        loadShop();
                        break;
                    }
                case 10: // Профиль
                    {
                        try
                        {
                            int row = dataGridView.CurrentCell.RowIndex;
                            string t = dataGridView[0, row].Value.ToString();
                            AddProfile MyForm = new AddProfile(false, t, this);
                            MyForm.ShowDialog();
                            if (MyForm.DialogResult == DialogResult.OK)
                            {
                                MessageBox.Show("Обновление прошло успешно!");
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Таблица имеет неверный формат!");
                            return;
                        }
                        loadProfile();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void friend_delete_button_Click(object sender, EventArgs e)
        {
            switch (friend_table_comboBox.SelectedIndex + 1)
            {
                case 1: // Должность
                    {
                        int row = 0;
                        string t = "";
                        try
                        {
                            row = dataGridView.CurrentCell.RowIndex;
                            t = dataGridView[0, row].Value.ToString();
                        }
                        catch
                        {
                            MessageBox.Show("Таблица имеет неверный формат!");
                            return;
                        }
                        var myBinding = new BasicHttpBinding();
                        var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Position/");
                        var myChannelFactory = new ChannelFactory<Position.SPosition>(myBinding, myEndpoint);

                        Position.SPosition client = null;
                        try
                        {
                            client = myChannelFactory.CreateChannel();
                            client.Delete(t);
                            ((ICommunicationObject)client).Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            if (client != null)
                            {
                                ((ICommunicationObject)client).Abort();
                            }
                            MessageBox.Show("Ошибка! Север не отвечает");
                            return;
                        }
                        loadPosition();
                        break;
                    }
                case 2: // Сотрудник
                    {
                        int row = 0;
                        string t = "";
                        try
                        {
                            row = dataGridView.CurrentCell.RowIndex;
                            t = dataGridView[0, row].Value.ToString();
                        }
                        catch
                        {
                            MessageBox.Show("Таблица имеет неверный формат!");
                            return;
                        }
                        var myBinding = new BasicHttpBinding();
                        var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Employee/");
                        var myChannelFactory = new ChannelFactory<Employee.SEmployee>(myBinding, myEndpoint);

                        Employee.SEmployee client = null;
                        try
                        {
                            client = myChannelFactory.CreateChannel();
                            client.Delete(t);
                            ((ICommunicationObject)client).Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            if (client != null)
                            {
                                ((ICommunicationObject)client).Abort();
                            }
                            MessageBox.Show("Ошибка! Север не отвечает");
                            return;
                        }
                        loadEmployee();
                        break;
                    }
                case 3: // Страна
                    {
                        int row = 0;
                        string t = "";
                        try
                        {
                            row = dataGridView.CurrentCell.RowIndex;
                            t = dataGridView[0, row].Value.ToString();
                        }
                        catch
                        {
                            MessageBox.Show("Таблица имеет неверный формат!");
                            return;
                        }
                        var myBinding = new BasicHttpBinding();
                        var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Country/");
                        var myChannelFactory = new ChannelFactory<Country.SCountry>(myBinding, myEndpoint);

                        Country.SCountry client = null;
                        try
                        {
                            client = myChannelFactory.CreateChannel();
                            client.Delete(t);
                            ((ICommunicationObject)client).Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            if (client != null)
                            {
                                ((ICommunicationObject)client).Abort();
                            }
                            MessageBox.Show("Ошибка! Север не отвечает");
                            return;
                        }
                        loadCountry();
                        break;
                    }
                case 4: // Производитель
                    {
                        int row = 0;
                        string t = "";
                        try
                        {
                            row = dataGridView.CurrentCell.RowIndex;
                            t = dataGridView[0, row].Value.ToString();
                        }
                        catch
                        {
                            MessageBox.Show("Таблица имеет неверный формат!");
                            return;
                        }
                        var myBinding = new BasicHttpBinding();
                        var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Factory/");
                        var myChannelFactory = new ChannelFactory<Factory.SFactory>(myBinding, myEndpoint);

                        Factory.SFactory client = null;
                        try
                        {
                            client = myChannelFactory.CreateChannel();
                            client.Delete(t);
                            ((ICommunicationObject)client).Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            if (client != null)
                            {
                                ((ICommunicationObject)client).Abort();
                            }
                            MessageBox.Show("Ошибка! Север не отвечает");
                            return;
                        }
                        loadFactory();
                        break;
                    }
                case 5: // Журнал производства
                    {
                        int row = 0;
                        string t = "";
                        try
                        {
                            row = dataGridView.CurrentCell.RowIndex;
                            t = dataGridView[0, row].Value.ToString();
                        }
                        catch
                        {
                            MessageBox.Show("Таблица имеет неверный формат!");
                            return;
                        }
                        var myBinding = new BasicHttpBinding();
                        var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Production_Journal/");
                        var myChannelFactory = new ChannelFactory<Production_Journal.SProduction_Journal>(myBinding, myEndpoint);

                        Production_Journal.SProduction_Journal client = null;
                        try
                        {
                            client = myChannelFactory.CreateChannel();
                            client.Delete(t);
                            ((ICommunicationObject)client).Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            if (client != null)
                            {
                                ((ICommunicationObject)client).Abort();
                            }
                            MessageBox.Show("Ошибка! Север не отвечает");
                            return;
                        }
                        loadProduction_Journal();
                        break;
                    }
                case 6: // Продукция
                    {
                        int row = 0;
                        string t = "";
                        try
                        {
                            row = dataGridView.CurrentCell.RowIndex;
                            t = dataGridView[0, row].Value.ToString();
                        }
                        catch
                        {
                            MessageBox.Show("Таблица имеет неверный формат!");
                            return;
                        }
                        var myBinding = new BasicHttpBinding();
                        var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Product/");
                        var myChannelFactory = new ChannelFactory<Product.SProduct>(myBinding, myEndpoint);

                        Product.SProduct client = null;
                        try
                        {
                            client = myChannelFactory.CreateChannel();
                            client.Delete(t);
                            ((ICommunicationObject)client).Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            if (client != null)
                            {
                                ((ICommunicationObject)client).Abort();
                            }
                            MessageBox.Show("Ошибка! Север не отвечает");
                            return;
                        }
                        loadProduct();
                        break;
                    }
                case 7: // Журнал поставок
                    {
                        int row = 0;
                        string t = "";
                        try
                        {
                            row = dataGridView.CurrentCell.RowIndex;
                            t = dataGridView[0, row].Value.ToString();
                        }
                        catch
                        {
                            MessageBox.Show("Таблица имеет неверный формат!");
                            return;
                        }
                        var myBinding = new BasicHttpBinding();
                        var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Sup_Journal/");
                        var myChannelFactory = new ChannelFactory<Sup_Journal.SSup_Journal>(myBinding, myEndpoint);

                        Sup_Journal.SSup_Journal client = null;
                        try
                        {
                            client = myChannelFactory.CreateChannel();
                            client.Delete(t);
                            ((ICommunicationObject)client).Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            if (client != null)
                            {
                                ((ICommunicationObject)client).Abort();
                            }
                            MessageBox.Show("Ошибка! Север не отвечает");
                            return;
                        }
                        loadSupJournal();
                        break;
                    }
                case 8: // Стоимость
                    {
                        loadCost();
                        break;
                    }
                case 9: // Магазин
                    {
                        int row = 0;
                        string t = "";
                        try
                        {
                            row = dataGridView.CurrentCell.RowIndex;
                            t = dataGridView[0, row].Value.ToString();
                        }
                        catch
                        {
                            MessageBox.Show("Таблица имеет неверный формат!");
                            return;
                        }
                        var myBinding = new BasicHttpBinding();
                        var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Shop/");
                        var myChannelFactory = new ChannelFactory<Shop.SShop>(myBinding, myEndpoint);

                        Shop.SShop client = null;
                        try
                        {
                            client = myChannelFactory.CreateChannel();
                            client.Delete(t);
                            ((ICommunicationObject)client).Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            if (client != null)
                            {
                                ((ICommunicationObject)client).Abort();
                            }
                            MessageBox.Show("Ошибка! Север не отвечает");
                            return;
                        }
                        loadShop();
                        break;
                    }
                case 10: // Профиль
                    {
                        int row = 0;
                        string t = "";
                        try
                        {
                            row = dataGridView.CurrentCell.RowIndex;
                            t = dataGridView[0, row].Value.ToString();
                        }
                        catch
                        {
                            MessageBox.Show("Таблица имеет неверный формат!");
                            return;
                        }
                        var myBinding = new BasicHttpBinding();
                        var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Profile/");
                        var myChannelFactory = new ChannelFactory<Profile.SProfile>(myBinding, myEndpoint);

                        Profile.SProfile client = null;
                        try
                        {
                            client = myChannelFactory.CreateChannel();
                            client.Delete(t);
                            ((ICommunicationObject)client).Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            if (client != null)
                            {
                                ((ICommunicationObject)client).Abort();
                            }
                            MessageBox.Show("Ошибка! Север не отвечает");
                            return;
                        }
                        loadProfile();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void thousand_button_Click(object sender, EventArgs e)
        {
            string path = "";
            saveFileDialog1.Filter = String.Format("xlsx files (*.xlsx)|*.xlsx|All files (*.*)|*.*");
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = saveFileDialog1.FileName;
                Thread th = new Thread(delegate () { toExcel(path); });
                th.Start();
            }
        }

        private void toExcel(string path)
        {
            try
            {
                var myBinding = new BasicHttpBinding();
                myBinding.MaxReceivedMessageSize = 70000000;
                myBinding.AllowCookies = false;
                var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/LibraryServer/Arrangement/");
                var myChannelFactory = new ChannelFactory<Arrangement.ServArrangement>(myBinding, myEndpoint);

                Arrangement.ServArrangement client = null;
                string s = "";
                try
                {
                    client = myChannelFactory.CreateChannel();
                    s = client.getAll();
                    ((ICommunicationObject)client).Close();
                }
                catch (Exception t)
                {
                    if (client != null)
                    {
                        ((ICommunicationObject)client).Abort();
                    }
                    MessageBox.Show(t.Message);
                    return;
                }

                string[,] array = JsonConvert.DeserializeObject<string[,]>(s);
                FileInfo newFile = new FileInfo(path);
                using (ExcelPackage xlPackage = new ExcelPackage(newFile))
                {

                    ExcelWorksheet ws = xlPackage.Workbook.Worksheets.Add("test");
                    //ws.Column[0].BackColor = Color.Blue;

                    int x = 1;
                    bool col = false;
                    for (int i = 0; i < array.GetLength(0); i++)
                    {
                        char pos = 'A';
                        col = false;
                        if (array[i, 0] != null)
                        {
                            for (int cell = 0; cell < array.GetLength(1); cell++)
                            {
                                string str = pos + x.ToString();
                                if (array[i, cell] != null)
                                {
                                    ws.Cells[str].Value = (array[i, cell]);
                                    if (i%2 == 0)
                                    {
                                        ws.Cells[str].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                        ws.Cells[str].Style.Fill.BackgroundColor.SetColor(Color.Blue);
                                    }
                                }
                                pos++;
                                col = !col;
                            }
                        }
                        x++;  
                    }
                    xlPackage.Save();
                }
                MessageBox.Show("Данные сохранены!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Недопустимое имя файла!");
            }
        }

        private void right_button_Click(object sender, EventArgs e)
        {
            if (table_comboBox.SelectedIndex == 2)
            {
                my_page++;
                page_label.Text = (my_page + 1).ToString();
                try
                {
                    dataGridView.Rows.Clear();
                    dataGridView.Columns.Clear();
                    var myBinding = new System.ServiceModel.BasicHttpBinding();
                    var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/LibraryServer/Arrangement/");
                    var myChannelFactory = new ChannelFactory<Arrangement.ServArrangement>(myBinding, myEndpoint);

                    Arrangement.ServArrangement client = null;
                    string s = "";
                    try
                    {
                        client = myChannelFactory.CreateChannel();
                        s = client.getAllArrangements(my_page.ToString());
                        ((ICommunicationObject)client).Close();
                    }
                    catch
                    {
                        if (client != null)
                        {
                            ((ICommunicationObject)client).Abort();
                        }
                    }

                    try
                    {
                        string[,] array = JsonConvert.DeserializeObject<string[,]>(s);

                        for (int l = 0; l < array.GetLength(1); l++)
                            if (array[0, l] != null)
                                dataGridView.Columns.Add(array[0, l], array[0, l]);
                        int row = 0;
                        for (int i = 1; i < array.GetLength(0); i++)
                        {
                            if (array[i, 0] != null)
                            {
                                dataGridView.Rows.Add();
                                for (int cell = 0; cell < array.GetLength(1); cell++)
                                    if (array[i, cell] != null)
                                        dataGridView.Rows[row].Cells[cell].Value = (array[i, cell]);
                                row++;
                            }
                        }
                        dataGridView.Columns[0].Visible = false;
                    }
                    catch
                    {
                        MessageBox.Show("Упс! Сервер недоступен!");
                    }
                }
                catch
                {

                }
            }      
        }

        private void left_button_Click(object sender, EventArgs e)
        {
            if (table_comboBox.SelectedIndex == 2)
            {
                if (my_page != 0)
                {
                    my_page--;
                    page_label.Text = (my_page + 1).ToString();
                    try
                    {
                        dataGridView.Rows.Clear();
                        dataGridView.Columns.Clear();
                        var myBinding = new System.ServiceModel.BasicHttpBinding();
                        var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/LibraryServer/Arrangement/");
                        var myChannelFactory = new ChannelFactory<Arrangement.ServArrangement>(myBinding, myEndpoint);

                        Arrangement.ServArrangement client = null;
                        string s = "";
                        try
                        {
                            client = myChannelFactory.CreateChannel();
                            s = client.getAllArrangements(my_page.ToString());
                            ((ICommunicationObject)client).Close();
                        }
                        catch
                        {
                            if (client != null)
                            {
                                ((ICommunicationObject)client).Abort();
                            }
                        }

                        try
                        {
                            string[,] array = JsonConvert.DeserializeObject<string[,]>(s);

                            for (int l = 0; l < array.GetLength(1); l++)
                                if (array[0, l] != null)
                                    dataGridView.Columns.Add(array[0, l], array[0, l]);
                            int row = 0;
                            for (int i = 1; i < array.GetLength(0); i++)
                            {
                                if (array[i, 0] != null)
                                {
                                    dataGridView.Rows.Add();
                                    for (int cell = 0; cell < array.GetLength(1); cell++)
                                        if (array[i, cell] != null)
                                            dataGridView.Rows[row].Cells[cell].Value = (array[i, cell]);
                                    row++;
                                }
                            }
                            dataGridView.Columns[0].Visible = false;
                        }
                        catch
                        {
                            MessageBox.Show("Упс! Сервер недоступен!");
                        }
                    }
                    catch
                    {

                    }
                }
            }
        }
    }
}
