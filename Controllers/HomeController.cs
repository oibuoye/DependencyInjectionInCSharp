using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DependencyInjectionInCSharp.Models;
using DependencyInjectionInCSharp.Configurations;
using Microsoft.Extensions.Options;

namespace DependencyInjectionInCSharp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TokenConfig _tokenConfig;

        public HomeController(ILogger<HomeController> logger, IOptions<TokenConfig> tokenConfig)
        {
            _logger = logger;
            _tokenConfig = tokenConfig.Value;
        }

        public IActionResult Index()
        {
            string getTokenKey = _tokenConfig.Key;
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
