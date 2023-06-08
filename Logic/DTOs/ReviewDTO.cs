using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.DTOs
{
    public class ReviewDTO
    {
        public int ReviewId { get; set; }
        public int Rating { get; set; }
        public string? ReviewName { get; set; }
        public UserDTO UserDTO { get; set; }
        public BookDTO BookDTO { get; set; }

        public ReviewDTO() { }
    }
}
