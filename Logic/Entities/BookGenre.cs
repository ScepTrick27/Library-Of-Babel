using Logic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{
    public class BookGenre
    {
        private Book book;
        private Genre genre;

        public BookGenre(Book book, Genre genre)
        {
            this.book = book;
            this.genre = genre;
        }

        public BookGenre(BookGenreDTO bookGenreDTO) 
        {
            this.book = new Book(bookGenreDTO.BookDTO);
            this.genre = new Genre(bookGenreDTO.GenreDTO);
        }

        public BookGenreDTO BookGenreToBookGenreDTO()
        {
            return new BookGenreDTO
            {
                BookDTO = book.BookToBookDTO(),
                GenreDTO = genre.GenreToGenreDTO()
            };
        }

        public Book Book { get => book; set => book = value; }
        public Genre Genre { get => genre; set => genre = value; }
    }
}
