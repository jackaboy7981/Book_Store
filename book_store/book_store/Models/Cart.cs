using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace book_store.Models
{
    public class Cart
    {
        [Key][Required]
        public string Userid { get; set; }
        public string Bookid1 { get; set; }
        public int Qty1 { get; set; }
        public string Bookid2 { get; set; }
        public int Qty2 { get; set; }
        public string Bookid3 { get; set; }
        public int Qty3 { get; set; }
        public string Bookid4 { get; set; }
        public int Qty4 { get; set; }
        public string Bookid5 { get; set; }
        public int Qty5 { get; set; }

        public Cart() { }

        public Cart(string uid,string bookid1,int qty1,string bookid2,int qty2,string bookid3,int qty3,string bookid4,int qty4,string bookid5,int qty5)
        {
            Userid = uid;
            Bookid1 = bookid1;
            Qty1 = qty1;
            Bookid2 = bookid2;
            Qty2 = qty2;
            Bookid3 = bookid3;
            Qty3 = qty3;
            Bookid4 = bookid4;
            Qty4 = qty4;
            Bookid5 = bookid5;
            Qty5 = qty5;
        }
    }
}