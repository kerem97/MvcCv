using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    [Authorize]
    public class EgitimController : Controller
    {
        // GET: Egitim
       GenericRepository<TblEgitimlerim> repo=new GenericRepository<TblEgitimlerim>();

        
        public ActionResult Index()
        {
            var dgr = repo.List();
            return View(dgr);
        }
        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();

        }
        [HttpPost]
        public ActionResult EgitimEkle(TblEgitimlerim p)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");

        }
        public ActionResult EgitimSil(int id)
        {
            var  t = repo.Find(x => x.ID == id);
            repo.Delete(t);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult EgitimGetir(int id)
        {
            var t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult EgitimGetir(TblEgitimlerim p)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimGetir");
            }

            var t = repo.Find(x => x.ID == p.ID);
            t.Baslik = p.Baslik;
            t.AltBaslik1 = p.AltBaslik1;
            t.Altbaslik2 = p.Altbaslik2;
            t.GNO = p.GNO;
            t.Tarih = p.Tarih;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}