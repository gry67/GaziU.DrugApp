using GaziU.DrugApp.DAL.Models;
using GaziU.DrugApp.UI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaziU.DrugApp.DAL.Repositories.Concrete
{
    public class DoktorRepository : GenericRepository<Doktor>, IDoktorRepository
    {
        private readonly AppDbContext context;
        public DoktorRepository(AppDbContext contex) : base(contex)
        {
            this.context = contex;
        }

        public Doktor DoktorVarMi(Doktor Doktor)
        {
            var entity = context.Doktorlar.SingleOrDefault(d => d.EPosta == Doktor.EPosta);
            return entity;
        }
    }
}
