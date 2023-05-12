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
    public class BookGenreDB : DBMediator , IBookGenreDB
    {
        public bool AddBookGenre(BookGenreDTO bookGenre)
        {
            try
            {
                using (SqlConnection conn = CreateConnection())
                {
                    const string sql = "INSERT INTO individual_book_genre ([book_id], [genre_id])" +
                    "VALUES (@book_id, @genre_id)";

                    SqlCommand cmd = new SqlCommand(sql, conn);


                    cmd.Parameters.AddWithValue("@book_id", bookGenre.BookDTO.BookId);
                    cmd.Parameters.AddWithValue("@genre_id", bookGenre.GenreDTO.GenreId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;

                }
            }
            catch (Exception ex) { return false; }
        }

        public List<BookGenreDTO> GetAllGenresForABookById(int bookId)
        {
            try
            {
                List<BookGenreDTO> bookGenres = new List<BookGenreDTO>();

                using (SqlConnection conn = CreateConnection())
                {
                    const string sql = "SELECT * FROM individual_book_genre bg INNER JOIN individual_book b ON bg.book_id = b.book_id INNER JOIN individual_genre g ON bg.genre_id = g.genre_id WHERE bg.book_id = @book_id";
                    
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@book_id", bookId);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();


                    while (dr.Read())
                    {
                        var bookGenre = new BookGenreDTO
                        {
                            BookDTO = new BookDTO
                            {
                                BookId = Convert.ToInt32(dr["book_id"]),
                                BookTitle = dr["book_title"].ToString(),
                                BookDescription = dr["book_description"].ToString(),
                                BookAuthor = dr["book_author"].ToString(),
                                BookPublishDate = Convert.ToDateTime(dr["book_publish_date"]),
                                BookImage = (byte[])dr["book_photo"]
                            },
                            GenreDTO = new GenreDTO
                            {
                                GenreId = Convert.ToInt32(dr["genre_id"]),
                                GenreName = dr["genre_name"].ToString(),
                            }

                        };

                        bookGenres.Add(bookGenre);
                    }
                    return bookGenres;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
