﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaziU.DrugApp.DAL.Models
{
    public class ActiveIngredient : BaseEntity
    {
        //Etken Madde ismini temsil eder
        public string IngredientName { get; set; }
        public string HalfLife { get; set; }
    }
}
