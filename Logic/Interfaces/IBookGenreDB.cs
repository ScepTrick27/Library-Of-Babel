using Logic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IBookGenreDB
    {
        public bool AddBookGenre(BookGenreDTO bookGenre);
        public List<BookGenreDTO> GetAllGenresForABookById(int bookId);
    }
}
