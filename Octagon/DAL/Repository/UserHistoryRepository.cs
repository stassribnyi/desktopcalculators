using DAL.EntityModel;
using Octagon.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class UserHistoryRepository : IRepository<UserHistoryModel>
    {
        private readonly UserDataEntities _contextEntities = new UserDataEntities();

        public void Create(UserHistoryModel item)
        {
            var model = new UserHistory
            {
                History_ID = item.HistoryId,
                User_ID = item.UserId,
                Expression = item.Expression
            };
            _contextEntities.UserHistories.Add(model);
            _contextEntities.SaveChanges();
        }

        public void Update(UserHistoryModel item)
        {
            var model = new UserHistory
            {
                History_ID = item.HistoryId,
                User_ID = item.UserId,
                Expression = item.Expression
            };
            _contextEntities.Entry(model).State = System.Data.Entity.EntityState.Modified;
            _contextEntities.SaveChanges();
        }

        public void Delete(UserHistoryModel item)
        {
            var model = new UserHistory
            {
                History_ID = item.HistoryId,
                User_ID = item.UserId,
                Expression = item.Expression
            };
            _contextEntities.UserHistories.Remove(model);
            _contextEntities.SaveChanges();
        }

        public IList<UserHistoryModel> Select(int userId)
        {
            return _contextEntities.UserHistories.Where(item => item.User_ID == userId).Select(i => new UserHistoryModel
            {
                HistoryId = i.History_ID,
                UserId = i.User_ID,
                Expression = i.Expression
            }).ToList();
        }


        public IList<UserHistoryModel> Select()
        {
            return _contextEntities.UserHistories.Select(i => new UserHistoryModel
            {
                HistoryId = i.History_ID,
                UserId = i.User_ID,
                Expression = i.Expression
            }).ToList();
        }
    }
}
