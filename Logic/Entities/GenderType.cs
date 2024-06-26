﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.DTOs;

namespace Logic.Classes
{
    public class GenderType
    {
        private int genderTypeId;
        private string genderTypeName;

        public GenderType(GenderTypeDTO genderTypeDTO)
        {
            genderTypeId = genderTypeDTO.GenderTypeId;
            genderTypeName = genderTypeDTO.GenderTypeName;
        }

        public GenderType(string genderTypeName)
        {
            this.genderTypeName = genderTypeName;
        }

        public GenderTypeDTO GenderTypeToGenderTypeDTO()
        {
            return new GenderTypeDTO() 
            {
                GenderTypeId = this.genderTypeId, 
                GenderTypeName = this.genderTypeName
            };
        }

        public int GenderTypeId { get => genderTypeId; set => genderTypeId = value; }
        public string GenderTypeName { get => genderTypeName; set => genderTypeName = value; }
    }
}
