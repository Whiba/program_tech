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
    public partial class Add_Arrangement : Form
    {
        bool update;
        List<string> val;

        public Add_Arrangement(List<string> s)
        {
            InitializeComponent();
            update = false;
            val = s;
            if (s.Count != 0) // обновление
            {
                place_textBox.Text = s[1];
                update = true;
            }
        }

        private void ok_button_Click(object sender, EventArgs e)
        {
            // это все проверка введенных данных, и для добавления и для обновления
            if (place_textBox.Text == "")
            {
                MessageBox.Show("Заполните поле 'Место' правильно!");
            }
            else
            {
                var myBinding = new System.ServiceModel.BasicHttpBinding();
                var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/LibraryServer/Arrangement/");
                var myChannelFactory = new ChannelFactory<Arrangement.ServArrangement>(myBinding, myEndpoint);

                Arrangement.ServArrangement client = null;
                try
                {
                    client = myChannelFactory.CreateChannel();
                    client.set_Place(place_textBox.Text);
                    if (!update) // добавление
                    {
                        client.SaveArrangement();
                    }
                    else // обновление
                    {
                        client.UpdateArrangement(val[0].ToString());
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
