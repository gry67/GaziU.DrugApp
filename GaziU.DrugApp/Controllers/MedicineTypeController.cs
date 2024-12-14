using AutoMapper;
using GaziU.DrugApp.BL;
using GaziU.DrugApp.BL.Abstract;
using GaziU.DrugApp.BL.Dtos;
using GaziU.DrugApp.DAL.Models;
using GaziU.DrugApp.Dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace GaziU.DrugApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MedicineTypeController : ControllerBase
    {
        private readonly IGenericManager<MedicineType> _genericManager;
        private readonly IMapper _mapper;


        public MedicineTypeController(IGenericManager<MedicineType> genericManager)
        {
            _genericManager = genericManager;
            _mapper = MapperSingleton.GetMapperInstance();
        }

        [HttpGet]
        public async Task<IActionResult> ilacTurleriniGetir()
        {
            var ilacturleri = await _genericManager.GetAllAsync();
            return Ok(ilacturleri);
        }


        [HttpPost]
        public async Task<IActionResult> ilacTuruEkle(MedicineTypeDto mTypeDto)
        {
            var entity = _mapper.Map<MedicineType>(mTypeDto);
            bool sonuc = await _genericManager.InsertAsync(entity);
            if (sonuc)
            {
                return Ok("ilaç Türü eklendi");
            }
            else
            {
                return Ok("işlem başarısız");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ilacTuruSil([FromRoute] int id)
        {
           var entity = await _genericManager.GetByIdAsync(id);
            if (entity is not null)
            {
                await _genericManager.DeleteAsync(id);
                return Ok("İlaç Türü Silindi");
            }
            else
            {
                return BadRequest("İlaç türü bulunamadı");
            }
        }
    }
}
