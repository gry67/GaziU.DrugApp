using GaziU.DrugApp.DAL.Models;
using GaziU.DrugApp.DAL.Repositories.Abstract;
using GaziU.DrugApp.UI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

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

        //Login and direction
        //Girişe mahsus hasta verisi cookie den alınmaz
        public IActionResult Hastaİslemleri(Hasta hasta)
        {
            Hasta entity = hastaRepository.HastaVarMi(hasta);
            if (entity!=null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, entity.Name),
                    new Claim(ClaimTypes.NameIdentifier, entity.Id.ToString()),
                    new Claim(ClaimTypes.Role, "Hasta")
                };
                
                var claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    IssuedUtc = DateTime.UtcNow,
                };

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme
                    ,new ClaimsPrincipal(claimsIdentity),authProperties);

                return RedirectToAction("HastaIslemleriIndex", "HastaIslemleri");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        //Login and direction
        public IActionResult Doktorİslemleri(Doktor doktor)
        {
            Doktor entity = doktorRepository.DoktorVarMi(doktor);
            if (entity != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, entity.Name),
                    new Claim(ClaimTypes.NameIdentifier, entity.Id.ToString()),
                    new Claim(ClaimTypes.Role, "Doktor")
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    IssuedUtc = DateTime.UtcNow,
                };

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme
                    , new ClaimsPrincipal(claimsIdentity), authProperties);

                return RedirectToAction("Index", "Doktor");
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
