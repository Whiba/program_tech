using Newtonsoft.Json;
using Npgsql;
using System;
using System.ServiceModel;
using System.Text.RegularExpressions;

namespace WcfServiceLibrary1
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class Employee : SEmployee
    {
        string Name = "";
        string Factory = "";
        string Position = "";
        public string Employee_Name
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

        public string Employee_Factory
        {
            get
            {
                return Factory;
            }

            set
            {
                Factory = value;
            }
        }
        public string Employee_Position
        {
            get
            {
                return Position;
            }

            set
            {
                Position = value;
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
            string SQL = "INSERT INTO \"Employee\"(\"Name\", \"ID_Factory\", \"ID_Position\", \"Is_del\") VALUES(@name, @id_factory, @id_position, 0);";
            command.CommandText = SQL;
            string id_factory = GetFactoryID(Factory);
            string id_position= GetPositionID(Position);
            command.Parameters.AddWithValue("@name", Name);
            command.Parameters.AddWithValue("@id_factory", id_factory);
            command.Parameters.AddWithValue("@id_position", id_position);
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

        public void Update(string newname)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User=postgres;Password=qwer;Database=TP_3;");
            NpgsqlCommand command = new NpgsqlCommand();
            string SQL = "UPDATE \"Employee\" SET \"Name\" = @newname, \"ID_Factory\" = @id_factory, \"ID_Position\" = @id_position WHERE \"Name\" = @name;";
            command.CommandText = SQL;
            string id_factory = GetFactoryID(Factory);
            string id_position = GetPositionID(Position);
            command.Parameters.AddWithValue("@id_position", id_position);
            command.Parameters.AddWithValue("@id_factory", id_factory);
            command.Parameters.AddWithValue("@name", Name);
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
            string[,] mas = new string[4, 20];
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User=postgres;Password=qwer;Database=TP_3;");
            NpgsqlCommand command = new NpgsqlCommand("SELECT \"Employee\".\"Name\", \"Position\".\"Name\" AS Position, \"Factory\".\"Name\" AS Factory FROM \"Employee\", \"Position\", \"Factory\" WHERE \"Employee\".\"Is_del\"=0 and \"Employee\".\"ID_Position\" = \"Position\".\"ID\" and \"Employee\".\"ID_Factory\"=\"Factory\".\"ID\"", conn);
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
            string[,] mas = new string[10, 4];
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User=postgres;Password=qwer;Database=TP_3;");
            NpgsqlCommand command = new NpgsqlCommand();
            string SQL = "SELECT \"Employee\".\"Name\", \"Position\".\"Name\", \"Factory\".\"Name\" FROM \"Employee\", \"Position\", \"Factory\" WHERE \"Employee\".\"Is_del\"=0 and \"Employee\".\"ID_Position\" = \"Position\".\"ID\" and \"Employee\".\"ID_Factory\"=\"Factory\".\"ID\" and \"Employee\".\"Name\" = @name;";
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
                            Factory = Regex.Replace(Convert.ToString(reader.GetValue(1)), "[ ]+", " ");
                            Position = Regex.Replace(Convert.ToString(reader.GetValue(2)), "[ ]+", " ");
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
            string SQL = "UPDATE \"Employee\" SET \"Is_del\" = 1 WHERE \"Name\"=@name;";
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
            return Name + " " + Factory + " " + Position;
        }

        private string GetPositionID(string name)
        {
            string id = "";
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User=postgres;Password=qwer;Database=TP_3;");
            NpgsqlCommand command = new NpgsqlCommand();
            string SQL = "SELECT \"ID\" FROM \"Position\" WHERE \"Name\"=@name";
            command.CommandText = SQL;
            command.Parameters.AddWithValue("@name", name);
            command.Connection = conn;
            NpgsqlDataReader reader = null;
            try
            {
                conn.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    id = Convert.ToString(reader.GetValue(0));
                }
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
            return id;
        }
        private string GetFactoryID(string name)
        {
            string id = "";
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User=postgres;Password=qwer;Database=TP_3;");
            NpgsqlCommand command = new NpgsqlCommand();
            string SQL = "SELECT \"ID\" FROM \"Factory\" WHERE \"Name\"=@name";
            command.CommandText = SQL;
            command.Parameters.AddWithValue("@name", name);
            command.Connection = conn;
            NpgsqlDataReader reader = null;
            try
            {
                conn.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    id = Convert.ToString(reader.GetValue(0));
                }
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
            return id;
        }
    }
}
