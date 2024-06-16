using GaziU.DrugApp.BL.Abstract;
using GaziU.DrugApp.DAL.Models;
using GaziU.DrugApp.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GaziU.DrugApp.UI.Controllers
{
    public class DoktorController : Controller
    {
        private readonly IGenericManager<Hasta> hastaManager;
        private readonly IGenericManager<DoktorMuayeneKaydi> muayeneManager;

        public DoktorController(IGenericManager<Hasta> hastaManager, IGenericManager<DoktorMuayeneKaydi> muayeneManager)
        {
            this.hastaManager = hastaManager;
            this.muayeneManager = muayeneManager;
        }

        public async Task<IActionResult> Index(Doktor doktor)
        {
            var entities = await hastaManager.GetAll(h=>h.DoktorId == doktor.Id);

            return View("DoktorIslemleriIndex",new DoktorIndexToMuayeneModel { doktor=doktor,hastalar=entities});
        }

        public IActionResult HastaMuayene(int hastaId,int doktorId)
        {
            ViewBag.DoktorId = doktorId;
            ViewBag.hastaId = hastaId;
            return View();
        }

        public async Task<IActionResult> HastaMuayeneKayitEkle(DoktorMuayeneKaydi kayit)
        {
            await muayeneManager.InsertAsync(kayit);
            return RedirectToAction("Index");
        }


    }
}
