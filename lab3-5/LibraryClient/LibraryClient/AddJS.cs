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
    public partial class AddJS : Form
    {
        bool f;
        private MainForm refForm;
        string ID = "";
        string Product = "";
        string Shop = "";
        string Date = "";

        public AddJS(bool flag, string id, string product, string shop, string date, MainForm refForm)
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
                Shop = shop;
                Date = date;
                comboBox1.Text = product;
                comboBox2.Text = shop;
                dateTimePicker1.Value = Convert.ToDateTime(date);
                this.refForm = refForm;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (f == true) // add
            {
                var myBinding = new BasicHttpBinding();
                var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Sup_Journal/");
                var myChannelFactory = new ChannelFactory<Sup_Journal.SSup_Journal>(myBinding, myEndpoint);

                Sup_Journal.SSup_Journal client = null;
                string s = "";
                try
                {
                    client = myChannelFactory.CreateChannel();
                    client.set_Sup_Journal_Shop(comboBox2.Text);
                    client.set_Sup_Journal_Product(comboBox1.Text);
                    client.set_Sup_Journal_Date(dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.Month + "-" + dateTimePicker1.Value.Day);
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
                        refForm.loadSupJournal();
                        this.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка! Сервер не отвечает");
                        return;
                    }
                }
            }
            else // update
            {
                var myBinding = new BasicHttpBinding();
                var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Sup_Journal/");
                var myChannelFactory = new ChannelFactory<Sup_Journal.SSup_Journal>(myBinding, myEndpoint);

                Sup_Journal.SSup_Journal client = null;
                string s = "";
                try
                {
                    client = myChannelFactory.CreateChannel();
                    client.set_Sup_Journal_Product(comboBox2.Text);
                    client.set_Sup_Journal_Date(dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.Month + "-" + dateTimePicker1.Value.Day);
                    client.set_Sup_Journal_Shop(comboBox1.Text);
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
                        refForm.loadSupJournal();
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

        private void AddJS_Load(object sender, EventArgs e)
        {
            if (f == true) // add
            {
                try
                {
                    loadProduct();
                    loadShop();
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
                    loadShop();
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

        private void loadShop()
        {
            var myBinding = new BasicHttpBinding();
            var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Shop/");
            var myChannelFactory = new ChannelFactory<Shop.SShop>(myBinding, myEndpoint);

            Shop.SShop client = null;
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
            var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Sup_Journal/");
            var myChannelFactory = new ChannelFactory<Sup_Journal.SSup_Journal>(myBinding, myEndpoint);

            Sup_Journal.SSup_Journal client = null;
            try
            {
                client = myChannelFactory.CreateChannel();
                client.getByName(ID);
                comboBox1.Text = Shop;
                comboBox2.Text = Product;
                dateTimePicker1.Value = Convert.ToDateTime(Date);
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
