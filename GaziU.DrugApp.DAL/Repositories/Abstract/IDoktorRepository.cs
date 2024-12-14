using GaziU.DrugApp.DAL.Models;
using GaziU.DrugApp.DAL.Repositories.Abstract;
using GaziU.DrugApp.DAL.Repositories.Concrete;

namespace GaziU.DrugApp.UI.Controllers
{
    public interface IDoktorRepository
    {
        Doktor DoktorVarMi(Doktor Doktor);
    }

}