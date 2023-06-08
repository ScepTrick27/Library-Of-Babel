using Logic.DTOs;
using Logic.Entities;

namespace Logic
{
    public class Book
    {
        private int bookId;
        private string bookTitle;
        private string bookDescription;
        private string bookAuthor;
        private DateTime bookPublishDate;
        private byte[] bookImage;
        private Genre genre;
        private double averageRating;

        public Book(BookDTO bookDTO)
        {
            bookId = bookDTO.BookId;
            bookTitle = bookDTO.BookTitle;
            bookDescription = bookDTO.BookDescription;
            bookAuthor = bookDTO.BookAuthor;
            bookPublishDate = bookDTO.BookPublishDate;
            bookImage = bookDTO.BookImage;
            genre = new Genre(bookDTO.Genre);
        }

        public Book(string bookTitle, string bookDescription, string bookAuthor, DateTime bookPublishDate, byte[] bookImage, Genre genre)
        {
            this.bookTitle = bookTitle;
            this.bookDescription = bookDescription;
            this.bookAuthor = bookAuthor;
            this.bookPublishDate = bookPublishDate;
            this.bookImage = bookImage;
            this.genre = genre;
        }

        public BookDTO BookToBookDTO()
        {
            return new BookDTO()
            {
                BookId = this.bookId,
                BookTitle = this.bookTitle,
                BookDescription = this.bookDescription,
                BookAuthor = this.bookAuthor,
                BookPublishDate = this.bookPublishDate,
                BookImage = this.bookImage,
                Genre = this.Genre.GenreToGenreDTO()
            };
        }

        public int BookId { get => bookId; }
        public string BookTitle { get => bookTitle; }
        public string BookDescription { get => bookDescription; }
        public string BookAuthor { get => bookAuthor; }
        public DateTime BookPublishDate { get => bookPublishDate; }
        public byte[] BookImage { get => bookImage; }
        public Genre Genre { get => genre; }
        public double AverageRating { get => averageRating; set => averageRating = value; }

        public override string ToString()
        {
            return BookTitle;
        }
    }
}