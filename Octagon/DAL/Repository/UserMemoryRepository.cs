using DAL.EntityModel;
using Octagon.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class UserMemoryRepository : IRepository<UserMemoryModel>
    {
        readonly UserDataEntities _contextEntities = new UserDataEntities();

        public void Create(UserMemoryModel item)
        {
            var model = new UserMemory {User_ID = item.UserId, Memory = item.Memory};
            _contextEntities.UserMemories.Add(model);
            _contextEntities.SaveChanges();
        }

        public void Update(UserMemoryModel item)
        {
            var model = new UserMemory { User_ID = item.UserId, Memory = item.Memory };
            _contextEntities.Entry(model).State  =  System.Data.Entity.EntityState.Modified;
            _contextEntities.SaveChanges();
        }

        public void Delete(UserMemoryModel item)
        {
            var model = new UserMemory { User_ID = item.UserId, Memory = item.Memory };
            _contextEntities.UserMemories.Remove(model);
            _contextEntities.SaveChanges();
        }

        public IList<UserMemoryModel> Select(int userId)
        {
            return _contextEntities.UserMemories.Where(i => i.User_ID == userId).Select(i => new UserMemoryModel
            {
                UserId = i.User_ID,
                Memory = i.Memory
            }).ToList();
        }
        
        public IList<UserMemoryModel> Select()
        {
            return _contextEntities.UserMemories.Select(i => new UserMemoryModel
            {
                UserId = i.User_ID,
                Memory = i.Memory
            }).ToList();
        }
    }
}
