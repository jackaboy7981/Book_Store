using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace book_store.Models
{
    internal interface IUserRepository
    {
        //List<User> GetAllUsers();
        //User GetUserById(string id);
        User AddUser(User user);
        //int UpdateUser(string id, User user);
        //int DeleteUser(string id);
    }
}
