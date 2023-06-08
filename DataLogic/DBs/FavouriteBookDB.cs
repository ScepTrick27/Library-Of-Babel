using Logic.DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Logic.Interfaces;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataLogic.DBs
{
    public class FavouriteBookDB : DBMediator, IFavouriteBookDB
    {
        public bool AddFavouriteBook(FavouriteBookDTO favouriteBookDTO)
        {
            try
            {
                using (SqlConnection conn = CreateConnection())
                {
                    const string sql = "INSERT INTO favorite_book ([person_id], [book_id])" +
                    "VALUES (@person_id, @book_id)";

                    SqlCommand cmd = new SqlCommand(sql, conn);


                    cmd.Parameters.AddWithValue("@person_id", favouriteBookDTO.UserDTO.PersonId);
                    cmd.Parameters.AddWithValue("@book_id", favouriteBookDTO.BookDTO.BookId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;

                }
            }
            catch (Exception ex) { return false; }
        }

        public List<FavouriteBookDTO> GetAllFavouriteBooksForUser(int id)
        {
            try
            {
                List<FavouriteBookDTO> favouriteBooks = new List<FavouriteBookDTO>();

                using (SqlConnection conn = CreateConnection())
                {
                    string sql = "SELECT * FROM favorite_book fb INNER JOIN customer c ON fb.person_id = c.person_id INNER JOIN" +
                        " person p ON c.person_id = p.person_id INNER JOIN gender g ON p.gender_id = g.gender_id" +
                        " INNER JOIN book b ON fb.book_id = b.book_id INNER JOIN genre ig ON b.genre_id = ig.genre_id WHERE fb.person_id = @id";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();


                    while (dr.Read())
                    {
                        var favouriteBookDTO = new FavouriteBookDTO
                        {
                            BookDTO = new BookDTO
                            {
                                BookId = Convert.ToInt32(dr["book_id"]),
                                BookTitle = dr["book_title"].ToString(),
                                BookDescription = dr["book_description"].ToString(),
                                BookAuthor = dr["book_author"].ToString(),
                                BookPublishDate = Convert.ToDateTime(dr["book_publish_date"]),
                                BookImage = (byte[])dr["book_photo"],
                                Genre = new GenreDTO
                                {
                                    GenreId = Convert.ToInt32(dr["genre_id"]),
                                    GenreName = dr["genre_name"].ToString(),
                                }
                            },
                            UserDTO = new UserDTO
                            {
                                PersonId = Convert.ToInt32(dr["person_id"]),
                                Email = dr["email"].ToString(),
                                Password = dr["password"].ToString(),
                                FirstName = dr["first_name"].ToString(),
                                LastName = dr["last_name"].ToString(),
                                GenderTypeDTO = new GenderTypeDTO
                                {
                                    GenderTypeId = Convert.ToInt32(dr["gender_id"]),
                                    GenderTypeName = dr["gender_name"].ToString()
                                },
                                DateOfBirth = Convert.ToDateTime(dr["date_of_birth"])
                            }
                        };
                        favouriteBooks.Add(favouriteBookDTO);
                    }
                    return favouriteBooks;
                }
            }
            catch (Exception ex)
            {
                // log ex;
                throw ex;
            }
        }
    }
}
