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
    public partial class Add_Reader : Form
    {
        bool update;
        List<string> val;

        public Add_Reader(List<string> s)
        {
            InitializeComponent();
            update = false;
            val = s;
            if (s.Count != 0) // обновление
            {
                ser_textBox.Text = s[1].Split(' ')[0];
                name_textBox.Text = s[1].Split(' ')[1];
                patron_textBox.Text = s[1].Split(' ')[2];
                address_textBox.Text = s[2];
                phone_textBox.Text = s[3];
                dateTimePicker.Value = Convert.ToDateTime(s[4]);
                update = true;
            }
        }

        private void ok_button_Click(object sender, EventArgs e)
        {
            if (ser_textBox.Text == "" || name_textBox.Text == "" || patron_textBox.Text == "" || address_textBox.Text == "" || phone_textBox.Text == "")
            {
                MessageBox.Show("Заполните все поля!");
            }
            else
            {
                var myBinding = new System.ServiceModel.BasicHttpBinding();
                var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/LibraryServer/Reader/");
                var myChannelFactory = new ChannelFactory<Reader.ServReader>(myBinding, myEndpoint);

                Reader.ServReader client = null;
                string s = "";
                try
                {
                    client = myChannelFactory.CreateChannel();
                    client.set_MyHuman(ser_textBox.Text + " " + name_textBox.Text + " " + patron_textBox.Text);
                    client.set_Address(address_textBox.Text);
                    client.set_Telephone(phone_textBox.Text);
                    client.set_MyStatus("Читатель");
                    client.set_Penalties("0");
                    client.set_Date_of_registration(dateTimePicker.Value.Year + "-" + dateTimePicker.Value.Month + "-" + dateTimePicker.Value.Day);
                    if (!update) // добавление
                    {
                        client.SaveReader();
                    }
                    else // обновление
                    {
                        client.UpdateReader(val[0].ToString());
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
    }
}
