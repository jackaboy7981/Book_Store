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
        public string Shippingaddress1 { get; set; }
        public string Shippingaddress2 { get; set; }
        public string Shippingaddress3 { get; set; }
        public User()
        { }

        public User(string name, string email, byte[] passwordHash, byte[] passwordSalt, bool status, bool isadmin, string shippingaddress1, string shippingaddress2, string shippingaddress3)
        {
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            Status = status;
            Isadmin = isadmin;
            Shippingaddress1 = shippingaddress1;
            Shippingaddress2 = shippingaddress2;
            Shippingaddress3 = shippingaddress3;
        }
    }
}