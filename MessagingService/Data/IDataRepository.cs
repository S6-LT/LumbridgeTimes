using MessagingService.Model;
using Microsoft.AspNetCore.Mvc;

namespace MessagingService.Data
{
    public interface IDataRepository
    {
        ActionResult AddMessage(Message message);
        Message GetById(int id);
        List<Message> GetAll();
        ActionResult DeleteById(int id);
    }
}
