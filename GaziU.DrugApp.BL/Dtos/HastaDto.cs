using GaziU.DrugApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaziU.DrugApp.BL.Dtos
{
    public class HastaDto
    {
        public string Name { get; set; }
        public byte Yas { get; set; }
        public string EPosta { get; set; }
        public string Sifre { get; set; }
        public ICollection<Drug> HastaDrugs { get; set; }
    }
}
