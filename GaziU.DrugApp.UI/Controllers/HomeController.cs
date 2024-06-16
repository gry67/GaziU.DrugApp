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
        private readonly IHastaRepository hastaRepository;
        private readonly IDoktorRepository doktorRepository;

        public HomeController(ILogger<HomeController> logger, BL.Abstract.IGenericManager<Hasta> hastaManager, IHastaRepository hastaRepository, IDoktorRepository doktorRepository)
        {
            _logger = logger;
            this.hastaManager = hastaManager;
            this.hastaRepository = hastaRepository;
            this.doktorRepository = doktorRepository;
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
                return RedirectToAction("DoktorIslemleriIndex", "Doktor", entity);
            }
            else
            {
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
