using Logic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IGenreDB
    {
        public List<GenreDTO> GetAllGenres();
        public GenreDTO GetGenreById(int id);
    }
}
