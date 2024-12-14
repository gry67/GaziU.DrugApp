using GaziU.DrugApp.DAL.Models;
using GaziU.DrugApp.DAL.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace GaziU.DrugApp.UI.Controllers
{
    public class TestlerController : Controller
    {
        private readonly IGenericManager<BeckAnksiyeteOlcegiKayit> anksiyeteManager;
        private readonly IGenericManager<BarnesAkatiziOlcegi> barnesManager;
        private readonly IGenericManager<BeckDepresyonOlcegiKayit> depresyonManager;
        private readonly IGenericManager<Hasta> hastaManager;


        public TestlerController(IGenericManager<BeckAnksiyeteOlcegiKayit> anksiyeteManager, IGenericManager<BarnesAkatiziOlcegi> barnesManager, IGenericManager<BeckDepresyonOlcegiKayit> depresyonManager, IGenericManager<Hasta> hastaManager)
        {
            this.anksiyeteManager = anksiyeteManager;
            this.barnesManager = barnesManager;
            this.depresyonManager = depresyonManager;
            this.hastaManager = hastaManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BeckAnksiyete(int hastaId)
        {
            ViewBag.hastaId = hastaId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BeckAnksiyeteKayit(BeckAnksiyeteOlcegiKayit kayit) 
        {
            await anksiyeteManager.InsertAsync(kayit);
            var entity = hastaManager.GetByIdAsync(kayit.hastaId);
            return RedirectToAction("HastaIslemleriIndexById", "HastaIslemleri", new { hastaId = kayit.hastaId });
        }

        public IActionResult BeckDepresyon(int hastaId)
        {
            ViewBag.hastaId = hastaId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BeckDepresyonKayit(BeckDepresyonOlcegiKayit kayit)
        {
            await depresyonManager.InsertAsync(kayit);
            var entity = hastaManager.GetByIdAsync(kayit.hastaId);
            return RedirectToAction("HastaIslemleriIndexById", "HastaIslemleri", new { hastaId = kayit.hastaId });
        }

        public async Task<IActionResult> BarnesAkatiziTesti(int hastaId)
        {
            ViewBag.hastaId = hastaId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BarnesAkatiziTestiKayit(BarnesAkatiziOlcegi kayit)
        {
            await barnesManager.InsertAsync(kayit);
            var entity = hastaManager.GetByIdAsync(kayit.hastaId);
            return RedirectToAction("HastaIslemleriIndexById", "HastaIslemleri", new { hastaId = kayit.hastaId });
        }
    }
}
