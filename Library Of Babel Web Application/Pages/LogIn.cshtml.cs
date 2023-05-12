using DataLogic.DBs;
using Logic.DTOs;
using Logic.Interfaces;
using Logic.Managers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System.Net;
using Logic.Exceptions;

namespace Library_Of_Babel_Web_Application.Pages
{
    public class LogInModel : PageModel
    {
        [BindProperty]
        public UserDTO UserObject { get; set; }
        [BindProperty]
        public string Message { get; set; }

        private readonly UserManager userManager;
        private readonly IUserDB userDB = new UserDB();

        public LogInModel()
        {
            userManager = new UserManager(userDB);
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            UserObject = userManager.GetUserByAccount(UserObject.Email, UserObject.Password).UserToUserDTO();
            if (UserObject.PersonId > -1)
            {
                try
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, UserObject.Email),
                        new Claim("id", UserObject.PersonId.ToString())
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    var props = new AuthenticationProperties();

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props);

                    return RedirectToPage("Index");
                }
                catch (UserException e)
                {
                    this.Message = "Invalid credentials";
                    ModelState.AddModelError("Invalid Credentials", e.Message);
                    return Page();
                }
            }
            else
            {
                this.Message = "Invalid credentials";
                return Page();
            }
        }
    }
}
