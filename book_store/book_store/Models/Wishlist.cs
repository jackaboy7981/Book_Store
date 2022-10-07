using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace book_store.Models
{
    public class Wishlist
    {
        [Key][Required]
        public string Email { get; set; }
        public int Itemsinwishlist{ get; set; }
        public string Bookid1 { get; set; }
        public string Bookid2 { get; set; }
        public string Bookid3 { get; set; }
        public string Bookid4 { get; set; }
        public string Bookid5 { get; set; }

        public Wishlist() { }

        public Wishlist(string email, int itemsinwishlist, string bookid1, string bookid2, string bookid3, string bookid4, string bookid5)
        {
            Email = email;
            Itemsinwishlist = itemsinwishlist;
            Bookid1 = bookid1;
            Bookid2 = bookid2;
            Bookid3 = bookid3;
            Bookid4 = bookid4;
            Bookid5 = bookid5;
        }
    }
}