using AutoMapper;
using GaziU.DrugApp.BL;
using GaziU.DrugApp.BL.Abstract;
using GaziU.DrugApp.BL.Dtos;
using GaziU.DrugApp.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GaziU.DrugApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HastaController : ControllerBase
    {
        private readonly IGenericManager<Hasta> _genericManager;
        private readonly IGenericManager<HastaIlacKayit> _hastaIlacKayitManager;
        private readonly IMapper _mapper;


        public HastaController(IGenericManager<Hasta> genericManager)
        {
            _genericManager = genericManager;
            _mapper = MapperSingleton.GetMapperInstance();
        }

        [HttpPost]
        public async Task<IActionResult> HastaIlacKayit([FromBody]HastaIlacKayitDto hIKDto)
        {
            var hasta = await _genericManager.GetByIdAsync(hIKDto.hastaId);
            if (hasta == null)
            {
                return NotFound("Hasta Bulunamadı");
            }
            var ilac = await _genericManager.GetByIdAsync(hIKDto.ilacId);
            if (ilac == null)
            {
                return NotFound("Ilac bulunamadi");
            }

            var hastaIlacKayıt = new HastaIlacKayit()
            {
                CreatedDate = DateTime.Now,
                HastaId = hIKDto.hastaId,
                IlacId = hIKDto.ilacId,
                KullanimBilgisi = hIKDto.kullanimBilgisi
            };

            bool sonuc = await _hastaIlacKayitManager.InsertAsync(hastaIlacKayıt);
            if (sonuc)
            {
                return Ok("Hastanın Yeni İlaç kaydı Eklendi");
            }
            else
            {
                return StatusCode(500, "Hastanın İlaç kaydı eklenemediw");
            }
        }

        [HttpGet("IlacKayitlariniGetir/{id}")]
        public async Task<IActionResult> HastaIlacKayitlariniGetir([FromRoute]int hastaId)
        {
            var kayitlar = _hastaIlacKayitManager.GetAll(x=>x.HastaId == hastaId);
            return Ok(kayitlar);
        }

       [HttpGet]
        public async Task<IActionResult> HastalariGetir()
        {
            var hastalar = await _genericManager.GetAllAsync();
            List<HastaDto> hastaDtos = new List<HastaDto>();
            foreach (var hasta in hastalar)
            {
                hastaDtos.Add(_mapper.Map<HastaDto>(hasta));
            }
            return Ok(hastaDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> HastaGetirId([FromRoute] int id)
        {
            var entity = await _genericManager.GetByIdAsync(id);
            if (entity is not null)
            {
                return Ok(entity);
            }
            else
            {
                return BadRequest("Verdiğiniz Id değerine göre hasta bulunamadı");
            }
        }


        [HttpPost]
        [Route("Ekle")]
        public async Task<IActionResult> HastaEkle([FromBody] HastaInsertDto hastaIDto)
        {
            var hasta = _mapper.Map<Hasta>(hastaIDto);
            bool sonuc = await _genericManager.InsertAsync(hasta);
            if (sonuc)
            {
                return Ok("Hasta Eklendi");
            }
            else
            {
                return BadRequest("işlem başarısız");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> HastaSilId([FromRoute] int id)
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
        public async Task<IActionResult> HastaGuncelle([FromBody]HastaUpdateDto hastaUDto)
        {
            var entity = _genericManager.GetByIdAsync(hastaUDto.Id);
            if (entity is null)
            {
                return NotFound("Verdiğiniz Id'ye göre hasta bulunamadı");
            }
            else
            {
                var hasta = _mapper.Map<Hasta>(hastaUDto);
                await _genericManager.UpdateAsync(hasta);
                return Ok("Hasta Güncellendi");
            }
        }
    }
}
