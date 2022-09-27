using DSD603_Asseessment_1_Movie_Database_and_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DSD603_Asseessment_1_Movie_Database_and_API.Controllers
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //private static Movie GetMovies(Movie movie)
        //{
        //    List<Movie> movies1 = new()
        //    {
        //        new Movie() { Id = 1, Title = "Movie 1" }

        //    };
        //    List<Movie>? movies = movies1;
        //    return movie;
        //}
    }
}