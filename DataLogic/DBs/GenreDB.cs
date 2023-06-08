using Logic.DTOs;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogic.DBs
{
    public class GenreDB : DBMediator, IGenreDB
    {
        public List<GenreDTO> GetAllGenres()
        {
            try
            {
                List<GenreDTO> genres = new List<GenreDTO>();

                using (SqlConnection conn = CreateConnection())
                {
                    string sql = "SELECT * FROM genre";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();


                    while (dr.Read())
                    {
                        var genreDTO = new GenreDTO
                        {
                            GenreId = Convert.ToInt32(dr["genre_id"]),
                            GenreName = dr["genre_name"].ToString(),

                        };

                        genres.Add(genreDTO);
                    }
                    return genres;
                }
            }
            catch (Exception ex)
            {
                // log ex;
                throw new NotImplementedException();
            }
        }

        public GenreDTO GetGenreById(int id)
        {
            try
            {
                using (SqlConnection conn = CreateConnection())
                {
                    const string sql = "SELECT * FROM genre WHERE genre_id = @genre_id";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@genre_id", id);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();


                    while (dr.Read())
                    {
                        var genre = new GenreDTO
                        {
                            GenreId = Convert.ToInt32(dr["genre_id"]),
                            GenreName = dr["genre_name"].ToString()
                        };

                        return genre;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            throw new NotImplementedException();
        }
    }
}
