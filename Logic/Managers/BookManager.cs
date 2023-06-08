using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Logic.DTOs;
using Logic.Entities;
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

        public List<ValidationResult> TryAddBook(Book book)
        {
            BookDTO bookDTO = book.BookToBookDTO();
            List<ValidationResult> validationResults = new List<ValidationResult>();
            if (Validator.TryValidateObject(bookDTO, new ValidationContext(bookDTO), validationResults, true))
            {
                bookDB.AddBook(bookDTO);
            }
            return validationResults;
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

        public Book GetBookById(int id)
        {
            return new Book(bookDB.GetBookById(id));
        }

        public List<FavouriteBook> GetAllFavouriteBooksForUser(int id)
        {
            List<FavouriteBook> favouriteBooks = new List<FavouriteBook>();

            foreach (FavouriteBookDTO favouriteBook in bookDB.GetAllFavouriteBooksForUser(id))
            {
                favouriteBooks.Add(new FavouriteBook(favouriteBook));
            }

            return favouriteBooks;
        }

        public List<Review> GetAllReviews()
        {
            List<Review> reviews = new List<Review>();

            foreach (ReviewDTO r in bookDB.GetAllReviews())
            {
                reviews.Add(new Review(r));
            }

            return reviews;
        }
    }
}
