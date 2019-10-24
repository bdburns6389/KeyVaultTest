using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KeyVaultTest.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace KeyVaultTest.Controllers
{
    
    public class HomeController : Controller
    {
        public IConfiguration Configuration { get; set; }
        private readonly AppSettings _appSettings;

        public HomeController(IConfiguration config, IOptions<AppSettings> appSettings)
        {
            Configuration = config;
            _appSettings = appSettings.Value;
        }
        public IActionResult Index()
        {
            ViewData["RootSetting"] = Configuration["TestAtRoot"];
            ViewData["AppSettingInAppSettings"] = _appSettings.TestInAppSettings;
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
