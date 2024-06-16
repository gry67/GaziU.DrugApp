using GaziU.DrugApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaziU.DrugApp.DAL.Repositories.Abstract
{
    public interface IHastaRepository : IGenericManager<Hasta>
    {
        Hasta HastaVarMi(Hasta hasta);
    }
}
