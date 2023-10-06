using Microsoft.AspNetCore.Mvc;
using UserService.Model;

namespace UserService.Data
{
    public class DataRepository : IDataRepository
    {
        private readonly UserDbContext db;

        public DataRepository(UserDbContext db)
        {
            this.db = db;
        }

        public ActionResult AddUser(User user)
        {
            db.User.Add(user);
            db.SaveChanges();
            return new OkResult();
        }

        public User GetById(int id)
        {
            return db.User.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<User> GetAll() => db.User.ToList();

        public ActionResult DeleteById(int id)
        {
            db.User.Remove(db.User.Where(x => x.Id == id).FirstOrDefault());
            db.SaveChanges();
            return new OkResult();
        }
    }
}
