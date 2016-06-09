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
    public partial class AddEmp : Form
    {
        private MainForm refForm;
        string Position = "";
        string Factory = "";
        bool f;

        public AddEmp(bool flag, string name, string position, string factory, MainForm refForm)
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
                Position = position;
                Factory = factory;
                textBox1.Text = name;
                comboBox1.Text = position;
                comboBox2.Text = factory;
                this.refForm = refForm;
            }
        }

        private void loadPosition()
        {
            var myBinding = new BasicHttpBinding();
            var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Position/");
            var myChannelFactory = new ChannelFactory<Position.SPosition>(myBinding, myEndpoint);

            Position.SPosition client = null;
            string s = "";
            try
            {
                client = myChannelFactory.CreateChannel();
                s = client.get_s();
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

        private void loadFactory()
        {
            var myBinding = new BasicHttpBinding();
            var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Factory/");
            var myChannelFactory = new ChannelFactory<Factory.SFactory>(myBinding, myEndpoint);

            Factory.SFactory client = null;
            string s = "";
            try
            {
                client = myChannelFactory.CreateChannel();
                s = client.get_name();
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
                    comboBox2.Items.Add(array[0, l]);
        }

        private void Load_data()
        {
            var myBinding = new BasicHttpBinding();
            var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Employee/");
            var myChannelFactory = new ChannelFactory<Employee.SEmployee>(myBinding, myEndpoint);

            Employee.SEmployee client = null;
            try
            {
                client = myChannelFactory.CreateChannel();
                client.getByName(Name);
                textBox1.Text = Name;
                comboBox1.Text = Position;
                comboBox2.Text = Factory;
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

        private void AddEmp_Load(object sender, EventArgs e)
        {
            if (f == true)
            {
                try
                {
                    loadPosition();
                    loadFactory();
                }
                catch
                {
                    MessageBox.Show("Ошибка! Сервер не отчеает");
                    return;
                }
            }
            else
            {
                try
                {
                    loadPosition();
                    loadFactory();
                    Load_data();
                }
                catch
                {
                    MessageBox.Show("Ошибка! Север не отвечает");
                    return;
                }
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
                    var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Employee/");
                    var myChannelFactory = new ChannelFactory<Employee.SEmployee>(myBinding, myEndpoint);

                    Employee.SEmployee client = null;
                    string s = "";
                    try
                    {
                        client = myChannelFactory.CreateChannel();
                        client.set_Employee_Name(textBox1.Text);
                        client.set_Employee_Position(comboBox1.Text);
                        client.set_Employee_Factory(comboBox2.Text);
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
                            refForm.loadEmployee();
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
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Заполните все поля!");
                }
                else
                {
                    var myBinding = new BasicHttpBinding();
                    var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Employee/");
                    var myChannelFactory = new ChannelFactory<Employee.SEmployee>(myBinding, myEndpoint);

                    Employee.SEmployee client = null;
                    string s = "";
                    try
                    {
                        client = myChannelFactory.CreateChannel();
                        client.set_Employee_Name(textBox1.Text);
                        client.set_Employee_Position(comboBox1.Text);
                        client.set_Employee_Factory(comboBox2.Text);
                        s = client.toString();
                        client.Update(Name);
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
                            refForm.loadEmployee();
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
    }
}
