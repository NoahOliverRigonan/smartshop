﻿using VideokeRental.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VideokeRental.Controllers
{
    public class HomeController : UserAccountController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult RentalVideoke()
        {
            ViewBag.Message = "Your Product.";

            return View();
        }
    }
}