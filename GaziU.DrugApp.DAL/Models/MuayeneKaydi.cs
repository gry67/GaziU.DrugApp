using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaziU.DrugApp.DAL.Models
{
        public class MuayeneKaydi : BaseEntity
        {
            public string MuayeneNotu { get; set; }

            public int DoktorId { get; set; }
            public Doktor Doktor { get; set; }

            public int HastaId { get; set; }
            public Hasta Hasta { get; set; }
        }
}
