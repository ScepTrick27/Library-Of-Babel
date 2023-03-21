using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogic.DTOs
{
    public struct GenderTypeDTO
    {
        public GenderTypeDTO(int genderTypeId, string genderTypeName) 
        {
            GenderTypeId= genderTypeId;
            GenderTypeName= genderTypeName;
        }
        public GenderTypeDTO(SqlDataReader dr)
        {
            GenderTypeId = Convert.ToInt32(dr["gender_id"]);
            GenderTypeName = dr["gender_name"].ToString();
        }

        public int GenderTypeId { get; set; }
        public string GenderTypeName { get; set; }
    }
}
