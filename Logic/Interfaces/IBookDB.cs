using Logic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IBookDB
    {
        public bool AddBook(BookDTO bookDTO);
        public BookDTO[] GetAllBooks();
        public BookDTO GetBookById(int id);
        public List<FavouriteBookDTO> GetAllFavouriteBooksForUser(int id);
        public List<ReviewDTO> GetAllReviewsForABookById(int bookId);
        public List<ReviewDTO> GetAllReviews();
    }
}
