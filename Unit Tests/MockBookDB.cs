using DataLogic.DBs;
using Logic.DTOs;
using Logic.Interfaces;
using Logic;
using Logic.Entities;

namespace UnitTests
{
    public class MockBookDB : IBookDB
    {
        BookDTO book = new BookDTO();
        List<BookDTO> books;
        byte[] testImage;

        public bool AddBook(BookDTO bookDTO)
        {
            books = new List<BookDTO>
            {
                bookDTO
            };
            if (books.Count > 0)
            {
                return true;
            }
            return false;
        }

        public BookDTO[] GetAllBooks()
        {
            books = new List<BookDTO>
            {
               new BookDTO
                {
                    BookId = 1,
                    BookTitle = "1",
                    BookDescription = "1",
                    BookAuthor = "1",
                    BookPublishDate = DateTime.Now,
                    BookImage = testImage,
                    Genre = new GenreDTO
                    {
                        GenreId = 1,
                        GenreName = "1",
                    }
                },
               new BookDTO
                {
                    BookId = 2,
                    BookTitle = "2",
                    BookDescription = "2",
                    BookAuthor = "2",
                    BookPublishDate = DateTime.Now,
                    BookImage = testImage,
                    Genre = new GenreDTO
                    {
                        GenreId = 2,
                        GenreName = "2",
                    }
                },
               new BookDTO
                {
                    BookId = 3,
                    BookTitle = "3",
                    BookDescription = "3",
                    BookAuthor = "3",
                    BookPublishDate = DateTime.Now,
                    BookImage = testImage,
                    Genre = new GenreDTO
                    {
                        GenreId = 3,
                        GenreName = "3",
                    }
                }
            };
            return books.ToArray();
        }

        public List<FavouriteBookDTO> GetAllFavouriteBooksForUser(int id)
        {

            List<FavouriteBookDTO> favouriteBooks = new List<FavouriteBookDTO>
            {
                new FavouriteBookDTO
                {
                    BookDTO = new BookDTO
                    {
                        BookId = 1,
                        BookTitle = "1",
                        BookDescription = "1",
                        BookAuthor = "1",
                        BookPublishDate = DateTime.Now,
                        BookImage = testImage,
                        Genre = new GenreDTO
                        {
                           GenreId = 1,
                           GenreName = "1",
                        }
                    },
                   UserDTO = new UserDTO
                   {
                                PersonId = 1,
                                Email = "1",
                                Password = "1",
                                FirstName = "1",
                                LastName = "1",
                                GenderTypeDTO = new GenderTypeDTO
                                {
                                    GenderTypeId = 1,
                                    GenderTypeName = "1"
                                },
                                DateOfBirth = DateTime.Now,
                   }
                },
                            new FavouriteBookDTO
            {
                BookDTO = new BookDTO
                {
                    BookId = 2,
                    BookTitle = "2",
                    BookDescription = "2",
                    BookAuthor = "2",
                    BookPublishDate = DateTime.Now,
                    BookImage = testImage,
                    Genre = new GenreDTO
                    {
                        GenreId = 2,
                        GenreName = "2",
                    }
                },
                UserDTO = new UserDTO
                {
                    PersonId = 1,
                    Email = "1",
                    Password = "1",
                    FirstName = "1",
                    LastName = "1",
                    GenderTypeDTO = new GenderTypeDTO
                    {
                        GenderTypeId = 1,
                        GenderTypeName = "1"
                    },
                    DateOfBirth = DateTime.Now,
                },

            }
        };


            if (id == 1)
            {
                return favouriteBooks;
            }
            return null;
        }

        public List<ReviewDTO> GetAllReviews()
        {
            List<ReviewDTO> reviews = new List<ReviewDTO>
            {
                new ReviewDTO
                {
                    ReviewId = 1,
                    Rating = 2,
                    ReviewName = "1",
                    UserDTO = new UserDTO
                    {
                        PersonId= 1,
                        Email = "1",
                        Password = "1",
                        FirstName = "1",
                        LastName = "1",
                        GenderTypeDTO = new GenderTypeDTO
                        {
                            GenderTypeId = 1,
                            GenderTypeName = "1"
                        },
                    DateOfBirth = DateTime.Now,
                    },
                    BookDTO = new BookDTO
                    {
                        BookId = 1,
                        BookTitle = "1",
                        BookDescription = "1",
                        BookAuthor = "1",
                        BookPublishDate = DateTime.Now,
                        BookImage = testImage,
                        Genre = new GenreDTO
                        {
                           GenreId = 1,
                           GenreName = "1",
                        }
                    }
                },

                new ReviewDTO
                {
                    ReviewId = 2,
                    Rating = 5,
                    ReviewName = "2",
                    UserDTO = new UserDTO
                    {
                        PersonId= 1,
                        Email = "1",
                        Password = "1",
                        FirstName = "1",
                        LastName = "1",
                        GenderTypeDTO = new GenderTypeDTO
                        {
                            GenderTypeId = 1,
                            GenderTypeName = "1"
                        },
                    DateOfBirth = DateTime.Now,
                    },
                    BookDTO = new BookDTO
                    {
                        BookId = 2,
                        BookTitle = "2",
                        BookDescription = "2",
                        BookAuthor = "2",
                        BookPublishDate = DateTime.Now,
                        BookImage = testImage,
                        Genre = new GenreDTO
                        {
                            GenreId = 2,
                            GenreName = "2",
                        }
                    },
                }
            };

            return reviews;
        }

        public List<ReviewDTO> GetAllReviewsForABookById(int bookId)
        {
            throw new NotImplementedException();
        }

        public BookDTO GetBookById(int id)
        {
            throw new NotImplementedException();
        }
    }

}