using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BaiWebNangCao.Models;

namespace BaiWebNangCao.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User data)
        {
            ShopEntities1 db = new ShopEntities1();

            if (ModelState.IsValid)
            {
                int count = db.Users.Count(x => x.username == data.username && x.password == data.password);
                if (count == 1)
                {
                    FormsAuthentication.SetAuthCookie(data.username, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng");
                }

            }
            return View(data);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}