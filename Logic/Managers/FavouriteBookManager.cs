using Logic.Interfaces;
using Logic.Entities;
using Logic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Managers
{
    public class FavouriteBookManager
    {
        private readonly IFavouriteBookDB favouriteBookDB;

        public FavouriteBookManager(IFavouriteBookDB favouriteBookDB)
        {
            this.favouriteBookDB = favouriteBookDB ?? throw new ArgumentNullException(nameof(favouriteBookDB));
        }

        public bool AddFavouriteBook(FavouriteBook favouriteBook)
        {
            return favouriteBookDB.AddFavouriteBook(favouriteBook.FavouriteBookToFavouriteBookDTO());
        }

        public List<FavouriteBook> GetAllFavouriteBooksForUser(int id)
        {
            List<FavouriteBook> favouriteBooks = new List<FavouriteBook>();

            foreach (FavouriteBookDTO favouriteBook in favouriteBookDB.GetAllFavouriteBooksForUser(id))
            {
                favouriteBooks.Add(new FavouriteBook(favouriteBook));
            }

            return favouriteBooks;
        }
    }
}
