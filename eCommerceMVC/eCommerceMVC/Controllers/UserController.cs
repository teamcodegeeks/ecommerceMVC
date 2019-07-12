using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eCommerceMVC.Models;
using eCommerceMVC.Repository;
using eCommerceMVC.Service;
using eCommerceMVC.UoW;

namespace eCommerceMVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Login()
        {
            UserServicecs user = new UserServicecs();
            user.Login("Lana", "123123");
            return View();
        }
        public ActionResult Register() {
            UserServicecs user = new UserServicecs();
            user.register("AllenHu", "125643", "123@gmail.com");
            return View();
        }
    }
}