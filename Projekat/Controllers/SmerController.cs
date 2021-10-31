using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projekat.Models;
using Projekat.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

namespace Projekat.Controllers
{
    /// <summary>
    /// Smer Kontroler
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Authorize]
    public class SmerController : Controller
    {
        private IMaterijalContext context;

        /// <summary>
        /// Kreira novu instancu <see cref="SmerController" /> klase.
        /// </summary>
        public SmerController()
        {
            context = new MaterijalContext();
        }

        /// <summary>
        /// Kreira novu instancu <see cref="SmerController"/> klase.
        /// </summary>
        /// <param name="Context">ImaterijalContext.</param>
        public SmerController(IMaterijalContext Context)
        {
            context = Context;
        }

        // GET: Smer
        /// <summary>
        /// Index akcija
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Vraca prikaz svih smerova.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> SmeroviPrikaz(int? id)
        {
            if (this.User.IsInRole("Ucenik"))
            {
                string SmerNaziv = await ApplicationUser.VratiSmer(User.Identity.Name);
                if (SmerNaziv != null)
                    return Redirect("/Razred/RazrediPrikaz/" + UrlEncode(SmerNaziv));
                else
                    return new NotFoundResult(); //"Smer nije nadjen"
            }
            var smerPoSk = context.smeroviPoSkolama.Where(x => x.skolaId == id).Select(x => x.smerId).ToList();
            List<SmerModel> smeroviInDb = context.smerovi.Where(x => smerPoSk.Contains(x.smerId)).ToList();
            SmerModel smer = new SmerModel();
            smer.smerovi = smeroviInDb;

            return View("SmeroviPrikaz", smer);
        }

        /// <summary>
        /// Vraca View na kome je forma za dodavanje smera
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "SuperAdministrator,LokalniUrednik")]
        public async Task<ActionResult> DodajSmer()
        {
            if (!this.User.IsInRole("SuperAdministrator"))
            {
                SkolaModel sk = await ApplicationUser.vratiSkoluModel(User.Identity.Name);
                DodajSmerViewModel viewModel = new DodajSmerViewModel();
                if (sk.IdSkole > 0)
                {
                    viewModel.skolaId = sk.IdSkole;
                }

                return View("DodajSmer", viewModel);
            }
            else
            {
                List<SkolaModel> temp = context.skole.ToList();
                DodajSmerViewModel vm = new DodajSmerViewModel()
                {
                    skole = temp
                };
                return View("DodajSmer", vm);
            }
        }

        /// <summary>
        /// Dodaje prosledjeni smer u bazu ili menja postojeci smer u bazi
        /// </summary>
        /// <param name="smer">Smer za dodavanje</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "SuperAdministrator,LokalniUrednik")]
        public ActionResult DodajSmer(DodajSmerViewModel smer)
        {
            SmerModel temp = new SmerModel();
            if (ModelState.IsValid)
            {
                if (smer.smerId == 0)
                {
                    SmerModel model = new SmerModel()
                    {
                        smerNaziv = smer.smerNaziv,
                        smerOpis = smer.smerOpis,
                        smerSkraceno = smer.smerSkraceno
                    };
                    try
                    {
                        context.Add<SmerModel>(model);
                        context.SaveChanges();
                        temp = context.smerovi.Where(x => x.smerNaziv == model.smerNaziv && x.smerOpis == model.smerOpis && x.smerSkraceno == model.smerSkraceno).SingleOrDefault();
                    }
                    catch { }
                }
                else
                {
                    var smerInDb = context.smerovi.Single(o => o.smerId == smer.smerId);

                    smerInDb.smerNaziv = smer.smerNaziv;
                    smerInDb.smerOpis = smer.smerOpis;

                    try
                    {
                        context.SaveChanges();
                        temp = context.smerovi.Where(x => x.smerId == smer.smerId).SingleOrDefault();
                    }
                    catch { }
                }
                if (smer.skolaId != 0)
                {
                    try
                    {
                        context.Add<SmerPoSkoli>(new SmerPoSkoli()
                        {
                            skolaId = smer.skolaId,
                            smerId = temp.smerId
                        });
                        context.SaveChanges();
                    }
                    catch { }
                }

                return RedirectToAction("SmeroviPrikaz", new { id = smer.skolaId });
            }
            return View();
        }
    }
}