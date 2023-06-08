using Logic.DTOs;
using Logic.Interfaces;
using Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Managers
{
    public class ReviewManager
    {
        private readonly IReviewDB reviewDB;

        public ReviewManager(IReviewDB reviewDB)
        {
            this.reviewDB = reviewDB ?? throw new ArgumentNullException(nameof(reviewDB));
        }

        public bool AddReview(Review review)
        {
            return reviewDB.AddReview(review.ReviewToReviewDTO());
        }

        public List<Review> GetAllReviewsForABookById(int bookId)
        {
            List<Review> reviews = new List<Review>();

            foreach (ReviewDTO r in reviewDB.GetAllReviewsForABookById(bookId))
            {
                reviews.Add(new Review(r));
            }

            return reviews;
        }

        public Review GetUserReviewForABookById(int bookId, int userId)
        {
            return new Review(reviewDB.GetUserReviewForABookById(bookId, userId));
        }

        public List<Review> GetUserReviews(int userId)
        {
            List<Review> reviews = new List<Review>();

            foreach (ReviewDTO r in reviewDB.GetUserReviews(userId))
            {
                reviews.Add(new Review(r));
            }
            return reviews;
        }
    }
}
