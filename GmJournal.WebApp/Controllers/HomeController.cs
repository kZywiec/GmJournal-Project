using GmJournal.Logic.Services.Users;
using GmJournal.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GmJournal.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserAccessService _userAccessService;

        public HomeController(ILogger<HomeController> logger, IUserAccessService userAccessService)
        {
            _logger = logger;
            _userAccessService = userAccessService;
        }

        public IActionResult Index()
        {
            ViewData["CurrentUser"] = _userAccessService.LoggedUser;
            if (_userAccessService.LoggedUser != null)
                ViewData["CurrentUser.name"] = _userAccessService.LoggedUser.login;
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