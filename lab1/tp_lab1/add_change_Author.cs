using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tp_lab1
{
    public partial class add_change_Author : Form
    {
        public add_change_Author(List<string> list, bool flag)
        {
            InitializeComponent();
            if (flag == true)
            {
                ser_text.Text = list[0];
                name_text.Text = list[1];
                middle_text.Text = list[2];
                city_text.Text = list[3];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ser_text.Text.Trim() != "" && name_text.Text.Trim() != "" && middle_text.Text.Trim() != "" && city_text.Text.Trim() != "")
                    DialogResult = DialogResult.OK;
                else
                    throw new Exception();
            }
            catch (Exception f)
            { 
                MessageBox.Show("Заполните все поля!");
            }
        }

        public List<string> retStr()
        {
            List<string> s = new List<string>();
            s.Add(ser_text.Text);
            s.Add(name_text.Text);
            s.Add(middle_text.Text);
            s.Add(city_text.Text);
            return s;
        }

        public List<string> retStrU()
        {
            List<string> s = new List<string>();
            s.Add(ser_text.Text);
            s.Add(name_text.Text);
            s.Add(middle_text.Text);
            s.Add(city_text.Text);
            return s;
        }
    }
}
