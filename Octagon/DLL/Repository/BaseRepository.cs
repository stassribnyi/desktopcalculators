using DLL.Parsers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Octagon.DataModels;

namespace DLL.Repository
{
    public abstract class BaseRepository
    {
        private const string ConnectionName = "UserData";

        protected SqlConnection GetConnection()
        {
            var connection = ConfigurationManager.ConnectionStrings[ConnectionName].ConnectionString;

            if (string.IsNullOrEmpty(connection)) throw new ArgumentException("Connection string is Empty");
            else
            {
                var northWindConnection = new SqlConnection(connection);
                return northWindConnection;
            }
        }

        protected List<T> Select<T>() where T : IParseble, new()
        {
            var list = new List<T>();

            using (var connection = GetConnection())
            {
                try
                {
                    //Открыть подключение 
                    connection.Open();

                    var querry = new StringBuilder();

                    var type = typeof(T).Name;

                    querry.AppendFormat("Select * From [{0}]", type);

                    var command = new SqlCommand(querry.ToString(), connection);

                    var reader = command.ExecuteReader();

                    var table = new DataTable();

                    if (reader.HasRows)
                    {
                        table.Load(reader);
                        foreach (DataRow row in table.Rows)
                        {
                            var model = new T();
                            row.Parse<T>(ref model);
                            list.Add(model);
                        }
                    }
                }
                catch (SqlException exeption)
                {
                    // Протоколировать исключение 
                    //exeption.Message;
                }
                finally
                {
                    // Гарантировать освобождение подключения 
                    connection.Close();
                }
            }
            return list;
        }
    }
}
