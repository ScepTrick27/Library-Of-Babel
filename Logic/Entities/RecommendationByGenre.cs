using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Interfaces;

namespace Logic.Entities
{
    public class RecommendationByGenre : IRecommendation
    {
        List<FavouriteBook> favouriteBooks;
        public RecommendationByGenre(List<FavouriteBook> favouriteBooks)
        {
            this.favouriteBooks = favouriteBooks;
        }

        public List<Book> GetRecommendedBooks(List<Book> books)
        {
            Dictionary<Genre, int> genreCounts = new Dictionary<Genre, int>();

            foreach (FavouriteBook favouriteBook in favouriteBooks)
            {
                Genre genre = favouriteBook.Book.Genre;

                if (genreCounts.ContainsKey(genre))
                {
                    genreCounts[genre]++;
                }
                else
                {
                    genreCounts[genre] = 1;
                }
            }

            List<Genre> topGenres = genreCounts.OrderByDescending(pair => pair.Value)
                                               .Take(3)
                                               .Select(pair => pair.Key)
                                               .ToList();

            List<Book> recommendedBooks = new List<Book>();

            foreach (Book book in books)
            {
                if (topGenres.Contains(book.Genre))
                {
                    recommendedBooks.Add(book);
                }
            }

            return recommendedBooks;
        }
    }
}
