using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace book_store.Models
{
    public class CouponSqlImpl : ICouponRepository
    {
        SqlConnection conn;
        SqlCommand comm;

        public CouponSqlImpl()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Bookstoredb"].ConnectionString);
            comm = new SqlCommand();
        }

        public Coupon AddCoupon(Coupon coupon)
        {
            comm.CommandText = "insert into Coupon (Couponcode,Discountpercentage) values ('" + coupon.Couponcode + "', '" + coupon.Discountpercentage + "')";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            if (row > 0)
            {
                return coupon;
            }
            else
            {
                return null;
            }
        }

        public int DeleteCoupon(string id)
        {
            //Debug.WriteLine("DELETE FROM Category WHERE Couponcode = '" + id + "'; ");
            comm.CommandText = "DELETE FROM Coupon WHERE Couponcode = '" + id + "'; ";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            return row;
        }

        public List<Coupon> GetAllCoupons()
        {
            List<Coupon> list = new List<Coupon>();
            comm.CommandText = "select * from Coupon";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                string couponcode = reader["Couponcode"].ToString();
                int discountpercentage = Convert.ToInt32(reader["Discountpercentage"]);
                list.Add(new Coupon(couponcode, discountpercentage));
            }
            conn.Close();
            return list;
        }

        public Coupon GetCouponById(string coupid)
        {
            comm.CommandText = "select * from Coupon where Couponcode ='" + coupid + "'";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                string couponcode = reader["Couponcode"].ToString();
                int discountpercentage = Convert.ToInt32(reader["Discountpercentage"]);
                Coupon cop = new Coupon(couponcode, discountpercentage);
                return cop;
            }
            conn.Close();
            return null;
        }

        public int UpdateCoupon(string id, Coupon coupon)
        {
            Debug.WriteLine("UPDATE Coupon SET Couponcode = '" + coupon.Couponcode + "', Discountpercentage = " + coupon.Discountpercentage + "  WHERE Couponcode = '" + id + "'; ");
            comm.CommandText = "UPDATE Coupon SET Couponcode = '" + coupon.Couponcode + "', Discountpercentage = " + coupon.Discountpercentage + "  WHERE Couponcode = '" + id + "'; ";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            return row;
        }
    }
}