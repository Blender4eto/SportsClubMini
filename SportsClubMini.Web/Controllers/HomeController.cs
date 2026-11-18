using Microsoft.AspNetCore.Mvc;
using SportsClubMini.Services.Contracts;
using SportsClubMini.Web.Models;
using System.Diagnostics;

namespace SportsClubMini.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISportClubService _sportClubService;

        public HomeController(ILogger<HomeController> logger, ISportClubService sportClubService)
        {
            _logger = logger;
            _sportClubService = sportClubService;
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
    }
}
