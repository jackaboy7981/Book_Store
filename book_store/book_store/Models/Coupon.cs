using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace book_store.Models
{
    public class Coupon
    {
        [Key]
        public string Couponcode { get; set; }
        public int Discountpercentage { get; set; }

        public Coupon() { }

        public Coupon(string couponcode, int discountpercentage)
        {
            Couponcode = couponcode;
            Discountpercentage = discountpercentage;
        }
    }
}