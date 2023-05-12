using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.DTOs
{
    public class GenderTypeDTO
    {
        public int GenderTypeId { get; set; }
        public string GenderTypeName { get; set; }

        public GenderTypeDTO() { }

        public GenderTypeDTO(int genderTypeId, string genderTypeName)
        {
            GenderTypeId = genderTypeId;
            GenderTypeName = genderTypeName;
        }
    }
}
