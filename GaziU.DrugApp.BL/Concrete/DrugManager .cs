using GaziU.DrugApp.BL.Abstract;
using GaziU.DrugApp.DAL.Models;
using GaziU.DrugApp.DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaziU.DrugApp.BL.Concrete
{
    public class DrugManager : GenericManager<Drug>, IDrugManager
    {
        private readonly IDrugRepository _drugRepository;

        public DrugManager(IDrugRepository drugRepository, DAL.Repositories.Abstract.IGenericManager<Drug> repository)
            : base(repository)
        {
            _drugRepository = drugRepository ?? throw new ArgumentNullException(nameof(drugRepository));
        }


        public async Task<IEnumerable<Drug>> GetAllDrugsAsync()
        {
            return await _drugRepository.GetAllIncludingAsync(drug => drug.MedicineType, drug => drug.ActiveIngredient);
        }
    }
}
