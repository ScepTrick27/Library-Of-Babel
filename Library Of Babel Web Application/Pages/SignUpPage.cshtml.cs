using Logic.Classes;
using Logic.DTOs;
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
        public UserDTO UserObject { get; set; }
        [BindProperty]
        public GenderTypeDTO GenderTypeObject { get; set; }
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
                    GenderTypeObject = genderType.GenderTypeToGenderTypeDTO();
                }
            }

            //UserObject.GenderTypeDTO = GenderTypeObject;
            UserObject.GenderTypeDTO = GenderTypeObject;

            userManager.AddUser(new User(UserObject));

            return RedirectToPage("/LogIn");

        }

        public IEnumerable<GenderType> genders => genderTypeManager.GetAllGenders();
    }
}
