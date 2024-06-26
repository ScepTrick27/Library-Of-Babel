﻿using DataLogic.DBs;
using Logic.Interfaces;
using Logic.Managers;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logic.DTOs;
using Logic.Classes;
using Microsoft.AspNetCore.Identity;

namespace Library_Of_Babel_Web_Application.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly BookManager _bookManager;

        private readonly UserManager _userManager;

        [BindProperty]
        public BookDTO bookObject { get; set; }

        public List<Book> recommendedBooks = new List<Book>();

        [BindProperty]
        public UserDTO UserObject { get; set; }

        public IndexModel(ILogger<IndexModel> logger, BookManager bookManager, UserManager userManager)
        {
            _logger = logger;
            _bookManager = bookManager;
            _userManager = userManager;
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

        public IActionResult RecommendedPage()
        {
            return RedirectToPage("/RecommendedPage");
        }

        public IEnumerable<Book> books => _bookManager.GetAllBooks();
    }
}