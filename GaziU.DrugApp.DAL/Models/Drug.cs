using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GaziU.DrugApp.DAL.Models
{
    public class Drug : BaseEntity
    {
        //İlaçların marka isimlerini temsil eder.
        public string TradeName { get; set; }
        public MedicineType MedicineType { get; set; }
        public int MedicineTypeId { get; set; }
        public ActiveIngredient ActiveIngredient { get; set; }
        public int ActiveIngredientId { get; set; }
    }
}
