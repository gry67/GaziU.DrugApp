using GaziU.DrugApp.DAL.Models;
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
    public class DrugRepository : GenericRepository<Drug> , IDrugRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Drug> _dbSet;

        public DrugRepository(AppDbContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<Drug>();
        }

        public async Task<IEnumerable<Drug>> GetAllIncludingAsync(params Expression<Func<Drug, object>>[] includeProperties)
        {
            IQueryable<Drug> query = _dbSet;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return await query.ToListAsync();
        }
    }
}
