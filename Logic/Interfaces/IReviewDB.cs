using Logic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IReviewDB
    {
        public bool AddReview(ReviewDTO reviewDTO);
        public List<ReviewDTO> GetAllReviewsForABookById(int bookId);
        public ReviewDTO GetUserReviewForABookById(int bookId, int userId);
        public List<ReviewDTO> GetUserReviews(int userId);
    }
}
