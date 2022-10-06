using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace book_store.Models
{
    public class UserSqlImpl : IUserRepository
    {
        SqlConnection conn;
        SqlCommand comm;

        public UserSqlImpl()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Bookstoredb"].ConnectionString);
            comm = new SqlCommand();
        }
        [HttpPost]
        public User AddUser(User user)
        {
            User testuser = GetUserByid(user.Email);
            if( testuser == null)
            {
            comm.CommandText = "insert into User_ (Name, Email, PasswordHash, PasswordSalt, Status, Isadmin, Shippingaddress1, Shippingaddress2, Shippingaddress3) values ('" + user.Name + "', '" + user.Email + "',  @Hash,  @Salt, '" + user.Status + "', '" + user.Isadmin + "', '" + user.Shippingaddress1 + "', '" + user.Shippingaddress2 + "', '" + user.Shippingaddress3 + "')";
            comm.Connection = conn;
            comm.Parameters.AddWithValue("@Hash", user.PasswordHash);
            comm.Parameters.AddWithValue("@Salt", user.PasswordSalt);
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            return user;
            }
            return null;

        }

        [HttpGet]
        public User GetUserByid(string id)
        {
            comm.CommandText = "select * from User_ where Email ='" + id + "'";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                string name = reader["Name"].ToString();
                string email = reader["Email"].ToString();
                byte[] passwordHash = (byte[])reader["PasswordHash"];
                byte[] passwordSalt = (byte[])reader["PasswordSalt"];
                bool status = Convert.ToBoolean(reader["Status"]);
                bool isadmin = Convert.ToBoolean(reader["Isadmin"]);
                string shippingaddress1 = reader["Shippingaddress1"].ToString();
                string shippingaddress2 = reader["Shippingaddress2"].ToString();
                string shippingaddress3 = reader["Shippingaddress3"].ToString();

                //Debug.WriteLine("\nPasswordhash = " + passwordHash + "\npasswordsalt =" + passwordSalt+"\n");
                User user= new User(name, email, passwordHash, passwordSalt, status, isadmin, shippingaddress1, shippingaddress2, shippingaddress3);
                conn.Close();

                return user;
            }
            conn.Close();
            return null;
        }

        public int UpdateUserStatus(User user)
        {
            //Debug.WriteLine("UPDATE User_ SET  Status = '" + user.Status + "' WHERE Email = '" + user.Email + "'; ");
            comm.CommandText = "UPDATE User_ SET  Status = '" + user.Status + "' WHERE Email = '" + user.Email + "'; ";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            return row;
        }

        public int UpdateShippingAddress(User user)
        {
            //Debug.WriteLine("UPDATE User_ SET  Shippingaddress1 = '" + user.Shippingaddress1 + "', Shippingaddress2 = '" + user.Shippingaddress2 + "', Shippingaddress3 = '" + user.Shippingaddress3 + "' WHERE Email = '" + user.Email + "'; ");
            comm.CommandText = "UPDATE User_ SET  Shippingaddress1 = '" + user.Shippingaddress1 + "', Shippingaddress2 = '" + user.Shippingaddress2 + "', Shippingaddress3 = '" + user.Shippingaddress3 + "' WHERE Email = '" + user.Email + "'; ";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            return row;
        }
    }
}