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
            comm.CommandText = "insert into User_ (Name, Email, PasswordHash, PasswordSalt, Status, Isadmin) values ('" + user.Name + "', '" + user.Email + "',  CONVERT(VARBINARY(MAX), '" + user.PasswordHash + "'),  CONVERT(VARBINARY(MAX), '" + user.PasswordSalt + "'), '" + user.Status + "', '" + user.Isadmin + "')";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            if (row > 0)
            {
                return user;
            }
            else
            {
                return null;
            }
        }
    }
}