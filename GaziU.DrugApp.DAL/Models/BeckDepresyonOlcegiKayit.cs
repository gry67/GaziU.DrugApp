using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaziU.DrugApp.DAL.Models
{
    public class BeckDepresyonOlcegiKayit : BaseEntity
    {
        public Hasta hasta { get; set; }
        public int hastaId { get; set; }

        public byte Soru1Puan { get; set; }
        public byte Soru2Puan { get; set; }
        public byte Soru3Puan { get; set; }
        public byte Soru4Puan { get; set; }
        public byte Soru5Puan { get; set; }
        public byte Soru6Puan { get; set; }
        public byte Soru7Puan { get; set; }
        public byte Soru8Puan { get; set; }
        public byte Soru9Puan { get; set; }
        public byte Soru10Puan { get; set; }
        public byte Soru11Puan { get; set; }
        public byte Soru12Puan { get; set; }
        public byte Soru13Puan { get; set; }
        public byte Soru14Puan { get; set; }
        public byte Soru15Puan { get; set; }
        public byte Soru16Puan { get; set; }
        public byte Soru17Puan { get; set; }
        public byte Soru18Puan { get; set; }
        public byte Soru19Puan { get; set; }
        public byte Soru20Puan { get; set; }
        public byte Soru21Puan { get; set; }

        public byte ToplamPuan { get; set; }
    }
}
