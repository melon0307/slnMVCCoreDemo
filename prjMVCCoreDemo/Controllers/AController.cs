using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using prjLottoApp.Models;
using prjMVCCoreDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace prjMVCCoreDemo.Controllers
{
    public class AController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public string sayHello()
        {
            return "Hello ASP.NET Core MVC";
        }
            
        public string lotto()
        {
            return (new CLottoGen()).getLotto();
        }

        public IActionResult showCountBySession()
        {
            int count = 0;
            if (HttpContext.Session.Keys.Contains("KK"))
                count = (int)HttpContext.Session.GetInt32("KK");
            count++;
            HttpContext.Session.SetInt32("KK", count); 
            ViewBag.kk = count;
            return View();
        }

        public string demoObjectToJson()
        {
            TProduct p = new TProduct();
            p.FName = "PS5";
            p.FQty = 20;
            p.FPrice = 9750;
            return JsonSerializer.Serialize(p);
        }

        public string demoJsonToObject()
        {
            string Json = demoObjectToJson();
            TProduct p = JsonSerializer.Deserialize<TProduct>(Json);
            return p.FName + "/" + p.FPrice.ToString();
        }
    }
}
