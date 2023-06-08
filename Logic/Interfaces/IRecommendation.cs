using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IRecommendation
    {
        public List<Book> GetRecommendedBooks(List<Book> books);
    }
}
