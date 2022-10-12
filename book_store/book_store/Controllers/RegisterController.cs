using book_store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web.Http;

namespace book_store.Controllers
{
    public class RegisterController : ApiController
    {
        public static User user = new User();
        private IUserRepository repository;
        private ICartRepository repositoryCart;
        private IWishlistRepository repositoryWishlist;

        public RegisterController()
        {
            repository = new UserSqlImpl();
            repositoryCart = new CartSqlImpl();
            repositoryWishlist = new WishlistSqlImpl();
        }

        [HttpPost]
        public IHttpActionResult Register(UserDTO request) 
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            //User user = new User();
            user.Name = request.Name;
            user.Email = request.Email;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Status = true;
            user.Isadmin = false;
            User returnuser = repository.AddUser(user);
            if (returnuser != null)
            {
                Cart cart = new Cart(user.Email,0,null, 0, null, 0, null, 0, null, 0, null, 0);
                var datac = repositoryCart.AddCart(cart);
                Wishlist wishlist = new Wishlist(user.Email, 0, null, null, null,  null, null);
                var dataw = repositoryWishlist.AddWishlist(wishlist);

                return Ok(user);
            }
            else 
            {
                string data = null;
                return Ok(data);
            }
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

    }
}
