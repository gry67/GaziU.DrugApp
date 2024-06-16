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

        public TestlerController(IGenericManager<BeckAnksiyeteOlcegiKayit> anksiyeteManager, IGenericManager<BarnesAkatiziOlcegi> barnesManager, IGenericManager<BeckDepresyonOlcegiKayit> depresyonManager)
        {
            this.anksiyeteManager = anksiyeteManager;
            this.barnesManager = barnesManager;
            this.depresyonManager = depresyonManager;
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
        public async Task<IActionResult> BeckAnksiyeteKayit(BeckAnksiyeteOlcegiKayit kayit) 
        {
            await anksiyeteManager.InsertAsync(kayit);
            return View("Index");
        }

        public IActionResult BeckDepresyon(int hastaId)
        {
            ViewBag.hastaId = hastaId;
            return View();
        }
        public async Task<IActionResult> BeckDepresyonKayit(BeckDepresyonOlcegiKayit kayit)
        {
            await depresyonManager.InsertAsync(kayit);
            return View("Index");
        }

        public async Task<IActionResult> BarnesAkatiziTesti(int hastaId)
        {
            ViewBag.hastaId = hastaId;
            return View();
        }

        public async Task<IActionResult> BarnesAkatiziTestiKayit(BarnesAkatiziOlcegi olcek)
        {
            await barnesManager.InsertAsync(olcek);
            return View("Index");
        }
    }
}
