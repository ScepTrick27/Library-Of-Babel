using Logic.DTOs;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataLogic.DBs
{
    public class BookDB : DBMediator, IBookDB
    {
        public bool AddBook(BookDTO bookDTO)
        {
            try
            {
                using (SqlConnection conn = CreateConnection())
                {
                    const string sql = "INSERT INTO individual_book ([book_title], [book_description], [book_author], [book_publish_date], [book_photo])" +
                    "VALUES (@book_title, @book_description, @book_author, @book_publish_date, @book_photo)";

                    SqlCommand cmd = new SqlCommand(sql, conn);


                    cmd.Parameters.AddWithValue("@book_title", bookDTO.BookTitle);
                    cmd.Parameters.AddWithValue("@book_description", bookDTO.BookDescription);
                    cmd.Parameters.AddWithValue("@book_author", bookDTO.BookAuthor);
                    cmd.Parameters.AddWithValue("@book_publish_date", bookDTO.BookPublishDate);
                    cmd.Parameters.AddWithValue("@book_photo", bookDTO.BookImage);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;

                }
            }
            catch (Exception ex) { return false; }
        }

        public BookDTO[] GetAllBooks()
        {
            try
            {
                List<BookDTO> books = new List<BookDTO>();

                using (SqlConnection conn = CreateConnection())
                {
                    string sql = "SELECT * FROM individual_book";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();


                    while (dr.Read())
                    {
                        var bookDTO = new BookDTO
                        {
                            BookId = Convert.ToInt32(dr["book_id"]),
                            BookTitle = dr["book_title"].ToString(),
                            BookDescription = dr["book_description"].ToString(),
                            BookAuthor = dr["book_author"].ToString(),
                            BookPublishDate = Convert.ToDateTime(dr["book_publish_date"]),
                            BookImage = (byte[])dr["book_photo"]
                        };

                        books.Add(bookDTO);
                    }
                    return books.ToArray();
                }
            }
            catch (Exception ex) { throw; }
        }
    }
}
