using DataLogic.DBs;
using Logic.Interfaces;
using Logic.Managers;
using Logic.DTOs ;
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
        public BookDTO bookObject { get; set; }

        //public List<BookDTO> bookss = new List<BookDTO>();

        public BookPageModel() 
        {
            bookManager = new BookManager(bookDB);
        }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (bookObject.BookId != -1)
            {
                HttpContext.Session.SetInt32("book_id", bookObject.BookId);
                return RedirectToPage("/Book");
            }
            else
            {
                return Page();
            }
        }

        public IEnumerable<Book> books => bookManager.GetAllBooks();
    }
}
