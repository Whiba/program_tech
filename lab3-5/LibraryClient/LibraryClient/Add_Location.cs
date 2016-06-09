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
    public partial class Add_Location : Form
    {
        bool update;
        List<string> val;

        public Add_Location(List<string> s)
        {
            InitializeComponent();
            update = false;
            val = s;
            if (s.Count == 0) // если добавление
            {
                LoadArrangement();
                arrang_comboBox.SelectedIndex = 0;
                LoadBook();
                book_comboBox.SelectedIndex = 0;
                LoadFloor();
                floor_comboBox.SelectedIndex = 0;
            }
            else // обновление
            {
                LoadArrangement();
                LoadBook();
                LoadFloor();
                book_comboBox.Text = s[1];
                floor_comboBox.Text = s[2];
                arrang_comboBox.Text = s[3];
                sector_textBox.Text = s[4];
                update = true;
            }
        }

        private void ok_button_Click(object sender, EventArgs e)
        {
            if (sector_textBox.Text == "")
            {
                MessageBox.Show("Заполните все поля!");
            }
            else
            {
                var myBinding = new System.ServiceModel.BasicHttpBinding();
                var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/LibraryServer/Location/");
                var myChannelFactory = new ChannelFactory<Location.ServLocation>(myBinding, myEndpoint);

                Location.ServLocation client = null;
                string s = "";
                try
                {
                    client = myChannelFactory.CreateChannel();
                    client.set_MyBook(book_comboBox.Text);
                    client.set_MyFloor(floor_comboBox.Text);
                    client.set_MyArrangement(arrang_comboBox.Text);
                    client.set_Sector(sector_textBox.Text);
                    if (!update) // добавление
                    {
                        client.SaveLocation();
                    }
                    else // обновление
                    {
                        client.UpdateLocation(val[0].ToString());
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

        private void LoadFloor()
        {
            floor_comboBox.Items.Clear();
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
                for (int i = 1; i < array.GetLength(0); i++)
                {
                    if (array[i, 1] != null)
                    {
                        floor_comboBox.Items.Add(array[i, 1]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Упс! Что-то пошло не так!");
            }
        }

        private void LoadArrangement()
        {
            arrang_comboBox.Items.Clear();
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
                for (int i = 1; i < array.GetLength(0); i++)
                {
                    if (array[i, 1] != null)
                    {
                        arrang_comboBox.Items.Add(array[i, 1]);
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
