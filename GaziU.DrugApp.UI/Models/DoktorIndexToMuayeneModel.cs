using GaziU.DrugApp.DAL.Models;

namespace GaziU.DrugApp.UI.Models
{
    public class DoktorIndexToMuayeneModel
    {
        public IEnumerable<Hasta> hastalar { get; set; }
        public Doktor doktor { get; set; }
    }
}
