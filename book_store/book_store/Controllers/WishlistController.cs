using book_store.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace book_store.Controllers
{
    public class WishlistController : ApiController
    {
        private IWishlistRepository repository;
        private ICartRepository cartrepository;

        public WishlistController()
        {
            repository = new WishlistSqlImpl();
            cartrepository = new CartSqlImpl();
        }

        [HttpGet]
        public IHttpActionResult Getwishlistbyid(string id)
        {
            var data = repository.GetWishlistById(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult Addnewwishlist(Wishlist wishlist)
        {
            var data = repository.AddWishlist(wishlist);
            return Ok(data);
        }

        // PUT api/values/5
        public IHttpActionResult Updatewishlist(string id, [FromBody] Wishlist wishlist)
        {
            var data = repository.UpdateWishlist(id, wishlist);

            return Ok(data);
        }

        // DELETE api/values/5
        public IHttpActionResult Deletewishlist(string id)
        {
            var data = repository.DeleteWishlist(id);

            return Ok(data);
        }

        [HttpGet, Authorize]
        public IHttpActionResult Movetocart(string id)
        {
            var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();  
            var email = claims?.Where(c => c.Type == ClaimTypes.Email).Select(c => c.Value).SingleOrDefault();
            Debug.WriteLine("\nEmail = "+email+"\n");
            var wishlist = repository.GetWishlistById(email);
            var cart = cartrepository.GetCartById(email);

            if(cart.Itemsincart<5)
            {
                if (wishlist.Bookid1 == id)
                {
                    wishlist.Bookid1 = wishlist.Bookid2;
                    wishlist.Bookid2 = wishlist.Bookid3;
                    wishlist.Bookid3 = wishlist.Bookid4;
                    wishlist.Bookid4 = wishlist.Bookid5;
                    wishlist.Bookid5 = null;
                    wishlist.Itemsinwishlist--;
                }
                else if (wishlist.Bookid2 == id)
                {
                    wishlist.Bookid2 = wishlist.Bookid3;
                    wishlist.Bookid3 = wishlist.Bookid4;
                    wishlist.Bookid4 = wishlist.Bookid5;
                    wishlist.Bookid5 = null;
                    wishlist.Itemsinwishlist--;
                }
                else if (wishlist.Bookid3 == id)
                {
                    wishlist.Bookid3 = wishlist.Bookid4;
                    wishlist.Bookid4 = wishlist.Bookid5;
                    wishlist.Bookid5 = null;
                    wishlist.Itemsinwishlist--;
                }
                else if (wishlist.Bookid4 == id)
                {
                    wishlist.Bookid4 = wishlist.Bookid5;
                    wishlist.Bookid5 = null;
                    wishlist.Itemsinwishlist--;
                }
                else if (wishlist.Bookid5 == id)
                {
                    wishlist.Bookid5 = null;
                    wishlist.Itemsinwishlist--;
                }

                if (cart.Itemsincart == 0) { cart.Bookid1 = id;cart.Qty1 = 1; cart.Itemsincart++; }
                else if(cart.Itemsincart == 1) { cart.Bookid2 = id; cart.Qty2 = 1; cart.Itemsincart++; }
                else if (cart.Itemsincart == 2) { cart.Bookid3 = id; cart.Qty3 = 1; cart.Itemsincart++; }
                else if (cart.Itemsincart == 3) { cart.Bookid4 = id; cart.Qty4 = 1; cart.Itemsincart++; }
                else if (cart.Itemsincart == 4) { cart.Bookid5 = id; cart.Qty5 = 1; cart.Itemsincart++; }
                var cartdata = cartrepository.UpdateCart(email, cart);
                var wishlistdata = repository.UpdateWishlist(email, wishlist);
                List<object> list = new List<object>
                {
                    cartdata,
                    wishlistdata
                };
                return Ok(list);
            }
            //Debug.WriteLine("\nEmail = "+email+"\n");
            //var data = repository.MoveToCart(id, );
            return Ok(0);
        }
    }
}
