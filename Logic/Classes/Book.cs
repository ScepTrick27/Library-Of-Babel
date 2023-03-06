﻿using DataLogic.DTOs;

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

        public Book() { }

        public Book(BookDTO bookDTO)
        {
            bookId = bookDTO.BookId;
            bookTitle = bookDTO.BookTitle;
            bookDescription = bookDTO.BookDescription;
            bookAuthor = bookDTO.BookAuthor;
            bookPublishDate= bookDTO.BookPublishDate;
            bookImage= bookDTO.BookImage;
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
            return new BookDTO(BookTitle, BookDescription, BookAuthor, BookPublishDate, BookImage);
        }

        public int BookId { get => bookId; set => bookId = value; }
        public string BookTitle { get => bookTitle; set => bookTitle = value; }
        public string BookDescription { get => bookDescription; set => bookDescription = value; }
        public string BookAuthor { get => bookAuthor; set => bookAuthor = value; }
        public DateTime BookPublishDate { get => bookPublishDate; set => bookPublishDate = value; }
        public byte[] BookImage { get => bookImage; set => bookImage = value; }

        public override string ToString()
        {
            return BookTitle;
        }
    }
}