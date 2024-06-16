using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaziU.DrugApp.DAL.Models
{
    public class HastaIlacKayit : BaseEntity
    {
        public Hasta Hasta { get; set; }
        public int HastaId { get; set; }
        public Drug Ilac { get; set; }
        public int IlacId { get; set; }
        public string KullanimBilgisi { get; set; }
    }
}
