using Logic.DTOs;
using Logic.Interfaces;
using Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Managers
{
    public class BookGenreManager
    {
        private readonly IBookGenreDB bookGenreDB;

        public BookGenreManager(IBookGenreDB bookGenreDB)
        {
            this.bookGenreDB = bookGenreDB ?? throw new ArgumentNullException(nameof(bookGenreDB));
        }

        public bool AddBookGenre(BookGenre bookGenre)
        {
            return bookGenreDB.AddBookGenre(bookGenre.BookGenreToBookGenreDTO());
        }

        public List<BookGenre> GetAllGenresForABookById(int bookId)
        {
            List<BookGenre> bookGenres = new List<BookGenre>();

            foreach (BookGenreDTO bg in bookGenreDB.GetAllGenresForABookById(bookId))
            {
                bookGenres.Add(new BookGenre(bg));
            }

            return bookGenres;
        }
    }
}
