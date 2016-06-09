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
    public partial class AddPosition : Form
    {
        bool f;
        private MainForm refForm;
        string Salary = "";

        public AddPosition(bool flag, string name, string salary, MainForm refForm)
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
                Salary = salary;
                textBox1.Text = name;
                textBox2.Text = salary;
                this.refForm = refForm;
            }
        }

        private void UpdatePosition_Load(object sender, EventArgs e)
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

        private void Load_data()
        {
            var myBinding = new BasicHttpBinding();
            var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Position/");
            var myChannelFactory = new ChannelFactory<Position.SPosition>(myBinding, myEndpoint);

            Position.SPosition client = null;
            try
            {
                client = myChannelFactory.CreateChannel();
                client.getByName(Name);
                textBox1.Text = Name;
                textBox2.Text = Salary;
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
                    var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Position/");
                    var myChannelFactory = new ChannelFactory<Position.SPosition>(myBinding, myEndpoint);

                    Position.SPosition client = null;
                    string s = "";
                    try
                    {
                        client = myChannelFactory.CreateChannel();
                        client.set_P_Name(textBox1.Text);
                        client.set_P_Salary(textBox2.Text);
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
                            refForm.loadPosition();
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
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Заполните все поля!");
                }
                else
                {
                    var myBinding = new BasicHttpBinding();
                    var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Position/");
                    var myChannelFactory = new ChannelFactory<Position.SPosition>(myBinding, myEndpoint);

                    Position.SPosition client = null;
                    string s = "";
                    try
                    {
                        client = myChannelFactory.CreateChannel();
                        s = client.toString();
                        client.Update(textBox1.Text, textBox2.Text, Name);
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
                            refForm.loadPosition();
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
    }
}
