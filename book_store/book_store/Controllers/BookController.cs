using book_store.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace book_store.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class BookController : ApiController
    {
        private IBookRepository bookrepository;
        private ICategoryRepository categoryrepository;

        public BookController()
        {
            bookrepository = new BookSqlImpl();
            categoryrepository = new CategorySqlImpl();
        }

        public IHttpActionResult GetAllBooks()
        {
            var data = bookrepository.GetBooksNewArrival();
            return Ok(data);
        }

        public IHttpActionResult Getbooksnewarrival()
        {
            var data = bookrepository.GetBooksNewArrival();
            return Ok(data);
        }

        public IHttpActionResult Getbooksfeatured()
        {
            var data = bookrepository.GetBooksFeatured();
            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult Getsearch(string id)
        {
            var bookdata = bookrepository.GetAllBooks();
            var categorydata = categoryrepository.GetAllCategories();
            List<Book> list = new List<Book>();
            for (int i =0;i<bookdata.Count; i++)
            {
                if(bookdata[i].Title.ToLower().Contains(id.ToLower()) || bookdata[i].Author.ToLower().Contains(id.ToLower()) || bookdata[i].ISBN.ToLower().Contains(id.ToLower()))
                {
                    list.Add(bookdata[i]);
                }
            }
            for (int i = 0; i < categorydata.Count; i++)
            {
                if (categorydata[i].Categoryname.ToLower().Contains(id.ToLower()))
                {
                    for(int j = 0;j<bookdata.Count;j++)
                    {
                        if(bookdata[j].Categoryid == categorydata[i].Categoryid)
                        {
                            list.Add(bookdata[j]);
                        }
                    }
                }
            }
            //Debug.WriteLine("\ncategory name : "+categorydata[0].Categoryname+"\n");

            return Ok(list);
        }

        [HttpGet]
        public IHttpActionResult Getbookbyid(string id)
        {
            var data = bookrepository.GetBookById(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult Addnewbook(Book book)
        {
            var data = bookrepository.AddBook(book);
            return Ok(data);
        }

        // PUT api/values/5
        public IHttpActionResult Updatebookdetails(string id, [FromBody] Book book)
        {
            var data = bookrepository.UpdateBook(id, book);

            return Ok(data);
        }

        // DELETE api/values/5
        public IHttpActionResult Deletebook(string id)
        {
            var data = bookrepository.DeleteBook(id);

            return Ok(data);
        }

    }
}
