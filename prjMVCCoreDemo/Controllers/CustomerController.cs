using Microsoft.AspNetCore.Mvc;
using prjMVCCoreDemo.Models;
using prjMVCCoreDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjMVCCoreDemo.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult List(CKeywordViewModel vModel)
        {
            dbDemoContext db = new dbDemoContext();
            IEnumerable<TCustomer> datas = null;
            if (string.IsNullOrEmpty(vModel.txtKeyword))
                datas = db.TCustomers;
            else
            {
                datas = db.TCustomers.Where(t => t.FName.Contains(vModel.txtKeyword) ||
                                               t.FPhone.Contains(vModel.txtKeyword) ||
                                               t.FAddress.Contains(vModel.txtKeyword) ||
                                               t.FEmail.Contains(vModel.txtKeyword)
                                               );
            }
            return View(datas);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TCustomer c)
        {
            dbDemoContext db = new dbDemoContext();
            db.TCustomers.Add(c);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            dbDemoContext db = new dbDemoContext();
            TCustomer cust = db.TCustomers.FirstOrDefault(c => c.FId == id);
            if (cust == null)
                return RedirectToAction("List");
            return View(cust);
        }

        [HttpPost]
        public IActionResult Edit(TCustomer c)
        {
            dbDemoContext db = new dbDemoContext();
            TCustomer cust = db.TCustomers.FirstOrDefault(c => c.FId == c.FId);

            if (cust != null)
            {
                cust.FName = c.FName;
                cust.FPhone = c.FPhone;
                cust.FEmail = c.FEmail;
                cust.FAddress = c.FAddress;
                cust.FPassword = c.FPassword;
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }

        public IActionResult Delete(int? id)
        {
            dbDemoContext db = new dbDemoContext();
            TCustomer c = db.TCustomers.FirstOrDefault(t => t.FId == id);
            db.TCustomers.Remove(c);
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
