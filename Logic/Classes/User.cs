using DataLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Classes
{
    public class User : Person
    {
        private string description;

        public User(string email, string password, string firstName, string lastName, GenderType genderType, DateTime dateOfBirth, string city, string country, string description) : base(email, password, firstName, lastName, genderType, dateOfBirth, city, country)
        {
            this.description = description;
        }

        public User(UserDTO userDTO) : base(userDTO)
        {
            this.email = userDTO.Email;
            this.password = userDTO.Password;
            this.firstName = userDTO.FirstName;
            this.lastName = userDTO.LastName;
            this.genderType = new GenderType(userDTO.GenderTypeDTO)
            {
                GenderTypeId = userDTO.GenderTypeDTO.GenderTypeId,
                GenderTypeName = userDTO.GenderTypeDTO.GenderTypeName,
            };
            this.dateOfBirth = userDTO.DateOfBirth;
            this.city = userDTO.City;
            this.country = userDTO.Country;
            this.description = userDTO.Description;
        }

        public UserDTO UserToUserDTO()
        {
            return new UserDTO(Email, Password, FirstName, LastName, GenderType.GenderTypeToGenderTypeDTO(), DateOfBirth, City, Country, Description);
        }

        public string Description { get => description; set => description = value; }
    }
}
