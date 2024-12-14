using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaziU.DrugApp.DAL.Models
{
    public class Doktor : BaseEntity
    {
        public string Name { get; set; }
        public DateTime? DogumTarihi { get; set; }
        public string EPosta { get; set; }
        public string Sifre { get; set; }

        public ICollection<Hasta> Hastalar { get; set; }

        public  ICollection<MuayeneKaydi> MuayeneKayitlari { get; set; }

    }
}
