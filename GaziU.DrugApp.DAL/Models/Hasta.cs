using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaziU.DrugApp.DAL.Models
{
    public class Hasta : BaseEntity
    {
        public string Name { get; set; }
        public DateTime? DogumTarihi { get; set; }
        public string EPosta { get; set; }
        public string Sifre { get; set; }
        public ICollection<Drug> HastaDrugs { get; set; }

        public Doktor Doktor { get; set; }
        public int DoktorId { get; set; }
        public ICollection<DoktorMuayeneKaydi> DoktorMuayeneKayitlari { get; set; }
    }

}
