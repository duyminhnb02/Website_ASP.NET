using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaiWebNangCao.Models;

namespace BaiWebNangCao.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddToCart(int productID)
        {
            ShopEntities1 db = new ShopEntities1();
            List<Cart> lstCart = (List<Cart>)Session["lstCart"];

            if (productID != -1)
            {
                if (lstCart == null)
                {
                    lstCart = new List<Cart>();
                }
                Cart obj = lstCart.FirstOrDefault(x => x.productID == productID);

                if (obj != null)
                {
                    obj.quantity += 1;
                }
                else
                {
                    Product product = db.Products.First(x => x.id == productID);
                    obj = new Cart();
                    obj.productID = productID;
                    obj.quantity = 1;
                    obj.productDetail = product;
                    lstCart.Add(obj);
                }

                Session["lstCart"] = lstCart;
                return View("Index", lstCart);
            }
            return View("Index", lstCart);
        }
        public ActionResult DeleteFromCart(long productID)
        {
            List<Cart> lst = (List<Cart>)Session["lstCart"];
            Session["lstCart"] = lst.Where(x => x.productID != productID).ToList();
            lst = (List<Cart>)Session["lstCart"];
            return View("Index", lst);

        }

        public ActionResult DeleteCart()
        {
            Session.Clear();
            return View("Index");
        }
    }
}