using Microsoft.AspNetCore.Mvc;
using prjMVCCoreDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjMVCCoreDemo.Controllers
{
    public class ShoppingController : Controller
    {
        public IActionResult List()
        {
            var db = (new dbDemoContext()).TProducts;
            return View(db);
        }

        [HttpGet]
        public ActionResult AddToSession(int? id)
        {
            dbDemoContext db = new dbDemoContext();
            TProduct prod = db.TProducts.FirstOrDefault(x => x.FId == id);
            if (prod == null)
                return RedirectToAction("List");
            return View(prod);
        }

    }
}
