using DAL.EntityModel;
using Octagon.DataModels;

namespace DAL.Services
{
    public class UserDataService : IServises<UserMemoryModel, UserHistoryModel, UserNameModel>
    {
        readonly UserDataEntities _contextEntities = new UserDataEntities();

        public void Create(UserMemoryModel userMemory, UserHistoryModel userHistory, UserNameModel userName)
        {
            var memoryEntity = new UserMemory { Memory = userMemory.Memory };

            var nameEntity = new UserName {User_ID = userName.UserId, Name = userName.Name};

            var historyEntity = new UserHistory
            {
                User_ID = userHistory.UserId,
                Expression = userHistory.Expression
            };

            _contextEntities.UserMemories.Add(memoryEntity);
            _contextEntities.UserNames.Add(nameEntity);
            _contextEntities.UserHistories.Add(historyEntity);
            _contextEntities.SaveChanges();
        }

        public void Update(UserMemoryModel userMemory, UserHistoryModel userHistory, UserNameModel userName)
        {
            var memoryEntity = new UserMemory { User_ID = userMemory.UserId, Memory = userMemory.Memory };

            var nameEntity = new UserName { User_ID = userName.UserId, Name = userName.Name };

            var historyEntity = new UserHistory
            {
                History_ID = userHistory.HistoryId,
                User_ID = userHistory.UserId,
                Expression = userHistory.Expression
            };

            _contextEntities.Entry(nameEntity).State = System.Data.Entity.EntityState.Modified;
            _contextEntities.Entry(memoryEntity).State = System.Data.Entity.EntityState.Modified;
            _contextEntities.Entry(historyEntity).State = System.Data.Entity.EntityState.Modified;
            _contextEntities.SaveChanges();
        }

        public void Delete(UserMemoryModel userMemory, UserHistoryModel userHistory, UserNameModel userName)
        {
            var memoryEntity = new UserMemory { User_ID = userMemory.UserId, Memory = userMemory.Memory };

            var nameEntity = new UserName { User_ID = userName.UserId, Name = userName.Name };

            var historyEntity = new UserHistory
            {
                History_ID = userHistory.HistoryId,
                User_ID = userHistory.UserId,
                Expression = userHistory.Expression
            };

            _contextEntities.UserHistories.Remove(historyEntity);
            _contextEntities.UserNames.Remove(nameEntity);
            _contextEntities.UserMemories.Remove(memoryEntity);
            _contextEntities.SaveChanges();
        }
    }
}
