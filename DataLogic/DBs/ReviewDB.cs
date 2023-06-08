using Logic.DTOs;
using Logic.Entities;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogic.DBs
{
    public class ReviewDB : DBMediator, IReviewDB
    {
        public bool AddReview(ReviewDTO reviewDTO)
        {
            try
            {
                using (SqlConnection conn = CreateConnection())
                {
                    const string sql = "INSERT INTO review ([rating], [review], [person_id], [book_id])" +
                    "VALUES (@rating, @review, @user_id, @book_id)";

                    SqlCommand cmd = new SqlCommand(sql, conn);


                    cmd.Parameters.AddWithValue("@rating", reviewDTO.Rating);
                    if (reviewDTO.ReviewName == null)
                    {
                        cmd.Parameters.AddWithValue("@review", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@review", reviewDTO.ReviewName);
                    }
                    cmd.Parameters.AddWithValue("@user_id", reviewDTO.UserDTO.PersonId);
                    cmd.Parameters.AddWithValue("@book_id", reviewDTO.BookDTO.BookId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;

                }
            }
            catch (Exception ex) { return false; }
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

        public ReviewDTO GetUserReviewForABookById(int bookId, int userId)
        {
            try
            {
                using (SqlConnection conn = CreateConnection())
                {
                    const string sql = "SELECT * FROM review bg INNER JOIN book b ON bg.book_id = b.book_id INNER JOIN genre g ON bg.genre_id = g.genre_id INNER JOIN customer c ON fb.person_id = c.person_id INNER JOIN person p ON c.person_id = p.person_id INNER JOIN gender g ON p.gender_id = g.gender_id WHERE bg.book_id = @book_id AND c.person_id_id = bg.user_id";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@book_id", bookId);
                    cmd.Parameters.AddWithValue("@user_id", userId);
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
                        return review;
                    }
                }
            }
            catch (Exception)
            {

                throw new NotImplementedException();
            }
            throw new NotImplementedException();
        }

        public List<ReviewDTO> GetUserReviews(int userId)
        {
            try
            {
                List<ReviewDTO> reviews = new List<ReviewDTO>();

                using (SqlConnection conn = CreateConnection())
                {
                    const string sql = "SELECT * FROM review bg INNER JOIN book b ON bg.book_id = b.book_id INNER JOIN genre g ON bg.genre_id = g.genre_id INNER JOIN customer c ON fb.person_id = c.person_id INNER JOIN person p ON c.person_id = p.person_id INNER JOIN gender g ON p.gender_id = g.gender_id WHERE c.person_id = @user_id";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@user_id", userId);
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
