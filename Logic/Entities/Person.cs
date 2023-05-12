using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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

        [Required(ErrorMessage = "The email field is required.")]
        [EmailAddress(ErrorMessage = "The email field is not a valid email address.")]
        public string Email { get => email; }

        [Required(ErrorMessage = "The password field is required.")]
        [StringLength(100, ErrorMessage = "The password must be at least {6} characters long.", MinimumLength = 6)]
        public string Password { get => password; }

        [Required(ErrorMessage = "The first name field is required.")]
        [StringLength(50, ErrorMessage = "The first name must be at most {1} characters long.")]
        public string FirstName { get => firstName; }

        [Required(ErrorMessage = "The last name field is required.")]
        [StringLength(50, ErrorMessage = "The last name must be at most {1} characters long.")]
        public string LastName { get => lastName; }

        public GenderType GenderType { get => genderType; }

        [Required(ErrorMessage = "The date of birth field is required.")]
        [DataType(DataType.Date, ErrorMessage = "The date of birth field is not a valid date.")]
        public DateTime DateOfBirth { get => dateOfBirth; }

        [Required(ErrorMessage = "The city field is required.")]
        [StringLength(50, ErrorMessage = "The city must be at most {1} characters long.")]
        public string City { get => city; }

        [Required(ErrorMessage = "The country field is required.")]
        [StringLength(50, ErrorMessage = "The country must be at most {1} characters long.")]
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
