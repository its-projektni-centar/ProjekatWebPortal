using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projekat.Models;

namespace Projekat.Controllers
{
	public class RazredController : Controller
	{

		// GET: Godina
		public ActionResult RazrediPrikaz(string id)
		{
			if (id == null) // ako je smer null
			{
				return RedirectToAction("SmeroviPrikaz", "Smer");
			}
			object smer = id;
			return View("RazrediPrikaz", smer);
			
		}

		
    }
}