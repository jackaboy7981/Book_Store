using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace book_store.Models
{
    internal interface IBookRepository
    {
        List<Book> GetAllBooks();
        List<Book> GetBooksNewArrival();
        List<Book> GetBooksFeatured();
        Book GetBookById(string id);
        Book AddBook(Book book);
        int UpdateBook(string id, Book book);
        int DeleteBook(string id);
        List<Book> GetBooksbyCategory(string catid);


    }
}
