using DataLogic.DBs;
using Logic.DTOs;
using Logic.Interfaces;
using Logic.Managers;
using Logic.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Library_Of_Babel_Web_Application.Pages
{
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
        
        public List<FavouriteBook> favouriteBooks = new List<FavouriteBook>();

        private readonly BookManager bookManager;
        private readonly IBookDB bookDB = new BookDB();

        private readonly GenreManager genreManager;
        private readonly IGenreDB genreDB = new GenreDB();

        private readonly BookGenreManager bookGenreManager;
        private readonly IBookGenreDB bookGenreDB = new BookGenreDB();

        private readonly FavouriteBookManager favouriteBookManager;
        private readonly IFavouriteBookDB favouriteBookDB = new FavouriteBookDB();

        private readonly UserManager userManager;
        private readonly IUserDB userDB = new UserDB();

        public BookModel()
        {
            bookManager = new BookManager(bookDB);
            genreManager = new GenreManager(genreDB);
            bookGenreManager = new BookGenreManager(bookGenreDB);
            favouriteBookManager = new FavouriteBookManager(favouriteBookDB);
            userManager = new UserManager(userDB);
            
        }
        public void OnGet()
        {
            BookObject = bookManager.GetBookById(HttpContext.Session.GetInt32("book_id").Value).BookToBookDTO();
            string? id = User?.FindFirst("id")?.Value;

            if (id != null)
            {
                UserObject = userManager.GetUserByID(Convert.ToInt32(id)).UserToUserDTO();
            }

            favouriteBooks = favouriteBookManager.GetAllFavouriteBooksForUser(UserObject.PersonId);
        }

        public IActionResult OnPost()
        {
            GenreObject = genreManager.GetGenreById(GenreId).GenreToGenreDTO();
            BookObject = bookManager.GetBookById(HttpContext.Session.GetInt32("book_id").Value).BookToBookDTO();

            string? id = User?.FindFirst("id")?.Value;

            if (id != null)
            {
                UserObject = userManager.GetUserByID(Convert.ToInt32(id)).UserToUserDTO();
            }

            bookGenreManager.AddBookGenre(new BookGenre(new Logic.Book(BookObject), new Genre(GenreObject)));
            favouriteBookManager.AddFavouriteBook(new FavouriteBook(new Logic.Classes.User(UserObject), new Logic.Book(BookObject)));

            return Page();
        }
        public IEnumerable<Genre> genres => genreManager.GetAllGenres();
    }
}
