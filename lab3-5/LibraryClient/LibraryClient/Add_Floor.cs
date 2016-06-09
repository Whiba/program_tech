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
    public partial class Add_Floor : Form
    {
        bool update;
        List<string> val;

        public Add_Floor(List<string> s)
        {
            InitializeComponent();
            update = false;
            val = s;
            if (s.Count != 0) // обновление
            {
                name_textBox.Text = s[1];
                update = true;
            }
        }

        private void ok_button_Click(object sender, EventArgs e)
        {
            if (name_textBox.Text == "")
            {
                MessageBox.Show("Заполните поле 'Название' правильно");
            }
            else
            {
                var myBinding = new System.ServiceModel.BasicHttpBinding();
                var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/LibraryServer/Floor/");
                var myChannelFactory = new ChannelFactory<Floor.ServFloor>(myBinding, myEndpoint);

                Floor.ServFloor client = null;
                string s = "";
                try
                {
                    client = myChannelFactory.CreateChannel();
                    client.set_Name(name_textBox.Text);
                    if (!update) // добавление
                    {
                        client.SaveFloor();
                    }
                    else // обновление
                    {
                        client.UpdateFloor(val[0].ToString());
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
