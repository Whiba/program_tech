using Newtonsoft.Json;
using Npgsql;
using System;
using System.ServiceModel;
using System.Text.RegularExpressions;

namespace WcfServiceLibrary1
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class Sup_Journal : SSup_Journal
    {
        string Shop = "";
        string Product = "";
        string Date = "";

        public string Sup_Journal_Shop
        {
            get
            {
                return Shop;
            }

            set
            {
                Shop = value;
            }
        }

        public string Sup_Journal_Product
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

        public string Sup_Journal_Date
        {
            get
            {
                return Date;
            }

            set
            {
                Date = value;
            }
        }

        public void Insert()
        {
            if (Shop == "" || Product == "" || Date == "")
            {
                throw new Exception("Ошибка! Объект не создан");
            }
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User=postgres;Password=qwer;Database=TP_3;");
            NpgsqlCommand command = new NpgsqlCommand();
            string SQL = "INSERT INTO \"Supplies_Journal\"(\"ID_Product\", \"ID_Shop\", \"Supply_date\", \"Is_del\") VALUES(@id_product, @id_shop, @date, 0);";
            command.CommandText = SQL;
            string id_product= GetProductID(Product);
            string id_shop = GetShopID(Shop);
            command.Parameters.AddWithValue("@id_product", id_product);
            command.Parameters.AddWithValue("@id_shop", id_shop);
            command.Parameters.AddWithValue("@date", Date);
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

        public void Update(string id)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User=postgres;Password=qwer;Database=TP_3;");
            NpgsqlCommand command = new NpgsqlCommand();
            string SQL = "UPDATE \"Supplies_Journal\" SET \"ID_Shop\" = @id_shop, \"ID_Product\" = @id_product, \"Supply_date\"=@date WHERE \"ID\" = @id; ";
            command.CommandText = SQL;
            string id_product = GetProductID(Product);
            string id_shop = GetShopID(Shop);
            command.Parameters.AddWithValue("@id_product", id_product);
            command.Parameters.AddWithValue("@id_shop", id_shop);
            command.Parameters.AddWithValue("@date", Date);
            command.Parameters.AddWithValue("@id", id);
            
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
            NpgsqlCommand command = new NpgsqlCommand("SELECT \"Supplies_Journal\".\"ID\", \"Product\".\"Name\" AS Product, \"Shop\".\"Name\" AS Shop, \"Supplies_Journal\".\"Supply_date\" FROM \"Supplies_Journal\", \"Product\", \"Shop\" WHERE \"Supplies_Journal\".\"Is_del\"=0 and \"Supplies_Journal\".\"ID_Product\" = \"Product\".\"ID\" and \"Supplies_Journal\".\"ID_Shop\"=\"Shop\".\"ID\"", conn);
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

        public string getByName(string id)
        {
            string[,] mas = new string[10, 3];
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User=postgres;Password=qwer;Database=TP_3;");
            NpgsqlCommand command = new NpgsqlCommand();
            string SQL = "SELECT \"Product\".\"Name\", \"Shop\".\"Name\", \"Supplies_Journal\".\"Supply_date\" FROM \"Supplies_Journal\", \"Product\", \"Shop\" WHERE\"Supplies_Journal\".\"Is_del\"=0 and \"Supplies_Journal\".\"ID_Product\"=\"Product\".\"ID\" and \"Supplies_Journal\".\"ID_Shop\"=\"Shop\".\"ID\";";
            command.CommandText = SQL;
            command.Parameters.AddWithValue("@id", id);
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
                            Shop = Regex.Replace(Convert.ToString(reader.GetValue(1)), "[ ]+", " ");
                            Date = Regex.Replace(Convert.ToString(reader.GetValue(2)), "[ ]+", " ");
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

        public void Delete(string id)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User=postgres;Password=qwer;Database=TP_3;");
            NpgsqlCommand command = new NpgsqlCommand();
            string SQL = "UPDATE\"Supplies_Journal\" SET \"Is_del\" = 1 WHERE \"ID\"=@id;";
            command.CommandText = SQL;
            command.Parameters.AddWithValue("@id", id);
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
            return Product + " " + Shop + " " + Date;
        }

        private string GetProductID(string name)
        {
            string id = "";
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User=postgres;Password=qwer;Database=TP_3;");
            NpgsqlCommand command = new NpgsqlCommand();
            string SQL = "SELECT \"ID\" FROM \"Product\" WHERE \"Name\"=@name";
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
        private string GetShopID(string name)
        {
            string id = "";
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User=postgres;Password=qwer;Database=TP_3;");
            NpgsqlCommand command = new NpgsqlCommand();
            string SQL = "SELECT \"ID\" FROM \"Shop\" WHERE \"Name\"=@name";
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
