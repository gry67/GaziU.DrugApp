using GaziU.DrugApp.DAL.Models;

namespace GaziU.DrugApp.UI.Controllers
{
    public interface IDoktorRepository
    {
        Doktor DoktorVarMi(Doktor Doktor);
    }

}