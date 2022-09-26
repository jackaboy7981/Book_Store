using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace book_store.Models
{
    public class User
    {
        public string Name { get; set; }
        [Key]
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public bool Isadmin { get; set; }
    }
}