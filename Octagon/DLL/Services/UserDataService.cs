using DLL.Repository;
using Octagon.DataModels;
using System;
using System.Data;

namespace DLL.Services
{
    public class UserDataService : BaseRepository
    {
        public void Create(UserMemoryModel userMemory, UserHistoryModel userHistory)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = connection.CreateCommand();

                // Запуск локальной транзакции
                var transaction = connection.BeginTransaction("CreateTransaction");

                // Must assign both transaction object and connection 
                // to Command object for a pending local transaction
                command.Connection = connection;
                command.Transaction = transaction;

                try
                {
                    //создание пользователя и памяти
                    command.CommandText = "dbo.UserMemoryCreate";
                    command.CommandType = CommandType.StoredProcedure;

                    // Входные параметр. 

                    command.Parameters.Add("@Memory", SqlDbType.Decimal);
                    command.Parameters["@Memory"].Value = userMemory.Memory;

                    // Выполнение хранимой процедуры. 
                    command.ExecuteNonQuery();

                    //создание истории на базе созданого пользователя
                    command.CommandText = "dbo.UserHistoryCreate";
                    command.CommandType = CommandType.StoredProcedure;

                    // Входные параметр. 
                    command.Parameters.Add("@User_ID", SqlDbType.Int);
                    command.Parameters["@User_ID"].Value = userHistory.UserId;

                    command.Parameters.Add("@Expression", SqlDbType.NChar, 100);
                    command.Parameters["@Expression"].Value = userHistory.Expression;

                    // Выполнение хранимой процедуры. 
                    command.ExecuteNonQuery();
                    
                    // Attempt to commit the transaction.
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    //ex.Message;
                }
            }
        }

        public void Update(UserMemoryModel userMemory, UserHistoryModel userHistory)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = connection.CreateCommand();

                // Запуск локальной транзакции
                var transaction = connection.BeginTransaction("UpdateTransaction");

                // Must assign both transaction object and connection 
                // to Command object for a pending local transaction
                command.Connection = connection;
                command.Transaction = transaction;

                try
                {
                    //update пользователя и памяти
                    command.CommandText = "dbo.UserMemoryUpdate";
                    command.CommandType = CommandType.StoredProcedure;

                    // Входные параметр. 

                    command.Parameters.Add("@User_ID", SqlDbType.Int);
                    command.Parameters["@User_ID"].Value = userMemory.UserId;

                    command.Parameters.Add("@Memory", SqlDbType.Decimal);
                    command.Parameters["@Memory"].Value = userMemory.Memory;

                    // Выполнение хранимой процедуры. 
                    command.ExecuteNonQuery();

                    //update истории 
                    command.CommandText = "dbo.UserHistoryUpdate";
                    command.CommandType = CommandType.StoredProcedure;

                    // Входные параметр. 
                    command.Parameters.Add("@History_ID", SqlDbType.Int);
                    command.Parameters["@History_ID"].Value = userHistory.HistoryId;

                    command.Parameters.Add("@User_ID", SqlDbType.Int);
                    command.Parameters["@User_ID"].Value = userHistory.UserId;

                    command.Parameters.Add("@Expression", SqlDbType.NChar, 100);
                    command.Parameters["@Expression"].Value = userHistory.Expression;

                    // Выполнение хранимой процедуры. 
                    command.ExecuteNonQuery();

                    // Attempt to commit the transaction.
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    //ex.Message;
                }
            }
        }

        public void Delete(UserMemoryModel userMemory, UserHistoryModel userHistory)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = connection.CreateCommand();

                // Запуск локальной транзакции
                var transaction = connection.BeginTransaction("DeleteTransaction");

                // Must assign both transaction object and connection 
                // to Command object for a pending local transaction
                command.Connection = connection;
                command.Transaction = transaction;

                try
                {
                    //удаление истории 
                    command.CommandText = "dbo.UserHistoryDelete";
                    command.CommandType = CommandType.StoredProcedure;

                    // Входные параметр. 
                    command.Parameters.Add("@History_ID", SqlDbType.Int);
                    command.Parameters["@History_ID"].Value = userHistory.HistoryId;

                    // Выполнение хранимой процедуры. 
                    command.ExecuteNonQuery();

                    //удаление пользователя и памяти
                    command.CommandText = "dbo.UserMemoryDelete";
                    command.CommandType = CommandType.StoredProcedure;

                    // Входные параметр. 

                    command.Parameters.Add("@User_ID", SqlDbType.Int);
                    command.Parameters["@User_ID"].Value = userMemory.UserId;

                    // Выполнение хранимой процедуры. 
                    command.ExecuteNonQuery();
                    
                    // Attempt to commit the transaction.
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    //ex.Message;
                }
            }
        }
    }
}
