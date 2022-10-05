using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

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

        public User AddUser(User user)
        {
            User testuser = GetUserByid(user.Email);
            if( testuser == null)
            {
            comm.CommandText = "insert into User_ (Name, Email, PasswordHash, PasswordSalt, Status, Isadmin) values ('" + user.Name + "', '" + user.Email + "',  @Hash,  @Salt, '" + user.Status + "', '" + user.Isadmin + "')";
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
                Debug.WriteLine("\nPasswordhash = " + passwordHash + "\npasswordsalt =" + passwordSalt+"\n");
                User user= new User(name, email, passwordHash, passwordSalt, status, isadmin);
                return user;
            }
            conn.Close();
            return null;
        }

    }
}