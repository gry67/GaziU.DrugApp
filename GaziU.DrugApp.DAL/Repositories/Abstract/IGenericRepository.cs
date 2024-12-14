using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GaziU.DrugApp.DAL.Repositories.Abstract
{
    public interface IGenericManager<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> expression);
        Task<bool> InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);

    }
}
