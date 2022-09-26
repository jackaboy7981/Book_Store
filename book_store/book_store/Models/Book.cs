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
        [Key]
        public string Bookid { get; set; }

        public string Categoryid { get; set; }

        [ForeignKey("Categoryid")]
        public virtual Category Category { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int Year { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public int Position { get; set; }
        public bool Status { get; set; }
        public string Img { get; set; }
    }
}