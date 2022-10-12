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
    public class BookSqlImpl : IBookRepository
    {
        SqlConnection conn;
        SqlCommand comm;

        public BookSqlImpl()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Bookstoredb"].ConnectionString);
            comm = new SqlCommand();
        }

        [HttpPost]
        public Book AddBook(Book book)
        {
            Debug.WriteLine("insert into Book (Bookid, Categoryid, Title, Author, ISBN, Year, Price, Description, Position, Status, Img, Isfeatured) values ('" + book.Bookid + "', '" + book.Categoryid + "', '" + book.Title + "', '" + book.Author + "', '" + book.ISBN + "', '" + book.Year + "', " + book.Price + ", '" + book.Description + "', " + book.Position + ", " + book.Status + ", '" + book.Img + "', " + book.Isfeatured + ")");
            comm.CommandText = "insert into Book (Bookid, Categoryid, Title, Author, ISBN, Year, Price, Description, Position, Status, Img, Isfeatured) values ('" + book.Bookid + "', '" + book.Categoryid + "', '" + book.Title + "', '" + book.Author + "', '" + book.ISBN + "', '" + book.Year + "', " + book.Price + ", '" + book.Description + "', " + book.Position + ", '" + book.Status + "', '" + book.Img + "', '" + book.Isfeatured + "')";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            if (row > 0)
            {
                return book;
            }
            else
            {
                return null;
            }
        }

        public int DeleteBook(string id)
        {
            Debug.WriteLine("DELETE FROM Book WHERE Bookid = '" + id + "'; ");
            comm.CommandText = "DELETE FROM Book WHERE Bookid = '" + id + "'; ";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            return row;
        }

        public List<Book> GetAllBooks()
        {
            List<Book> list = new List<Book>();
            comm.CommandText = "select * from Book";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                string bid = reader["Bookid"].ToString();
                string cid = reader["Categoryid"].ToString();
                string title = reader["Title"].ToString();
                string author = reader["Author"].ToString();
                string isbn = reader["ISBN"].ToString();
                int year = Convert.ToInt32(reader["Year"]);
                float price = Convert.ToSingle(reader["Price"]);
                string des = reader["Description"].ToString();
                int pos = Convert.ToInt32(reader["Position"]);
                bool status = Convert.ToBoolean(reader["Status"]);
                string img = reader["Img"].ToString();
                bool isfeat = Convert.ToBoolean(reader["Isfeatured"]);
                DateTime createdate = Convert.ToDateTime(reader["Createdate"]);
                list.Add(new Book(bid, cid, title, author, isbn, year, price, des, pos, status, img, isfeat, createdate));
            }
            conn.Close();
            return list;
        }

        public List<Book> GetBooksNewArrival()
        {
            List<Book> list = new List<Book>();
            comm.CommandText = "select * from Book ORDER BY Createdate DESC";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                string bid = reader["Bookid"].ToString();
                string cid = reader["Categoryid"].ToString();
                string title = reader["Title"].ToString();
                string author = reader["Author"].ToString();
                string isbn = reader["ISBN"].ToString();
                int year = Convert.ToInt32(reader["Year"]);
                float price = Convert.ToSingle(reader["Price"]);
                string des = reader["Description"].ToString();
                int pos = Convert.ToInt32(reader["Position"]);
                bool status = Convert.ToBoolean(reader["Status"]);
                string img = reader["Img"].ToString();
                bool isfeat = Convert.ToBoolean(reader["Isfeatured"]);
                DateTime createdate = Convert.ToDateTime(reader["Createdate"]);
                list.Add(new Book(bid, cid, title, author, isbn, year, price, des, pos, status, img, isfeat, createdate));
            }
            conn.Close();
            return list;
        }

        public List<Book> GetBooksFeatured()
        {
            List<Book> list = new List<Book>();
            comm.CommandText = "select * from Book WHERE Isfeatured = 'true'";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                string bid = reader["Bookid"].ToString();
                string cid = reader["Categoryid"].ToString();
                string title = reader["Title"].ToString();
                string author = reader["Author"].ToString();
                string isbn = reader["ISBN"].ToString();
                int year = Convert.ToInt32(reader["Year"]);
                float price = Convert.ToSingle(reader["Price"]);
                string des = reader["Description"].ToString();
                int pos = Convert.ToInt32(reader["Position"]);
                bool status = Convert.ToBoolean(reader["Status"]);
                string img = reader["Img"].ToString();
                bool isfeat = Convert.ToBoolean(reader["Isfeatured"]);
                DateTime createdate = Convert.ToDateTime(reader["Createdate"]);
                list.Add(new Book(bid, cid, title, author, isbn, year, price, des, pos, status, img, isfeat, createdate));
            }
            conn.Close();
            return list;
        }

        public List<Book> GetBooksbyCategory(string catid)
        {
            List<Book> list = new List<Book>();
            comm.CommandText = "select * from Book WHERE Categoryid = '"+catid+"'";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                string bid = reader["Bookid"].ToString();
                string cid = reader["Categoryid"].ToString();
                string title = reader["Title"].ToString();
                string author = reader["Author"].ToString();
                string isbn = reader["ISBN"].ToString();
                int year = Convert.ToInt32(reader["Year"]);
                float price = Convert.ToSingle(reader["Price"]);
                string des = reader["Description"].ToString();
                int pos = Convert.ToInt32(reader["Position"]);
                bool status = Convert.ToBoolean(reader["Status"]);
                string img = reader["Img"].ToString();
                bool isfeat = Convert.ToBoolean(reader["Isfeatured"]);
                DateTime createdate = Convert.ToDateTime(reader["Createdate"]);
                list.Add(new Book(bid, cid, title, author, isbn, year, price, des, pos, status, img, isfeat, createdate));
            }
            conn.Close();
            return list;
        }

        public Book GetBookById(string id)
        {
            comm.CommandText = "select * from Book where Bookid ='" + id + "'";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                string bid = reader["Bookid"].ToString();
                string cid = reader["Categoryid"].ToString();
                string title = reader["Title"].ToString();
                string author = reader["Author"].ToString();
                string isbn = reader["ISBN"].ToString();
                int year = Convert.ToInt32(reader["Year"]);
                float price = Convert.ToSingle(reader["Price"]);
                string des = reader["Description"].ToString();
                int pos = Convert.ToInt32(reader["Position"]);
                bool status = Convert.ToBoolean(reader["Status"]);
                string img = reader["Img"].ToString();
                bool isfeat = Convert.ToBoolean(reader["Isfeatured"]);
                DateTime createdate = Convert.ToDateTime(reader["Createdate"]);
                Book book = new Book(bid, cid, title, author, isbn, year, price, des, pos, status, img, isfeat, createdate);
                conn.Close();
                return book;
            }
            conn.Close();
            return null;
        }

        public int UpdateBook(string id, Book book)
        {
            Debug.WriteLine("UPDATE Book SET Bookid = '" + book.Bookid + "',Categoryid = '" + book.Categoryid + "', Title = '" + book.Title + "', ISBN = '" + book.ISBN + "', Year = '" + book.Year + "', Price = '" + book.Price + "', Description = '" + book.Description + "', Position = " + book.Position + ", Status = " + book.Status + "Img = '" + book.Img + "',Isfeatured = " + book.Isfeatured + ", Createdate = '" + book.Createdate + "'  WHERE Categoryid = '" + id + "'; ");
            comm.CommandText = "UPDATE Book SET Bookid = '"+ book.Bookid +"',Categoryid = '" + book.Categoryid + "', Title = '" + book.Title + "', Author = '" + book.Author + "', ISBN = '" + book.ISBN + "', Year = '" + book.Year + "', Price = '" + book.Price + "', Description = '" + book.Description + "', Position = " + book.Position + ", Status = " + book.Status + "Img = '" + book.Img + "',Isfeatured = " + book.Isfeatured + ", Createdate = '" + book.Createdate + "'  WHERE Categoryid = '" + id + "'; ";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            return row;
        }
    }
}