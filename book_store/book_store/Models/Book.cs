using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace book_store.Models
{
    public class Book
    {
        [Key][Required]
        public string Bookid { get; set; }
        [Required]
        public string Categoryid { get; set; }

        [ForeignKey("Categoryid")]
        public virtual Category Category { get; set; }
        [Required]
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int Year { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public int Position { get; set; }
        [Required]
        public bool Status { get; set; }
        public string Img { get; set; }
        [Required]
        public bool Isfeatured { get; set; }
        public DateTime Createdate { get; set; }

        public Book()
        { }

        public Book(string bookid, string catid, string title, string author, string isbn,int year, float price, string des, int pos, bool status, string imgurl, bool isfeat, DateTime createdate)
        {
            Bookid = bookid; 
            Categoryid = catid;
            Title = title;
            Author = author;
            ISBN = isbn;
            Year = year;
            Price = price;
            Description = des;
            Position = pos;
            Status = status;
            Img = imgurl;
            Isfeatured = isfeat;
            Createdate = createdate;
        }
    }
}