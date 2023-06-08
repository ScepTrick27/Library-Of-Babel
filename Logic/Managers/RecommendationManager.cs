using Logic.DTOs;
using Logic.Entities;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Logic.Managers
{
    public class RecommendationManager
    {
        private Dictionary<string, Type> recommendationTypes;
        private readonly IRecommendation recommendation;
        private readonly IBookDB bookDB;
        private int userID;

        public RecommendationManager(IBookDB bookDB)
        {
            recommendationTypes = new Dictionary<string, Type>();
            this.bookDB = bookDB ?? throw new ArgumentNullException(nameof(bookDB));
            recommendationTypes.Add("ByGenre", typeof(RecommendationByGenre));
            recommendationTypes.Add("ByRating", typeof(RecommendationByRating));
        }

        public List<Book> GetRecommendedBooks(string strategyName, List<Book> books, int userID)
        {
            IRecommendation recommendation = GetRecommendation(strategyName, userID);
            return recommendation.GetRecommendedBooks(books);
        }

        private IRecommendation GetRecommendation(string strategyName, int userID)
        {
            if (recommendationTypes.ContainsKey(strategyName))
            {
                Type recommendationType = recommendationTypes[strategyName];
                if (typeof(IRecommendation).IsAssignableFrom(recommendationType))
                {
                    if (strategyName == "ByGenre")
                    {
                        List<FavouriteBook> favouriteBooks = GetFavouriteBooksForCurrentUser(userID);
                        return (IRecommendation)Activator.CreateInstance(recommendationType, favouriteBooks);
                    }
                    else if (strategyName == "ByRating")
                    {
                        List<Review> reviews = GetAllReviews();
                        return (IRecommendation)Activator.CreateInstance(recommendationType, reviews);
                    }
                }
            }

            throw new ArgumentException("Invalid strategyName or recommendation type.");
        }

        private List<FavouriteBook> GetFavouriteBooksForCurrentUser(int userID)
        {
            List<FavouriteBook> favouriteBooks = new List<FavouriteBook>();

            foreach (FavouriteBookDTO favouriteBook in bookDB.GetAllFavouriteBooksForUser(userID))
            {
                favouriteBooks.Add(new FavouriteBook(favouriteBook));
            }

            return favouriteBooks;
        }

        private List<Review> GetAllReviews()
        {
            List<Review> reviews = new List<Review>();

            foreach (ReviewDTO r in bookDB.GetAllReviews())
            {
                reviews.Add(new Review(r));
            }

            return reviews;
        }

        private void GetCurrentUserId(int userID)
        {
            UserID = userID;
        }

        public int UserID { get; private set; }
    }
}
