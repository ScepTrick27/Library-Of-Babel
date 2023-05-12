using Logic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IFavouriteBookDB
    {
        public bool AddFavouriteBook(FavouriteBookDTO favouriteBookDTO);
        public List<FavouriteBookDTO> GetAllFavouriteBooksForUser(int id);
    }
}
