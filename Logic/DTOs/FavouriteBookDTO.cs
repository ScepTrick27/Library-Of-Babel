using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.DTOs
{
    public struct FavouriteBookDTO
    {
        public UserDTO UserDTO { get; set; }
        public BookDTO BookDTO { get; set; }
    }
}
