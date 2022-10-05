using book_store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace book_store.Controllers
{
    public class UserController : ApiController
    {
        private IUserRepository repository;

        public UserController()
        {
            repository = new UserSqlImpl();
        }
        public IHttpActionResult UpdateStatus(User user)
        {
            var data = repository.UpdateUserStatus(user);

            return Ok(data);
        }

        public IHttpActionResult Updateshippingaddress(User user)
        {
            var data = repository.UpdateShippingAddress(user);

            return Ok(data);
        }
    }
}
