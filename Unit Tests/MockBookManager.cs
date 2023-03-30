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

            if (bookManager.AddBook(new Book("testTitle", "testDescription", "testAuthor", DateTime.Now, testImage)) == true)
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
        public void GetAllBooks()
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

    }
}
