using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaziU.DrugApp.BL.Dtos
{
    public class HastaIlacKayitDto
    {
        public int hastaId { get; set; }
        public int ilacId { get; set; }
        public string kullanimBilgisi { get; set; }
    }
}
