using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogic.DTOs
{
    public struct GenreDTO
    {
        public GenreDTO(SqlDataReader dr)
        {
            GenreId = Convert.ToInt32(dr["genre_id"]);
            GenreName = dr["genre_name"].ToString();
        }

        public int GenreId { get; set; }
        public string GenreName { get; set; }
    }
}
