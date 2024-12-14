using GaziU.DrugApp.BL.Abstract;
using GaziU.DrugApp.DAL.Models;
using GaziU.DrugApp.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GaziU.DrugApp.UI.Controllers
{
    public class DoktorIslemleriController : Controller
    {

        private readonly IDrugManager drugManager;
        private readonly IGenericManager<HastaIlacKayit> ilacKAyitManager;
        private readonly IGenericManager<Hasta> hastaManager;
        private readonly IGenericManager<BeckAnksiyeteOlcegiKayit> anksiyeteManager;
        private readonly IGenericManager<BeckDepresyonOlcegiKayit> beckManager;
        private readonly IGenericManager<BarnesAkatiziOlcegi> barnesManager;
        private readonly IGenericManager<MuayeneKaydi> muayeneManager;
        public DoktorIslemleriController(IDrugManager drugManager, IGenericManager<HastaIlacKayit> genericManager, IGenericManager<Hasta> hastaManager, IGenericManager<BeckDepresyonOlcegiKayit> beckManager, IGenericManager<BeckAnksiyeteOlcegiKayit> anksiyeteManager, IGenericManager<BarnesAkatiziOlcegi> barnesManager, IGenericManager<MuayeneKaydi> muayeneManager)
        {
            this.drugManager = drugManager;
            ilacKAyitManager = genericManager;
            this.hastaManager = hastaManager;
            this.beckManager = beckManager;
            this.anksiyeteManager = anksiyeteManager;
            this.barnesManager = barnesManager;
            this.muayeneManager = muayeneManager;
        }

        public async Task<IActionResult> MuayeneKayitlarList(int hastaId)
        {
            var kayitlar = await muayeneManager.GetAll(i=>i.HastaId== hastaId);
            ViewBag.hastaId = hastaId;
            return View(kayitlar);
        }

        public async Task<IActionResult> MuayeneKaydiSil(int hastaId, int kayitId)
        {
            if (kayitId == 0)
            {
                return Ok("muayene kaydı silinemiyor. kayitId null");
            }

            if (await muayeneManager.DeleteAsync(kayitId))
            {
                return RedirectToAction("MuayeneKayitlarList", new { hastaId = hastaId });
            }else
            {
                return Ok("silme başarısız");
            }
            
        }


        public async Task<IActionResult> KullandigiIlaclarById(int hastaId)
        {
            var ilacKayitlari = await ilacKAyitManager.GetAll(i => i.HastaId == hastaId);
            if (ilacKayitlari == null)
            {
                return NotFound("hastanın ilaç kayıtları gelmedi");
            }
            List<IlacKayitlariViewModel> kayitlar = new List<IlacKayitlariViewModel>();

            if (ilacKayitlari != null)
            {
                foreach (var item in ilacKayitlari)
                {
                    var ilac = await drugManager.GetByIdAsync(item.IlacId);

                    kayitlar.Add(new IlacKayitlariViewModel()
                    {
                        İlacAdi = ilac.TradeName,
                        KullanimBilgisi = item.KullanimBilgisi,
                        KayitTarihi = item.CreatedDate,
                        hastaId = hastaId,
                        kayitId = item.Id
                    });
                }
            }
            ViewBag.hastaId = hastaId;
            var hasta = await hastaManager.GetByIdAsync(hastaId);

            ViewBag.IlacKayitlari = kayitlar;
            return View(hasta);
        }

        public async Task<IActionResult> IlacKaydiSil(int hastaId, int Id)
        {
            if (await ilacKAyitManager.DeleteAsync(Id))
            {
                return RedirectToAction("KullandigiIlaclarById", new { hastaId = hastaId });
            }
            else
            {
                return Ok("silme başarısız");
            }
        }
        

        public async Task<IActionResult> IlacEkle(int hastaId)
        {
            var entity = await hastaManager.GetByIdAsync(hastaId);
            IEnumerable<Drug> ilaclar = await drugManager.GetAllAsync();
            ViewBag.IlacListesi = ilaclar;
            ViewBag.hastaId = hastaId;
            return View(entity);
        }

        public async Task<IActionResult> Ekle(HastaIlacKayit ilacKaydi)
        {
            ViewBag.hastaId = ilacKaydi.HastaId;
            await ilacKAyitManager.InsertAsync(ilacKaydi);
            var entity = await hastaManager.GetByIdAsync(ilacKaydi.HastaId);
            return RedirectToAction("KullandigiIlaclarById", new {hastaId = ilacKaydi.HastaId});
        }



        //Test sonuçlarını döndüren actionlar


        public async Task<IActionResult> AnksiyeteTestSil(int id, int hastaId)
        {
            if (await anksiyeteManager.DeleteAsync(id))
            {
                return RedirectToAction("YapilanTestler", new { id = hastaId });
            }
            else
            {
                return BadRequest("Anksiyete testi silinemedi");
            }
        }
        public async Task<IActionResult> YapilanTestler(int id)
        {
            //Anksiyete testleri
            if (id == 0)
            {
                return NotFound("id 0 geldi");
            }
            List<BeckAnksiyeteOlcegiKayit> kayitlar = new List<BeckAnksiyeteOlcegiKayit>();
            var veriler = await anksiyeteManager.GetAll(h => h.hastaId == id);

            foreach (var item in veriler)
            {
                kayitlar.Add(item);
            }

            ViewBag.hastaId = id;


            return View(kayitlar);
        }

        public async Task<IActionResult> DepresyonTestSil(int Id, int hastaId)
        {
            
            if (await beckManager.DeleteAsync(Id))
            {
                return RedirectToAction("BeckDepresyonTestler", new { id = hastaId });
            }
            else
            {
                return BadRequest("depresyon testi silinemedi");
            }
        }

        public async Task<IActionResult> BeckDepresyonTestler(int id)
        {
            if (id == 0)
            {
                return NotFound("id 0 geldi");
            }
            List<BeckDepresyonOlcegiKayit> kayitlar = new List<BeckDepresyonOlcegiKayit>();
            var veriler = await beckManager.GetAll(h => h.hastaId == id);

            foreach (var item in veriler)
            {
                kayitlar.Add(item);
            }

            ViewBag.hastaId = id;

            return View(kayitlar);
        }


        public async Task<IActionResult> AkatiziTestSil(int kayitId,int hastaId)
        {
            if (await barnesManager.DeleteAsync(kayitId))
            {
                return RedirectToAction("BarnesAkatiziTesler", new { id = hastaId });
            }
            else
            {
                return Ok("Test silinemedi");
            }
        }

        public async Task<IActionResult> BarnesAkatiziTesler(int id)
        {

            if (id == 0)
            {
                return NotFound("id 0 geldi");
            }
            List<BarnesAkatiziOlcegi> kayitlar = new List<BarnesAkatiziOlcegi>();
            var veriler = await barnesManager.GetAll(h => h.hastaId == id);

            foreach (var item in veriler)
            {
                kayitlar.Add(item);
            }

            ViewBag.hastaId = id;


            return View(kayitlar);
        }
    }
}
