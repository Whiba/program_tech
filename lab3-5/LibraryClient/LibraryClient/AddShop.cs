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
    public partial class AddShop : Form
    {
        bool f;
        private MainForm refForm;
        string Address = "";
        string Profile = "";

        public AddShop(bool flag, string name, string profile, string address, MainForm refForm)
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
                Profile = profile;
                textBox1.Text = name;
                textBox2.Text = address;
                comboBox1.Text = profile;
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
                    var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Shop/");
                    var myChannelFactory = new ChannelFactory<Shop.SShop>(myBinding, myEndpoint);

                    Shop.SShop client = null;
                    string s = "";
                    try
                    {
                        client = myChannelFactory.CreateChannel();
                        client.set_Shop_Name(textBox1.Text);
                        client.set_Shop_Address(textBox2.Text);
                        client.set_Shop_Profile(comboBox1.Text);
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
                            refForm.loadShop();
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
                    var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Shop/");
                    var myChannelFactory = new ChannelFactory<Shop.SShop>(myBinding, myEndpoint);

                    Shop.SShop client = null;
                    string s = "";
                    try
                    {
                        client = myChannelFactory.CreateChannel();
                        client.set_Shop_Name(textBox1.Text);
                        client.set_Shop_Address(textBox2.Text);
                        client.set_Shop_Profile(comboBox1.Text);
                        s = client.toString();
                        client.Update(textBox1.Text, Name, textBox2.Text);
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
                            refForm.loadShop();
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

        private void AddShop_Load(object sender, EventArgs e)
        {
            if (f == true) // add
            {
                try
                {
                    loadProfile();
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
                    loadProfile();
                    Load_data();
                }
                catch
                {
                    MessageBox.Show("Ошибка! Север не отвечает");
                    return;
                }
            }
        }

        private void loadProfile()
        {
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

            string[,] array = JsonConvert.DeserializeObject<string[,]>(s);

            for (int l = 1; l < array.GetLength(1); l++)
                if (array[0, l] != null)
                    comboBox1.Items.Add(array[0, l]);

        }

        private void Load_data()
        {
            var myBinding = new BasicHttpBinding();
            var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Shop/");
            var myChannelFactory = new ChannelFactory<Shop.SShop>(myBinding, myEndpoint);

            Shop.SShop client = null;
            try
            {
                client = myChannelFactory.CreateChannel();
                client.getByName(Name);
                textBox1.Text = Name;
                textBox2.Text = Address;
                comboBox1.Text = Profile;
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
