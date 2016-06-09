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
    public partial class AddProfile : Form
    {
        bool f;
        private MainForm refForm;

        public AddProfile(bool flag, string name, MainForm refForm)
        {
            InitializeComponent();
            f = flag;

            if (f == true) // add
            {
                this.refForm = refForm;
            }
            else // update
            {
                Name = name;
                textBox1.Text = name;
                this.refForm = refForm;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (f == true) // add
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Заполните все поля!");
                }
                else
                {
                    var myBinding = new BasicHttpBinding();
                    var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Profile/");
                    var myChannelFactory = new ChannelFactory<Profile.SProfile>(myBinding, myEndpoint);

                    Profile.SProfile client = null;
                    string s = "";
                    try
                    {
                        client = myChannelFactory.CreateChannel();
                        client.set_Profile_Name(textBox1.Text);
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
                            refForm.loadProfile();
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
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Заполните все поля!");
                }
                else
                {
                    var myBinding = new BasicHttpBinding();
                    var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Profile/");
                    var myChannelFactory = new ChannelFactory<Profile.SProfile>(myBinding, myEndpoint);

                    Profile.SProfile client = null;
                    string s = "";
                    try
                    {
                        client = myChannelFactory.CreateChannel();
                        s = client.toString();
                        client.Update(Name, textBox1.Text);
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
                            refForm.loadProfile();
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

        private void AddProfile_Load(object sender, EventArgs e)
        {
            if (f == false) // update
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
            var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Profile/");
            var myChannelFactory = new ChannelFactory<Profile.SProfile>(myBinding, myEndpoint);

            Profile.SProfile client = null;
            try
            {
                client = myChannelFactory.CreateChannel();
                client.getByName(Name);
                textBox1.Text = Name;
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
