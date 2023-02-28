using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogic.DTOs
{
    public class BookGenreDTO
    {
        public BookGenreDTO(BookDTO bookDTO, GenreDTO genreDTO)
        {
            BookDTO = bookDTO;
            GenreDTO = genreDTO;
        }

        public BookGenreDTO(SqlDataReader dr)
        {
            BookDTO = new BookDTO(dr);
            GenreDTO = new GenreDTO(dr);
        }

        public BookDTO BookDTO { get; set; }
        public GenreDTO GenreDTO { get; set; }

    }
}
