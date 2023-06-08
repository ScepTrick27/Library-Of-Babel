using Logic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Classes;

namespace Logic.Entities
{
    public class Review
    {
        private int reviewId;
        private int rating;
        private string reviewName;
        private User user;
        private Book book;

        public Review(int reviewId, int rating, string reviewName, User user, Book book)
        {
            this.reviewId = reviewId;
            this.rating = rating;
            this.reviewName = reviewName;
            this.user = user;
            this.book = book;
        }

        public Review(ReviewDTO reviewDTO)
        {
            this.reviewId = reviewDTO.ReviewId;
            this.rating = reviewDTO.Rating;
            this.reviewName = reviewDTO.ReviewName;
            this.user = new User(reviewDTO.UserDTO);
            this.book = new Book(reviewDTO.BookDTO);
        }

        public ReviewDTO ReviewToReviewDTO()
        {
            return new ReviewDTO
            {
                ReviewId = this.reviewId,
                Rating = this.rating,
                ReviewName = this.reviewName,
                UserDTO = this.user.UserToUserDTO(),
                BookDTO = this.book.BookToBookDTO()
            };
        }

        public int ReviewId { get => reviewId; set => reviewId = value; }
        public int Rating { get => rating; set => rating = value; }
        public string ReviewName { get => reviewName; set => reviewName = value; }
        public User User { get => user; set => user = value; }
        public Book Book { get => book; set => book = value; }
    }
}
