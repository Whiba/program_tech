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
    public partial class AddJP : Form
    {
        bool f;
        private MainForm refForm;
        string ID = "";
        string Product = "";
        string Factory = "";
        string Number = "";

        public AddJP(bool flag, string id, string factory, string product, string number, MainForm refForm)
        {
            InitializeComponent();
            f = flag;

            if (flag == true) // add
            {
                this.refForm = refForm;
            }
            else // update
            {
                ID = id;
                Product = product;
                Factory = factory;
                Number = number;
                comboBox1.Text = factory;
                comboBox2.Text = product;
                textBox1.Text = number;
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
                    var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Production_Journal/");
                    var myChannelFactory = new ChannelFactory<Production_Journal.SProduction_Journal>(myBinding, myEndpoint);

                    Production_Journal.SProduction_Journal client = null;
                    string s = "";
                    try
                    {
                        client = myChannelFactory.CreateChannel();
                        client.set_Production_Journal_Factory(comboBox1.Text);
                        client.set_Production_Journal_Product(comboBox2.Text);
                        client.set_Production_Journal_Number(textBox1.Text);
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
                            refForm.loadProduction_Journal();
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
                    var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Production_Journal/");
                    var myChannelFactory = new ChannelFactory<Production_Journal.SProduction_Journal>(myBinding, myEndpoint);

                    Production_Journal.SProduction_Journal client = null;
                    string s = "";
                    try
                    {
                        client = myChannelFactory.CreateChannel();
                        client.set_Production_Journal_Product(comboBox2.Text);
                        client.set_Production_Journal_Number(textBox1.Text);
                        client.set_Production_Journal_Factory(comboBox1.Text);
                        s = client.toString();
                        client.Update(ID);
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
                            refForm.loadProduction_Journal();
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

        private void AddJP_Load(object sender, EventArgs e)
        {
            if (f == true) // add
            {
                try
                {
                    loadProduct();
                    loadFactory();
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
                    loadProduct();
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

        private void loadProduct()
        {
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

            string[,] array = JsonConvert.DeserializeObject<string[,]>(s);

            for (int l = 1; l < array.GetLength(1); l++)
                if (array[0, l] != null)
                    comboBox2.Items.Add(array[0, l]);

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
                    comboBox1.Items.Add(array[0, l]);
        }

        private void Load_data()
        {
            var myBinding = new BasicHttpBinding();
            var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Production_Journal/");
            var myChannelFactory = new ChannelFactory<Production_Journal.SProduction_Journal>(myBinding, myEndpoint);

            Production_Journal.SProduction_Journal client = null;
            try
            {
                client = myChannelFactory.CreateChannel();
                client.getByName(ID);
                comboBox1.Text = Factory;
                comboBox2.Text = Product;
                textBox1.Text = Number;
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
