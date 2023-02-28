using DataLogic.DBs;
using DataLogic.Interfaces;
using Logic.Managers;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Library_Of_Babel_Web_Application.Pages
{
    public class BookPageModel : PageModel
    {
        private readonly BookManager bookManager;
        private readonly IBookDB bookDB = new BookDB();
        [BindProperty]
        public Book bookObject { get; set; }

        public BookPageModel() 
        {
            bookManager = new BookManager(bookDB);
        }
        public void OnGet()
        {
        }

        public IEnumerable<Book> books => bookManager.GetAllBooks();
    }
}
