using Microsoft.Ajax.Utilities;
using System.Web;
using System.Web.Mvc;

namespace Projekat.Controllers
{
    public class RazredController : Controller
    {
        // GET: Godina
        public ActionResult RazrediPrikaz(int id)
        {
            if (id == 0) // ako je smer null
            {
                return RedirectToAction("SmeroviPrikaz", "Smer");
            }
            
            //object smer = HttpUtility.UrlDecode(id);

            return View("RazrediPrikaz", id);
        }
    }
}