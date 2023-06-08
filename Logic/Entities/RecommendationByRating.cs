using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{
    public class RecommendationByRating : IRecommendation
    {
        List<Review> reviews;
        public RecommendationByRating(List<Review> reviews) 
        {
            this.reviews = reviews;
        }

        public List<Book> GetRecommendedBooks(List<Book> books)
        {
            foreach (Book book in books)
            {
                int sum = 0;
                int count = 0;

                foreach (Review review in reviews)
                {
                    if (review.Book.BookId == book.BookId)
                    {
                        sum += review.Rating;
                        count++;
                    }
                }

                if (count > 0)
                {
                    book.AverageRating = (double)sum / count;
                }
                else
                {
                    book.AverageRating = 0;
                }
            }

            books.Sort((book1, book2) => book2.AverageRating.CompareTo(book1.AverageRating));

            return books;
        }
    }
}
