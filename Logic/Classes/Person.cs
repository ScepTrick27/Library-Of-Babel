using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLogic.DTOs;


namespace Logic.Classes
{
    public abstract class Person
    {
        protected int personId;
        protected string email;
        protected string password;
        protected string firstName;
        protected string lastName;
        protected GenderType genderType;
        protected DateTime dateOfBirth;
        protected string city;
        protected string country;

        protected Person(string email, string password, string firstName, string lastName, GenderType genderType, DateTime dateOfBirth, string city, string country)
        {
            this.email = email;
            this.password = password;
            this.firstName = firstName;
            this.lastName = lastName;
            this.genderType = genderType;
            this.dateOfBirth = dateOfBirth;
            this.city = city;
            this.country = country;
        }

        protected Person(UserDTO personDTO)
        {
            this.email = personDTO.Email;
            this.password = personDTO.Password;
            this.firstName = personDTO.FirstName;
            this.lastName = personDTO.LastName;
            this.genderType = new GenderType()
            {
                GenderTypeId = personDTO.GenderTypeDTO.GenderTypeId,
                GenderTypeName = personDTO.GenderTypeDTO.GenderTypeName,
            };
            this.dateOfBirth = personDTO.DateOfBirth;
            this.city = personDTO.City;
            this.country = personDTO.Country;
        }

        protected Person() { }

        protected int PersonId { get => personId; set => personId = value; }
        protected string Email { get => email; set => email = value; }
        protected string Password { get => password; set => password = value; }
        protected string FirstName { get => firstName; set => firstName = value; }
        protected string LastName { get => lastName; set => lastName = value; }
        protected GenderType GenderType { get => genderType; set => genderType = value; }
        protected DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        protected string City { get => city; set => city = value; }
        protected string Country { get => country; set => country = value; }
    }
}
