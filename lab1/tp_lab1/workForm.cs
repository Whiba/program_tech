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
    public partial class workForm : Form
    {
        NpgsqlConnection myConnection;
        string connect;
        string myUser;
        List<string> viewList;
        List<string> tableList;
        Random rnd;
        int totalPage;
        int currentPage;

        public workForm(string user, string con)
        {
            InitializeComponent();
            myUser = user;
            connect = con;
            myConnection = new NpgsqlConnection(connect);
            viewList = new List<string>();
            tableList = new List<string>();
            rnd = new Random();
            totalPage = 0;
            currentPage = 0;
            if (myUser == "Администратор")
            {
                addButton.Enabled = true;
                deleteButton.Enabled = true;
                changeButton.Enabled = true;
            }
            if (myUser == "Пользователь")
            {
                addButton.Enabled = true;
                deleteButton.Enabled = false;
                changeButton.Enabled = true;
            }
            if (myUser == "Гость")
            {
                addButton.Enabled = false;
                deleteButton.Enabled = false;
                changeButton.Enabled = false;
            }
            userLabel.Text = myUser;
            viewList.Add("\"author_view\"");
            viewList.Add("\"book_view\"");
            tableList.Add("\"Author\"");
            tableList.Add("\"Book\"");
            catalogComboBox.SelectedIndex = 0;
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

        // удаление выделенных записей
        public void deleteTheRecord(string tableName, DataGridView nameGrid)
        {
            List<string> myList = new List<string>();
            int allSelectedItem = nameGrid.SelectedRows.Count;
            int currentItem = 0;
            try
            {
                if (allSelectedItem == 0)
                    throw new Exception();
                while (currentItem < allSelectedItem)
                {
                    myList.Add((string)nameGrid.SelectedRows[currentItem].Cells[0].Value.ToString());
                    currentItem++;
                }
            }
            catch (Exception ex)
            {
                if (allSelectedItem == 0)
                    MessageBox.Show("Выделите целую строку!");
                //MessageBox.Show(ex.Message);
                return;
            }

            string sequensy = "";
            foreach (string s in myList)
            {
                sequensy += " ";
                sequensy += "'" + s + "',";
            }
            string delQuerry = "";
            delQuerry = "UPDATE \"myShema\"." + tableName + " SET \"isDel\"='true' WHERE id IN (" + sequensy.TrimEnd(',', ' ') + ")";               
            NpgsqlCommand com = new NpgsqlCommand(delQuerry, myConnection);
            myConnection.Open();
            com.ExecuteNonQuery();
            myConnection.Close();
        }

        // посыл запроса на обновление таблицы
        public void updateQuery()
        {
            string comText = "SELECT * FROM \"myShema\"." + viewList[catalogComboBox.SelectedIndex] + " ORDER BY id LIMIT 10 OFFSET " + currentPage * 10;
            NpgsqlCommand command = new NpgsqlCommand(comText, myConnection);
            tableData.DataSource = UpdateGrid(command);
            tableData.Columns[0].Visible = false;
            page_label.Text = (currentPage + 1).ToString() + "/" + totalPage.ToString();
        }

        // кнопка удаления записей
        private void deleteButton_Click(object sender, EventArgs e)
        {
            deleteTheRecord(tableList[catalogComboBox.SelectedIndex], tableData);
            updateQuery();
        }

        // смена пользователя
        private void changeUserButton_Click(object sender, EventArgs e)
        {
            Autentification userForm = new Autentification();
            userForm.Show();
            this.Close();
        }

        // добавление записи
        private void addButton_Click(object sender, EventArgs e)
        {
            List<string> L = new List<string>();
            int sw = catalogComboBox.SelectedIndex + 1;
            switch(sw)
            {
                case 1: // Автор
                    {
                        add_change_Author dialA = new add_change_Author(L, false);                       
                        dialA.ShowDialog();
                        if (dialA.DialogResult == DialogResult.OK)
                        {
                            List<string> sA = dialA.retStr();
                            doINSERT(sA);
                        }
                        updateQuery();                  
                        break;
                    }
                case 2: // Книги
                    {
                        List<string> authors = new List<string>();
                        List<string> authorsID = new List<string>();
                        getAllAuthors(authors);
                        getAuthorsID(authorsID);
                        add_change_Book dialB = new add_change_Book(authors, L, false, 0);
                        dialB.ShowDialog();
                        if (dialB.DialogResult == DialogResult.OK)
                        {
                            List<string> sB = dialB.retStrB(authorsID);
                            doINSERT(sB);
                        }
                        updateQuery();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        // изменение записи
        private void changeButton_Click(object sender, EventArgs e)
        {
            int count = tableData.SelectedRows.Count;
            if (count == 1)
            {
                int sw = catalogComboBox.SelectedIndex + 1;
                string  id = tableData.SelectedRows[0].Cells[0].Value.ToString();
                // flag == true -> UPDATE
                switch (sw)
                {
                    case 1: // Автор
                        {
                            string quStr = "SELECT sername, name, middlename, city FROM \"myShema\"." + tableList[catalogComboBox.SelectedIndex] + " WHERE id=" + id;
                            List<string> L1 = new List<string>();
                            fillListsMany(L1, quStr);
                            add_change_Author dialA = new add_change_Author(L1, true);
                            dialA.ShowDialog();
                            if (dialA.DialogResult == DialogResult.OK)
                            {
                                List<string> sA = dialA.retStrU();
                                doUPDATE(sA, id);
                            }
                            updateQuery();
                            break;
                        }
                    case 2: // Книги
                        {
                            string quStr = "SELECT id_author, name, publishing, year, numb_paper FROM \"myShema\"." + tableList[catalogComboBox.SelectedIndex] + " WHERE id=" + id;
                            List<string> L1 = new List<string>();
                            int index = 0;
                            int n = 0;
                            fillListsMany(L1, quStr);
                            string au_str = L1[0];
                            List<string> authors = new List<string>();
                            List<string> authorsID = new List<string>();
                            getAllAuthors(authors);
                            getAuthorsID(authorsID);
                            foreach (string s in authorsID)
                            {
                                if (s == au_str)
                                {
                                    index = n;
                                    break;
                                }
                                else
                                    n++;
                            }
                            add_change_Book dialB = new add_change_Book(authors, L1, true, index);
                            dialB.ShowDialog();
                            if (dialB.DialogResult == DialogResult.OK)
                            {
                                List<string> sB = dialB.retStrBU(authorsID);
                                doUPDATE(sB, id);
                            }
                            updateQuery();
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            else
            {
                if (count == 0)
                    MessageBox.Show("Выберите запись, которую хотите отредактировать!");
                if (count > 1)
                    MessageBox.Show("Пожалуйста, выберите одну запись!");
            }              
        }

        // сделать запрос INSERT, как параметр передаем вставляемые значения
        public void doINSERT(List<string> part)
        {
            string tableName = tableList[catalogComboBox.SelectedIndex];
            string insQuerry = "";

            if (catalogComboBox.SelectedIndex == 0)
                insQuerry = "INSERT INTO \"myShema\"." + tableName + whatFill() + " VALUES (@authSer, @authName, @authMiddle, @authCity, 'FALSE')";
            if (catalogComboBox.SelectedIndex == 1)
                insQuerry = "INSERT INTO \"myShema\"." + tableName + whatFill() + " VALUES (@bookIDauth, @bookName, @bookPubl, @bookYear, @bookPaper, 'FALSE')";
            NpgsqlCommand con = new NpgsqlCommand(insQuerry, myConnection);

            if (catalogComboBox.SelectedIndex == 0)
            {
                con.Parameters.Add("@authSer", part[0]);
                con.Parameters.Add("@authName", part[1]);
                con.Parameters.Add("@authMiddle", part[2]);
                con.Parameters.Add("@authCity", part[3]);
            }
            if (catalogComboBox.SelectedIndex == 1)
            {
                con.Parameters.Add("@bookIDauth", part[0]);
                con.Parameters.Add("@bookName", part[1]);
                con.Parameters.Add("@bookPubl", part[2]);
                con.Parameters.Add("@bookYear", part[3]);
                con.Parameters.Add("@bookPaper", part[4]);
            }

            myConnection.Open();
            try
            {
                con.ExecuteNonQuery();
            }
            catch (Exception f)
            {
                MessageBox.Show("Введите корректные данные!");
            }
            myConnection.Close();
        }

        // сделать запрос UPDATE, как параметр передаем вставляемые значения
        public void doUPDATE(List<string> part, string id)
        {
            string tableName = tableList[catalogComboBox.SelectedIndex];
            string updQuerry = "";

            if (catalogComboBox.SelectedIndex == 0)
                updQuerry = "UPDATE \"myShema\"." + tableName + " SET sername=@authSer, name=@authName, middlename=@authMiddle, city=@authCity WHERE id = @authID";
            if (catalogComboBox.SelectedIndex == 1)
                updQuerry = "UPDATE \"myShema\"." + tableName + " SET id_author=@bookIDauth, name=@bookName, publishing=@bookPubl, year=@bookYear, numb_paper=@bookPaper WHERE id = @bookID";
            NpgsqlCommand con = new NpgsqlCommand(updQuerry, myConnection);

            if (catalogComboBox.SelectedIndex == 0)
            {
                con.Parameters.Add("@authSer", part[0]);
                con.Parameters.Add("@authName", part[1]);
                con.Parameters.Add("@authMiddle", part[2]);
                con.Parameters.Add("@authCity", part[3]);
                con.Parameters.Add("@authID", id);
            }
            if (catalogComboBox.SelectedIndex == 1)
            {
                con.Parameters.Add("@bookIDauth", part[0]);
                con.Parameters.Add("@bookName", part[1]);
                con.Parameters.Add("@bookPubl", part[2]);
                con.Parameters.Add("@bookYear", part[3]);
                con.Parameters.Add("@bookPaper", part[4]);
                con.Parameters.Add("@bookID", id);
            }

            myConnection.Open();
            try
            {
                con.ExecuteNonQuery();
            }
            catch (Exception f)
            {
                MessageBox.Show("Введите корректные данные!");
            }
            myConnection.Close();
        }

        // какие поля в запросе INSERT
        public string whatFill()
        {
            string s = "";
            string s1 = "";
            string s2 = "";
            string s3 = "";
            string s4 = "";
            int sw = catalogComboBox.SelectedIndex + 1;
            switch (sw)
            {
                case 1: // Автор
                    {
                        s1 = "(sername, name, middlename, city, \"isDel\")";
                        s = s1;
                        break;
                    }
                case 2: // Книги
                    {
                        s2 = "(id_author, name, publishing, year, numb_paper, \"isDel\")";
                        s = s2;
                        break;
                    }
                default:
                    {                      
                        break;
                    }
            }
            return s;           
        }

        // заполнить списко авторов
        public void fillAuthorLists(List<string> list, string command)
        {
            string CommandText = command;
            NpgsqlCommand myCom = new NpgsqlCommand(CommandText, myConnection);
            DataTable dt = UpdateGrid(myCom);
            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(row[0].ToString() + " " + row[1].ToString()[0] + "." + row[2].ToString()[0] + ".");
                }
            }
            catch (Exception f)
            { }
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

        // заполнить список из одной строки
        public void fillListsMany(List<string> list, string command)
        {
            string CommandText = command;
            NpgsqlCommand myCom = new NpgsqlCommand(CommandText, myConnection);
            DataTable dt = UpdateGrid(myCom);
            int i = 0;
            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    foreach (object item in row.ItemArray)
                    {
                        list.Add(item.ToString());
                    }
                }
            }
            catch (Exception f)
            { }
        }

        public void getAllAuthors(List<string> myList)
        {            
            string com1 = "SELECT sername, name, middlename, city FROM \"myShema\".\"Author\" WHERE \"isDel\" = 'FALSE'";
            fillAuthorLists(myList, com1);
        }

        public void getAuthorsID(List<string> myList)
        {
            string com1 = "SELECT id FROM \"myShema\".\"Author\" WHERE \"isDel\" = 'FALSE'";
            fillLists(myList, com1);
        }

        public void getAllBooks(List<string> myList)
        {
            string com1 = "SELECT name FROM \"myShema\".\"Book\" WHERE \"isDel\" = 'FALSE'";
            fillLists(myList, com1);
        }

        public void getBooksID(List<string> myList)
        {
            string com1 = "SELECT id FROM \"myShema\".\"Book\" WHERE \"isDel\" = 'FALSE'";
            fillLists(myList, com1);
        }

        private void catalogComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPage = 0;
            updateQuery();
            totalPage = getTotalPages();
            page_label.Text = (currentPage+1).ToString() + "/" + totalPage.ToString();
        }

        public int getTotalPages()
        {
            int res = 0;
            string qu = "SELECT count(id) FROM \"myShema\"." + viewList[catalogComboBox.SelectedIndex];
            int num = 0;
            string value = "";
            NpgsqlCommand com = new NpgsqlCommand(qu, myConnection);
            DataTable dt = UpdateGrid(com);
            foreach (DataRow row in dt.Rows)
                value = row[0].ToString();
            num = Convert.ToInt32(value);
            res = Convert.ToInt32(Math.Ceiling(num * 0.1));
            return res;
        }

        private void grantleft_button_Click(object sender, EventArgs e)
        {
            currentPage = 0;
            updateQuery();
        }

        private void oneleft_button_Click(object sender, EventArgs e)
        {
            int page = currentPage;
            if (currentPage != 0)
                currentPage--;
            else
                currentPage = 0;
            updateQuery();
        }

        private void right_button_Click(object sender, EventArgs e)
        {
            int page = currentPage + 1;
            if (page < totalPage)
                currentPage++;
            else
                currentPage = totalPage - 1;
            updateQuery();
        }

        private void grantright_button_Click(object sender, EventArgs e)
        {
            currentPage = totalPage-1;
            updateQuery();
        }
    }
}
