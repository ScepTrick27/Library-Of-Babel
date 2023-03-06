using DataLogic.DTOs;
using DataLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
            finally
            {
                conn.Close();
            }
        }

        public BookDTO[] GetAllBooks()
        {
            try
            {
                List<BookDTO> books = new List<BookDTO>();
                string sql = "SELECT * FROM individual_book";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {
                    books.Add(new BookDTO(dr));
                }
                return books.ToArray();

            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
        }
    }
}
