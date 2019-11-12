﻿using MainApp.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MainApp.Controllers
{
    public class HomeController : Controller
    {
        [CustomAuthorize(Roles = "admin")]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.result = "Ваш логин: " + User.Identity.Name;
            }
            else
            {
                ViewBag.result = "Вы не авторизованы";
            }

            return View();
        }

        [CustomAuthorize(Roles = "admin")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [CustomAuthorize(Roles = "user")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        [Authorize]
        public ActionResult Unauthorized()
        {
            ViewBag.Message = "You dont have permission!";
            return View();
        }
    }
}