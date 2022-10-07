using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace book_store.Models
{
    public class WishlistSqlImpl: IWishlistRepository
    {
        SqlConnection conn;
        SqlCommand comm;

        public WishlistSqlImpl()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Bookstoredb"].ConnectionString);
            comm = new SqlCommand();
        }

        public Wishlist AddWishlist(Wishlist wishlist)
        {
            int count = 0;
            if (wishlist.Bookid1 == null)
            {
                wishlist.Bookid1 = "NULL";
            }
            else
            {
                count++;
                wishlist.Bookid1 = "'" + wishlist.Bookid1 + "'";
            }
            if (wishlist.Bookid2 == null)
            {
                wishlist.Bookid2 = "NULL";
            }
            else
            {
                count++;
                wishlist.Bookid2 = "'" + wishlist.Bookid2 + "'";
            }
            if (wishlist.Bookid3 == null)
            {
                wishlist.Bookid3 = "NULL";
            }
            else
            {
                count++;
                wishlist.Bookid3 = "'" + wishlist.Bookid3 + "'";
            }
            if (wishlist.Bookid4 == null)
            {
                wishlist.Bookid4 = "NULL";
            }
            else
            {
                count++;
                wishlist.Bookid4 = "'" + wishlist.Bookid4 + "'";
            }
            if (wishlist.Bookid5 == null)
            {
                wishlist.Bookid5 = "NULL";
            }
            else
            {
                count++;
                wishlist.Bookid5 = "'" + wishlist.Bookid5 + "'";
            }
            Debug.WriteLine("insert into Wishlist (Email, Itemsinwishlist, Bookid1, Bookid2, Bookid3, Bookid4, Bookid5) values ('" + wishlist.Email + "', " + count + ", " + wishlist.Bookid1 + ", " + wishlist.Bookid2 + ", " + wishlist.Bookid3 + ", " + wishlist.Bookid4 + ", " + wishlist.Bookid5 + ")");
            comm.CommandText = "insert into Wishlist (Email, Itemsinwishlist, Bookid1, Bookid2, Bookid3, Bookid4, Bookid5) values ('" + wishlist.Email + "', " + count + ", " + wishlist.Bookid1 + ", " + wishlist.Bookid2 + ", " + wishlist.Bookid3 + ", " + wishlist.Bookid4 + ", " + wishlist.Bookid5 + ")";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            if (row > 0)
            {
                return wishlist;
            }
            else
            {
                return null;
            }
        }

        public int DeleteWishlist(string id)
        {
            Debug.WriteLine("DELETE FROM Wishlist WHERE Email = '" + id + "'; ");
            comm.CommandText = "DELETE FROM Wishlist WHERE Email = '" + id + "'; ";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            return row;
        }

        public List<Wishlist> GetAllWishlist()
        {
            List<Wishlist> list = new List<Wishlist>();
            comm.CommandText = "select * from Wishlist";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                string email = reader["Email"].ToString();
                int itemsincart = Convert.ToInt32(reader["Itemsincart"]);
                string bookid1 = reader["Bookid1"].ToString();
                string bookid2 = reader["Bookid2"].ToString();
                string bookid3 = reader["Bookid3"].ToString();
                string bookid4 = reader["Bookid4"].ToString();
                string bookid5 = reader["Bookid5"].ToString();
                list.Add(new Wishlist(email, itemsincart, bookid1,  bookid2, bookid3, bookid4, bookid5));
            }
            conn.Close();
            return list;
        }

        public Wishlist GetWishlistById(string emailid)
        {
            comm.CommandText = "select * from Wishlist where Email ='" + emailid + "'";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                string email = reader["Email"].ToString();
                int itemsincart = Convert.ToInt32(reader["Itemsinwishlist"]);
                string bookid1 = reader["Bookid1"].ToString();
                string bookid2 = reader["Bookid2"].ToString();
                string bookid3 = reader["Bookid3"].ToString();
                string bookid4 = reader["Bookid4"].ToString();
                string bookid5 = reader["Bookid5"].ToString();
                Wishlist wishlist = new Wishlist(email, itemsincart, bookid1, bookid2, bookid3, bookid4, bookid5);
                conn.Close();
                return wishlist;
            }
            conn.Close();
            return null;
        }

        public int UpdateWishlist(string id, Wishlist wishlist)
        {
            int count = 0;
            if (wishlist.Bookid1 == null || wishlist.Bookid1 == "")
            {
                wishlist.Bookid1 = "NULL";
            }
            else
            {
                count++;
                wishlist.Bookid1 = "'" + wishlist.Bookid1 + "'";
            }
            if (wishlist.Bookid2 == null || wishlist.Bookid2 == "")
            {
                wishlist.Bookid2 = "NULL";
            }
            else
            {
                count++;
                wishlist.Bookid2 = "'" + wishlist.Bookid2 + "'";
            }
            if (wishlist.Bookid3 == null || wishlist.Bookid3 == "")
            {
                wishlist.Bookid3 = "NULL";
            }
            else
            {
                count++;
                wishlist.Bookid3 = "'" + wishlist.Bookid3 + "'";
            }
            if (wishlist.Bookid4 == null || wishlist.Bookid4 == "")
            {
                wishlist.Bookid4 = "NULL";
            }
            else
            {
                count++;
                wishlist.Bookid4 = "'" + wishlist.Bookid4 + "'";
            }
            if (wishlist.Bookid5 == null || wishlist.Bookid5 == "")
            {
                wishlist.Bookid5 = "NULL";
            }
            else
            {
                count++;
                wishlist.Bookid5 = "'" + wishlist.Bookid5 + "'";
            }
            //Debug.WriteLine("UPDATE Category SET Categoryid = '" + category.Categoryid + "', Categoryname = '" + category.Categoryname + "', Description = '" + category.Description + "', Img = '" + category.Img + "', Status = " + category.Status + ", Position = " + category.Position + " WHERE Categoryid = '" + id + "'; ");
            comm.CommandText = "UPDATE Wishlist SET Itemsinwishlist = " + count + ", Bookid1 = " + wishlist.Bookid1 + ", Bookid2 = " + wishlist.Bookid2 + ", Bookid3 = " + wishlist.Bookid3 + ", Bookid4 = " + wishlist.Bookid4 + ", Bookid5 = " + wishlist.Bookid5 + "  WHERE Email = '" + id + "'; ";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            return row;
        }

        public int MoveToCart(string id)
        {
            int data = 0;
            return data;
        }
    }
}