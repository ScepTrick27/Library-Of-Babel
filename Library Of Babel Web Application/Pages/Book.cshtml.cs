using DataLogic.DBs;
using Logic.DTOs;
using Logic.Interfaces;
using Logic.Managers;
using Logic.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Library_Of_Babel_Web_Application.Pages
{
    [Authorize]
    public class BookModel : PageModel
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
        public bool ReviewdBook { get; set; }
        [BindProperty]
        public ReviewDTO ReviewObject { get; set; }

        public List<FavouriteBook> favouriteBooks = new List<FavouriteBook>();

        private readonly BookManager _bookManager;

        private readonly GenreManager _genreManager;

        private readonly FavouriteBookManager _favouriteBookManager;

        private readonly UserManager _userManager;

        private readonly ReviewManager _reviewManager;

        public List<Review> reviews = new List<Review>();

        public BookModel(BookManager bookManager, GenreManager genreManager, FavouriteBookManager favouriteBookManager, UserManager userManager, ReviewManager reviewManager)
        {
            _bookManager = bookManager;
            _genreManager = genreManager;
            _favouriteBookManager = favouriteBookManager;
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

            favouriteBooks = _favouriteBookManager.GetAllFavouriteBooksForUser(UserObject.PersonId);

            foreach (FavouriteBook fb in favouriteBooks)
            {
                if (BookObject.BookId == fb.Book.BookToBookDTO().BookId)
                {
                    IsBookInside = true;
                    break;
                }
            }

            reviews = _reviewManager.GetAllReviewsForABookById(BookObject.BookId);

            foreach (Review review in reviews)
            {
                if (UserObject.PersonId == review.User.PersonId && BookObject.BookId == review.Book.BookId)
                {
                    ReviewdBook = true;
                    break;
                }
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

            _favouriteBookManager.AddFavouriteBook(new FavouriteBook(new Logic.Classes.User(UserObject), new Logic.Book(BookObject)));

            return RedirectToPage("Index");
        }

        public IEnumerable<Genre> genres => _genreManager.GetAllGenres();
    }
}
