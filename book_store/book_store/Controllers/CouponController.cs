using book_store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace book_store.Controllers
{
    public class CouponController : ApiController
    {
        private ICouponRepository repository;

        public CouponController()
        {
            repository = new CouponSqlImpl();
        }

        [HttpGet, Authorize(Roles ="True")]
        public IHttpActionResult Getallcoupons()
        {
            var data = repository.GetAllCoupons();
            return Ok(data);
        }

        [HttpGet, Authorize(Roles = "True")]
        public IHttpActionResult Getcouponbyid(string id)
        {
            var data = repository.GetCouponById(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpPost, Authorize(Roles = "True")]
        public IHttpActionResult Addnewcoupon(Coupon coupon)
        {
            var data = repository.AddCoupon(coupon);
            return Ok(data);
        }

        // PUT api/values/5
        [Authorize(Roles = "True")]
        public IHttpActionResult Updatecoupon(string id, [FromBody] Coupon coupon)
        {
            var data = repository.UpdateCoupon(id, coupon);

            return Ok(data);
        }

        // DELETE api/values/5
        [Authorize(Roles = "True")]
        public IHttpActionResult Deletecoupon(string id)
        {
            var data = repository.DeleteCoupon(id);

            return Ok(data);
        }
    }
}
