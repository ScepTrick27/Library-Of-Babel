using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.DTOs;


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

        public int PersonId { get => personId; }
        public string Email { get => email; }
        public string Password { get => password; }
        public string FirstName { get => firstName; }
        public string LastName { get => lastName; }
        public GenderType GenderType { get => genderType; }
        public DateTime DateOfBirth { get => dateOfBirth; }
        public string City { get => city; }
        public string Country { get => country; }

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
            this.personId = personDTO.PersonId;
            this.email = personDTO.Email;
            this.password = personDTO.Password;
            this.firstName = personDTO.FirstName;
            this.lastName = personDTO.LastName;
            this.genderType = new GenderType(personDTO.GenderTypeDTO)
            {
                GenderTypeId = personDTO.GenderTypeDTO.GenderTypeId,
                GenderTypeName = personDTO.GenderTypeDTO.GenderTypeName,
            };
            this.dateOfBirth = personDTO.DateOfBirth;
            this.city = personDTO.City;
            this.country = personDTO.Country;
        }
    }
}
