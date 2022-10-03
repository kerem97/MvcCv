using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class iletisimController : Controller
    {
        GenericRepository<Tblİletisim> repo = new GenericRepository<Tblİletisim>();
        // GET: iletisim
        public ActionResult Index()
        {
            var msj = repo.List();           
            return View(msj);
        }
       
    }
}