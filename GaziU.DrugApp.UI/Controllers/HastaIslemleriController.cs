using GaziU.DrugApp.BL.Abstract;
using GaziU.DrugApp.BL.Concrete;
using GaziU.DrugApp.DAL.Models;
using GaziU.DrugApp.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace GaziU.DrugApp.UI.Controllers
{
    public class HastaIslemleriController : Controller
    {
        private readonly IDrugManager drugManager;
        private readonly IGenericManager<HastaIlacKayit> manager;
        private readonly IGenericManager<Hasta> hastaManager;
        private readonly IGenericManager<BeckAnksiyeteOlcegiKayit> anksiyeteManager;
        private readonly IGenericManager<BeckDepresyonOlcegiKayit> beckManager;
        private readonly IGenericManager<BarnesAkatiziOlcegi> barnesManager;



        public HastaIslemleriController(IDrugManager drugManager, IGenericManager<HastaIlacKayit> genericManager, IGenericManager<Hasta> hastaManager, IGenericManager<BeckDepresyonOlcegiKayit> beckManager, IGenericManager<BeckAnksiyeteOlcegiKayit> anksiyeteManager, IGenericManager<BarnesAkatiziOlcegi> barnesManager)
        {
            this.drugManager = drugManager;
            manager = genericManager;
            this.hastaManager = hastaManager;
            this.beckManager = beckManager;
            this.anksiyeteManager = anksiyeteManager;
            this.barnesManager = barnesManager;
        }

        public async Task<IActionResult> HastaIslemleriIndex(Hasta hasta)
        {
            ViewBag.IlacListesi = await drugManager.GetAllAsync();
            return View(hasta);
        }

        public async Task<IActionResult> HastaIslemleriIndexById(int hastaId)
        {
            var hasta = await hastaManager.GetByIdAsync(hastaId);

            if (hasta == null)
            {
                return NotFound();
            }
            ViewBag.IlacListesi = await drugManager.GetAllAsync();
            return View("HastaIslemleriIndex", hasta);
        }

        public async Task<IActionResult> Ekle(HastaIlacKayit ilacKaydi)
        {
            await manager.InsertAsync(ilacKaydi);
            var entity = await hastaManager.GetByIdAsync(ilacKaydi.HastaId);
            return RedirectToAction("KullandigiIlaclar", entity);
        }

        public async Task<IActionResult> KullandigiIlaclar(Hasta hasta)
        {

            var ilacKayitlari = await manager.GetAll(i => i.HastaId == hasta.Id);
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
                        KayitTarihi = item.CreatedDate
                    });
                }
            }
            ViewBag.hastaId = hasta.Id;

            ViewBag.IlacKayitlari = kayitlar;
            return View(hasta);
        }

        public async Task<IActionResult> KullandigiIlaclarById(int hastaId)
        {
            if (hastaId==null)
            {
                return NotFound("hastaId gelmedi");
            }else if (hastaId == 0)
            {
                return NotFound("HastaId 0 geldi");
            }

            var entity = await hastaManager.GetByIdAsync(hastaId);
            if (entity==null)
            {
                return NotFound("hasta sorgudan gelmedi"+$"{hastaId}");
            }

            return RedirectToAction("KullandigiIlaclar", entity);
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

        public async Task<IActionResult> BarnesAkatiziTesleri(int id)
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
