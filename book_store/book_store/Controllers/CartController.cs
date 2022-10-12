using book_store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace book_store.Controllers
{
    public class CartController : ApiController
    {
        private ICartRepository repository;

        public CartController()
        {
            repository = new CartSqlImpl();
        }

        [HttpGet, Authorize(Roles = "True")]
        public IHttpActionResult Getallcarts()
        {
            var data = repository.GetAllCarts();
            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult Getcartbyid(string id)
        {
            var data = repository.GetCartById(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }


        // PUT api/values/5
        public IHttpActionResult UpdateWishlist(string id, [FromBody] Cart cart)
        {
            var data = repository.UpdateCart(id, cart);

            return Ok(data);
        }

        // DELETE api/values/5
        public IHttpActionResult Deletecart(string id)
        {
            var data = repository.DeleteCart(id);

            return Ok(data);
        }
    }
}
