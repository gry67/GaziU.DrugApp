using GaziU.DrugApp.BL.Abstract;
using GaziU.DrugApp.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace GaziU.DrugApp.UI.Controllers
{
    public class DoktorController : Controller
    {
        private readonly IGenericManager<Hasta> hastaManager;
        private readonly IGenericManager<DoktorMuayeneKaydi> muayeneManager;
        public IActionResult Index(Doktor doktor)
        {
            var entities = hastaManager.GetAll(h=>h.DoktorId == doktor.Id);

            return View(entities);
        }

        public IActionResult HastaMuayene(int id)
        {
            ViewBag.hastaId = id;
            return View();
        }

        public async Task<IActionResult> HastaMuayeneKayitEkle(DoktorMuayeneKaydi kayit)
        {
            await muayeneManager.InsertAsync(kayit);
            return View();
        }


    }
}
