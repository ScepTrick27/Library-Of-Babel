using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Interfaces;
using UnitTests;
using Logic.Managers;
using Logic;
using Logic.Entities;
using DataLogic.DBs;
using Logic.DTOs;

namespace Unit_Tests
{
    [TestClass]
    public class MockBookManager
    {
        byte[] testImage;
        [TestMethod]
        public void AddBook()
        {
            bool success;
            IBookDB bookDB = new MockBookDB();
            BookManager bookManager = new BookManager(bookDB);

            if (bookManager.AddBook(new Book("testTitle", "testDescription", "testAuthor", DateTime.Now, testImage, new Logic.Entities.Genre(1, "female"))) == true)
            {
                success = true;
            }
            else
            {
                success = false;
            }
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void VeifyBookList()
        {
            IBookDB bookDB = new MockBookDB();
            BookManager bookManager = new BookManager(bookDB);
            bool success;
            if (bookManager.GetAllBooks().Length > 0)
            {
                success = true;
            }
            else
            {
                success = false;
            }
            Assert.IsTrue(success);
        }

        public List<Book> GetAllBooks()
        {
            IBookDB bookDB = new MockBookDB();
            BookManager bookManager = new BookManager(bookDB);
            List<Book> books = new List<Book>();

            foreach (BookDTO b in bookDB.GetAllBooks())
            {
                books.Add(new Book(b));
            }

            return books;
        }

        [TestMethod]
        public void RecommendBooksByGenre_IfTheUserAddedBookToFavourites()
        {
            IBookDB bookDB = new MockBookDB();
            RecommendationManager recommendationManager = new RecommendationManager(bookDB);
            List<Book> books = GetAllBooks();

            var output = recommendationManager.GetRecommendedBooks("ByGenre", books, 1);

            Assert.AreEqual(2, output.Count);
            CollectionAssert.Contains(output, books[0]);
            CollectionAssert.Contains(output, books[1]);
        }

        [TestMethod]
        public void RecommendBookByRating_IfThereAreRatings()
        {
            IBookDB bookDB = new MockBookDB();
            RecommendationManager recommendationManager = new RecommendationManager(bookDB);
            List<Book> books = GetAllBooks();

            var output = recommendationManager.GetRecommendedBooks("ByRating", books, 1);

            Assert.AreEqual(3, output.Count);
            Assert.AreEqual(books[0], output[0]);
            Assert.AreEqual(books[1], output[1]);
        }
    }
}
