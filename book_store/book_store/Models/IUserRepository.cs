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
        User GetUserByid(string id);
        User AddUser(User user);
        int UpdateUserStatus(User user);
        int UpdateShippingAddress(User user);
        //int DeleteUser(string id);
    }
}
