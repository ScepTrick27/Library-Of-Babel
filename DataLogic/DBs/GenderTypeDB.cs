using Logic.DTOs;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogic.DBs
{
    public class GenderTypeDB : DBMediator, IGenderTypeDB
    {
        public GenderTypeDTO[] GetAllGenders()
        {
            try
            {
                List<GenderTypeDTO> genders = new List<GenderTypeDTO>();

                using (SqlConnection conn = CreateConnection())
                {
                    string sql = "SELECT * FROM individual_gender";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        var genderTypeDTO = new GenderTypeDTO
                        {
                            GenderTypeId = Convert.ToInt32(dr["gender_id"]),
                            GenderTypeName = dr["gender_name"].ToString()
                        };

                        genders.Add(genderTypeDTO);
                    }
                    return genders.ToArray();
                }
            }
            catch (Exception ex) { throw; }
        }
    }
}
