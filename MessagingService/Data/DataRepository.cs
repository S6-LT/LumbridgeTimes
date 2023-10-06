using MessagingService.Model;
using Microsoft.AspNetCore.Mvc;

namespace MessagingService.Data
{
    public class DataRepository : IDataRepository
    {
        private readonly MessagingDbContext db;

        public DataRepository(MessagingDbContext db)
        {
            this.db = db;
        }

        public ActionResult AddMessage(Message message)
        {
            db.Message.Add(message);
            db.SaveChanges();
            return new OkResult();
        }

        public Message GetById(int id)
        {
            return db.Message.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Message> GetAll() => db.Message.ToList();

        public ActionResult DeleteById(int id)
        {
            db.Message.Remove(db.Message.Where(x => x.Id == id).FirstOrDefault());
            db.SaveChanges();
            return new OkResult();
        }
    }
}
