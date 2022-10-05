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
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool Status { get; set; }
        public bool Isadmin { get; set; }

        public User()
        { }

        public User(string name, string email, byte[] passwordHash, byte[] passwordSalt, bool status, bool isadmin)
        {
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            Status = status;
            Isadmin = isadmin;
        }
    }
}