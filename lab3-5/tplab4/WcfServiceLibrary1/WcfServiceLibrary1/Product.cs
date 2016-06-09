using Newtonsoft.Json;
using Npgsql;
using System;
using System.ServiceModel;
using System.Text.RegularExpressions;

namespace WcfServiceLibrary1
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class Product : SProduct
    {
        string Name = "";
        string Cost = "";

        public string Product_Name
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

        public string Product_Cost
        {
            get
            {
                return Cost;
            }

            set
            {
                Cost = value;
            }
        }

        public void Insert()
        {
            if (Name == "" || Cost == "")
            {
                throw new Exception("Ошибка! Объект не создан");
            }
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User=postgres;Password=qwer;Database=TP_3;");
            NpgsqlCommand command = new NpgsqlCommand();
            string SQL = "INSERT INTO \"Product\"(\"Name\", \"Cost\", \"Is_del\") VALUES(@name, @cost, 0); ";
            command.CommandText = SQL;
            command.Parameters.AddWithValue("@name", Name);
            command.Parameters.AddWithValue("@cost", Cost);
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

        public void Update(string newname, string name, string newcost)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User=postgres;Password=qwer;Database=TP_3;");
            NpgsqlCommand command = new NpgsqlCommand();
            string SQL = "UPDATE \"Product\" SET \"Name\" = @newname, \"Cost\" = @cost WHERE \"Name\" = @name;";
            command.CommandText = SQL;
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@newname", newname);
            command.Parameters.AddWithValue("@cost", newcost);
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
            string[,] mas = new string[2, 20];
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User=postgres;Password=qwer;Database=TP_3;");
            NpgsqlCommand command = new NpgsqlCommand("SELECT \"Name\", \"Cost\" FROM \"Product\" WHERE \"Is_del\"=0", conn);
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
                            //Array.Resize<int>(ref mas, mas.Length + 2);
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
            string SQL = "SELECT \"Name\", \"Cost\" FROM \"Product\" WHERE \"Is_del\"=0 and \"Name\"= @name;";
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
                            Cost = Regex.Replace(Convert.ToString(reader.GetValue(1)), "[ ]+", " ");
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
            string SQL = "UPDATE \"Product\" SET \"Is_del\" = 1 WHERE \"Name\"=@name;";
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
            return Name + " " + Cost;
        }

    }
}
