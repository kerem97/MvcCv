using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        DbCvEntities1 db = new DbCvEntities1();
        // GET: Default
        public ActionResult Index()
        {
            var degerler = db.TblHakkinda.ToList();
            return View(degerler);
        }
        public PartialViewResult SosyalMedya()
        {
            var sm = db.TblSosyalMedya.Where(x => x.Durum == true).ToList();
            return PartialView(sm);
        }
        public PartialViewResult Deneyim()
        {
            var deneyimler = db.TblDeneyimlerim.ToList();
            return PartialView(deneyimler);
        }

        public PartialViewResult Egitim()
        {
            var egitimler = db.TblEgitimlerim.ToList();
            return PartialView(egitimler);
        }

        public PartialViewResult Yetenek()
        {
            var yetenek = db.TblYeteneklerim.ToList();
            return PartialView(yetenek);
        }

        public PartialViewResult Hobi()
        {
            var hobi = db.TblHobilerim.ToList();
            return PartialView(hobi);
        }

        public PartialViewResult Sertifika()
        {
            var st = db.TblSertifikalarım.ToList();
            return PartialView(st);
        }
        [HttpGet]
        public PartialViewResult iletisim()
        {

            return PartialView();
        }
        [HttpPost]
        public PartialViewResult iletisim(Tblİletisim t)
        {
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Tblİletisim.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}