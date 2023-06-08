using DataLogic.DBs;
using Logic.DTOs;
using Logic.Entities;
using Logic.Interfaces;
using Logic.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Library_Of_Babel_Web_Application.Pages
{
    public class AddReviewPageModel : PageModel
    {
        [BindProperty]
        public BookDTO BookObject { get; set; }
        [BindProperty]
        public GenreDTO GenreObject { get; set; }
        [BindProperty]
        public UserDTO UserObject { get; set; }
        [BindProperty]
        public int GenreId { get; set; }
        [BindProperty]
        public bool IsBookInside { get; set; }
        [BindProperty]
        public ReviewDTO ReviewObject { get; set; }

        public List<FavouriteBook> favouriteBooks = new List<FavouriteBook>();

        private readonly BookManager _bookManager;
 

        private readonly UserManager _userManager;

        private readonly ReviewManager _reviewManager;

        public List<Review> reviews = new List<Review>();

        public AddReviewPageModel(BookManager bookManager, UserManager userManager, ReviewManager reviewManager)
        {
            _bookManager = bookManager;
            _userManager = userManager;
            _reviewManager = reviewManager;

        }
        public void OnGet()
        {
            BookObject = _bookManager.GetBookById(HttpContext.Session.GetInt32("book_id").Value).BookToBookDTO();
            string? id = User?.FindFirst("id")?.Value;

            if (id != null)
            {
                UserObject = _userManager.GetUserByID(Convert.ToInt32(id)).UserToUserDTO();
            }
        }

        public IActionResult OnPost()
        {
            BookObject = _bookManager.GetBookById(HttpContext.Session.GetInt32("book_id").Value).BookToBookDTO();

            string? id = User?.FindFirst("id")?.Value;

            if (id != null)
            {
                UserObject = _userManager.GetUserByID(Convert.ToInt32(id)).UserToUserDTO();
            }

            ReviewObject.UserDTO = UserObject;
            ReviewObject.BookDTO = BookObject;

            _reviewManager.AddReview(new Review(ReviewObject));

            return RedirectToPage("Book");
        }
    }
}
