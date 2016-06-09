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
    public partial class AddProduct : Form
    {
        bool f;
        private MainForm refForm;
        string Cost = "";

        public AddProduct(bool flag, string name, string cost, MainForm refForm)
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
                Cost = cost;
                textBox1.Text = name;
                textBox2.Text = cost;
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
                    var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Product/");
                    var myChannelFactory = new ChannelFactory<Product.SProduct>(myBinding, myEndpoint);

                    Product.SProduct client = null;
                    string s = "";
                    try
                    {
                        client = myChannelFactory.CreateChannel();
                        client.set_Product_Name(textBox1.Text);
                        client.set_Product_Cost(textBox2.Text);
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
                            refForm.loadProduct();
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
                    var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Product/");
                    var myChannelFactory = new ChannelFactory<Product.SProduct>(myBinding, myEndpoint);

                    Product.SProduct client = null;
                    string s = "";
                    try
                    {
                        client = myChannelFactory.CreateChannel();
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
                        MessageBox.Show("Ошибка! Север не отвечает");
                        return;
                    }
                    if (refForm != null)
                    {
                        try
                        {
                            refForm.loadProduct();
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

        private void AddProduct_Load(object sender, EventArgs e)
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
            var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Product/");
            var myChannelFactory = new ChannelFactory<Product.SProduct>(myBinding, myEndpoint);

            Product.SProduct client = null;
            try
            {
                client = myChannelFactory.CreateChannel();
                client.getByName(Name);
                textBox1.Text = Name;
                textBox2.Text = Cost;
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
