using Logic.Classes;
using Logic.DTOs;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Managers
{
    public class GenderTypeManager
    {
        private readonly IGenderTypeDB genderTypeDB;

        public GenderTypeManager(IGenderTypeDB genderTypeDB)
        {
            this.genderTypeDB = genderTypeDB ?? throw new ArgumentNullException(nameof(genderTypeDB));
        }

        public GenderType[] GetAllGenders()
        {
            List<GenderType> genders = new List<GenderType>();

            foreach (GenderTypeDTO g in genderTypeDB.GetAllGenders())
            {
                genders.Add(new GenderType(g));
            }

            return genders.ToArray();
        }
    }
}
