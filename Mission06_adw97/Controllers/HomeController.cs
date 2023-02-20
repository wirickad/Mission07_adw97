using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private MovieContext movieContext { get; set; }
        //Constuctor
        public HomeController(ILogger<HomeController> logger, MovieContext mc)
        {
            _logger = logger;
            movieContext = mc;
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
            ViewBag.Categories = movieContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(Movie mo)
        {
            
            if (ModelState.IsValid)
            {
                movieContext.Add(mo);
                movieContext.SaveChanges();

                return View("Confirmation", mo);
            }
            else
            {
                ViewBag.Categories = movieContext.Categories.ToList();
                return View(mo);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult MovieList()
        {
            
            var movieList = movieContext.Movies.Include(x => x.Category).ToList();
             
            return View(movieList);
        }

        //This is for editing the data

        [HttpGet]
        public IActionResult Edit(int MovieId)
        {
            ViewBag.Categories = movieContext.Categories.ToList();
            var movieForm = movieContext.Movies.Single(x => x.MovieId == MovieId);
            return View("AddMovie", movieForm);
        }

        [HttpPost]
        public IActionResult Edit(Movie mov)
        {
            movieContext.Update(mov);
            movieContext.SaveChanges();
            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int MovieId)
        {
            var movie = movieContext.Movies.Single(x => x.MovieId == MovieId);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(Movie mov)
        {
            movieContext.Movies.Remove(mov);
            movieContext.SaveChanges();
            return RedirectToAction("MovieList");
        }
    }
}
