using GaziU.DrugApp.DAL.Models;
using GaziU.DrugApp.DAL.Repositories.Abstract;
using GaziU.DrugApp.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GaziU.DrugApp.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BL.Abstract.IGenericManager<Hasta> hastaManager;
        private readonly BL.Abstract.IGenericManager<Doktor> doktorManager;
        private readonly IHastaRepository hastaRepository;
        private readonly IDoktorRepository doktorRepository;

        public HomeController(ILogger<HomeController> logger, BL.Abstract.IGenericManager<Hasta> hastaManager, IHastaRepository hastaRepository, IDoktorRepository doktorRepository, BL.Abstract.IGenericManager<Doktor> doktorManager)
        {
            _logger = logger;
            this.hastaManager = hastaManager;
            this.hastaRepository = hastaRepository;
            this.doktorRepository = doktorRepository;
            this.doktorManager = doktorManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Hastaİslemleri(Hasta hasta)
        {
            Hasta entity = hastaRepository.HastaVarMi(hasta);
            if (entity!=null)
            {
                return RedirectToAction("HastaIslemleriIndex", "HastaIslemleri", entity);
            }else
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult Doktorİslemleri(Doktor doktor)
        {
            Doktor entity = doktorRepository.DoktorVarMi(doktor);
            if (entity != null)
            {
                return RedirectToAction("Index", "Doktor", entity);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult Uyelik()
        {
            return View();
        }

        public async Task<IActionResult> DoktorUyelik(Doktor doktor)
        {
            Doktor entity = doktorRepository.DoktorVarMi(doktor);
            if (entity != null)
            {
                return RedirectToAction("Doktorİslemleri", "Doktor", entity);
            }
            else
            {
                await doktorManager.InsertAsync(doktor);
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> HastaUyelik(Hasta hasta)
        {
            Hasta entity = hastaRepository.HastaVarMi(hasta);
            if (entity != null)
            {
                return RedirectToAction("Hastaİslemleri", "Doktor", entity);
            }
            else
            {
                hasta.DoktorId = 1;
                await hastaManager.InsertAsync(hasta);
                return RedirectToAction("Index");
            }
        }






        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
