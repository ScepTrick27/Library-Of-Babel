using Logic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IUserDB
    {
        public bool AddUser(UserDTO userDTO);
        public UserDTO GetUserByAccount(string email, string password);
        public UserDTO GetUserByID(int id);
    }
}
