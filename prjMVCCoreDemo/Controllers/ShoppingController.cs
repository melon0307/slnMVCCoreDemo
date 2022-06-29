using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using prjMVCCoreDemo.Models;
using prjMVCCoreDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace prjMVCCoreDemo.Controllers
{
    public class ShoppingController : Controller
    {
        public IActionResult CartView()
        {
            if (HttpContext.Session.Keys.Contains(CDictionary.SK_已加入購物車的_商品們_列表))
            {
                string JsonCart = HttpContext.Session.GetString(CDictionary.SK_已加入購物車的_商品們_列表);
                List<CShoppingCartItem> cart = JsonSerializer.Deserialize<List<CShoppingCartItem>>(JsonCart);
                return View(cart);
            }
            else
                return RedirectToAction("List");            
        }

        public IActionResult List()
        {
            var db = (new dbDemoContext()).TProducts;
            List<CProductViewModel> list = new List<CProductViewModel>();

            foreach(TProduct t in db)
            {
                CProductViewModel p = new CProductViewModel();
                p.product = t;
                list.Add(p);
            }
            return View(list);
        }

        [HttpGet]
        public IActionResult AddToSession(int? id)
        {
            dbDemoContext db = new dbDemoContext();
            TProduct prod = db.TProducts.FirstOrDefault(x => x.FId == id);
            if (prod == null)
                return RedirectToAction("List");
            return View(prod);
        }

        [HttpPost]
        public IActionResult AddToSession(CAddToCartViewModel mvModel)
        {
            dbDemoContext db = new dbDemoContext();
            TProduct prod = db.TProducts.FirstOrDefault(x => x.FId == mvModel.txtFId);
            if (prod == null)
                return RedirectToAction("List");

            string JsonCart = "";
            List<CShoppingCartItem> cart = null;

            if (HttpContext.Session.Keys.Contains(CDictionary.SK_已加入購物車的_商品們_列表))
            {
                JsonCart = HttpContext.Session.GetString(CDictionary.SK_已加入購物車的_商品們_列表);
                cart = JsonSerializer.Deserialize<List<CShoppingCartItem>>(JsonCart);
            }
            else
                cart = new List<CShoppingCartItem>();

            CShoppingCartItem cartItem = new CShoppingCartItem()
            {
                productId = mvModel.txtFId,
                price = (decimal)prod.FPrice,
                count = mvModel.txtCount,
                product = prod
            };
            cart.Add(cartItem);

            JsonCart = JsonSerializer.Serialize(cart);
            HttpContext.Session.SetString(CDictionary.SK_已加入購物車的_商品們_列表, JsonCart);
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.Keys.Contains(CDictionary.SK_已加入購物車的_商品們_列表))
            {
                string JsonCart = HttpContext.Session.GetString(CDictionary.SK_已加入購物車的_商品們_列表);
                List<CShoppingCartItem> cart = JsonSerializer.Deserialize<List<CShoppingCartItem>>(JsonCart);
                cart.RemoveAt(id);
                JsonCart = JsonSerializer.Serialize(cart);
                HttpContext.Session.SetString(CDictionary.SK_已加入購物車的_商品們_列表, JsonCart);
            }
            return RedirectToAction("CartView");
        }
    }
}
