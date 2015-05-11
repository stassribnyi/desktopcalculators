using DAL.EntityModel;
using Octagon.DataModels;

namespace DAL.Services
{
    public class UserDataService : IServises<UserMemoryModel, UserHistoryModel>
    {
        readonly UserDataEntities _contextEntities = new UserDataEntities();

        public void Create(UserMemoryModel userMemory, UserHistoryModel userHistory)
        {
            var memoryEntity = new UserMemory { User_ID = userMemory.UserId, Memory = userMemory.Memory };

            var historyEntity = new UserHistory
            {
                History_ID = userHistory.HistoryId,
                User_ID = userHistory.UserId,
                Expression = userHistory.Expression
            };

            _contextEntities.UserMemories.Add(memoryEntity);
            _contextEntities.UserHistories.Add(historyEntity);
            _contextEntities.SaveChanges();
        }

        public void Update(UserMemoryModel userMemory, UserHistoryModel userHistory)
        {
            var memoryEntity = new UserMemory { User_ID = userMemory.UserId, Memory = userMemory.Memory };

            var historyEntity = new UserHistory
            {
                History_ID = userHistory.HistoryId,
                User_ID = userHistory.UserId,
                Expression = userHistory.Expression
            };
            
            _contextEntities.Entry(memoryEntity).State = System.Data.Entity.EntityState.Modified;
            _contextEntities.Entry(historyEntity).State = System.Data.Entity.EntityState.Modified;
            _contextEntities.SaveChanges();
        }

        public void Delete(UserMemoryModel userMemory, UserHistoryModel userHistory)
        {
            var memoryEntity = new UserMemory { User_ID = userMemory.UserId, Memory = userMemory.Memory };

            var historyEntity = new UserHistory
            {
                History_ID = userHistory.HistoryId,
                User_ID = userHistory.UserId,
                Expression = userHistory.Expression
            };

            _contextEntities.UserMemories.Remove(memoryEntity);
            _contextEntities.UserHistories.Remove(historyEntity);
            _contextEntities.SaveChanges();
        }
    }
}
