using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using prjMVCCoreDemo.Models;
using prjMVCCoreDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace prjMVCCoreDemo.Controllers
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
            if (!HttpContext.Session.Keys.Contains(CDictionary.SK_LOGINED_USER))
                return RedirectToAction("LogIn");
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

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(CLogInViewModel vModel)
        {
            TCustomer cust = (new dbDemoContext()).TCustomers.FirstOrDefault(c => c.FEmail.Equals(vModel.txtAccount));
            if(cust != null)
            {
                if (cust.FPassword.Equals(vModel.txtPassword))
                {
                    string JsonUser = JsonSerializer.Serialize(cust);
                    HttpContext.Session.SetString(CDictionary.SK_LOGINED_USER, JsonUser);
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}
