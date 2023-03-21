using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogic.DTOs
{
    public struct FavouriteBookDTO
    {
        public FavouriteBookDTO(UserDTO userDTO, BookDTO bookDTO)
        {
            UserDTO = userDTO;
            BookDTO = bookDTO;
        }

        public FavouriteBookDTO(SqlDataReader dr)
        {
            UserDTO = new UserDTO(dr);
            BookDTO = new BookDTO(dr);
        }

        public UserDTO UserDTO { get; set; }
        public BookDTO BookDTO { get; set; }
    }
}
