using DataLogic.DBs;
using Logic.Classes;
using Logic.Interfaces;
using Logic.Managers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System.Net;

namespace Library_Of_Babel_Web_Application.Pages
{
    public class LogInModel : PageModel
    {
        [BindProperty]
        public User UserObject { get; set; }
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
            UserObject = userManager.GetUserByAccount(UserObject.Email, UserObject.Password);
            if (UserObject.PersonId > -1)
            {
                try
                {
                    //HttpContext.Session.SetInt32("user_id", UserObject.PersonId);
                    Response.Cookies.Append("user_id", UserObject.PersonId.ToString());
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, UserObject.Email)
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    var props = new AuthenticationProperties();

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props);

                    return RedirectToPage("Index");
                }
                catch (Exception e)
                {
                    this.Message = "Invalid credentials";
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
