using Newtonsoft.Json;
using Npgsql;
using System;
using System.ServiceModel;
using System.Text.RegularExpressions;

namespace WcfServiceLibrary1
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class Profile : SProfile
    {
        string Name = "";

        public string Profile_Name
        {
            get
            {
                return Name;
            }

            set
            {
                Name = value;
            }
        }

        public void Insert()
        {
            if (Name == "")
            {
                throw new Exception("Ошибка! Объект не создан");
            }
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User=postgres;Password=qwer;Database=TP_3;");
            NpgsqlCommand command = new NpgsqlCommand();
            string SQL = "INSERT INTO \"Profile\"(\"Name\", \"Is_del\") VALUES(@name, 0);";
            command.CommandText = SQL;
            command.Parameters.AddWithValue("@name", Name);
            command.Connection = conn;
            NpgsqlDataReader reader = null;
            try
            {
                conn.Open();
                reader = command.ExecuteReader();
                reader.Close();
            }
            catch (Exception m)
            {
                throw new Exception(m.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void Update(string name, string newname)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User=postgres;Password=qwer;Database=TP_3;");
            NpgsqlCommand command = new NpgsqlCommand();
            string SQL = "UPDATE \"Profile\" SET \"Name\" = @newname WHERE \"Name\" = @name; ";
            command.CommandText = SQL;
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@newname", newname);
            command.Connection = conn;
            NpgsqlDataReader reader = null;
            try
            {
                conn.Open();
                reader = command.ExecuteReader();
                reader.Close();
            }
            catch (Exception m)
            {
                throw new Exception(m.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        public string get()
        {
            string[,] mas = new string[1, 20];
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User=postgres;Password=qwer;Database=TP_3;");
            NpgsqlCommand command = new NpgsqlCommand("SELECT \"Name\" FROM \"Profile\" WHERE \"Profile\".\"Is_del\"=0", conn);
            NpgsqlDataReader reader = null;
            try
            {
                conn.Open();
                reader = command.ExecuteReader();
                int i = reader.VisibleFieldCount;

                if (i > 0 && reader.HasRows)
                {
                    for (int l = 0; l < i; l++)
                        mas[l, 0] = reader.GetName(l);

                    int row = 1;
                    while (reader.Read())
                    {
                        for (int cell = 0; cell < i; cell++)
                        {
                            mas[cell, row] = Regex.Replace(Convert.ToString(reader.GetValue(cell)), "[ ]+", " ");
                        }
                        row++;
                    }
                }
                else throw new Exception("Ошибка! Записи не найдены");
                reader.Close();
            }
            catch (Exception m)
            {
                throw new Exception(m.Message);
            }
            finally
            {
                conn.Close();
            }
            return JsonConvert.SerializeObject(mas);
        }

        public string getByName(string name)
        {
            string[,] mas = new string[10, 3];
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User=postgres;Password=qwer;Database=TP_3;");
            NpgsqlCommand command = new NpgsqlCommand();
            string SQL = "SELECT \"Name\" FROM \"Profile\" WHERE \"Is_del\"=0 and \"Name\" = @name;";
            command.CommandText = SQL;
            command.Parameters.AddWithValue("@name", name);
            command.Connection = conn;
            NpgsqlDataReader reader = null;
            try
            {
                conn.Open();
                reader = command.ExecuteReader();
                int i = reader.VisibleFieldCount;

                if (i > 0 && reader.HasRows)
                {
                    for (int l = 0; l < i; l++)
                        mas[l, 0] = reader.GetName(l);

                    int row = 1;
                    while (reader.Read())
                    {
                        for (int cell = 0; cell < i; cell++)
                        {
                            mas[cell, row] = Regex.Replace(Convert.ToString(reader.GetValue(cell)), "[ ]+", " ");
                            Name = Regex.Replace(Convert.ToString(reader.GetValue(0)), "[ ]+", " ");
                        }
                        row++;
                    }
                }
                else throw new Exception("Ошибка! Записи не найдены");
                reader.Close();
            }
            catch (Exception m)
            {
                throw new Exception(m.Message);
            }
            finally
            {
                conn.Close();
            }
            return JsonConvert.SerializeObject(mas);
        }

        public void Delete(string name)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User=postgres;Password=qwer;Database=TP_3;");
            NpgsqlCommand command = new NpgsqlCommand();
            string SQL = "UPDATE \"Profile\" SET \"Is_del\" = 1 WHERE \"Name\"=@name;";
            command.CommandText = SQL;
            command.Parameters.AddWithValue("@name", name);
            command.Connection = conn;
            NpgsqlDataReader reader = null;
            try
            {
                conn.Open();
                reader = command.ExecuteReader();
                reader.Close();
            }
            catch (Exception m)
            {
                throw new Exception(m.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public string toString()
        {
            return Name;
        }

    }
}
