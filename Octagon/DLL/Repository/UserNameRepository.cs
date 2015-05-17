using System.Linq;
using Octagon.DataModels;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DLL.Repository
{
    public class UserNameRepository : BaseRepository, IRepository<UserNameModel>
    {
        public void Create(UserNameModel item)
        {
            using (var connection = GetConnection())
            {
                try
                {
                    //Открыть подключение 
                    connection.Open();

                    var command = new SqlCommand("dbo.UserNameCreate", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    // Входные параметр. 
                    
                    command.Parameters.Add("@User_ID", SqlDbType.Int);
                    command.Parameters["@User_ID"].Value = item.UserId;

                    command.Parameters.Add("@Name", SqlDbType.NChar, 50);
                    command.Parameters["@Name"].Value = item.Name;

                    // Выполнение хранимой процедуры. 
                    command.ExecuteNonQuery();

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
        }

        public void Update(UserNameModel item)
        {
            using (var connection = GetConnection())
            {
                try
                {
                    //Открыть подключение 
                    connection.Open();

                    var command = new SqlCommand("dbo.UserNameUpdate", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    // Входные параметр. 

                    command.Parameters.Add("@User_ID", SqlDbType.Int);
                    command.Parameters["@User_ID"].Value = item.UserId;

                    command.Parameters.Add("@Name", SqlDbType.NChar, 50);
                    command.Parameters["@Name"].Value = item.Name;

                    // Выполнение хранимой процедуры. 
                    command.ExecuteNonQuery();

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
        }

        public void Delete(UserNameModel item)
        {
            using (var connection = GetConnection())
            {
                try
                {
                    //Открыть подключение 
                    connection.Open();

                    var command = new SqlCommand("dbo.UserNameDelete", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    // Входные параметр. 
                    command.Parameters.Add("@User_ID", SqlDbType.Int);
                    command.Parameters["@User_ID"].Value = item.UserId;

                    // Выполнение хранимой процедуры. 
                    command.ExecuteNonQuery();

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
        }

        public IList<UserNameModel> Select(int userId)
        {
            return Select<UserNameModel>().Where(i => i.UserId == userId).ToList();
        }
        
        public IList<UserNameModel> Select()
        {
            return Select<UserNameModel>().ToList();
        }
    }
}
