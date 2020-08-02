using Projekat.Models;
using Projekat.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Projekat.Controllers
{
    public class ModulController : Controller
    {
        private IMaterijalContext context;

        public ModulController()
        {
            context = new MaterijalContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        //GET: /Modul/ModulPrikaz
        /// <returns></returns>
        /// </summary>
        /// Prikazuje module na odredjenom predmetu
        /// <param name="id">ID predmeta za koji zelimo da prikazemo module.</param>
        [Authorize]
        public ActionResult ModulPrikaz(int id)
        {
            context = new MaterijalContext();
            int pID = 0;

            List<ModulModel> moduli;
            try
            {
                pID = context.predmeti.FirstOrDefault(x => x.predmetId == id).predmetId;
            }
            catch { }
            if (pID != 0)
            {
                ViewBag.predmetId = pID;
                moduli = context.moduli.Where(x => x.predmetId == pID).ToList();
                return View(moduli);
            }
            return View("FileNotFound");
        }

        public JsonResult GetSmerovi(int skolaID)
        {
            DodajModulViewModel viewModel = new DodajModulViewModel
            {
                Skole = context.skole.ToList(),
                Smerovi = context.smerovi.ToList(),
                Predmeti = context.predmeti.ToList()
            };
            var smeroviPoSkoli = context.smeroviPoSkolama.Where(x => x.skolaId == skolaID).Select(x => x.smerId).ToList();
            viewModel.SmeroviPoSkolama = context.smerovi.Where(x => smeroviPoSkoli.Contains(x.smerId)).ToList();
            if (viewModel.SmeroviPoSkolama.Count > 0)
            {
                int id = viewModel.SmeroviPoSkolama.FirstOrDefault().smerId;

                var predmetiposmeru = context.predmetiPoSmeru.Where(x => x.smerId == id).Select(c => c.predmetId).ToList();
                viewModel.PredmetPoSmeru = viewModel.Predmeti.Where(x => predmetiposmeru.Contains(x.predmetId)).ToList();

                var res = new { smerovi = viewModel.SmeroviPoSkolama, predmeti = viewModel.PredmetPoSmeru };

                return Json(res, JsonRequestBehavior.AllowGet);
            }
            viewModel.PredmetPoSmeru = new List<PredmetModel>();
            var result = new { smerovi = viewModel.SmeroviPoSkolama, predmeti = viewModel.PredmetPoSmeru };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPredmeti(int smerID)
        {
            DodajModulViewModel viewModel = new DodajModulViewModel
            {
                Skole = context.skole.ToList(),
                Smerovi = context.smerovi.ToList(),
                Predmeti = context.predmeti.ToList()
            };
            var predmetiposmeru = context.predmetiPoSmeru.Where(x => x.smerId == smerID).Select(c => c.predmetId).ToList();
            viewModel.PredmetPoSmeru = viewModel.Predmeti.Where(x => predmetiposmeru.Contains(x.predmetId)).ToList();

            return Json(viewModel.PredmetPoSmeru, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdministrator,LokalniUrednik")]
        public async Task<ActionResult> DodajModul()
        {
            DodajModulViewModel viewModel = new DodajModulViewModel
            {
                Skole = context.skole.ToList(),
                Smerovi = context.smerovi.ToList(),
                Predmeti = context.predmeti.ToList()
            };

            try
            {
                var skId = viewModel.Skole.ToList()[0].IdSkole;
                if (!this.User.IsInRole("SuperAdministrator"))
                {
                    SkolaModel sk = await ApplicationUser.vratiSkoluModel(User.Identity.Name);
                    if (sk.IdSkole > 0)
                    {
                        skId = sk.IdSkole;
                    }
                }
                var smeroviPoSkoli = context.smeroviPoSkolama.Where(x => x.skolaId == skId).Select(x => x.smerId).ToList();
                viewModel.SmeroviPoSkolama = context.smerovi.Where(x => smeroviPoSkoli.Contains(x.smerId)).ToList();
                int id = viewModel.SmeroviPoSkolama.First().smerId;
                var predmetiposmeru = context.predmetiPoSmeru.Where(x => x.smerId == id).Select(c => c.predmetId).ToList();
                viewModel.PredmetPoSmeru = viewModel.Predmeti.Where(x => predmetiposmeru.Contains(x.predmetId));

                if (TempData["SuccMsg"] != null) { ViewBag.SuccMsg = TempData["SuccMsg"]; }

                return View("DodajModul", viewModel);
            }
            catch (ArgumentOutOfRangeException) { return new HttpNotFoundResult("Nema unetih smerova"); }
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdministrator,LokalniUrednik")]
        public ActionResult DodajModul(DodajModulViewModel m)
        {
            context = new MaterijalContext();

            //vrednost ponekad zaluta
            if (m.modul.predmetId != null)
            {
                m.predmetId = m.modul.predmetId;
            }
            else if (m.predmetId != null)
            {
                m.modul.predmetId = m.predmetId;
            }

            try
            {
                context.Add<ModulModel>(m.modul);
                context.SaveChanges();
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            //}
            return RedirectToAction("DodajModul");
        }

        [HttpGet]
        public JsonResult Provera(string ime, int predmetID)
        {
            bool result = false;
            var provera = context.moduli.Where(x => x.modulNaziv == ime && x.predmetId == predmetID).FirstOrDefault();

            if (provera == null)
            {
                result = true;

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult ProveraIzmena(string ime, int predmetID, int modulID)
        {
            bool result = false;
            ModulModel provera = context.moduli.Where(x => x.modulNaziv == ime && x.predmetId == predmetID).FirstOrDefault();
            ModulModel trenutni = context.moduli.Where(x => x.modulId == modulID).FirstOrDefault();

            if (provera == null)
            {
                result = true;

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (provera.modulId == trenutni.modulId)
                {
                    result = true;

                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdministrator,LokalniUrednik, GlobalniUrednik")]
        public JsonResult Delete(int id)
        {
            bool result = false;
            context = new MaterijalContext();
            ModulModel modul;

            var materijalPoModulu = from m in context.materijalPoModulu
                                    join x in context.materijali
                                    on m.materijalId equals x.materijalId
                                    where m.modulId == id
                                    select x.materijalId;
            var listaMaterijalId = materijalPoModulu.ToList();
            try
            {
                modul = context.moduli.Single(x => x.modulId == id);
            }
            catch
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            try
            {
                context.Delete(modul);
                context.SaveChanges();
                result = true;
            }
            catch
            {
                result = false;
                return Json(result, JsonRequestBehavior.AllowGet);
            }

            try
            {
                if (listaMaterijalId != null)
                {
                    foreach (var i in listaMaterijalId)
                    {
                        var postoji = context.materijalPoModulu.Where(x => x.materijalId == i);
                        if (postoji.Count() == 0)
                        {
                            MaterijalModel zaBrisanje = context.materijali.Single(x => x.materijalId == i);
                            try
                            {
                                zaBrisanje.Obrisan = true;
                                context.SaveChanges();
                            }
                            catch
                            {
                                result = false;
                                return Json(result, JsonRequestBehavior.AllowGet);
                            }
                        }
                    }
                    result = true;
                }
            }
            catch
            {
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdministrator, LokalniUrednik")]
        public async Task<ActionResult> EditModul(int id, int? smerId)
        {
            ModulModel modul = context.moduli.Where(x => x.modulId == id).Single();
            DodajModulViewModel viewModel = new DodajModulViewModel
            {
                Skole = context.skole.ToList(),
                Smerovi = context.smerovi.ToList(),
                Predmeti = context.predmeti.ToList()
            };
            viewModel.modul = modul;
            try
            {
                var skId = viewModel.Skole.ToList()[0].IdSkole;
                if (!this.User.IsInRole("SuperAdministrator"))
                {
                    SkolaModel sk = await ApplicationUser.vratiSkoluModel(User.Identity.Name);
                    if (sk.IdSkole > 0)
                    {
                        skId = sk.IdSkole;
                    }
                }
                var smeroviPoSkoli = context.smeroviPoSkolama.Where(x => x.skolaId == skId).Select(x => x.smerId).ToList();
                viewModel.SmeroviPoSkolama = context.smerovi.Where(x => smeroviPoSkoli.Contains(x.smerId)).ToList();
                int smerid = viewModel.SmeroviPoSkolama.First().smerId;
                var predmetiposmeru = context.predmetiPoSmeru.Where(x => x.smerId == smerid).Select(c => c.predmetId).ToList();
                viewModel.PredmetPoSmeru = viewModel.Predmeti.Where(x => predmetiposmeru.Contains(x.predmetId));

                if (TempData["SuccMsg"] != null) { ViewBag.SuccMsg = TempData["SuccMsg"]; }

                return View("EditModul", viewModel);
            }
            catch (ArgumentOutOfRangeException) { return new HttpNotFoundResult("Nema unetih smerova"); }
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdministrator,LokalniUrednik")]
        public ActionResult EditModul(DodajModulViewModel m)
        {
            if (m.modul.predmetId != null)
            {
                m.predmetId = m.modul.predmetId;
            }
            else if (m.predmetId != null)
            {
                m.modul.predmetId = m.predmetId;
            }
            ModulModel editovan = m.modul;
            ModulModel modul = context.moduli.Where(x => x.modulId == editovan.modulId).Single();

            modul.modulNaziv = editovan.modulNaziv;
            modul.modulOpis = editovan.modulOpis;
            modul.predmetId = editovan.predmetId;
            try
            {
                context.SaveChanges();
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            return RedirectToAction("ModulPrikaz", new { id = modul.predmetId });
        }
    }
}