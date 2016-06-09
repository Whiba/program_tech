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
    public partial class Add_Genre : Form
    {
        bool update;
        List<string> val;

        public Add_Genre(List<string> s)
        {
            InitializeComponent();
            update = false;
            val = s;
            if (s.Count != 0) // изменение
            {
                name_textBox.Text = s[1];
                discription_textBox.Text = s[2];
                update = true;
            }
        }

        private void ok_button_Click(object sender, EventArgs e)
        {
            if (name_textBox.Text == "" || discription_textBox.Text == "")
            {
                MessageBox.Show("Заполните поля правильно!");
            }
            else
            {
                var myBinding = new System.ServiceModel.BasicHttpBinding();
                var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/LibraryServer/Genre/");
                var myChannelFactory = new ChannelFactory<Genre.ServGenre>(myBinding, myEndpoint);

                Genre.ServGenre client = null;
                string s = "";
                try
                {
                    client = myChannelFactory.CreateChannel();
                    client.set_Name(name_textBox.Text);
                    client.set_Discription(discription_textBox.Text);
                    if (!update) // добавление
                    {
                        client.SaveGenre();
                    }
                    else // обновление
                    {
                        client.UpdateGenre(val[0].ToString());
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
