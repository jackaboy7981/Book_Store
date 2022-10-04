using book_store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace book_store.Controllers
{
    public class BookController : ApiController
    {
        private IBookRepository repository;

        public BookController()
        {
            repository = new BookSqlImpl();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = repository.GetAllBooks();
            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            var data = repository.GetBookById(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult Post(Book book)
        {
            var data = repository.AddBook(book);
            return Ok(data);
        }

        // PUT api/values/5
        public IHttpActionResult Put(string id, [FromBody] Book book)
        {
            var data = repository.UpdateBook(id, book);

            return Ok(data);
        }

        // DELETE api/values/5
        public IHttpActionResult Delete(string id)
        {
            var data = repository.DeleteBook(id);

            return Ok(data);
        }
    }
}
