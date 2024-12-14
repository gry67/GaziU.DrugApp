using GaziU.DrugApp.DAL.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GaziU.DrugApp.DAL.Repositories.Concrete
{
    public class GenericRepository<T> : IGenericManager<T> where T : class
    {
        public readonly AppDbContext _context;
        DbSet<T> _dbSet;

        public GenericRepository(AppDbContext contex)
        {
            _context = contex;
            _dbSet = _context.Set<T>();
        }

        
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                return false;
            }
            _dbSet.Remove(entity);
            if (await _context.SaveChangesAsync() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var entities = await _dbSet.ToListAsync();
            return entities;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity;
        }

        public async Task<bool> InsertAsync(T entity)
        {
            var Insertedentity = await _dbSet.AddAsync(entity);
            ;
            if (0< _context.SaveChanges())
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public async Task UpdateAsync(T entity)
        {
            try
            {
                var updatedEntity = _dbSet.Update(entity);
                if (updatedEntity.State == EntityState.Modified)
                {
                    Console.WriteLine($"entity repositoryde güncellendi");
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Güncelleme esnasında Repository'de hata oluştu: {ex}");
            }

        }

        
    }
}
