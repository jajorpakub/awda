using lab1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Diagnostics;

namespace lab1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About ()
        {
            ViewBag.Name = "Gabrysia";
            ViewBag.godzina = DateTime.Now.Hour;
            ViewBag.powitanie = ViewBag.godzina < 17 ? "Hejka rano" : "Hejka wieczorem";
            

            Dane[] osoby =
            {
                new Dane {Name = "Gabrysia", Surname = "Krzeczek"},
                new Dane {Name = "Tosia", Surname = "Bunny"},
            };
            return View(osoby);
        }

        public IActionResult Kalkulator(Kalkulator kalkulator)
        {
            if (kalkulator.Operacja == "+")
            {
                ViewBag.liczymy = kalkulator.A + kalkulator.B;
            }
            else if (kalkulator.Operacja == "-")
            {
                ViewBag.liczymy = kalkulator.A - kalkulator.B;
            }
            else if (kalkulator.Operacja == "/")
            {
                ViewBag.liczymy = kalkulator.A / kalkulator.B;
            }
            else if(kalkulator.Operacja == "*")
            {
                ViewBag.liczymy = kalkulator.A * kalkulator.B;
            }
            
            return View();
        }

        public IActionResult UrodzinyForm()
        {
            return View();
        }

        public IActionResult Urodziny(Urodziny urodziny)
        {
            ViewBag.powitanie = $"WItaj {urodziny.Imie} {DateTime.Now.Year - urodziny.Rok}";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}