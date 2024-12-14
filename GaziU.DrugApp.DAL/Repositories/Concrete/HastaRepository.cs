using GaziU.DrugApp.DAL.Models;
using GaziU.DrugApp.DAL.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GaziU.DrugApp.DAL.Repositories.Concrete
{
    public class HastaRepository : IHastaRepository
    {
        private readonly AppDbContext context;
        public HastaRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await context.Hastalar.FindAsync(id);
            if (entity != null)
            {
                context.Remove(entity);
                if (await context.SaveChangesAsync() > 0)
                {
                    return true;
                } else { return false; }
            }
            return false;
        }

        public async Task<IEnumerable<Hasta>> GetAll(Expression<Func<Hasta, bool>> expression)
        {
            return await context.Hastalar.Where(expression).ToListAsync();  
        }

        public async Task<IEnumerable<Hasta>> GetAllAsync()
        {
            return await context.Hastalar.ToListAsync();
        }

        public async Task<Hasta> GetByIdAsync(int id)
        {
            var entity = await context.Hastalar.FindAsync(id);
            if (entity != null)
            {
                return entity;
            }
            else
            {
                return null;
            }
        }

        public Hasta? HastaVarMi(Hasta hasta)
        {
            var entity = context.Hastalar.SingleOrDefault(h => h.EPosta == hasta.EPosta);
            return entity;
        }

        public Task<bool> InsertAsync(Hasta entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Hasta entity)
        {
            throw new NotImplementedException();
        }

    }
}
