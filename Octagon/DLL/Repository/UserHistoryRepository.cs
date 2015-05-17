using System.Linq;
using Octagon.DataModels;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DLL.Repository
{
    public class UserHistoryRepository : BaseRepository, IRepository<UserHistoryModel>
    {
        public void Create(UserHistoryModel item)
        {
            using (var connection = GetConnection())
            {
                try
                {
                    //Открыть подключение 
                    connection.Open();

                    var command = new SqlCommand("dbo.UserHistoryCreate", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    // Входные параметр. 

                    command.Parameters.Add("@User_ID", SqlDbType.Int);
                    command.Parameters["@User_ID"].Value = item.UserId;

                    command.Parameters.Add("@Expression", SqlDbType.NChar, 100);
                    command.Parameters["@Expression"].Value = item.Expression;

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

        public void Update(UserHistoryModel item)
        {
            using (var connection = GetConnection())
            {
                try
                {
                    //Открыть подключение 
                    connection.Open();

                    var command = new SqlCommand("dbo.UserHistoryUpdate", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    // Входные параметр. 
                    command.Parameters.Add("@History_ID", SqlDbType.Int);
                    command.Parameters["@History_ID"].Value = item.HistoryId;

                    command.Parameters.Add("@User_ID", SqlDbType.Int);
                    command.Parameters["@User_ID"].Value = item.UserId;

                    command.Parameters.Add("@Expression", SqlDbType.NChar, 100);
                    command.Parameters["@Expression"].Value = item.Expression;

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

        public void Delete(UserHistoryModel item)
        {
            using (var connection = GetConnection())
            {
                try
                {
                    //Открыть подключение 
                    connection.Open();

                    var command = new SqlCommand("dbo.UserHistoryDelete", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    // Входные параметр. 
                    command.Parameters.Add("@History_ID", SqlDbType.Int);
                    command.Parameters["@History_ID"].Value = item.HistoryId;

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

        public IList<UserHistoryModel> Select(int userId)
        {
            return Select<UserHistoryModel>().Where(i => i.UserId == userId).ToList();
        }
        
        public IList<UserHistoryModel> Select()
        {
            return Select<UserHistoryModel>().ToList();
        }
    }
}
