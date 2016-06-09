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

namespace LibraryClient
{
    public partial class AddCountry : Form
    {
        private MainForm refForm;
        string Continent = "";
        string Square = "";
        bool f;

        public AddCountry(bool flag, string name, string continent, string square, MainForm refForm)
        {
            InitializeComponent();
            f = flag;

            if (flag == true) // add
            {
                this.refForm = refForm;
            }
            else // update
            {
                Name = name;
                Continent = continent;
                Square = square;
                textBox1.Text = name;
                textBox2.Text = continent;
                textBox3.Text = square;
                this.refForm = refForm;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (f == true) // add
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Заполните все поля!");
                }
                else
                {
                    var myBinding = new BasicHttpBinding();
                    var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Country/");
                    var myChannelFactory = new ChannelFactory<Country.SCountry>(myBinding, myEndpoint);

                    Country.SCountry client = null;
                    string s = "";
                    try
                    {
                        client = myChannelFactory.CreateChannel();
                        client.set_Country_Name(textBox1.Text);
                        client.set_Country_Continent(textBox2.Text);
                        client.set_Country_Square(textBox3.Text);
                        s = client.toString();
                        client.Insert();
                        ((ICommunicationObject)client).Close();
                        DialogResult = DialogResult.OK;
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
                    if (refForm != null)
                    {
                        try
                        {
                            refForm.loadCountry();
                            this.Close();
                        }
                        catch
                        {
                            MessageBox.Show("Ошибка! Север не отвечает");
                            return;
                        }
                    }
                }
            }
            else // update
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Заполните все поля!");
                }
                else
                {
                    var myBinding = new BasicHttpBinding();
                    var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Country/");
                    var myChannelFactory = new ChannelFactory<Country.SCountry>(myBinding, myEndpoint);

                    Country.SCountry client = null;
                    string s = "";
                    try
                    {
                        client = myChannelFactory.CreateChannel();
                        s = client.toString();
                        client.Update(textBox1.Text, Name, textBox2.Text, textBox3.Text);
                        ((ICommunicationObject)client).Close();
                        DialogResult = DialogResult.OK;
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
                    if (refForm != null)
                    {
                        try
                        {
                            refForm.loadCountry();
                            this.Close();
                        }
                        catch
                        {
                            MessageBox.Show("Ошибка! Север не отвечает");
                            return;
                        }
                    }
                }
            }
        }

        private void AddCountry_Load(object sender, EventArgs e)
        {
            if (f == false)
            {
                try
                {
                    Load_data();
                }
                catch
                {
                    MessageBox.Show("Ошибка! Север не отвечает");
                    return;
                }
            }
        }

        private void Load_data()
        {
            var myBinding = new BasicHttpBinding();
            var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Country/");
            var myChannelFactory = new ChannelFactory<Country.SCountry>(myBinding, myEndpoint);

            Country.SCountry client = null;
            try
            {
                client = myChannelFactory.CreateChannel();
                client.getByName(Name);
                textBox1.Text = Name;
                textBox2.Text = Continent;
                textBox3.Text = Square;
                ((ICommunicationObject)client).Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (client != null)
                {
                    ((ICommunicationObject)client).Abort();
                }
            }
        }
    }
}
