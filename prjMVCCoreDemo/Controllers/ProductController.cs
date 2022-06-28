using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using prjMVCCoreDemo.Models;
using prjMVCCoreDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace prjMVCCoreDemo.Controllers
{
    public class ProductController : Controller
    {
        private IWebHostEnvironment _environment;

        public ProductController(IWebHostEnvironment p )
        {
            _environment = p;
        }

        public IActionResult List(CKeywordViewModel vModel)
        {
            dbDemoContext db = new dbDemoContext();
            IEnumerable<TProduct> datas = null;

            if (string.IsNullOrEmpty(vModel.txtKeyword))
                datas = db.TProducts;
            else
                datas = db.TProducts.Where(t => t.FName.Contains(vModel.txtKeyword));

            return View(datas);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TProduct p)
        {
            dbDemoContext db = new dbDemoContext();
            db.TProducts.Add(p);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Delete(int? id)
        {
            dbDemoContext db = new dbDemoContext();
            TProduct p = db.TProducts.FirstOrDefault(t => t.FId == id);
            db.TProducts.Remove(p);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            dbDemoContext db = new dbDemoContext();
            TProduct prod = db.TProducts.FirstOrDefault(x => x.FId == id);
            if (prod == null)
                return RedirectToAction("List");
            return View(prod);
        }

        [HttpPost]
        public IActionResult Edit(CProductViewModel p)
        {
            dbDemoContext db = new dbDemoContext();
            TProduct prod = db.TProducts.FirstOrDefault(t => t.FId == p.FId);

            if (prod != null)
            {
                if (p.photo != null)
                {
                    string pName = Guid.NewGuid().ToString() + ".png";
                    p.photo.CopyTo(new FileStream(_environment.WebRootPath + "/Images/" + pName, FileMode.Create));
                    prod.FImagePath = pName;
                }
                prod.FName = p.FName;
                prod.FPrice = p.FPrice;
                prod.FQty = p.FQty;
                prod.FCost = p.FCost;
            }
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
