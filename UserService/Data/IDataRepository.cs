using Microsoft.AspNetCore.Mvc;
using UserService.Model;

namespace UserService.Data
{
    public interface IDataRepository
    {
        ActionResult AddUser(User user);
        User GetById(int id);
        List<User> GetAll();
        ActionResult DeleteById(int id);
    }
}
