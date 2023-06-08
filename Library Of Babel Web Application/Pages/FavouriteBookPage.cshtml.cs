using Logic.DTOs;
using Logic.Managers;
using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logic.Entities;

namespace Library_Of_Babel_Web_Application.Pages
{
    [Authorize]
    public class FavouriteBookPageModel : PageModel
    {
        private readonly BookManager _bookManager;

        private readonly UserManager _userManager;

        private readonly FavouriteBookManager _favouriteBookManager;

        [BindProperty]
        public BookDTO bookObject { get; set; }

        public List<FavouriteBook> favouriteBooks = new List<FavouriteBook>();

        [BindProperty]
        public UserDTO UserObject { get; set; }

        public FavouriteBookPageModel(BookManager bookManager, UserManager userManager, FavouriteBookManager favouriteBookManager)
        {
            _bookManager = bookManager;
            _userManager = userManager;
            _favouriteBookManager = favouriteBookManager;
        }
        public void OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                string? id = User?.FindFirst("id")?.Value;

                if (id != null)
                {
                    UserObject = _userManager.GetUserByID(Convert.ToInt32(id)).UserToUserDTO();
                }
            }

            favouriteBooks = _favouriteBookManager.GetAllFavouriteBooksForUser(UserObject.PersonId);
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
    }
}
