using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using Newtonsoft.Json;

namespace LibraryClient
{
    public partial class Add_Journal : Form
    {
        bool update;
        List<string> val;

        public Add_Journal(List<string> s)
        {
            InitializeComponent();
            update = false;
            val = s;
            if (s.Count == 0) // если добавление
            {
                LoadLibr();
                libr_comboBox.SelectedIndex = 0;
                LoadReader();
                reader_comboBox.SelectedIndex = 0;
                LoadBook();
                book_comboBox.SelectedIndex = 0;
            }
            else // если обновление
            {
                LoadLibr();
                LoadReader();
                LoadBook();
                libr_comboBox.Text = s[1];
                reader_comboBox.Text = s[2];
                book_comboBox.Text = s[3];
                number_textBox.Text = s[4];
                dateTimePicker.Value = Convert.ToDateTime(s[5]);
                update = true;
            }
        }

        private void ok_button_Click(object sender, EventArgs e)
        {
            if (number_textBox.Text == "")
            {
                MessageBox.Show("''");
            }
            else
            {
                var myBinding = new System.ServiceModel.BasicHttpBinding();
                var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/LibraryServer/Journal/");
                var myChannelFactory = new ChannelFactory<Journal.ServJournal>(myBinding, myEndpoint);

                Journal.ServJournal client = null;
                string s = "";
                try
                {
                    client = myChannelFactory.CreateChannel();
                    client.set_MyLibrarian(libr_comboBox.Text);
                    client.set_MyReader(reader_comboBox.Text);
                    client.set_MyBook(book_comboBox.Text);
                    client.set_Number_of_book(number_textBox.Text);
                    client.set_Date_of_issue(dateTimePicker.Value.Year + "-" + dateTimePicker.Value.Month + "-" + dateTimePicker.Value.Day);
                    if (!update) // добавление
                    {
                        client.SaveJournal();
                    }
                    else // обновление
                    {
                        client.UpdateJournal(val[0].ToString());
                    }
                    ((ICommunicationObject)client).Close();
                    DialogResult = DialogResult.OK;
                }
                catch
                {
                    if (client != null)
                    {
                        ((ICommunicationObject)client).Abort();
                    }
                }
            }
        }

        private void LoadLibr()
        {
            libr_comboBox.Items.Clear();
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
                for (int i = 1; i < array.GetLength(0); i++)
                {
                    if (array[i, 1] != null && !libr_comboBox.Items.Contains(array[i, 1]))
                    {
                        libr_comboBox.Items.Add(array[i, 1]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Упс! Что-то пошло не так!");
            }
        }

        private void LoadReader()
        {
            reader_comboBox.Items.Clear();
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
                for (int i = 1; i < array.GetLength(0); i++)
                {
                    if (array[i, 1] != null && !reader_comboBox.Items.Contains(array[i, 1]))
                    {
                        reader_comboBox.Items.Add(array[i, 1]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Упс! Что-то пошло не так!");
            }
        }

        private void LoadBook()
        {
            book_comboBox.Items.Clear();
            var myBinding = new System.ServiceModel.BasicHttpBinding();
            var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/LibraryServer/Book/");
            var myChannelFactory = new ChannelFactory<Book.ServBook>(myBinding, myEndpoint);

            Book.ServBook client = null;
            string s = "";
            try
            {
                client = myChannelFactory.CreateChannel();
                s = client.getBookList();
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
                for (int i = 1; i < array.GetLength(0); i++)
                {
                    if (array[i, 1] != null && !book_comboBox.Items.Contains(array[i, 1]))
                    {
                        book_comboBox.Items.Add(array[i, 1]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Упс! Что-то пошло не так!");
            }
        }
    }
}
