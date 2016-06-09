using Newtonsoft.Json;
using Npgsql;
using System;
using System.ServiceModel;
using System.Text.RegularExpressions;

namespace WcfServiceLibrary1
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class Shop : SShop
    {
        string Name = "";
        string Profile = "";
        string Address = "";

        public string Shop_Name
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

        public string Shop_Profile
        {
            get
            {
                return Profile;
            }

            set
            {
                Profile = value;
            }
        }

        public string Shop_Address
        {
            get
            {
                return Address;
            }

            set
            {
                Address = value;
            }
        }
            
        public void Insert()
        {
            if (Name == "" || Address == "")
            {
                throw new Exception("Ошибка! Объект не создан");
            }
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User=postgres;Password=qwer;Database=TP_3;");
            NpgsqlCommand command = new NpgsqlCommand();
            string SQL = "INSERT INTO \"Shop\"(\"Name\", \"ID_Profile\", \"Address\", \"Is_del\") VALUES(@name, @id_profile, @address, 0); ";
            command.CommandText = SQL;
            string id_profile = GetProfileID(Profile);
            command.Parameters.AddWithValue("@id_profile", id_profile);
            command.Parameters.AddWithValue("@name", Name);
            command.Parameters.AddWithValue("@address", Address);
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

        public void Update(string newname, string name, string address)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User=postgres;Password=qwer;Database=TP_3;");
            NpgsqlCommand command = new NpgsqlCommand();
            string SQL = "UPDATE \"Shop\" SET \"Name\" = @newname, \"Address\" = @address, \"ID_Profile\" = @id_profile WHERE \"Name\" = @name;";
            command.CommandText = SQL;
            string id_profile = GetProfileID(Profile);
            command.Parameters.AddWithValue("@id_profile", id_profile);
            command.Parameters.AddWithValue("@name", Name);
            command.Parameters.AddWithValue("@address", Address);
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
            string[,] mas = new string[3, 20];
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User=postgres;Password=qwer;Database=TP_3;");
            NpgsqlCommand command = new NpgsqlCommand("SELECT \"Shop\".\"Name\", \"Profile\".\"Name\" AS Profile, \"Shop\".\"Address\" FROM \"Shop\", \"Profile\" WHERE \"Shop\".\"Is_del\"=0 and \"Shop\".\"ID_Profile\" = \"Profile\".\"ID\"", conn);
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
            string SQL = "SELECT \"Shop\".\"Name\", \"Profile\".\"Name\" AS Profile, \"Shop\".\"Address\" FROM \"Shop\", \"Profile\" WHERE \"Shop\".\"Is_del\"=0 and \"Shop\".\"ID_Profile\" = \"Profile\".\"ID\" and \"Shop\".\"Name\" = @name;";
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
                            Profile = Regex.Replace(Convert.ToString(reader.GetValue(1)), "[ ]+", " ");
                            Address = Regex.Replace(Convert.ToString(reader.GetValue(2)), "[ ]+", " ");
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
            string SQL = "UPDATE \"Shop\" SET \"Is_del\" = 1 WHERE \"Name\"=@name;";
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
            return Name + " " + Profile+ " " + Address;
        }

        private string GetProfileID(string name)
        {
            string id = "";
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User=postgres;Password=qwer;Database=TP_3;");
            NpgsqlCommand command = new NpgsqlCommand();
            string SQL = "SELECT \"ID\" FROM \"Profile\" WHERE \"Name\"=@name";
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
