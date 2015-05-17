using System.Linq;
using Octagon.DataModels;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DLL.Repository
{
    public class UserMemoryRepository : BaseRepository, IRepository<UserMemoryModel>
    {
        public void Create(UserMemoryModel item)
        {
            using (var connection = GetConnection())
            {
                try
                {
                    //Открыть подключение 
                    connection.Open();

                    var command = new SqlCommand("dbo.UserMemoryCreate", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    // Входные параметр. 
                    
                    command.Parameters.Add("@Memory", SqlDbType.Float);
                    command.Parameters["@Memory"].Value = item.Memory;

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

        public void Update(UserMemoryModel item)
        {
            using (var connection = GetConnection())
            {
                try
                {
                    //Открыть подключение 
                    connection.Open();

                    var command = new SqlCommand("dbo.UserMemoryUpdate", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    // Входные параметр. 

                    command.Parameters.Add("@User_ID", SqlDbType.Int);
                    command.Parameters["@User_ID"].Value = item.UserId;
                    
                    command.Parameters.Add("@Memory", SqlDbType.Float);
                    command.Parameters["@Memory"].Value = item.Memory;

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

        public void Delete(UserMemoryModel item)
        {
            using (var connection = GetConnection())
            {
                try
                {
                    //Открыть подключение 
                    connection.Open();

                    var command = new SqlCommand("dbo.UserMemoryDelete", connection)
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

        public IList<UserMemoryModel> Select(int userId)
        {
            return Select<UserMemoryModel>().Where(i => i.UserId == userId).ToList();
        }
        
        public IList<UserMemoryModel> Select()
        {
            return Select<UserMemoryModel>().ToList();
        }
    }
}
