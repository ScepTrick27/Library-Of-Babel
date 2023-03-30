using Logic.Classes;
using Logic.Managers;
using Logic.Interfaces;
using DataLogic.DBs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Logic;

namespace Library_Of_Babel_Web_Application.Pages
{
    public class SignUpPageModel : PageModel
    {
        [BindProperty]
        public User UserObject { get; set; }
        [BindProperty]
        public GenderType GenderTypeObject { get; set; }
        [BindProperty]
        public int GenderTypeId { get; set; }

        private readonly UserManager userManager;
        private readonly GenderTypeManager genderTypeManager;
        private readonly IUserDB userDB = new UserDB();
        private readonly IGenderTypeDB genderTypeDB = new GenderTypeDB();

        public SignUpPageModel()
        {
            userManager = new UserManager(userDB);
            genderTypeManager = new GenderTypeManager(genderTypeDB);
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            foreach (GenderType genderType in genders)
            {
                if (genderType.GenderTypeId == GenderTypeId)
                {
                    GenderTypeObject = genderType;
                }
            }

            UserObject.GenderType = GenderTypeObject;

            userManager.AddUser(UserObject);

            return RedirectToPage("/LogIn");

        }

        public IEnumerable<GenderType> genders => genderTypeManager.GetAllGenders();
    }
}
