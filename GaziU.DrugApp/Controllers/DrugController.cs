using AutoMapper;
using GaziU.DrugApp.BL;
using GaziU.DrugApp.BL.Abstract;
using GaziU.DrugApp.BL.Dtos;
using GaziU.DrugApp.DAL.Models;
using GaziU.DrugApp.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;

namespace GaziU.DrugApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugController : ControllerBase
    {
        private readonly IGenericManager<Drug> _genericManager;
        private readonly IDrugManager _drugManager;
        private readonly IMapper _mapper;


        public DrugController(IGenericManager<Drug> genericManager, IDrugManager drugManager)
        {
            _genericManager = genericManager;
            _mapper = MapperSingleton.GetMapperInstance();
            _drugManager = drugManager;
        }

        [HttpGet]
        public async Task<IActionResult> ilaclariGetir()
        {
            var ilaclar = await _drugManager.GetAllDrugsAsync();
            var ilaclarDto = _mapper.Map<IEnumerable<DrugViewDto>>(ilaclar);
            return Ok(ilaclarDto);
        }

        [HttpPost]
        public async Task<IActionResult> ilacEkle([FromBody] DrugDto drugDto)
        {
            if (drugDto == null)
            {
                return BadRequest();
            }

            var drug = _mapper.Map<Drug>(drugDto);

            try
            {
                await _drugManager.InsertAsync(drug);
                return Ok(new { Message = "İlaç başarıyla eklendi." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Bir hata oluştu: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ilacSil([FromRoute] int id)
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
    }
}
