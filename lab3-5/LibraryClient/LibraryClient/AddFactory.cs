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
    public partial class AddFactory : Form
    {
        bool f;
        private MainForm refForm;
        string Address = "";
        string Country = "";

        public AddFactory(bool flag, string name, string address, string country, MainForm refForm)
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
                Address = address;
                Country = country;
                textBox1.Text = name;
                textBox2.Text = address;
                comboBox1.Text = country;
                this.refForm = refForm;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (f == true) // add
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Заполните все поля!");
                }
                else
                {
                    var myBinding = new BasicHttpBinding();
                    var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Factory/");
                    var myChannelFactory = new ChannelFactory<Factory.SFactory>(myBinding, myEndpoint);

                    Factory.SFactory client = null;
                    string s = "";
                    try
                    {
                        client = myChannelFactory.CreateChannel();
                        client.set_Factory_Name(textBox1.Text);
                        client.set_Factory_Address(textBox2.Text);
                        client.set_Factory_Country(comboBox1.Text);
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
                        MessageBox.Show("Ошибка! Сервер не отвечает");
                        return;
                    }
                    if (refForm != null)
                    {
                        try
                        {
                            refForm.loadFactory();
                            this.Close();
                        }
                        catch
                        {
                            MessageBox.Show("Ошибка! Сервер не отвечает");
                            return;
                        }
                    }
                }
            }
            else // update
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Заполните все поля!");
                }
                else
                {
                    var myBinding = new BasicHttpBinding();
                    var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Factory/");
                    var myChannelFactory = new ChannelFactory<Factory.SFactory>(myBinding, myEndpoint);

                    Factory.SFactory client = null;
                    string s = "";
                    try
                    {
                        client = myChannelFactory.CreateChannel();
                        client.set_Factory_Name(textBox1.Text);
                        client.set_Factory_Address(textBox2.Text);
                        client.set_Factory_Country(comboBox1.Text);
                        s = client.toString();
                        client.Update(Name, textBox1.Text, textBox2.Text);
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
                        MessageBox.Show("Ошибка! Сервер не отвечает");
                        return;
                    }
                    if (refForm != null)
                    {
                        try
                        {
                            refForm.loadFactory();
                            this.Close();
                        }
                        catch
                        {
                            MessageBox.Show("Ошибка! Сервер не отвечает");
                            return;
                        }
                    }
                }
            }
        }

        private void AddFactory_Load(object sender, EventArgs e)
        {
            if (f == true) // add
            {
                try
                {
                    loadCountry();
                }
                catch
                {
                    MessageBox.Show("Ошибка! Сервер не отчеает");
                    return;
                }
            }
            else // update
            {
                try
                {
                    loadCountry();
                    Load_data();
                }
                catch
                {
                    MessageBox.Show("Ошибка! Север не отвечает");
                    return;
                }
            }
        }

        private void loadCountry()
        {
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

            string[,] array = JsonConvert.DeserializeObject<string[,]>(s);

            for (int l = 1; l < array.GetLength(1); l++)
                if (array[0, l] != null)
                    comboBox1.Items.Add(array[0, l]);

        }

        private void Load_data()
        {
            var myBinding = new BasicHttpBinding();
            var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Factory/");
            var myChannelFactory = new ChannelFactory<Factory.SFactory>(myBinding, myEndpoint);

            Factory.SFactory client = null;
            try
            {
                client = myChannelFactory.CreateChannel();
                client.getByName(Name);
                textBox1.Text = Name;
                textBox2.Text = Address;
                comboBox1.Text = Country;
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
