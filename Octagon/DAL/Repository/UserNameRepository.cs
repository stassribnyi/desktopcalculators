using DAL.EntityModel;
using Octagon.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class UserNameRepository : IRepository<UserNameModel>
    {
        private readonly UserDataEntities _contextEntities = new UserDataEntities();

        public void Create(UserNameModel item)
        {
            var model = new UserName
            {
                User_ID = item.UserId,
                Name = item.Name
            };
            _contextEntities.UserNames.Add(model);
            _contextEntities.SaveChanges();
        }

        public void Update(UserNameModel item)
        {
            var model = new UserName
            {
                User_ID = item.UserId,
                Name = item.Name
            };
            _contextEntities.Entry(model).State = System.Data.Entity.EntityState.Modified;
            _contextEntities.SaveChanges();
        }

        public void Delete(UserNameModel item)
        {
            var model = new UserName
            {
                User_ID = item.UserId,
                Name = item.Name
            };
            _contextEntities.UserNames.Remove(model);
            _contextEntities.SaveChanges();
        }

        public IList<UserNameModel> Select(int userId)
        {
            return _contextEntities.UserNames.Where(item => item.User_ID == userId).Select(i => new UserNameModel()
            {
                UserId = i.User_ID,
                Name = i.Name
            }).ToList();
        }

        public IList<UserNameModel> Select()
        {
            return _contextEntities.UserNames.Select(i => new UserNameModel()
            {
                UserId = i.User_ID,
                Name = i.Name
            }).ToList();
        }
    }
}
