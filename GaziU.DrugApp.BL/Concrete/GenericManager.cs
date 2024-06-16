using GaziU.DrugApp.BL.Abstract;
using GaziU.DrugApp.DAL.Repositories.Abstract;
using GaziU.DrugApp.DAL.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GaziU.DrugApp.BL.Concrete
{
    public class GenericManager<T>  : Abstract.IGenericManager<T> where T : class
    {
        private readonly DAL.Repositories.Abstract.IGenericManager<T> _repository;

        public GenericManager(DAL.Repositories.Abstract.IGenericManager<T> repository) 
        {
            _repository = repository;
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> expression)
        {
            return  await _repository.GetAll(expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<bool> InsertAsync(T entity)
        {
            return await _repository.InsertAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            await _repository.UpdateAsync(entity);
        }
    }
}
