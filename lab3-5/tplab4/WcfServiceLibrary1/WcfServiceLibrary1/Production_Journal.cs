using Newtonsoft.Json;
using Npgsql;
using System;
using System.ServiceModel;
using System.Text.RegularExpressions;

namespace WcfServiceLibrary1
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class Production_Journal : SProduction_Journal
    {
        string Factory = "";
        string Product = "";
        string Number = "";
        public string Production_Journal_Factory
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

        public string Production_Journal_Product
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
        public string Production_Journal_Number
        {
            get
            {
                return Number;
            }

            set
            {
                Number = value;
            }
        }

        public void Insert()
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User=postgres;Password=qwer;Database=TP_3;");
            NpgsqlCommand command = new NpgsqlCommand();
            string SQL = "INSERT INTO \"Production_Journal\"(\"ID_Factory\", \"ID_Product\", \"Number\", \"Is_del\") VALUES(@factory, @product, @number, 0);";
            command.CommandText = SQL;
            string id_factory = GetFactoryID(Factory);
            string id_product = GetProductID(Product);
            command.Parameters.AddWithValue("@factory", id_factory);
            command.Parameters.AddWithValue("@product", id_product);
            command.Parameters.AddWithValue("@number", Number);
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
            string SQL = "UPDATE \"Production_Journal\" SET \"ID_Factory\"=@id_factory, \"ID_Product\"=@id_product, \"Number\"=@number WHERE \"ID\"=@id;";
            command.CommandText = SQL;
            string id_factory = GetFactoryID(Factory);
            string id_product = GetProductID(Product);
            command.Parameters.AddWithValue("@id_factory", id_factory);
            command.Parameters.AddWithValue("@id_product", id_product);
            command.Parameters.AddWithValue("@number", Number);
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

        public string getByName(string id)
        {
            string[,] mas = new string[10, 3];
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User=postgres;Password=qwer;Database=TP_3;");
            NpgsqlCommand command = new NpgsqlCommand();
            string SQL = "SELECT \"Production_Journal\".\"ID_Factory\", \"Production_Journal\".\"ID_Product\", \"Production_Journal\".\"Number\" FROM \"Production_Journal\"  WHERE \"Is_del\"=0 and \"ID\" = @id;";
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
                            Factory = Regex.Replace(Convert.ToString(reader.GetValue(0)), "[ ]+", " ");
                            Product = Regex.Replace(Convert.ToString(reader.GetValue(1)), "[ ]+", " ");
                            Number = Regex.Replace(Convert.ToString(reader.GetValue(2)), "[ ]+", " ");
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

        public string get()
        {
            string[,] mas = new string[4, 20];
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User=postgres;Password=qwer;Database=TP_3;");
            NpgsqlCommand command = new NpgsqlCommand("SELECT \"Production_Journal\".\"ID\", \"Factory\".\"Name\" AS Factory, \"Product\".\"Name\" AS Product, \"Production_Journal\".\"Number\" FROM \"Production_Journal\", \"Factory\", \"Product\" WHERE \"Production_Journal\".\"Is_del\"=0 and \"Production_Journal\".\"ID_Factory\"=\"Factory\".\"ID\" and \"Production_Journal\".\"ID_Product\"=\"Product\".\"ID\"", conn);
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

        public void Delete(string id)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User=postgres;Password=qwer;Database=TP_3;");
            NpgsqlCommand command = new NpgsqlCommand();
            string SQL = "UPDATE \"Production_Journal\" SET \"Is_del\"=1 WHERE \"ID\"=@id;";
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
            return Factory + " " + Product + " " + Number;
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

    }
}
