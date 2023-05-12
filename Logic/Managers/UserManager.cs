using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Classes;
using Logic.DTOs;
using Logic.Exceptions;
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
            try
            {
                return new User(userDB.GetUserByAccount(email, password));
            }
            catch (UserException e)
            {

                throw new UserException("Error occurred while getting a user by account.", e);
            }
        }

        public User GetUserByID(int id)
        {
            return new User(userDB.GetUserByID(id));
        }

    }
}
