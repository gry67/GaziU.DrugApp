using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaziU.DrugApp.DAL.Models
{
    public class DoktorMuayeneKaydi:BaseEntity
    {
        public string MuayeneNotlari { get; set; }
        public int HastaId { get; set; } 
        public ICollection<Hasta> Hasta { get; set; } 

        public int DoktorId { get; set; }
        public ICollection<Doktor> Doktor { get; set; }
    }
}
