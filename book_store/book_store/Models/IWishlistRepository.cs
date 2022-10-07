using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace book_store.Models
{
    internal interface IWishlistRepository
    {
        //List<Cart> GetAllCarts();
        Wishlist GetWishlistById(string id);
        Wishlist AddWishlist(Wishlist wishlist);
        int UpdateWishlist(string id, Wishlist wishlist);
        int DeleteWishlist(string id);
        //int MoveToCart(string id);
    }
}
