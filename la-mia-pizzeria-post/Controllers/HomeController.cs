﻿using la_mia_pizzeria_post.Data;
using la_mia_pizzeria_post.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace la_mia_pizzeria_model.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PizzeDbContext _db;

        public HomeController(ILogger<HomeController> logger, PizzeDbContext db)
        {
            _db = db;
            _logger = logger;
            
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Menu()
        {
            List<Pizza> pizze = _db.Pizze.ToList();
            return View(pizze);
        }
        
        public IActionResult Create()
        {            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza pizza)
        {
            if (!ModelState.IsValid)
            {
                return View(pizza);
            }
            
            _db.Pizze.Add(pizza);
            _db.SaveChanges();
            return RedirectToAction(nameof(Menu));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Pizza? pizza = _db.Pizze.First(x => x.Id == id);
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