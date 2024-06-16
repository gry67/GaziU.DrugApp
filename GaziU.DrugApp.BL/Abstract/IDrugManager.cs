using GaziU.DrugApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaziU.DrugApp.BL.Abstract
{
    public interface IDrugManager : IGenericManager<Drug>
    {
        Task<IEnumerable<Drug>> GetAllDrugsAsync();
    }
}
