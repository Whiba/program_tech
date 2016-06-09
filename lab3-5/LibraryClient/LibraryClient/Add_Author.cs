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
    public partial class Add_Author : Form
    {
        bool update;
        List<string> val;

        public Add_Author(List<string> s)
        {
            InitializeComponent();
            update = false;
            val = s;
            if (s.Count != 0) // обновление
            {
                ser_textBox.Text = s[1].Split(' ')[0];
                name_textBox.Text = s[1].Split(' ')[1];
                patron_textBox.Text = s[1].Split(' ')[2];
                dateTimePicker.Value = Convert.ToDateTime(s[2]);
                info_textBox.Text = s[3];
                update = true;
            }
        }

        private void ok_button_Click(object sender, EventArgs e)
        {
            if (ser_textBox.Text == "" || name_textBox.Text == "" || patron_textBox.Text == "")
            {
                MessageBox.Show("Заполните ФИО!");
            }
            else
            {
                var myBinding = new System.ServiceModel.BasicHttpBinding();
                var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/LibraryServer/Author/");
                var myChannelFactory = new ChannelFactory<Author.ServAuthor>(myBinding, myEndpoint);

                Author.ServAuthor client = null;
                string s = "";
                try
                {
                    client = myChannelFactory.CreateChannel();
                    client.set_MyHuman(ser_textBox.Text + " " + name_textBox.Text + " " + patron_textBox.Text);
                    client.set_Date_of_birdth(dateTimePicker.Value.Year + "-" + dateTimePicker.Value.Month + "-" + dateTimePicker.Value.Day);
                    client.set_Information(info_textBox.Text);
                    if (!update) // добавление
                    {
                        client.SaveAuthor();
                    }
                    else // обновление
                    {
                        client.UpdateAuthor(val[0].ToString());
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
