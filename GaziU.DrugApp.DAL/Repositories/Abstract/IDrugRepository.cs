using GaziU.DrugApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GaziU.DrugApp.DAL.Repositories.Abstract
{
    public interface IDrugRepository : IGenericManager<Drug>
    {
        Task<IEnumerable<Drug>> GetAllIncludingAsync(params Expression<Func<Drug, object>>[] includeProperties);
    }
}
