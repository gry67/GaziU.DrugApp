using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaziU.DrugApp.DAL.Models
{
    public class DoktorMuayeneKaydi:BaseEntity
    {
        public string MuayeneNotları { get; set; }
        public Hasta hasta { get; set; }
        public int hastaId { get; set; }

    }
}
