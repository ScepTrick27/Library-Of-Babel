using System.Data.SqlClient;

namespace DataLogic
{
    public class UserDTO
    {
        public UserDTO(string email, string password, string firstName, string lastName, GenderTypeDTO genderTypeDTO, DateTime dateOfBirth, string city, string country, string description)
        {
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            GenderTypeDTO = genderTypeDTO;
            DateOfBirth = dateOfBirth;
            City = city;
            Country = country;
            Description = description;
        }

        public UserDTO(SqlDataReader dr) 
        {
            PersonId = Convert.ToInt32(dr["person_id"]);
            Email = dr["email"].ToString();
            Password = dr["password"].ToString();
            FirstName = dr["first_name"].ToString();
            LastName = dr["last_name"].ToString();
            GenderTypeDTO = new GenderTypeDTO(dr);
            DateOfBirth = Convert.ToDateTime(dr["date_of_birth"]);
        }

        public int PersonId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderTypeDTO GenderTypeDTO { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
    }
}