using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projekat.Models;
using Projekat.ViewModels;

namespace Projekat.Controllers
{
    public class ForumController : Controller
    {
        // GET: Forum
        MaterijalContext materijal;

        public ForumController()
        {
            materijal = new MaterijalContext();
        }

        [Authorize(Roles = "Profesor,Ucenik")]
        public ActionResult forum()
        {
            //Beleznik: potrebna inicijalizacija da bi se ucitali podaci na view modele
            //
            List<Forum_Post> model = materijal.Forum.Where(n => n.approved.Equals("yes")).ToList();
            if (model.Count() > 0)
            {
                var myviewmodel = new ForumViewModel();
                myviewmodel.postsModel = model;
                int i = model.Count();
                ViewBag.BrojRezultat = i;
                return View(myviewmodel);
            }
            else
            {
                ViewBag.Poruka = "Trenutno nema nikakvih objava!";
                return View();
            }
        }
        [HttpGet]
        public ActionResult PrikaziSadrzaj(int idPost)
        {
            var model = materijal.Message.Where(x => x.Id_post.Equals(idPost) && x.odobrenje.Equals("yes")).ToList();
            var myviewmodel = new ForumViewModel();

            myviewmodel.Forummessage = model;

                return View(myviewmodel); 
            
        }
        [HttpGet]
        public ActionResult OdobravanjeSadrzaj2(int id)
        {
            Forum_Message model = materijal.Message.Find(id);
            using (MaterijalContext db = new MaterijalContext())
            {
                db.Message.Attach(model);
                model.odobrenje = "yes";

                db.SaveChanges();
            }
            TempData["Succ"] = "Uspešno odobren sadržaj";
            return RedirectToAction("OdobravanjeSadrzaja", "Forum");
        }
        public ActionResult Prikaz()
        {
            return View("Sadrzaj");
        }
        [Authorize(Roles ="Ucenik")]
        [HttpGet]
        public ActionResult DodavanjeTema()
        {
            if (TempData["SuccMsg"]!=null){ ViewBag.SuccMsg = TempData["SuccMsg"]; }

            return View();
        }
        [Authorize(Roles ="Ucenik")] // inace logout
        [HttpPost]
        public ActionResult DodavanjeTema(string idUser,string approved,Forum_Post forum,HttpPostedFileBase file)
        {

            
                forum.Id = idUser;
                forum.approved = approved;
                forum.imgTema = file.FileName;
                forum.posteddate = DateTime.Now;

                materijal.Forum.Add(forum);
                materijal.SaveChanges();

                file.SaveAs(Server.MapPath("~/Content/img/") + file.FileName);

                TempData["SuccMsg"] = "Uspešno postavljena nova tema";

                return RedirectToAction("DodavanjeTema", "Forum");
            //return Content("HUAAA");
            
        }
        [Authorize(Roles ="Profesor")]
        [HttpGet]
        public ActionResult OdobravanjeTema()
        {
            if (TempData["Succ"] != null)
            {
                ViewBag.SuccMsg = TempData["Succ"];
            }
            if (TempData["nesto"] != null) { ViewBag.nesto = TempData["nesto"]; }

            List<Forum_Post> model = materijal.Forum.Where(n => n.approved.Equals("false")).ToList();

            if (model.Count()>0)
            {
                var myviewmodel = new ForumViewModel();
                myviewmodel.postsModel = model;


                return View(myviewmodel);
            }
            else
            {
                ViewBag.ErrorMsg = "Trenutno nema tema za odobravanje!";
                return View();
            }
        }
        [Authorize(Roles ="Profesor")]
        [HttpGet]
        public ActionResult OdobravanjeTema2(int id)
        {
                Forum_Post forum = materijal.Forum.Find(id);
                using (MaterijalContext db = new MaterijalContext())
                {
                    db.Forum.Attach(forum);
                    forum.approved = "yes";

                    db.SaveChanges();
                }
                TempData["Succ"] = "Uspešno odobrena tema";
                return RedirectToAction("OdobravanjeTema", "Forum");

        }

        [Authorize(Roles ="Profesor")]
        [HttpGet]
        public ActionResult OdobravanjeSadrzaja()
        {
            List<Forum_Message> model = materijal.Message.Where(n => n.odobrenje.Equals("false")).ToList();
            if (TempData["Succ"] != null) { ViewBag.SuccMsg = TempData["Succ"]; }

            if (model.Count()>0)
            {
                var myviewmodel = new ForumViewModel();
                myviewmodel.Forummessage = model;

                return View(myviewmodel);
            }
            else
            {
                ViewBag.ErrorMsg = "Trenutno nema sadržaja za odobravanje!";
                return View();
            }
        }
        [Authorize(Roles ="Profesor,Ucenik")]
        [HttpPost]
        public ActionResult KomentarDodavanje(int idPost,Forum_Message fm, string nesto)
        {

            fm.Id_post = idPost;
            fm.messageDate = DateTime.Now;
            fm.odobrenje = "false";

            return RedirectToAction("forum", "Forum");
        }
    }
}