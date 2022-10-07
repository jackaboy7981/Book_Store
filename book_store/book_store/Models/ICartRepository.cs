using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace book_store.Models
{
    internal interface ICartRepository
    {
        List<Cart> GetAllCarts();
        Cart GetCartById(string id);
        Cart AddCart(Cart cart);
        int UpdateCart(string id, Cart cart);
        int DeleteCart(string id);
    }
}
