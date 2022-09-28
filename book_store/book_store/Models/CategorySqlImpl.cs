using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace book_store.Models
{
    public class CategorySqlImpl : ICategoryRepository
    {
        SqlConnection conn;
        SqlCommand comm;

        public CategorySqlImpl()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Bookstoredb"].ConnectionString);
            comm = new SqlCommand();
        }

        public Category AddCategory(Category category)
        {
            comm.CommandText = "insert into Category (Categoryid, Categoryname, Description, Img, Status, Position) values ('" + category.Categoryid + "', '" + category.Categoryname + "', '" + category.Description + "', '" + category.Img + "', '" + category.Status + "', '" + category.Position + "')";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            if (row > 0)
            {
                return category;
            }
            else
            {
                return null;
            }
        }

        public int DeleteCategory(string id)
        {
            Debug.WriteLine("DELETE FROM Category WHERE Categoryid = '"+id+"'; ");
            comm.CommandText = "DELETE FROM Category WHERE Categoryid = '"+id+"'; ";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            return row;
        }

        public List<Category> GetAllCategories()
        {
            List<Category> list = new List<Category>();
            comm.CommandText = "select * from Category";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                string cid = reader["Categoryid"].ToString();
                string catname = reader["Categoryname"].ToString();
                string des = reader["Description"].ToString();
                string imgurl = reader["Img"].ToString();
                bool status = Convert.ToBoolean(reader["Status"]);
                int pos = Convert.ToInt32(reader["Position"]);
                DateTime createdate = Convert.ToDateTime(reader["Createdate"]);
                list.Add(new Category(cid, catname, des, imgurl, status, pos, createdate));
            }
            conn.Close();
            return list;
        }

        public Category GetCategoryById(string catid)
        {
            comm.CommandText = "select * from Category where Categoryid ='" + catid + "'";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            { 
                string cid = reader["Categoryid"].ToString();
                string catname = reader["Categoryname"].ToString();
                string des = reader["Description"].ToString();
                string imgurl = reader["Img"].ToString();
                bool status = Convert.ToBoolean(reader["Status"]);
                int pos = Convert.ToInt32(reader["Position"]);
                DateTime createdate = Convert.ToDateTime(reader["Createdate"]);
                Category cat = new Category(cid, catname, des, imgurl, status, pos, createdate);
                return cat;
            }
            conn.Close();
            return null;
        }

        public int UpdateCategory(string id, Category category)
        {
            Debug.WriteLine("UPDATE Category SET Categoryid = '"+category.Categoryid+"', Categoryname = '"+category.Categoryname+"', Description = '"+category.Description+"', Img = '"+category.Img+"', Status = "+category.Status+", Position = "+category.Position+" WHERE Categoryid = '"+id+"'; ");
            comm.CommandText = "UPDATE Category SET Categoryid = '"+category.Categoryid+"', Categoryname = '"+category.Categoryname+"', Description = '"+category.Description+"', Img = '"+category.Img+"', Status = '"+category.Status+"', Position = "+category.Position+"  WHERE Categoryid = '"+id+"'; ";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            return row;
        }
    }
}