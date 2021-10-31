using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projekat.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekat.Controllers
{
    public class SkolaController : Controller
    {
        private IMaterijalContext context;

        public SkolaController()
        {
            context = new MaterijalContext();
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> SkolaPrikaz()
        {
            if (User.IsInRole("SuperAdministrator") || User.IsInRole("GlobalniUrednik"))
            {
                List<SkolaModel> skole = context.skole.ToList();
                return View(skole);
            }
            int skolaId = (int)await ApplicationUser.vratiSkolu(User.Identity.Name);
            return RedirectToAction("SmeroviPrikaz", "Smer", new { id = skolaId });
        }
    }
}