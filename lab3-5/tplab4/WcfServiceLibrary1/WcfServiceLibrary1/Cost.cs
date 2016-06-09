using Newtonsoft.Json;
using Npgsql;
using System;
using System.ServiceModel;
using System.Text.RegularExpressions;

namespace WcfServiceLibrary1
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class Cost : SCost
    {
        string Product = "";
        string Old_cost = "";
        string New_cost = "";
        string Date_C = "";

        public string Cost_Product
        {
            get
            {
                return Product;
            }

            set
            {
                Product = value;
            }
        }

        public string Cost_Old_cost
        {
            get
            {
                return Old_cost;
            }

            set
            {
                Old_cost = value;
            }
        }
        public string Cost_New_cost
        {
            get
            {
                return New_cost;
            }

            set
            {
                New_cost = value;
            }
        }

        public string Cost_Date_C
        {
            get
            {
                return Cost_Date_C;
            }

            set
            {
                Cost_Date_C = value;
            }
        }

        public string get()
        {
            string[,] mas = new string[5, 20];
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User=postgres;Password=qwer;Database=TP_3;");
            NpgsqlCommand command = new NpgsqlCommand("SELECT \"Old_Product\", \"New_Product\", \"Old_cost\", \"New_cost\", \"Date_C\" FROM \"Cost\"", conn);
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
                            if (reader.GetValue(cell) is DateTime)
                                mas[cell, row] = Regex.Replace(Convert.ToString(reader.GetDate(cell)), "[ ]+", " ");
                            else
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

        public string getByName(string product)
        {
            string[,] mas = new string[10, 3];
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User=postgres;Password=qwer;Database=TP_3;");
            NpgsqlCommand command = new NpgsqlCommand();
            string SQL = "SELECT \"Product\", \"Old_cost\".\"New_cost\", \"Date_C\" FROM \"Cost\" and \"Product\" = @product;";
            command.CommandText = SQL;
            command.Parameters.AddWithValue("@product", product);
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
                            Product = Regex.Replace(Convert.ToString(reader.GetValue(0)), "[ ]+", " ");
                            Old_cost = Regex.Replace(Convert.ToString(reader.GetValue(1)), "[ ]+", " ");
                            New_cost = Regex.Replace(Convert.ToString(reader.GetValue(1)), "[ ]+", " ");
                            Date_C = Regex.Replace(Convert.ToString(reader.GetValue(2)), "[ ]+", " ");
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
        public string toString()
        {
            return Product + " " + Old_cost + " " + New_cost + " " + Date_C;
        }
    }
}
