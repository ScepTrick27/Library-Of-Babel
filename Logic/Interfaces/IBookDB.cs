using Logic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IBookDB
    {
        public bool AddBook(BookDTO bookDTO);
        public BookDTO[] GetAllBooks();
    }
}
