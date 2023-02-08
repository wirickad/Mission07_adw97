using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission06_adw97.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_adw97.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieContext _blahContext { get; set; }
        //Constuctor
        public HomeController(ILogger<HomeController> logger, MovieContext mc)
        {
            _logger = logger;
            _blahContext = mc;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(Movie mo)
        {
            _blahContext.Add(mo);
            _blahContext.SaveChanges();

            return View("Confirmation", mo);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
