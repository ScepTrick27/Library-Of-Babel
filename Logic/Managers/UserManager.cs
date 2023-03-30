using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Classes;
using Logic.DTOs;
using Logic.Interfaces;

namespace Logic.Managers
{
    public class UserManager
    {
        private readonly IUserDB userDB;

        public UserManager(IUserDB userDB)
        {
            this.userDB = userDB ?? throw new ArgumentNullException(nameof(userDB));
        }

        public bool AddUser(User user)
        {
            return userDB.AddUser(user.UserToUserDTO());
        }

        public User GetUserByAccount(string email, string password)
        {
            return new User(userDB.GetUserByAccount(email, password));
        }

        public User GetUserByID(int id)
        {
            return new User(userDB.GetUserByID(id));
        }

    }
}
