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
    public partial class add_change_Book : Form
    {
        public add_change_Book(List<string> list, List<string> list2, bool flag, int num)
        {
            InitializeComponent();
            foreach (string s in list)
                author_combo.Items.Add(s);
            if (flag == false)
                author_combo.SelectedIndex = 0;
            if (flag == true)
            {
                author_combo.SelectedIndex = num;
                book_name_text.Text = list2[1];
                publ_text.Text = list2[2];
                year_text.Text = list2[3].Trim('.', ' ', ':').Split()[0].Split('.')[2];
                str_numb_text.Text = list2[4];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int what = 0;
            try
            {
                what = 0;
                int y = Convert.ToInt32(year_text.Text);
                int n = Convert.ToInt32(str_numb_text.Text);
                if (y < 1500 || y > 2017)
                    throw new Exception();
                if (n == 0)
                    throw new Exception();
                if (book_name_text.Text.Trim() != "" && publ_text.Text.Trim() != "" && year_text.Text.Trim() != "" && str_numb_text.Text.Trim() != "")
                    DialogResult = DialogResult.OK;
                if (book_name_text.Text.Trim() == "" || publ_text.Text.Trim() == "" || year_text.Text.Trim() == "" || str_numb_text.Text.Trim() == "")
                {
                    what = 1;
                    throw new Exception();
                }
            }
            catch (Exception f)
            {
                if (what == 0)
                    MessageBox.Show("Заполните поля корректно!");
                if (what == 1)
                    MessageBox.Show("Заполните все поля!");
            }
        }

        public List<string> retStrB(List<string> list2)
        {
            List<string> s = new List<string>();
            string year = year_text.Text + "-01-01";
            s.Add(list2[author_combo.SelectedIndex].ToString());
            s.Add(book_name_text.Text);
            s.Add(publ_text.Text);
            s.Add(year);
            s.Add(str_numb_text.Text);
            return s;
        }

        public List<string> retStrBU(List<string> list2)
        {
            List<string> s = new List<string>();
            string year = year_text.Text + "-01-01";
            s.Add(list2[author_combo.SelectedIndex].ToString());
            s.Add(book_name_text.Text);
            s.Add(publ_text.Text);
            s.Add(year);
            s.Add(str_numb_text.Text);
            return s;
        }
    }
}
