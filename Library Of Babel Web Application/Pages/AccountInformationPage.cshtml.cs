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
            //if (HttpContext.Session.GetInt32("user_id").Value != null)
            //{
            //    UserObject = userManager.GetUserByID(HttpContext.Session.GetInt32("user_id").Value);
            string? id = User?.FindFirst("id")?.Value;
            //}
            if (id != null)
            {
                UserObject = userManager.GetUserByID(Convert.ToInt32(id)).UserToUserDTO();
                //foreach (GenderType genderType in genders)
                //{
                //    if (genderType.GenderTypeId == GenderTypeId)
                //    {
                //        GenderTypeObject = genderType;
                //    }
                //}

                //UserObject.GenderType = GenderTypeObject;
            }
        }

        public IEnumerable<GenderType> genders => genderTypeManager.GetAllGenders();
    }
}
