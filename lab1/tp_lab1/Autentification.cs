using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace tp_lab1
{
    public partial class Autentification : Form
    {
        NpgsqlConnection myConnection;
        string connect = "Server=localhost;User=admin;Password=admin;Database=Library";
        List<string> userList;
        List<string> passList;
        string rightPassword;

        public Autentification()
        {
            InitializeComponent();
            myConnection = new NpgsqlConnection(connect);
            userList = new List<string>();
            passList = new List<string>();
            userText.Items.Clear();
            rightPassword = "";

            userList.Add("Администратор");
            userList.Add("Пользователь");
            userList.Add("Гость");
            string passqu = "SELECT pass FROM \"myShema\".user_table";
            fillLists(passList, passqu);
            /*passList.Add("admin");
            passList.Add("user");
            passList.Add("guest");*/
            foreach (string s in userList)
                userText.Items.Add(s);
            userText.SelectedIndex = 0;         
        }

        // заполнить список из одного элемента
        public void fillLists(List<string> list, string command)
        {
            string CommandText = command;
            NpgsqlCommand myCom = new NpgsqlCommand(CommandText, myConnection);
            DataTable dt = UpdateGrid(myCom);
            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(row[0].ToString());
                }
            }
            catch (Exception f)
            { }
        }

        // обновить показываемую таблицу
        public DataTable UpdateGrid(NpgsqlCommand myCommand)
        {
            myConnection.Open();
            DataTable dt = null;
            try
            {
                NpgsqlDataReader dr = myCommand.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            myConnection.Close();
            return dt;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            bool itsOk = false;
            string connectString = "";
            if (userText.Text == "Администратор")
                connectString = "Server=localhost;User=admin;Password=" + passwordText.Text + ";Database=Library";/**/
            if (userText.Text == "Пользователь")
                connectString = "Server=localhost;User=my_user;Password=" + passwordText + ";Database=Library";
            if (userText.Text == "Гость")
                connectString = "Server=localhost;User=my_guest;Password=" + passwordText + ";Database=Library";
            myConnection = new NpgsqlConnection(connectString);

            try
            {              
                //myConnection.Open();
                //myConnection.Close();
                if (passwordText.Text != passList[userText.SelectedIndex])
                    throw new Exception();
                itsOk = true;
            }
            catch (Exception f)
            {
                //MessageBox.Show(f.Message);
                MessageBox.Show("Неверный логин/пароль! Введите снова!");
            }

            if (itsOk)
            {
                workForm form = new workForm(userText.Text, connectString);
                form.Show();
                this.Hide();
            } 
        }
    }
}
