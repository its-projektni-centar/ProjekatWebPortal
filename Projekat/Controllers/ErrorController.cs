using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Projekat.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ViewResult Index()
        {
            return View("Error");
        }
        public ViewResult NotFound()
        {
            Response.StatusCode = 404;  
            return View("FileNotFound");
        }
        public ViewResult UnauthorizedAccess()
        {
            Response.StatusCode = 403; 
            return View("UnauthorizedAccess");
        }
    }
}