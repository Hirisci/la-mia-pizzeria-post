using la_mia_pizzeria_post.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Diagnostics;

namespace la_mia_pizzeria_model.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly List<Pizza> _pizze;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _pizze = new List<Pizza>
            {
                new Pizza(0, "/img/MARGHERITA-1.jpg","Margerita", "Pomodori pelati, spolverata di formaggio grattugiato e fior di latte d’Agerola", 6.00f),
                new Pizza(1, "/img/MARGHERITA-1.jpg", "Diavola", "Pomodori pelati, salame piccante spolverata di formaggio grattugiato e fior di latte d’Agerola",  7.00f),
                new Pizza(2, "/img/MARGHERITA-1.jpg", "Prosciutto e Funghi", "Pomodori pelati, funghi, prosciutto spolverata di formaggio grattugiato e fior di latte d’Agerola", 8.00f),
                new Pizza(3, "/img/MARGHERITA-1.jpg", "Napoli", "Pomodori pelati, spolverata di formaggio grattugiato e fior di latte d’Agerola",  9.00f),
                new Pizza(4, "/img/MARGHERITA-1.jpg", "Emilia", "Ragu bolognese, spolverata di formaggio grattugiato e fior di latte d’Agerola",  10.00f),
            };
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Menu()
        {
            return View(_pizze);
        }

        public IActionResult Create()
        {            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Pizza pizza)
        {
            if (ModelState.IsValid)
            {
                // aggiongo a database
                return Menu();
            }

            // ritorno indietro
            return RedirectToAction()
        }


        public IActionResult Details(int id)
        {
            Pizza? pizza = _pizze.Find(x=> x.Id == id);
            return View(pizza);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}