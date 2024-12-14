using GaziU.DrugApp.BL.Abstract;
using GaziU.DrugApp.DAL.Models;
using GaziU.DrugApp.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GaziU.DrugApp.UI.Controllers
{
    public class DoktorController : Controller
    {
        private readonly IGenericManager<Hasta> hastaManager;
        private readonly IGenericManager<MuayeneKaydi> muayeneManager;
        private readonly IGenericManager<Doktor> doktorManager;
        private int doktorId;

        public DoktorController(IGenericManager<Hasta> hastaManager, IGenericManager<MuayeneKaydi> muayeneManager, IGenericManager<Doktor> doktorManager)
        {
            this.hastaManager = hastaManager;
            this.muayeneManager = muayeneManager;
            this.doktorManager = doktorManager;
        }

        private int FindIdByCookie()
        {
            return Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }



        public async Task<IActionResult> Index()
        {
            doktorId = FindIdByCookie();
            var entities = await hastaManager.GetAll(h => h.DoktorId == doktorId);
            var doktor = await doktorManager.GetByIdAsync(doktorId);

            return View("DoktorIslemleriIndex", new DoktorIndexToMuayeneModel { doktor = doktor, hastalar = entities });
        }

        public IActionResult HastaMuayene(int hastaId,int doktorId)
        {
            ViewBag.DoktorId = doktorId;
            ViewBag.hastaId = hastaId;
            return View();
        }

        public async Task<IActionResult> HastaMuayeneKayitEkle(MuayeneKaydi kayit)
        {
            await muayeneManager.InsertAsync(kayit);
            return RedirectToAction("HastaMuayene",new {hastaId=kayit.HastaId, doktorId=kayit.DoktorId});
        }
    }
}
