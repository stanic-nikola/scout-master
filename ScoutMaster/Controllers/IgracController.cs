using ScoutMaster.Models; //neophodno za IgracBO
using ScoutMaster.Models.EntityFramework; // neophodno zbog IgracRepozitorijum
using ScoutMaster.Models.Interfaces; //neophodna za interfejs IIgracRepozitorijum
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScoutMaster.Controllers
{
    public class IgracController : Controller
    {
        //Polja ciji su hendleri interfejsi, prihvataju reference u konstruktoru
        #region Polja
        private IIgracRepozitorijum igracRepozitorijum;
        #endregion

        public IgracController()
        {
            igracRepozitorijum = new IgracRepozitorijum();
        }//ctor

        public ActionResult Index()
        {
            ViewBag.Igraci = igracRepozitorijum.VratiSve();
            return View();
        }//Index() 

        public ActionResult VratiIgracePoId(int id)
        {
            if (id == 0)
            {
                return PartialView("_ListaIgraca", igracRepozitorijum.VratiSve());
            }
            return PartialView("_ListaIgraca", igracRepozitorijum.VratiPoId(id));
        }//VratiIgracePoId GET

        public ActionResult AzurirajIgraca(int id)
        {
            IgracBO igracBO = igracRepozitorijum.VratiPoId(id);
            return View(igracBO);
        }//AzurirajIgraca() GET

        [HttpPost]
        public ActionResult AzurirajIgraca(IgracBO igrac)
        {
            if (ModelState.IsValid)
            {
                igracRepozitorijum.Azuriraj(igrac);
                TempData["Success"] = "Uspešno ste ažurirali igrača sa imenom " + igrac.Ime + " " + igrac.Prezime +".";
            }
            return RedirectToAction("Index");

        }//AzurirajIgraca() POST

        public ActionResult DodajIgraca()
        {
            return View("DodajIgraca");
        }//DodajIgraca() VIEW

        [HttpPost]
        public ActionResult DodajIgraca(IgracBO igrac)
        {
            if(ModelState.IsValid)
            {
                igracRepozitorijum.Dodaj(igrac);
                TempData["Success"] = "Uspešno ste dodali novog igrača sa imenom " + igrac.Ime + " " + igrac.Prezime + ".";
            }
            return RedirectToAction("Index");
        }//DodajIgraca() POST

        [HttpGet]
        public ActionResult ObrisiIgraca(int id)
        {
            IgracBO igracBO = igracRepozitorijum.VratiPoId(id);
            return View(igracBO);
        }//ObrisiIgraca() GET

        [HttpPost]
        public ActionResult ObrisiIgraca(IgracBO igrac)
        {
            if(ModelState.IsValid)
            {
                igracRepozitorijum.Obrisi(igrac);
                TempData["Success"] = "Uspešno ste obrisali igrača sa imenom " + igrac.Ime + " " + igrac.Prezime + ".";
            }
            return RedirectToAction("Index");
        }//ObrisiIgraca() POST

    }//controller
}//namespace