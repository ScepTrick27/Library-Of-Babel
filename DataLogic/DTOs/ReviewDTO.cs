using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogic.DTOs
{
    public struct ReviewDTO
    {
        public ReviewDTO(int rating, string? reviewName, UserDTO userDTO, BookDTO bookDTO)
        {
            Rating = rating;
            ReviewName = reviewName;
            UserDTO = userDTO;
            BookDTO = bookDTO;
        }

        public ReviewDTO(SqlDataReader dr)
        {
            ReviewId = Convert.ToInt32(dr["review_id"]);
            Rating = Convert.ToInt32(dr["rating"]);
            ReviewName = dr["review"].ToString();
            UserDTO = new UserDTO(dr);
            BookDTO = new BookDTO(dr);
        }

        public int ReviewId { get; set; }
        public int Rating { get; set; }
        public string? ReviewName { get; set; }
        public UserDTO UserDTO { get; set; }
        public BookDTO BookDTO { get; set; }
    }
}
