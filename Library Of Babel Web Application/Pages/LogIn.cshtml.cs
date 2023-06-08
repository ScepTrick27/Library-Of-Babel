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
using Microsoft.AspNetCore.Components;

namespace Library_Of_Babel_Web_Application.Pages
{
    public class LogInModel : PageModel
    {
        [BindProperty]
        public UserDTO UserObject { get; set; }
        [BindProperty]
        public string Message { get; set; }

        private readonly UserManager userManager;

        public LogInModel(UserManager userManager)
        {
            this.userManager = userManager;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {

            try
            {
                UserObject = userManager.GetUserByAccount(UserObject.Email, UserObject.Password).UserToUserDTO();
                if (UserObject.PersonId > -1)
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
                else
                {
                    this.Message = "Invalid credentials";
                    return Page();
                }
            }
            catch (UserException e)
            {
                this.Message = "Invalid credentials";
                ModelState.AddModelError("Invalid Credentials", e.Message);
                return Page();
            }
        }
    }
}
