using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.DTOs
{
    public struct BookGenreDTO
    {
        public BookDTO BookDTO { get; set; }
        public GenreDTO GenreDTO { get; set; }
    }
}
