using DataLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogic.DBs
{
    public class UserDB : DBMediator
    {
        public bool AddUser(UserDTO userDTO)
        {
            try
            {
                const string sql = @"declare @password_salt varchar(max) = crypt_gen_random(16)
                        INSERT INTO individual_person ([email], [password], [password_salt], [first_name], [last_name], [gender_id], [date_of_birth], [city], [country])" +
                "VALUES (@email, hashbytes('SHA2_256', convert(varchar(max), concat(convert(varchar(max), @password), @password_salt))), @password_salt, @first_name, @last_name, @gender_id, @date_of_birth, @city, @country); SELECT SCOPE_IDENTITY()";

                SqlCommand cmd = new SqlCommand(sql, conn);


                cmd.Parameters.AddWithValue("@email", userDTO.Email);
                cmd.Parameters.AddWithValue("@password", userDTO.Password);
                cmd.Parameters.AddWithValue("@first_name", userDTO.FirstName);
                cmd.Parameters.AddWithValue("@last_name", userDTO.LastName);
                cmd.Parameters.AddWithValue("@gender_id", userDTO.GenderTypeDTO.GenderTypeId);
                cmd.Parameters.AddWithValue("@date_of_birth", userDTO.DateOfBirth);
                cmd.Parameters.AddWithValue("@city", userDTO.City);
                cmd.Parameters.AddWithValue("@country", userDTO.Country);

                conn.Open();
                int insertedId = Convert.ToInt32(cmd.ExecuteScalar());

                const string query = "INSERT INTO synthesis_customer ([person_id], [user_description])" +
                    "VALUES (@person_id, @user_description)";

                SqlCommand cmd1 = new SqlCommand(query, conn);

                cmd1.Parameters.AddWithValue("@person_id", insertedId);
                cmd1.Parameters.AddWithValue("@bonus_points", userDTO.Description);

                cmd1.ExecuteNonQuery();

                return true;

            }
            finally
            {
                conn.Close();
            }
        }

        public UserDTO GetUserByAccount(string email, string password)
        {
            try
            {
                string sql = "SELECT * FROM individual_person ip INNER JOIN individual_customer ic ON ip.person_id = ic.person_id WHERE email = @email AND password = hashbytes('SHA2_256', convert(varchar(max), concat(convert(varchar(max), @password), password_salt)))";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {
                    return new UserDTO(dr);
                }
            }
            finally
            {
                conn.Close();
            }
            return null;
        }

    }
}
