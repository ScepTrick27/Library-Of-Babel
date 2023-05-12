using Logic.DTOs;
using Logic.Interfaces;
using Logic.Exceptions;
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
            catch (SqlException ex) 
            { 
                BookException bookException = new BookException("An error occurred while adding the book to the database", ex);
                return false; 
            }
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
            catch (SqlException ex) {
                // log ex;
                throw new BookException("Something went wrong when getting all the books", ex);
            }
        }

        public BookDTO GetBookById(int id)
        {
            try
            {
                using (SqlConnection conn = CreateConnection())
                {
                    string sql = "SELECT * FROM individual_book WHERE book_id = @book_id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@book_id", id);
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

                        return bookDTO;
                    }
                }
            }
            catch (SqlException ex)
            {
                // log ex;
                throw new BookException("Something went wrong while getting the book by ID" , ex);
            }
            throw new BookException("The book with the specified ID could not be found");
        }
    }
}
