using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Newtonsoft.Json;
using Npgsql;

namespace LibraryServer
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Book : ServBook
    {
        string myAuthor;
        string myGenre;
        string name;
        string year;
        string publishing;
        string paper_number;
        string book_number;

        public string getAllBooks(string num)
        {
            string[,] mas = new string[100,8];
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "SELECT * FROM \"myShema\".book_view  ORDER BY id LIMIT 10 OFFSET @lim";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@lim", Convert.ToInt32(num) * 100);
            DataTable dt = UpdateGrid(myConnection, com);

            int i = 0;
            int j = 0;
            foreach(DataColumn col in dt.Columns)
            {
                if (i != 2 && i != 3)
                {
                    mas[0, j] = col.ToString();
                    j++;
                }
                i++;
            }
            if (dt.Rows.Count > 0)
            {
                j = 0;
                int ur = 1;
                string val = "";
                foreach (DataRow row in dt.Rows)
                {
                    for (i = 0, j = 0; i < 10; i++)
                    {
                        if (i != 1 && i != 3 && i != 2)
                        {
                            val = row[i].ToString();
                            mas[ur, j] = val;
                            j++;
                        }
                        if (i == 1)
                        {
                            val = row[1].ToString() + " " + row[2].ToString() + " " + row[3].ToString();
                            mas[ur, j] = val;
                            j++;
                        }
                    }
                    ur++;
                }
            }
            return JsonConvert.SerializeObject(mas);
        }

        public string getBookByName(string n)
        {
            string[,] mas = new string[100, 8];
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "SELECT * FROM \"myShema\".book_view WHERE \"Название книги\"=@n";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@n", n);
            DataTable dt = UpdateGrid(myConnection, com);

            int i = 0;
            int j = 0;
            foreach (DataColumn col in dt.Columns)
            {
                if (i != 2 && i != 3)
                {
                    mas[0, j] = col.ToString();
                    j++;
                }
                i++;
            }
            if (dt.Rows.Count > 0)
            {
                j = 0;
                int ur = 1;
                string val = "";
                foreach (DataRow row in dt.Rows)
                {
                    for (i = 0, j = 0; i < 10; i++)
                    {
                        if (i != 1 && i != 3 && i != 2)
                        {
                            val = row[i].ToString();
                            mas[ur, j] = val;
                            j++;
                        }
                        if (i == 1)
                        {
                            val = row[1].ToString() + " " + row[2].ToString() + " " + row[3].ToString();
                            mas[ur, j] = val;
                            j++;
                        }
                    }
                    ur++;
                }
            }
            return JsonConvert.SerializeObject(mas);
        }

        public int getIdBookByName(string n)
        {
            int index = 0;
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "SELECT id FROM \"myShema\".book_view WHERE \"Название книги\"=@n";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@n", n);
            DataTable dt = UpdateGrid(myConnection, com);

            foreach(DataRow row in dt.Rows)
            {
                index = Convert.ToInt32(row[0].ToString());
            }

            return index;
        }

        public string getBookList()
        {
            string[,] mas = new string[100, 2];
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "SELECT id, name FROM \"myShema\".\"Book\" ORDER BY id";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            DataTable dt = UpdateGrid(myConnection, com);

            int i = 0;
            int j = 0;
            foreach (DataColumn col in dt.Columns)
            {
                mas[0, j] = col.ToString();
                j++;
            }
            if (dt.Rows.Count > 0)
            {
                j = 0;
                int ur = 1;
                string val = "";
                foreach (DataRow row in dt.Rows)
                {
                    for (i = 0, j = 0; i < 2; i++)
                    {
                        val = row[i].ToString();
                        mas[ur, j] = val;
                        j++;
                    }
                    ur++;
                }
            }
            return JsonConvert.SerializeObject(mas);
        }

        public void SaveBook()
        {
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "INSERT INTO \"myShema\".\"Book\"(id_author, id_genre, name, year, publishing, paper_number, book_number)VALUES (@idAuthor, @idGenre, @name, @year, @publ, @paperN, @bookN)";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@idAuthor", getIdAuthorByName(myAuthor));
            com.Parameters.AddWithValue("@idGenre", getIdGenreByName(myGenre));
            com.Parameters.AddWithValue("@name", name);
            com.Parameters.AddWithValue("@year", year);
            com.Parameters.AddWithValue("@publ", publishing);
            com.Parameters.AddWithValue("@paperN", paper_number);
            com.Parameters.AddWithValue("@bookN", book_number);

            try
            {
                myConnection.Open();
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
        }

        public void DeleteBook(string index)
        {
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "DELETE FROM \"myShema\".\"Book\" WHERE id = @id";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@id", index);

            try
            {
                myConnection.Open();
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
        }

        public void UpdateBook(string index)
        {
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
             string query = "UPDATE \"myShema\".\"Book\" SET id_author=@idAuthor, id_genre=@idGenre, name=@name, year=@year, publishing=@publ, paper_number=@paperN, book_number=@bookN WHERE id = @id";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@idAuthor", getIdAuthorByName(myAuthor));
            com.Parameters.AddWithValue("@idGenre", getIdGenreByName(myGenre));
            com.Parameters.AddWithValue("@name", name);
            com.Parameters.AddWithValue("@year", year);
            com.Parameters.AddWithValue("@publ", publishing);
            com.Parameters.AddWithValue("@paperN", paper_number);
            com.Parameters.AddWithValue("@bookN", book_number);
            com.Parameters.AddWithValue("@id", index);

            try
            {
                myConnection.Open();
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
        }

        public string BookToString()
        {
            return myAuthor + " " + myGenre + " " + name + " " + year + " " + publishing + " " + paper_number + " " + book_number;
        }

        public string MyAuthor
        {
            get
            {
                return myAuthor;
            }

            set
            {
                myAuthor = value;
            }
        }

        public string MyGenre
        {
            get
            {
                return myGenre;
            }

            set
            {
                myGenre = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Year
        {
            get
            {
                return year;
            }

            set
            {
                year = value;
            }
        }

        public string Publishing
        {
            get
            {
                return publishing;
            }

            set
            {
                publishing = value;
            }
        }

        public string Paper_number
        {
            get
            {
                return paper_number;
            }

            set
            {
                paper_number = value;
            }
        }

        public string Book_number
        {
            get
            {
                return book_number;
            }

            set
            {
                book_number = value;
            }
        }

        private DataTable UpdateGrid(NpgsqlConnection myConnection, NpgsqlCommand myCommand)
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
                //throw new Exception(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
            return dt;
        }

        private int getIdAuthorByName(string n)
        {
            int index = 0;
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "SELECT id FROM \"myShema\".author_view WHERE \"Фамилия\"=@s AND \"Имя\"=@n AND \"Отчество\"=@p";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@s", n.Split(' ')[0]);
            com.Parameters.AddWithValue("@n", n.Split(' ')[1]);
            com.Parameters.AddWithValue("@p", n.Split(' ')[2]);
            DataTable dt = UpdateGrid(myConnection, com);

            foreach (DataRow row in dt.Rows)
            {
                index = Convert.ToInt32(row[0].ToString());
            }

            return index;
        }

        private int getIdGenreByName(string n)
        {
            int index = 0;
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "SELECT id FROM \"myShema\".genre_view WHERE \"Название\"=@n";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@n", n);
            DataTable dt = UpdateGrid(myConnection, com);

            foreach (DataRow row in dt.Rows)
            {
                index = Convert.ToInt32(row[0].ToString());
            }

            return index;
        }
    }
    
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Arrangement : ServArrangement
    {
        string place;

        public string getAllArrangements(string num)
        {
            string[,] mas = new string[100, 2];
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary1");
            string query = "SELECT * FROM \"myShema\".arrangement_view  ORDER BY id LIMIT 10 OFFSET @lim";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@lim", Convert.ToInt32(num) * 100);
            DataTable dt = UpdateGrid(myConnection, com);

            int i = 0;
            int j = 0;
            foreach (DataColumn col in dt.Columns)
            {
                mas[0, j] = col.ToString();
                j++;
            }
            if (dt.Rows.Count > 0)
            {
                j = 0;
                int ur = 1;
                string val = "";
                foreach (DataRow row in dt.Rows)
                {
                    for (i = 0, j = 0; i < 2; i++)
                    {
                        val = row[i].ToString();
                        mas[ur, j] = val;
                        j++;
                    }
                    ur++;
                }
            }
            return JsonConvert.SerializeObject(mas);
        }

        public string getAll()
        {
            string[,] mas = new string[150000, 2];
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary1");
            string query = "SELECT * FROM \"myShema\".arrangement_view  ORDER BY id";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            DataTable dt = UpdateGrid(myConnection, com);

            int i = 0;
            int j = 0;
            foreach (DataColumn col in dt.Columns)
            {
                mas[0, j] = col.ToString();
                j++;
            }
            if (dt.Rows.Count > 0)
            {
                j = 0;
                int ur = 1;
                string val = "";
                foreach (DataRow row in dt.Rows)
                {
                    for (i = 0, j = 0; i < 2; i++)
                    {
                        val = row[i].ToString();
                        mas[ur, j] = val;
                        j++;
                    }
                    ur++;
                }
            }
            return JsonConvert.SerializeObject(mas);
        }

        public void SaveArrangement()
        {
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "INSERT INTO \"myShema\".\"Arrangement\" (place) VALUES (@place)";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@place", place);

            try
            {
                myConnection.Open();
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
        }

        public void DeleteArrangement(string index)
        {
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "DELETE FROM \"myShema\".\"Arrangement\" WHERE id = @id";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@id", index);

            try
            {
                myConnection.Open();
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
        }

        public void UpdateArrangement(string index)
        {
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "UPDATE \"myShema\".\"Arrangement\" SET place=@place WHERE id = @id";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@place", place);
            com.Parameters.AddWithValue("@id", index);

            try
            {
                myConnection.Open();
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
        }

        public string ArrangementToString()
        {
            return place;
        }

        public string Place
        {
            get
            {
                return place;
            }

            set
            {
                place = value;
            }
        }

        private DataTable UpdateGrid(NpgsqlConnection myConnection, NpgsqlCommand myCommand)
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
                //throw new Exception(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
            return dt;
        }
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Author : ServAuthor
    {
        string myHuman;
        string date_of_birdth;
        string information;

        public string getAllAuthors(string num)
        {
            string[,] mas = new string[100, 4];
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "SELECT * FROM \"myShema\".author_view  ORDER BY id LIMIT 10 OFFSET @lim";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@lim", Convert.ToInt32(num) * 100);
            DataTable dt = UpdateGrid(myConnection, com);

            int i = 0;
            int j = 0;
            foreach (DataColumn col in dt.Columns)
            {
                if (i != 2 && i != 3)
                {
                    mas[0, j] = col.ToString();
                    j++;
                }
                i++;
            }
            if (dt.Rows.Count > 0)
            {
                j = 0;
                int ur = 1;
                string val = "";
                foreach (DataRow row in dt.Rows)
                {
                    for (i = 0, j = 0; i < 6; i++)
                    {
                        if (i != 1 && i != 3 && i != 2)
                        {
                            val = row[i].ToString();
                            mas[ur, j] = val;
                            j++;
                        }
                        if (i == 1)
                        {
                            val = row[1].ToString() + " " + row[2].ToString() + " " + row[3].ToString();
                            mas[ur, j] = val;
                            j++;
                        }
                    }
                    ur++;
                }
            }
            return JsonConvert.SerializeObject(mas);
        }

        public string getAuthorBySername(string n)
        {
            string[,] mas = new string[100, 6];
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "SELECT * FROM \"myShema\".author_view WHERE \"Фамилия\"=@n";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@n", n);
            DataTable dt = UpdateGrid(myConnection, com);

            int i = 0;
            int j = 0;
            foreach (DataColumn col in dt.Columns)
            {
                if (i != 2 && i != 3)
                {
                    mas[0, j] = col.ToString();
                    j++;
                }
                i++;
            }
            if (dt.Rows.Count > 0)
            {
                j = 0;
                int ur = 1;
                string val = "";
                foreach (DataRow row in dt.Rows)
                {
                    for (i = 0, j = 0; i < 7; i++)
                    {
                        if (i != 1 && i != 3 && i != 2)
                        {
                            val = row[i].ToString();
                            mas[ur, j] = val;
                            j++;
                        }
                        if (i == 1)
                        {
                            val = row[1].ToString() + " " + row[2].ToString() + " " + row[3].ToString();
                            mas[ur, j] = val;
                            j++;
                        }
                    }
                    ur++;
                }
            }
            return JsonConvert.SerializeObject(mas);
        }

        public int getIdAuthorByName(string n)
        {
            int index = 0;
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "SELECT id FROM \"myShema\".author_view WHERE \"Фамилия\"=@s AND \"Имя\"=@n AND \"Отчество\"=@p";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@s", n.Split(' ')[0]);
            com.Parameters.AddWithValue("@n", n.Split(' ')[1]);
            com.Parameters.AddWithValue("@p", n.Split(' ')[2]);
            DataTable dt = UpdateGrid(myConnection, com);

            foreach (DataRow row in dt.Rows)
            {
                index = Convert.ToInt32(row[0].ToString());
            }

            return index;
        }

        public void SaveAuthor()
        {
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "INSERT INTO \"myShema\".\"Author\"(sername, name, patronymic, date_of_birdth, information)VALUES (@ser, @name, @patron, @date, @info)";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@ser", myHuman.Split(' ')[0]);
            com.Parameters.AddWithValue("@name", myHuman.Split(' ')[1]);
            com.Parameters.AddWithValue("@patron", myHuman.Split(' ')[2]);
            com.Parameters.AddWithValue("@date", date_of_birdth);
            com.Parameters.AddWithValue("@info", information);
            
            try
            {
                myConnection.Open();
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
        }

        public void DeleteAuthor(string index)
        {
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "DELETE FROM \"myShema\".\"Author\" WHERE id = @id";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@id", index);

            try
            {
                myConnection.Open();
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
        }

        public void UpdateAuthor(string index)
        {
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "UPDATE \"myShema\".\"Author\" SET sername=@ser, name=@name, patronymic=@patron, date_of_birdth=@date, information=@info WHERE id = @id";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@ser", myHuman.Split(' ')[0]);
            com.Parameters.AddWithValue("@name", myHuman.Split(' ')[1]);
            com.Parameters.AddWithValue("@patron", myHuman.Split(' ')[2]);
            com.Parameters.AddWithValue("@date", date_of_birdth);
            com.Parameters.AddWithValue("@info", information);
            com.Parameters.AddWithValue("@id", index);

            try
            {
                myConnection.Open();
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
        }

        public string AuthorToString()
        {
            return myHuman + " " + date_of_birdth + " " + information;
        }

        public string MyHuman
        {
            get
            {
                return myHuman;
            }

            set
            {
                myHuman = value;
            }
        }

        public string Date_of_birdth
        {
            get
            {
                return date_of_birdth;
            }

            set
            {
                date_of_birdth = value;
            }
        }

        public string Information
        {
            get
            {
                return information;
            }

            set
            {
                information = value;
            }
        }

        private DataTable UpdateGrid(NpgsqlConnection myConnection, NpgsqlCommand myCommand)
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
                //throw new Exception(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
            return dt;
        }
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Floor : ServFloor
    {
        string name;

        public string getAllFloors(string num)
        {
            string[,] mas = new string[100, 2];
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "SELECT * FROM \"myShema\".floor_view  ORDER BY id LIMIT 10 OFFSET @lim";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@lim", Convert.ToInt32(num) * 100);
            DataTable dt = UpdateGrid(myConnection, com);

            int i = 0;
            int j = 0;
            foreach (DataColumn col in dt.Columns)
            {
                mas[0, j] = col.ToString();
                j++;
            }
            if (dt.Rows.Count > 0)
            {
                j = 0;
                int ur = 1;
                string val = "";
                foreach (DataRow row in dt.Rows)
                {
                    for (i = 0, j = 0; i < 2; i++)
                    {
                        val = row[i].ToString();
                        mas[ur, j] = val;
                        j++;
                    }
                    ur++;
                }
            }
            return JsonConvert.SerializeObject(mas);
        }

        public void SaveFloor()
        {
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "INSERT INTO \"myShema\".\"Floor\" (name) VALUES (@name)";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@name", name);

            try
            {
                myConnection.Open();
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
        }

        public void DeleteFloor(string index)
        {
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "DELETE FROM \"myShema\".\"Floor\" WHERE id = @id";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@id", index);

            try
            {
                myConnection.Open();
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
        }

        public void UpdateFloor(string index)
        {
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "UPDATE \"myShema\".\"Floor\" SET name=@name WHERE id = @id";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@name", name);
            com.Parameters.AddWithValue("@id", index);

            try
            {
                myConnection.Open();
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
        }

        public string FloorToString()
        {
            return name;
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        private DataTable UpdateGrid(NpgsqlConnection myConnection, NpgsqlCommand myCommand)
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
                //throw new Exception(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
            return dt;
        }
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Genre : ServGenre
    {
        string name;
        string discription;

        public string getAllGenres(string num)
        {
            string[,] mas = new string[100, 3];
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "SELECT * FROM \"myShema\".genre_view  ORDER BY id LIMIT 10 OFFSET @lim";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@lim", Convert.ToInt32(num) * 100);
            DataTable dt = UpdateGrid(myConnection, com);

            int i = 0;
            int j = 0;
            foreach (DataColumn col in dt.Columns)
            {
                mas[0, j] = col.ToString();
                j++;
            }
            if (dt.Rows.Count > 0)
            {
                j = 0;
                int ur = 1;
                string val = "";
                foreach (DataRow row in dt.Rows)
                {
                    for (i = 0, j = 0; i < 3; i++)
                    {
                        val = row[i].ToString();
                        mas[ur, j] = val;
                        j++;
                    }
                    ur++;
                }
            }
            return JsonConvert.SerializeObject(mas);
        }

        public string getGenreByName(string n)
        {
            string[,] mas = new string[100, 8];
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "SELECT * FROM \"myShema\".genre_view WHERE \"Название\"=@n";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@n", n);
            DataTable dt = UpdateGrid(myConnection, com);

            int i = 0;
            int j = 0;
            foreach (DataColumn col in dt.Columns)
            {
                if (i != 2 && i != 3)
                {
                    mas[0, j] = col.ToString();
                    j++;
                }
                i++;
            }
            if (dt.Rows.Count > 0)
            {
                j = 0;
                int ur = 1;
                string val = "";
                foreach (DataRow row in dt.Rows)
                {
                    for (i = 0, j = 0; i < 4; i++)
                    {
                        if (i != 1 && i != 3 && i != 2)
                        {
                            val = row[i].ToString();
                            mas[ur, j] = val;
                            j++;
                        }
                        if (i == 1)
                        {
                            val = row[1].ToString() + " " + row[2].ToString() + " " + row[3].ToString();
                            mas[ur, j] = val;
                            j++;
                        }
                    }
                    ur++;
                }
            }
            return JsonConvert.SerializeObject(mas);
        }

        public int getIdGenreByName(string n)
        {
            int index = 0;
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "SELECT id FROM \"myShema\".genre_view WHERE \"Название\"=@n";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@n", n);
            DataTable dt = UpdateGrid(myConnection, com);

            foreach (DataRow row in dt.Rows)
            {
                index = Convert.ToInt32(row[0].ToString());
            }

            return index;
        }

        public void SaveGenre()
        {
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "INSERT INTO \"myShema\".\"Genre\" (name, discription) VALUES (@name, @discription)";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@name", name);
            com.Parameters.AddWithValue("@discription", discription);

            try
            {
                myConnection.Open();
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
        }

        public void DeleteGenre(string index)
        {
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "DELETE FROM \"myShema\".\"Genre\" WHERE id = @id";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@id", index);

            try
            {
                myConnection.Open();
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
        }

        public void UpdateGenre(string index)
        {
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "UPDATE \"myShema\".\"Genre\" SET name=@name, discription=@discription WHERE id = @id";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@name", name);
            com.Parameters.AddWithValue("@discription", discription);
            com.Parameters.AddWithValue("@id", index);

            try
            {
                myConnection.Open();
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
        }

        public string GenreToString()
        {
            return name + " " + discription;
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Discription
        {
            get
            {
                return discription;
            }

            set
            {
                discription = value;
            }
        }

        private DataTable UpdateGrid(NpgsqlConnection myConnection, NpgsqlCommand myCommand)
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
                //throw new Exception(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
            return dt;
        }
    }
    
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Librarian : ServLibrarian
    {
        string myHuman;
        string date_of_employment;
        string telephone;

        public string getAllLibrarians(string num)
        {
            string[,] mas = new string[1000, 4];
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "SELECT * FROM \"myShema\".librarian_view  ORDER BY id LIMIT 10 OFFSET @lim";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@lim", Convert.ToInt32(num) * 100);
            DataTable dt = UpdateGrid(myConnection, com);

            int i = 0;
            int j = 0;
            foreach (DataColumn col in dt.Columns)
            {
                if (i != 2 && i != 3)
                {
                    mas[0, j] = col.ToString();
                    j++;
                }
                i++;
            }
            if (dt.Rows.Count > 0)
            {
                j = 0;
                int ur = 1;
                string val = "";
                foreach (DataRow row in dt.Rows)
                {
                    for (i = 0, j = 0; i < 6; i++)
                    {
                        if (i != 1 && i != 3 && i != 2)
                        {
                            val = row[i].ToString();
                            mas[ur, j] = val;
                            j++;
                        }
                        if (i == 1)
                        {
                            val = row[1].ToString() + " " + row[2].ToString() + " " + row[3].ToString();
                            mas[ur, j] = val;
                            j++;
                        }
                    }
                    ur++;
                }
            }
            return JsonConvert.SerializeObject(mas);
        }

        public void SaveLibrarian()
        {
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "INSERT INTO \"myShema\".\"Librarian\"(sername, name, patronymic, date_of_employment, telephone) VALUES (@ser, @name, @patron, @date, @phone)";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@ser", myHuman.Split(' ')[0]);
            com.Parameters.AddWithValue("@name", myHuman.Split(' ')[1]);
            com.Parameters.AddWithValue("@patron", myHuman.Split(' ')[2]);
            com.Parameters.AddWithValue("@date", date_of_employment);
            com.Parameters.AddWithValue("@phone", telephone);

            try
            {
                myConnection.Open();
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
        }

        public void DeleteLibrarian(string index)
        {
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "DELETE FROM \"myShema\".\"Librarian\" WHERE id = @id";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@id", index);

            try
            {
                myConnection.Open();
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
        }

        public void UpdateLibrarian(string index)
        {
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "UPDATE \"myShema\".\"Librarian\" SET sername=@ser, name=@name, patronymic=@patron, date_of_employment=@date, telephone=@phone WHERE id = @id";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@ser", myHuman.Split(' ')[0]);
            com.Parameters.AddWithValue("@name", myHuman.Split(' ')[1]);
            com.Parameters.AddWithValue("@patron", myHuman.Split(' ')[2]);
            com.Parameters.AddWithValue("@date", date_of_employment);
            com.Parameters.AddWithValue("@phone", telephone);
            com.Parameters.AddWithValue("@id", index);

            try
            {
                myConnection.Open();
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
        }

        public string LibrarianToString()
        {
            return myHuman + " " + date_of_employment + " " + telephone;
        }

        public string MyHuman
        {
            get
            {
                return myHuman;
            }

            set
            {
                myHuman = value;
            }
        }

        public string Date_of_employment
        {
            get
            {
                return date_of_employment;
            }

            set
            {
                date_of_employment = value;
            }
        }

        public string Telephone
        {
            get
            {
                return telephone;
            }

            set
            {
                telephone = value;
            }
        }

        private DataTable UpdateGrid(NpgsqlConnection myConnection, NpgsqlCommand myCommand)
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
                //throw new Exception(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
            return dt;
        }
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Location : ServLocation
    {
        string myBook;
        string myFloor;
        string myArrangement;
        string sector;

        public string getAllLocations(string num)
        {
            string[,] mas = new string[1000, 5];
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "SELECT * FROM \"myShema\".location_view  ORDER BY id LIMIT 10 OFFSET @lim";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@lim", Convert.ToInt32(num) * 100);
            DataTable dt = UpdateGrid(myConnection, com);

            int i = 0;
            int j = 0;
            foreach (DataColumn col in dt.Columns)
            {
                mas[0, j] = col.ToString();
                j++;
            }
            if (dt.Rows.Count > 0)
            {
                j = 0;
                int ur = 1;
                string val = "";
                foreach (DataRow row in dt.Rows)
                {
                    for (i = 0, j = 0; i < 5; i++)
                    {
                        val = row[i].ToString();
                        mas[ur, j] = val;
                        j++;
                    }
                    ur++;
                }
            }
            return JsonConvert.SerializeObject(mas);
        }

        public int getIdBookByName(string n)
        {
            int index = 0;
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "SELECT id FROM \"myShema\".\"Book\" WHERE name=@n";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@n", n);
            DataTable dt = UpdateGrid(myConnection, com);

            foreach (DataRow row in dt.Rows)
            {
                index = Convert.ToInt32(row[0].ToString());
            }

            return index;
        }

        public int getIdFloorByName(string n)
        {
            int index = 0;
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "SELECT id FROM \"myShema\".\"Floor\" WHERE name=@n";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@n", n);
            DataTable dt = UpdateGrid(myConnection, com);

            foreach (DataRow row in dt.Rows)
            {
                index = Convert.ToInt32(row[0].ToString());
            }

            return index;
        }

        public int getIdArrangementByName(string n)
        {
            int index = 0;
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "SELECT id FROM \"myShema\".\"Arrangement\" WHERE place=@n";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@n", n);
            DataTable dt = UpdateGrid(myConnection, com);

            foreach (DataRow row in dt.Rows)
            {
                index = Convert.ToInt32(row[0].ToString());
            }

            return index;
        }

        public void SaveLocation()
        {
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "INSERT INTO \"myShema\".\"Location\" (id_book, id_floor, id_arrangement, sector) VALUES (@id_book, @id_floor, @id_arrangement, @sector)";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@id_book", getIdBookByName(myBook));
            com.Parameters.AddWithValue("@id_floor", getIdFloorByName(myFloor));
            com.Parameters.AddWithValue("@id_arrangement", getIdArrangementByName(myArrangement));
            com.Parameters.AddWithValue("@sector", sector);

            try
            {
                myConnection.Open();
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
        }

        public void DeleteLocation(string index)
        {
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "DELETE FROM \"myShema\".\"Location\" WHERE id = @id";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@id", index);

            try
            {
                myConnection.Open();
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
        }

        public void UpdateLocation(string index)
        {
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "UPDATE \"myShema\".\"Location\" SET id_book=@id_book, id_floor=@id_floor, id_arrangement=@id_arrangement, sector=@sector WHERE id = @id";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@id_book", getIdBookByName(myBook));
            com.Parameters.AddWithValue("@id_floor", getIdFloorByName(myFloor));
            com.Parameters.AddWithValue("@id_arrangement", getIdArrangementByName(myArrangement));
            com.Parameters.AddWithValue("@sector", sector);
            com.Parameters.AddWithValue("@id", index);

            try
            {
                myConnection.Open();
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
        }

        public string LocationToString()
        {
            return myBook + " " + myFloor + " " + myArrangement + " " + sector;
        }

        public string MyBook
        {
            get
            {
                return myBook;
            }

            set
            {
                myBook = value;
            }
        }

        public string MyFloor
        {
            get
            {
                return myFloor;
            }

            set
            {
                myFloor = value;
            }
        }

        public string MyArrangement
        {
            get
            {
                return myArrangement;
            }

            set
            {
                myArrangement = value;
            }
        }

        public string Sector
        {
            get
            {
                return sector;
            }

            set
            {
                sector = value;
            }
        }

        private DataTable UpdateGrid(NpgsqlConnection myConnection, NpgsqlCommand myCommand)
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
                //throw new Exception(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
            return dt;
        }
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Reader : ServReader
    {
        string myHuman;
        string address;
        string telephone;
        string date_of_registration;
        string myStatus;
        string penalties;

        public string getAllReaders(string num)
        {
            string[,] mas = new string[1000, 7];
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "SELECT * FROM \"myShema\".reader_view  ORDER BY id LIMIT 10 OFFSET @lim";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@lim", Convert.ToInt32(num) * 100);
            DataTable dt = UpdateGrid(myConnection, com);

            int i = 0;
            int j = 0;
            foreach (DataColumn col in dt.Columns)
            {
                if (i != 2 && i != 3)
                {
                    mas[0, j] = col.ToString();
                    j++;
                }
                i++;
            }
            if (dt.Rows.Count > 0)
            {
                j = 0;
                int ur = 1;
                string val = "";
                foreach (DataRow row in dt.Rows)
                {
                    for (i = 0, j = 0; i < 9; i++)
                    {
                        if (i != 1 && i != 3 && i != 2)
                        {
                            val = row[i].ToString();
                            mas[ur, j] = val;
                            j++;
                        }
                        if (i == 1)
                        {
                            val = row[1].ToString() + " " + row[2].ToString() + " " + row[3].ToString();
                            mas[ur, j] = val;
                            j++;
                        }
                    }
                    ur++;
                }
            }
            return JsonConvert.SerializeObject(mas);
        }

        public int getIdStatusByName(string n)
        {
            int index = 0;
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "SELECT id FROM \"myShema\".status_view WHERE \"Название\"=@n";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@n", n);
            DataTable dt = UpdateGrid(myConnection, com);

            foreach (DataRow row in dt.Rows)
            {
                index = Convert.ToInt32(row[0].ToString());
            }

            return index;
        }

        public void SaveReader()
        {
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "INSERT INTO \"myShema\".\"Reader\"(sername, name, patronymic, address, telephone, date_of_registration, id_status, penalties) VALUES (@ser, @name, @patron, @address, @phone, @date, @id_status, @penalties)";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@ser", myHuman.Split(' ')[0]);
            com.Parameters.AddWithValue("@name", myHuman.Split(' ')[1]);
            com.Parameters.AddWithValue("@patron", myHuman.Split(' ')[2]);
            com.Parameters.AddWithValue("@address", address);
            com.Parameters.AddWithValue("@phone", telephone);
            com.Parameters.AddWithValue("@date", date_of_registration);
            com.Parameters.AddWithValue("@id_status", getIdStatusByName(myStatus));
            com.Parameters.AddWithValue("@penalties", penalties);

            try
            {
                myConnection.Open();
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
        }

        public void DeleteReader(string index)
        {
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "DELETE FROM \"myShema\".\"Reader\" WHERE id = @id";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@id", index);

            try
            {
                myConnection.Open();
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
        }
        
        public void UpdateReader(string index)
        {
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "UPDATE \"myShema\".\"Reader\" SET sername=@ser, name=@name, patronymic=@patron, address=@address, telephone=@phone, date_of_registration=@date, id_status=@id_status, penalties=@penalties WHERE id = @id";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@ser", myHuman.Split(' ')[0]);
            com.Parameters.AddWithValue("@name", myHuman.Split(' ')[1]);
            com.Parameters.AddWithValue("@patron", myHuman.Split(' ')[2]);
            com.Parameters.AddWithValue("@address", address);
            com.Parameters.AddWithValue("@phone", telephone);
            com.Parameters.AddWithValue("@date", date_of_registration);
            com.Parameters.AddWithValue("@id_status", getIdStatusByName(myStatus));
            com.Parameters.AddWithValue("@penalties", penalties);
            com.Parameters.AddWithValue("@id", index);

            try
            {
                myConnection.Open();
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
        }

        public string ReaderToString()
        {
            return myHuman + " " + address + " " + telephone + " " + date_of_registration + " " + myStatus + " " + penalties;
        }

        public string MyHuman
        {
            get
            {
                return myHuman;
            }

            set
            {
                myHuman = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public string Telephone
        {
            get
            {
                return telephone;
            }

            set
            {
                telephone = value;
            }
        }

        public string Date_of_registration
        {
            get
            {
                return date_of_registration;
            }

            set
            {
                date_of_registration = value;
            }
        }

        public string MyStatus
        {
            get
            {
                return myStatus;
            }

            set
            {
                myStatus = value;
            }
        }

        public string Penalties
        {
            get
            {
                return penalties;
            }

            set
            {
                penalties = value;
            }
        }

        private DataTable UpdateGrid(NpgsqlConnection myConnection, NpgsqlCommand myCommand)
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
                //throw new Exception(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
            return dt;
        }
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Status : ServStatus
    {
        string name;
        string discription;

        public string getAllStatuses(string num)
        {
            string[,] mas = new string[1000, 3];
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "SELECT * FROM \"myShema\".status_view  ORDER BY id LIMIT 10 OFFSET @lim";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@lim", Convert.ToInt32(num) * 100);
            DataTable dt = UpdateGrid(myConnection, com);

            int i = 0;
            int j = 0;
            foreach (DataColumn col in dt.Columns)
            {
                mas[0, j] = col.ToString();
                j++;
            }
            if (dt.Rows.Count > 0)
            {
                j = 0;
                int ur = 1;
                string val = "";
                foreach (DataRow row in dt.Rows)
                {
                    for (i = 0, j = 0; i < 3; i++)
                    {
                        val = row[i].ToString();
                        mas[ur, j] = val;
                        j++;
                    }
                    ur++;
                }
            }
            return JsonConvert.SerializeObject(mas);
        }

        public void SaveStatus()
        {
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "INSERT INTO \"myShema\".\"Status\" (name, discription) VALUES (@name, @discription)";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@name", name);
            com.Parameters.AddWithValue("@discription", discription);

            try
            {
                myConnection.Open();
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
        }

        public void DeleteStatus(string index)
        {
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "DELETE FROM \"myShema\".\"Status\" WHERE id = @id";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@id", index);

            try
            {
                myConnection.Open();
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
        }

        public void UpdateStatus(string index)
        {
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "UPDATE \"myShema\".\"Status\" SET name=@name, discription=@discription WHERE id = @id";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@name", name);
            com.Parameters.AddWithValue("@discription", discription);
            com.Parameters.AddWithValue("@id", index);

            try
            {
                myConnection.Open();
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
        }

        public string StatusToString()
        {
            return name + " " + discription;
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Discription
        {
            get
            {
                return discription;
            }

            set
            {
                discription = value;
            }
        }

        private DataTable UpdateGrid(NpgsqlConnection myConnection, NpgsqlCommand myCommand)
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
                //throw new Exception(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
            return dt;
        }
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Journal : ServJournal
    {
        string myLibrarian;
        string myReader;
        string myBook;
        string number_of_book;
        string date_of_issue;

        public string getAllJournals(string num)
        {
            string[,] mas = new string[1000, 6];
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "SELECT * FROM \"myShema\".journal_view  ORDER BY id LIMIT 10 OFFSET @lim";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@lim", Convert.ToInt32(num) * 100);
            DataTable dt = UpdateGrid(myConnection, com);

            int i = 0;
            int j = 0;
            foreach (DataColumn col in dt.Columns)
            {
                if (i != 2 && i != 3 && i != 5 && i != 6)
                {
                    mas[0, j] = col.ToString();
                    j++;
                }
                i++;
            }
            if (dt.Rows.Count > 0)
            {
                j = 0;
                int ur = 1;
                string val = "";
                foreach (DataRow row in dt.Rows)
                {
                    for (i = 0, j = 0; i < 10; i++)
                    {
                        if (i != 1 && i != 3 && i != 2 && i != 4 && i != 5 && i != 6)
                        {
                            val = row[i].ToString();
                            mas[ur, j] = val;
                            j++;
                        }
                        if (i == 1)
                        {
                            val = row[1].ToString() + " " + row[2].ToString() + " " + row[3].ToString();
                            mas[ur, j] = val;
                            j++;
                        }
                        if (i == 4)
                        {
                            val = row[4].ToString() + " " + row[5].ToString() + " " + row[6].ToString();
                            mas[ur, j] = val;
                            j++;
                        }
                    }
                    ur++;
                }
            }
            return JsonConvert.SerializeObject(mas);
        }

        public int getIdLibrarianByName(string n)
        {
            int index = 0;
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "SELECT id FROM \"myShema\".\"Librarian\" WHERE sername=@s AND name=@n AND patronymic=@p";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@s", n.Split(' ')[0]);
            com.Parameters.AddWithValue("@n", n.Split(' ')[1]);
            com.Parameters.AddWithValue("@p", n.Split(' ')[2]);
            DataTable dt = UpdateGrid(myConnection, com);

            foreach (DataRow row in dt.Rows)
            {
                index = Convert.ToInt32(row[0].ToString());
            }

            return index;
        }

        public int getIdReaderByName(string n)
        {
            int index = 0;
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "SELECT id FROM \"myShema\".\"Reader\" WHERE sername=@s AND name=@n AND patronymic=@p";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@s", n.Split(' ')[0]);
            com.Parameters.AddWithValue("@n", n.Split(' ')[1]);
            com.Parameters.AddWithValue("@p", n.Split(' ')[2]);
            DataTable dt = UpdateGrid(myConnection, com);

            foreach (DataRow row in dt.Rows)
            {
                index = Convert.ToInt32(row[0].ToString());
            }

            return index;
        }

        public int getIdBookByName(string n)
        {
            int index = 0;
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "SELECT id FROM \"myShema\".\"Book\" WHERE name=@n";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@n", n);
            DataTable dt = UpdateGrid(myConnection, com);

            foreach (DataRow row in dt.Rows)
            {
                index = Convert.ToInt32(row[0].ToString());
            }

            return index;
        }

        public void SaveJournal()
        {
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "INSERT INTO \"myShema\".\"Journal\" (id_librarian, id_reader, id_book, number_of_book, date_of_issue) VALUES (@id_librarian, @id_reader, @id_book, @Nbook, @date)";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@id_librarian", getIdLibrarianByName(myLibrarian));
            com.Parameters.AddWithValue("@id_reader", getIdReaderByName(myReader));
            com.Parameters.AddWithValue("@id_book", getIdBookByName(myBook));
            com.Parameters.AddWithValue("@Nbook", number_of_book);
            com.Parameters.AddWithValue("@date", date_of_issue);

            try
            {
                myConnection.Open();
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
        }

        public void DeleteJournal(string index)
        {
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "DELETE FROM \"myShema\".\"Journal\" WHERE id = @id";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@id", index);

            try
            {
                myConnection.Open();
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
        }

        public void UpdateJournal(string index)
        {
            NpgsqlConnection myConnection = new NpgsqlConnection("Server=localhost;User=admin;Password=admin;Database=myLibrary");
            string query = "UPDATE \"myShema\".\"Journal\" SET id_librarian=@id_librarian, id_reader=@id_reader, id_book=@id_book, number_of_book=@Nbook, date_of_issue=@date WHERE id = @id";
            NpgsqlCommand com = new NpgsqlCommand(query, myConnection);
            com.Parameters.AddWithValue("@id_librarian", getIdLibrarianByName(myLibrarian));
            com.Parameters.AddWithValue("@id_reader", getIdReaderByName(myReader));
            com.Parameters.AddWithValue("@id_book", getIdBookByName(myBook));
            com.Parameters.AddWithValue("@Nbook", number_of_book);
            com.Parameters.AddWithValue("@date", date_of_issue);
            com.Parameters.AddWithValue("@id", index);

            try
            {
                myConnection.Open();
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
        }

        public string JournalToString()
        {
            return myLibrarian + " " + myReader + " " + myBook + " " + number_of_book + " " + date_of_issue;
        }

        public string MyLibrarian
        {
            get
            {
                return myLibrarian;
            }

            set
            {
                myLibrarian = value;
            }
        }

        public string MyReader
        {
            get
            {
                return myReader;
            }

            set
            {
                myReader = value;
            }
        }

        public string MyBook
        {
            get
            {
                return myBook;
            }

            set
            {
                myBook = value;
            }
        }

        public string Number_of_book
        {
            get
            {
                return number_of_book;
            }

            set
            {
                number_of_book = value;
            }
        }

        public string Date_of_issue
        {
            get
            {
                return date_of_issue;
            }

            set
            {
                date_of_issue = value;
            }
        }

        private DataTable UpdateGrid(NpgsqlConnection myConnection, NpgsqlCommand myCommand)
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
                //throw new Exception(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
            return dt;
        }
    }
}
