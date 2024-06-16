using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaziU.DrugApp.DAL.Models
{
    public class BarnesAkatiziOlcegi : BaseEntity
    {
        public Hasta hasta { get; set; }
        public int hastaId { get; set; }
        public int Soru1Puan { get; set; }
        public int Soru2Puan { get; set; }
        public int Soru3Puan { get; set; }
        public int Soru4Puan { get; set; }
        public int Soru5Puan { get; set; }
        public int Soru6Puan { get; set; }
        public int Soru7Puan { get; set; }
        public int Soru8Puan { get; set; }
        public int Soru9Puan { get; set; }
        public int Soru10Puan { get; set; }
        public int ToplamPuan { get; set; }
    }
}
