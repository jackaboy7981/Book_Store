using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace book_store.Models
{
    internal interface ICouponRepository
    {
        List<Coupon> GetAllCoupons();
        Coupon GetCouponById(string id);
        Coupon AddCoupon(Coupon coupon);
        int UpdateCoupon(string id, Coupon coupon);
        int DeleteCoupon(string id);
    }
}
