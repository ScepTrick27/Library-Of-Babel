using Logic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{
    public class Genre
    {
        private int genreId;
        private string genreName;

        public Genre(int genreId, string genreName)
        {
            this.genreId = genreId;
            this.genreName = genreName;
        }

        public Genre(GenreDTO genreDTO) 
        {
            this.genreId = genreDTO.GenreId;
            this.genreName= genreDTO.GenreName;
        }

        public GenreDTO GenreToGenreDTO()
        {
            return new GenreDTO
            {
                GenreId = this.genreId,
                GenreName = this.genreName,
            };
        }

        public override string ToString()
        {
            return genreName;
        }

        public int GenreId { get => genreId; set => genreId = value; }
        public string GenreName { get => genreName; set => genreName = value; }
    }
}
