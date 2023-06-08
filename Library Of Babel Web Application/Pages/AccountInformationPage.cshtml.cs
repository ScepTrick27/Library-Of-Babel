using DataLogic.DBs;
using Logic.Classes;
using Logic.DTOs;
using Logic.Managers;
using Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Library_Of_Babel_Web_Application.Pages
{
    [Authorize]
    public class AccountInformationPageModel : PageModel
    {
        [BindProperty]
        public UserDTO UserObject { get; set; }
        [BindProperty]
        public GenderTypeDTO GenderTypeObject { get; set; }
        [BindProperty]
        public int GenderTypeId { get; set; }

        private readonly UserManager _userManager;

        private readonly GenderTypeManager _genderTypeManager;


        public AccountInformationPageModel(UserManager userManager, GenderTypeManager genderTypeManager)
        {
            _userManager = userManager;
            _genderTypeManager = genderTypeManager;
        }

        public void OnGet()
        {
            string? id = User?.FindFirst("id")?.Value;

            if (id != null)
            {
                UserObject = _userManager.GetUserByID(Convert.ToInt32(id)).UserToUserDTO();
            }
        }

        public async Task<IActionResult> OnPost()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToPage("Index");
        }

        public IEnumerable<GenderType> genders => _genderTypeManager.GetAllGenders();
    }
}
