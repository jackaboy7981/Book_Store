using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace book_store.Models
{
    public class Category
    {
        [Key]
        public string Categoryid { get; set; }
        public string Categoryname { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public bool Status { get; set; }
        public int Position { get; set; }
        public DateTime Createdate { get; set; }

        public Category()
        { }

        public Category(string catid,string catname,string des, string imgurl, bool status, int pos, DateTime createdate)
        {
            Categoryid = catid;
            Categoryname = catname;
            Description = des;
            Img = imgurl;
            Status = status;
            Position = pos;
            Createdate = createdate;
        }

    }
}