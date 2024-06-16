using AutoMapper;
using GaziU.DrugApp.BL.Abstract;
using GaziU.DrugApp.BL;
using GaziU.DrugApp.DAL.Models;
using GaziU.DrugApp.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GaziU.DrugApp.BL.Dtos;

namespace GaziU.DrugApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActiveIngredientController : ControllerBase
    {
        private readonly IGenericManager<ActiveIngredient> _genericManager;
        private readonly IMapper _mapper;


        public ActiveIngredientController(IGenericManager<ActiveIngredient> genericManager)
        {
            _genericManager = genericManager;
            _mapper = MapperSingleton.GetMapperInstance();
        }

        [HttpGet]
        public async Task<IActionResult> EtkenMaddeleriGetir()
        {
            var etkenMaddeler = await _genericManager.GetAllAsync();
            return Ok(etkenMaddeler);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> EtkenMaddeGetirId([FromRoute]int id)
        {
            var entity = await _genericManager.GetByIdAsync(id);
            if (entity is not null)
            {
                return Ok(entity);
            }
            else
            {
                return BadRequest("Verdiğiniz Id değerine göre etken madde bulunamadı");
            }
        }


        [HttpPost]
        public async Task<IActionResult> EtkenMaddeEkle(ActiveIngredient aIngredient)
        {
            bool sonuc = await _genericManager.InsertAsync(aIngredient);
            if (sonuc)
            {
                return Ok("Etken Madde Eklendi");
            }
            else
            {
                return BadRequest("işlem başarısız");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EtkenMaddeSil([FromRoute] int id)
        {
            var entity = await _genericManager.GetByIdAsync(id);
            if (entity is not null)
            {
                await _genericManager.DeleteAsync(id);
                return Ok("İlaç Silindi");
            }
            else
            {
                return BadRequest("İlaç bulunamadı");
            }
        }

        [HttpPut]
        public async Task<IActionResult> EtkenMaddeGuncelle([FromBody] ActiveIngredientDto aIngredientDto)
        {
            var entity = _mapper.Map<ActiveIngredient>(aIngredientDto);
            await _genericManager.UpdateAsync(entity);
            return Ok("Etken Madde Güncellendi");
        }
    }
}
