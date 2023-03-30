using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.DTOs;
using Logic.Interfaces;

namespace Logic.Managers
{
    public class BookManager
    {
        private readonly IBookDB bookDB;

        public BookManager(IBookDB bookDB)
        {
            this.bookDB = bookDB ?? throw new ArgumentNullException(nameof(bookDB));
        }

        public bool AddBook(Book book)
        {
            return bookDB.AddBook(book.BookToBookDTO());
        }

        public Book[] GetAllBooks()
        {
            List<Book> books = new List<Book>();

            foreach (BookDTO b in bookDB.GetAllBooks())
            {
                books.Add(new Book(b));
            }

            return books.ToArray();
        }
    }
}
