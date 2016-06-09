using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryClient
{
    public partial class Add_Book : Form
    {
        bool update;
        List<string> val;

        public Add_Book(List<string> s)
        {
            InitializeComponent();
            update = false;
            val = s;
            if (s.Count == 0) // если добавление
            {
                LoadBook();
                comboBox1.SelectedIndex = 0;
                LoadGenre();
                comboBox2.SelectedIndex = 0;
            }
            else // если обновление
            {
                LoadBook();
                LoadGenre();
                comboBox1.Text = s[1];
                comboBox2.Text = s[2];
                name_textBox.Text = s[3];
                year_textBox.Text = s[4];
                publ_textBox.Text = s[5];
                pepr_textBox.Text = s[6];
                numB_textBox.Text = s[7];
                update = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // это все проверка введенных данных, и для добавления и для обновления
            try
            {
                int y = Convert.ToInt32(year_textBox.Text);
                if (y >= 2016 || y <= 1800)
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Заполните поле 'Год издания' правильно!");
                year_textBox.Text = ""; 
            }

            try
            {
                int y = Convert.ToInt32(pepr_textBox.Text);
                if (y >= 1000 || y <= 0)
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Заполните поле 'Количество страниц' правильно!");
                pepr_textBox.Text = "";
            }

            try
            {
                int y = Convert.ToInt32(numB_textBox.Text);
                if (y >= 1000 || y <= 0)
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Заполните поле 'Количество книг' правильно!");
                numB_textBox.Text = "";
            }

            if (name_textBox.Text == "" || year_textBox.Text == "" || publ_textBox.Text == "" || pepr_textBox.Text == "" || numB_textBox.Text == "")
            {
                MessageBox.Show("Заполните все поля!");
            }
            else
            {
                var myBinding = new System.ServiceModel.BasicHttpBinding();
                var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/LibraryServer/Book/");
                var myChannelFactory = new ChannelFactory<Book.ServBook>(myBinding, myEndpoint);

                Book.ServBook client = null;
                string s = "";
                try
                {
                    client = myChannelFactory.CreateChannel();
                    client.set_MyAuthor(comboBox1.Text);
                    client.set_MyGenre(comboBox2.Text);
                    client.set_Name(name_textBox.Text);
                    client.set_Year(year_textBox.Text);
                    client.set_Publishing(publ_textBox.Text);
                    client.set_Paper_number(pepr_textBox.Text);
                    client.set_Book_number(numB_textBox.Text);
                    if (!update) // добавление
                    {
                        client.SaveBook();
                    }
                    else // обновление
                    {
                        client.UpdateBook(val[0].ToString());
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
            comboBox1.Items.Clear();
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
                for (int i = 1; i < array.GetLength(0); i++)
                {
                    if (array[i, 1] != null && !comboBox1.Items.Contains(array[i, 1]))
                    {
                        comboBox1.Items.Add(array[i, 1]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Упс! Что-то пошло не так!");
            }
        }

        private void LoadGenre()
        {
            comboBox2.Items.Clear();
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
                for (int i = 1; i < array.GetLength(0); i++)
                {
                    if (array[i, 1] != null)
                    {
                        comboBox2.Items.Add(array[i, 1]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Упс! Что-то пошло не так!");
            }
        }

        private void year_textBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void pepr_textBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void numB_textBox_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
