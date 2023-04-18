using DataLogic.DBs;
using Logic.Classes;
using Logic.DTOs;
using Logic.Managers;
using Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
        private readonly UserManager userManager;
        private readonly IUserDB userDB = new UserDB();
        private readonly GenderTypeManager genderTypeManager;
        private readonly IGenderTypeDB genderTypeDB = new GenderTypeDB();


        public AccountInformationPageModel()
        {
            userManager = new UserManager(userDB);
            genderTypeManager = new GenderTypeManager(genderTypeDB);
        }

        public void OnGet()
        {
            string? id = User?.FindFirst("id")?.Value;

            if (id != null)
            {
                UserObject = userManager.GetUserByID(Convert.ToInt32(id)).UserToUserDTO();
            }
        }

        public IEnumerable<GenderType> genders => genderTypeManager.GetAllGenders();
    }
}
