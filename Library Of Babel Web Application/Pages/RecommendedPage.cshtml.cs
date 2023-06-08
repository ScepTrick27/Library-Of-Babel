using DataLogic.DBs;
using Logic.DTOs;
using Logic.Interfaces;
using Logic.Managers;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library_Of_Babel_Web_Application.Pages
{
    public class RecommendedPageModel : PageModel
    {
        private readonly BookManager _bookManager;

        private readonly UserManager _userManager;

        private readonly RecommendationManager _recommendationManager;
        [BindProperty]
        public BookDTO bookObject { get; set; }

        public List<Book> recommendedBooks = new List<Book>();

        [BindProperty]
        public UserDTO UserObject { get; set; }

        public string name;

        public RecommendedPageModel(BookManager bookManager, UserManager userManager, RecommendationManager recommendationManager)
        {
            _bookManager = bookManager;
            _userManager = userManager;
            _recommendationManager = recommendationManager;
        }
        public void OnGet()
        {
            name = Request.Query["name"];
            if (User.Identity.IsAuthenticated)
            {
                string? id = User?.FindFirst("id")?.Value;

                if (id != null)
                {
                    UserObject = _userManager.GetUserByID(Convert.ToInt32(id)).UserToUserDTO();
                }
                recommendedBooks = _recommendationManager.GetRecommendedBooks(name, books.ToList(), UserObject.PersonId);
            }

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

        public IEnumerable<Book> books => _bookManager.GetAllBooks();
    }
}
