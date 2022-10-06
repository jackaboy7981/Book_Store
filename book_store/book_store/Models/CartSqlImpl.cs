﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace book_store.Models
{
    public class CartSqlImpl : ICartRepository
    {
        SqlConnection conn;
        SqlCommand comm;

        public CartSqlImpl()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Bookstoredb"].ConnectionString);
            comm = new SqlCommand();
        }

        public Cart AddCart(Cart cart)
        {
            comm.CommandText = "insert into Cart (Userid, Bookid1, Qty1, Bookid2, Qty2, Bookid3, Qty3, Bookid4, Qty4, Bookid5, Qty5) values ('" + cart.Userid + "', '" + cart.Bookid1 + "', " + cart.Qty1 + ", '" + cart.Bookid2 + "', " + cart.Qty2 + ", '" + cart.Bookid3 + "', " + cart.Qty3 + ", '" + cart.Bookid4 + "', " + cart.Qty4 + ", '" + cart.Bookid5 + "', " + cart.Qty5 + ")";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            if (row > 0)
            {
                return cart;
            }
            else
            {
                return null;
            }
        }

        public int DeleteCart(string id)
        {
            Debug.WriteLine("DELETE FROM Cart WHERE Userid = '" + id + "'; ");
            comm.CommandText = "DELETE FROM Cart WHERE Userid = '" + id + "'; ";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            return row;
        }

        public List<Cart> GetAllCarts()
        {
            List<Cart> list = new List<Cart>();
            comm.CommandText = "select * from Cart";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                string uid = reader["Userid"].ToString();
                string bookid1 = reader["Bookid1"].ToString();
                int qty1 = Convert.ToInt32(reader["Qty1"]);
                string bookid2 = reader["Bookid2"].ToString();
                int qty2 = Convert.ToInt32(reader["Qty2"]);
                string bookid3 = reader["Bookid3"].ToString();
                int qty3 = Convert.ToInt32(reader["Qty3"]);
                string bookid4 = reader["Bookid4"].ToString();
                int qty4 = Convert.ToInt32(reader["Qty4"]);
                string bookid5 = reader["Bookid5"].ToString();
                int qty5 = Convert.ToInt32(reader["Qty5"]);
                list.Add(new Cart(uid, bookid1, qty1, bookid2, qty2, bookid3, qty3, bookid4, qty4, bookid5, qty5));
            }
            conn.Close();
            return list;
        }

        public Cart GetCartById(string userid)
        {
            comm.CommandText = "select * from Cart where Userid ='" + userid + "'";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                string uid = reader["Userid"].ToString();
                string bookid1 = reader["Bookid1"].ToString();
                int qty1 = Convert.ToInt32(reader["Qty1"]);
                string bookid2 = reader["Bookid2"].ToString();
                int qty2 = Convert.ToInt32(reader["Qty2"]);
                string bookid3 = reader["Bookid3"].ToString();
                int qty3 = Convert.ToInt32(reader["Qty3"]);
                string bookid4 = reader["Bookid4"].ToString();
                int qty4 = Convert.ToInt32(reader["Qty4"]);
                string bookid5 = reader["Bookid5"].ToString();
                int qty5 = Convert.ToInt32(reader["Qty5"]);
                Cart cart = new Cart(uid, bookid1, qty1, bookid2, qty2, bookid3, qty3, bookid4, qty4, bookid5, qty5);
                conn.Close();
                return cart;
            }
            conn.Close();
            return null;
        }

        public int UpdateCart(string id, Cart cart)
        {
            //Debug.WriteLine("UPDATE Category SET Categoryid = '" + category.Categoryid + "', Categoryname = '" + category.Categoryname + "', Description = '" + category.Description + "', Img = '" + category.Img + "', Status = " + category.Status + ", Position = " + category.Position + " WHERE Categoryid = '" + id + "'; ");
            comm.CommandText = "UPDATE Cart SET Bookid1 = '" + cart.Bookid1 + "', Qty1 = '" + cart.Qty1 + "', Bookid2 = '" + cart.Bookid2 + "', Qty2 = '" + cart.Qty2 + "', Bookid3 = '" + cart.Bookid3 + "', Qty3 = '" + cart.Qty3 + "', Bookid4 = '" + cart.Bookid4 + "', Qty4 = '" + cart.Qty4 + "', Bookid5 = '" + cart.Bookid5 + "', Qty5 = '" + cart.Qty5 + "'  WHERE Userid = '" + id + "'; ";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            return row;
        }
    }
}