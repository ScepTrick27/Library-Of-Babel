using Logic.DTOs;
using Logic.Interfaces;
using Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Managers
{
    public class GenreManager
    {
        private readonly IGenreDB genreDB;

        public GenreManager(IGenreDB genreDB)
        {
            this.genreDB = genreDB ?? throw new ArgumentNullException(nameof(genreDB));
        }

        public List<Genre> GetAllGenres()
        {
            List<Genre> genres = new List<Genre>();

            foreach (GenreDTO b in genreDB.GetAllGenres())
            {
                genres.Add(new Genre(b));
            }

            return genres;
        }

        public Genre GetGenreById(int id)
        {
            return new Genre(genreDB.GetGenreById(id));
        }
    }
}
