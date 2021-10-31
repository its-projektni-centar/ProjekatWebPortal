﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Projekat.Controllers
{
    /// <summary>
    /// Home Kontroler
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Authorize]
    public class HomeController : Controller
    {
        /// <summary>
        /// Index Akcija.
        /// </summary>
        /// <returns></returns>
        
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// About akcija.
        /// </summary>
        /// <returns></returns>
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        /// <summary>
        /// Contact akcija.
        /// </summary>
        /// <returns></returns>
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}