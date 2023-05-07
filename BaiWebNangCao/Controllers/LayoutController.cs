using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaiWebNangCao.Models;

namespace BaiWebNangCao.Controllers
{
    public class LayoutController : Controller
    {
        // GET: Layout
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListProduct(string type)
        {
            ShopEntities1 db = new ShopEntities1();
            List<Product> lst = new List<Product>();
            if(type == "Hot")
            {
                lst = db.Products.Where(x => x.Category.name == "Hot").Take(8).ToList();
            }
            else if(type == "Featured")
            {
                lst = db.Products.Where(x => x.Category.name == "Featured").Take(8).ToList();

            }

            ViewBag.type = type;

            return PartialView(lst);
        }
    }
}