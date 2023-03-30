using Logic.DTOs;

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

        public Book(BookDTO bookDTO)
        {
            bookId = bookDTO.BookId;
            bookTitle = bookDTO.BookTitle;
            bookDescription = bookDTO.BookDescription;
            bookAuthor = bookDTO.BookAuthor;
            bookPublishDate = bookDTO.BookPublishDate;
            bookImage = bookDTO.BookImage;
        }

        public Book(string bookTitle, string bookDescription, string bookAuthor, DateTime bookPublishDate, byte[] bookImage)
        {
            this.bookTitle = bookTitle;
            this.bookDescription = bookDescription;
            this.bookAuthor = bookAuthor;
            this.bookPublishDate = bookPublishDate;
            this.bookImage = bookImage;
        }

        public BookDTO BookToBookDTO()
        {
            return new BookDTO()
            {
                BookTitle = this.bookTitle,
                BookDescription = this.bookDescription,
                BookAuthor = this.bookAuthor,
                BookPublishDate = this.bookPublishDate,
                BookImage = this.bookImage
            };
        }

        public int BookId { get => bookId; }
        public string BookTitle { get => bookTitle; }
        public string BookDescription { get => bookDescription; }
        public string BookAuthor { get => bookAuthor; }
        public DateTime BookPublishDate { get => bookPublishDate; }
        public byte[] BookImage { get => bookImage; }

        public override string ToString()
        {
            return BookTitle;
        }
    }
}