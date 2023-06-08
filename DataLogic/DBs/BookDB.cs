using Logic.DTOs;
using Logic.Interfaces;
using Logic.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace DataLogic.DBs
{
    public class BookDB : DBMediator, IBookDB
    {
        public bool AddBook(BookDTO bookDTO)
        {
            try
            {
                using (SqlConnection conn = CreateConnection())
                {
                    const string sql = "INSERT INTO book ([book_title], [book_description], [book_author], [book_publish_date], [book_photo], [genre_id])" +
                    "VALUES (@book_title, @book_description, @book_author, @book_publish_date, @book_photo, @genre_id)";

                    SqlCommand cmd = new SqlCommand(sql, conn);


                    cmd.Parameters.AddWithValue("@book_title", bookDTO.BookTitle);
                    cmd.Parameters.AddWithValue("@book_description", bookDTO.BookDescription);
                    cmd.Parameters.AddWithValue("@book_author", bookDTO.BookAuthor);
                    cmd.Parameters.AddWithValue("@book_publish_date", bookDTO.BookPublishDate);
                    cmd.Parameters.AddWithValue("@book_photo", bookDTO.BookImage);
                    cmd.Parameters.AddWithValue("@genre_id", bookDTO.Genre.GenreId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;

                }
            }
            catch (SqlException ex)
            {
                BookException bookException = new BookException("An error occurred while adding the book to the database", ex);
                throw bookException;
            }
        }

        public BookDTO[] GetAllBooks()
        {
            try
            {
                List<BookDTO> books = new List<BookDTO>();

                using (SqlConnection conn = CreateConnection())
                {
                    string sql = "SELECT * FROM book ib INNER JOIN genre ig ON ib.genre_id = ig.genre_id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();


                    while (dr.Read())
                    {
                        var bookDTO = new BookDTO
                        {
                            BookId = Convert.ToInt32(dr["book_id"]),
                            BookTitle = dr["book_title"].ToString(),
                            BookDescription = dr["book_description"].ToString(),
                            BookAuthor = dr["book_author"].ToString(),
                            BookPublishDate = Convert.ToDateTime(dr["book_publish_date"]),
                            BookImage = (byte[])dr["book_photo"],
                            Genre = new GenreDTO
                            {
                                GenreId = Convert.ToInt32(dr["genre_id"]),
                                GenreName = dr["genre_name"].ToString(),
                            }
                        };

                        books.Add(bookDTO);
                    }
                    return books.ToArray();
                }
            }
            catch (SqlException ex)
            {
                // log ex;
                throw new BookException("Something went wrong when getting all the books", ex);
            }
        }

        public BookDTO GetBookById(int id)
        {
            try
            {
                using (SqlConnection conn = CreateConnection())
                {
                    string sql = "SELECT * FROM book ib INNER JOIN genre ig ON ib.genre_id = ig.genre_id WHERE book_id = @book_id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@book_id", id);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();


                    while (dr.Read())
                    {
                        var bookDTO = new BookDTO
                        {
                            BookId = Convert.ToInt32(dr["book_id"]),
                            BookTitle = dr["book_title"].ToString(),
                            BookDescription = dr["book_description"].ToString(),
                            BookAuthor = dr["book_author"].ToString(),
                            BookPublishDate = Convert.ToDateTime(dr["book_publish_date"]),
                            BookImage = (byte[])dr["book_photo"],
                            Genre = new GenreDTO
                            {
                                GenreId = Convert.ToInt32(dr["genre_id"]),
                                GenreName = dr["genre_name"].ToString(),
                            }
                        };

                        return bookDTO;
                    }
                }
            }
            catch (SqlException ex)
            {
                // log ex;
                throw new BookException("Something went wrong while getting the book by ID", ex);
            }
            throw new BookException("The book with the specified ID could not be found");
        }

        public List<FavouriteBookDTO> GetAllFavouriteBooksForUser(int id)
        {
            try
            {
                List<FavouriteBookDTO> favouriteBooks = new List<FavouriteBookDTO>();

                using (SqlConnection conn = CreateConnection())
                {
                    string sql = "SELECT * FROM favorite_book fb INNER JOIN customer c ON fb.person_id = c.person_id INNER JOIN" +
                        " person p ON c.person_id = p.person_id INNER JOIN gender g ON p.gender_id = g.gender_id" +
                        " INNER JOIN book b ON fb.book_id = b.book_id INNER JOIN genre ig ON b.genre_id = ig.genre_id WHERE fb.person_id = @id";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();


                    while (dr.Read())
                    {
                        var favouriteBookDTO = new FavouriteBookDTO
                        {
                            BookDTO = new BookDTO
                            {
                                BookId = Convert.ToInt32(dr["book_id"]),
                                BookTitle = dr["book_title"].ToString(),
                                BookDescription = dr["book_description"].ToString(),
                                BookAuthor = dr["book_author"].ToString(),
                                BookPublishDate = Convert.ToDateTime(dr["book_publish_date"]),
                                BookImage = (byte[])dr["book_photo"],
                                Genre = new GenreDTO
                                {
                                    GenreId = Convert.ToInt32(dr["genre_id"]),
                                    GenreName = dr["genre_name"].ToString(),
                                }
                            },
                            UserDTO = new UserDTO
                            {
                                PersonId = Convert.ToInt32(dr["person_id"]),
                                Email = dr["email"].ToString(),
                                Password = dr["password"].ToString(),
                                FirstName = dr["first_name"].ToString(),
                                LastName = dr["last_name"].ToString(),
                                GenderTypeDTO = new GenderTypeDTO
                                {
                                    GenderTypeId = Convert.ToInt32(dr["gender_id"]),
                                    GenderTypeName = dr["gender_name"].ToString()
                                },
                                DateOfBirth = Convert.ToDateTime(dr["date_of_birth"])
                            }
                        };
                        favouriteBooks.Add(favouriteBookDTO);
                    }
                    return favouriteBooks;
                }
            }
            catch (Exception ex)
            {
                // log ex;
                throw ex;
            }
        }

        public List<ReviewDTO> GetAllReviewsForABookById(int bookId)
        {
            try
            {
                List<ReviewDTO> reviews = new List<ReviewDTO>();

                using (SqlConnection conn = CreateConnection())
                {
                    const string sql = "SELECT * FROM review r INNER JOIN book b ON r.book_id = b.book_id INNER JOIN genre g ON b.genre_id = g.genre_id INNER JOIN person p ON r.person_id = p.person_id INNER JOIN customer c ON p.person_id = c.person_id INNER JOIN gender gr ON p.gender_id = gr.gender_id WHERE r.book_id = @book_id";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@book_id", bookId);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();


                    while (dr.Read())
                    {
                        var review = new ReviewDTO
                        {
                            ReviewId = Convert.ToInt32(dr["review_id"]),
                            Rating = Convert.ToInt32(dr["rating"]),
                            ReviewName = dr["review"].ToString(),
                            UserDTO = new UserDTO
                            {
                                PersonId = Convert.ToInt32(dr["person_id"]),
                                Email = dr["email"].ToString(),
                                Password = dr["password"].ToString(),
                                FirstName = dr["first_name"].ToString(),
                                LastName = dr["last_name"].ToString(),
                                GenderTypeDTO = new GenderTypeDTO
                                {
                                    GenderTypeId = Convert.ToInt32(dr["gender_id"]),
                                    GenderTypeName = dr["gender_name"].ToString()
                                },
                                DateOfBirth = Convert.ToDateTime(dr["date_of_birth"])
                            },
                            BookDTO = new BookDTO
                            {
                                BookId = Convert.ToInt32(dr["book_id"]),
                                BookTitle = dr["book_title"].ToString(),
                                BookDescription = dr["book_description"].ToString(),
                                BookAuthor = dr["book_author"].ToString(),
                                BookPublishDate = Convert.ToDateTime(dr["book_publish_date"]),
                                BookImage = (byte[])dr["book_photo"],
                                Genre = new GenreDTO
                                {
                                    GenreId = Convert.ToInt32(dr["genre_id"]),
                                    GenreName = dr["genre_name"].ToString(),
                                }
                            }

                        };
                    }
                    return reviews;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ReviewDTO> GetAllReviews()
        {
            try
            {
                List<ReviewDTO> reviews = new List<ReviewDTO>();

                using (SqlConnection conn = CreateConnection())
                {
                    const string sql = "SELECT * FROM review r INNER JOIN book b ON r.book_id = b.book_id INNER JOIN genre g ON b.genre_id = g.genre_id INNER JOIN customer c ON r.person_id = c.person_id INNER JOIN person p ON c.person_id = p.person_id INNER JOIN gender gr ON p.gender_id = gr.gender_id";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();


                    while (dr.Read())
                    {
                        var review = new ReviewDTO
                        {
                            ReviewId = Convert.ToInt32(dr["review_id"]),
                            Rating = Convert.ToInt32(dr["rating"]),
                            ReviewName = dr["review"].ToString(),
                            UserDTO = new UserDTO
                            {
                                PersonId = Convert.ToInt32(dr["person_id"]),
                                Email = dr["email"].ToString(),
                                Password = dr["password"].ToString(),
                                FirstName = dr["first_name"].ToString(),
                                LastName = dr["last_name"].ToString(),
                                GenderTypeDTO = new GenderTypeDTO
                                {
                                    GenderTypeId = Convert.ToInt32(dr["gender_id"]),
                                    GenderTypeName = dr["gender_name"].ToString()
                                },
                                DateOfBirth = Convert.ToDateTime(dr["date_of_birth"])
                            },
                            BookDTO = new BookDTO
                            {
                                BookId = Convert.ToInt32(dr["book_id"]),
                                BookTitle = dr["book_title"].ToString(),
                                BookDescription = dr["book_description"].ToString(),
                                BookAuthor = dr["book_author"].ToString(),
                                BookPublishDate = Convert.ToDateTime(dr["book_publish_date"]),
                                BookImage = (byte[])dr["book_photo"],
                                Genre = new GenreDTO
                                {
                                    GenreId = Convert.ToInt32(dr["genre_id"]),
                                    GenreName = dr["genre_name"].ToString(),
                                }
                            }

                        };
                        reviews.Add(review);
                    }
                    return reviews;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
    }
