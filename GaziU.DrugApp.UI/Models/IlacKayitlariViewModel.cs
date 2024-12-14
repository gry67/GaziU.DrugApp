using GaziU.DrugApp.DAL.Models;

namespace GaziU.DrugApp.UI.Models
{
    public class IlacKayitlariViewModel
    {
        public string İlacAdi { get; set; }
        public string KullanimBilgisi { get; set; }
        public int hastaId { get; set; }
        public int kayitId { get; set; }
        public DateTime? KayitTarihi { get; set; }
    }
}
