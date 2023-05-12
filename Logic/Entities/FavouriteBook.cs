using Logic.Classes;
using Logic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{
    public class FavouriteBook
    {
        private User user;
        private Book book;

        public FavouriteBook(User user, Book book)
        {
            this.user = user;
            this.book = book;
        }

        public FavouriteBook(FavouriteBookDTO favouriteBookDTO)
        {
            this.user = new User(favouriteBookDTO.UserDTO);
            this.book = new Book(favouriteBookDTO.BookDTO);
        }

        public FavouriteBookDTO FavouriteBookToFavouriteBookDTO()
        {
            return new FavouriteBookDTO()
            {
                UserDTO = this.user.UserToUserDTO(), 
                BookDTO = this.book.BookToBookDTO() 
            };
        }

        public User User { get => user; set => user = value; }
        public Book Book { get => book; set => book = value; }
    }
}
