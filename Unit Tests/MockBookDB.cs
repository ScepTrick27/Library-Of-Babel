using DataLogic.DBs;
using Logic.DTOs;
using Logic.Interfaces;
using Logic;

namespace UnitTests
{
    public class MockBookDB : IBookDB
    {
        BookDTO book = new BookDTO();
        List<BookDTO> books;

        public bool AddBook(BookDTO bookDTO)
        {
            books = new List<BookDTO>
            {
                bookDTO
            };
            if (books.Count > 0)
            {
                return true;
            }
            return false;
        }

        public BookDTO[] GetAllBooks()
        {
            books = new List<BookDTO>
            {
                book
            };
            return books.ToArray();
        }
    }

}