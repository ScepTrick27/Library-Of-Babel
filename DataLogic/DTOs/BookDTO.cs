using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataLogic.DTOs
{
    public class BookDTO
    {
        public BookDTO(string bookTitle, string bookDescription, string bookAuthor, DateTime bookPublishDate, string bookIsbn, byte[] bookImage)
        {
            BookTitle = bookTitle;
            BookDescription = bookDescription;
            BookAuthor = bookAuthor;
            BookPublishDate = bookPublishDate;
            BookIsbn = bookIsbn;
            BookImage = bookImage;
        }

        public BookDTO(SqlDataReader dr)
        {
            BookId = Convert.ToInt32(dr["book_id"]);
            BookTitle = dr["book_title"].ToString();
            BookDescription = dr["book_description"].ToString();
            BookAuthor = dr["book_author"].ToString();
            BookPublishDate = Convert.ToDateTime(dr["book_publish_date"]);
            BookIsbn = dr["book_isbn"].ToString();
            BookImage = (byte[])dr["book_photo"];
        }

        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public string BookDescription { get; set; }
        public string BookAuthor { get; set; }
        public DateTime BookPublishDate { get; set; }
        public string BookIsbn { get; set; }
        public byte[] BookImage { get; set; }
    }
}
