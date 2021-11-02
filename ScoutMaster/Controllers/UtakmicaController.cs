using ScoutMaster.Models; // Zbog UtakmicaBO
using ScoutMaster.Models.EntityFramework; // Zbog UtakmicaRepozitorijum
using ScoutMaster.Models.Interfaces; // Zbog interfejsa
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScoutMaster.Controllers
{
    public class UtakmicaController : Controller
    {
        //polje utakmicaRepozitorijum tipa interfejs koje u konstruktoru dobija referencu na UtakmicaRepozitorijum
        #region Polja      
        IUtakmicaRepozitorijum utakmicaRepozitorijum;
        #endregion


        public UtakmicaController()
        {
            utakmicaRepozitorijum = new UtakmicaRepozitorijum();
        }//ctor

        public ActionResult VratiUtakmicuPoId(int id)
        {
            if (id == 0)
            {
                return PartialView("_ListaUtakmica", utakmicaRepozitorijum.VratiSveUtakmice());
            }
            return PartialView("_ListaUtakmica", utakmicaRepozitorijum.VratiUtakmicuPoId(id));
        }//VratiUtakmicuPoId() GET

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Utakmice = utakmicaRepozitorijum.VratiSveUtakmice();
            return View();
        }//Index Prikaz svih utakmica GET

        [HttpGet]
        public ActionResult ObrisiUtakmicu(int id)
        {
            UtakmicaBO utakmicaBO = utakmicaRepozitorijum.VratiUtakmicuPoId(id);
            return View(utakmicaBO);
        }//ObrisiUtakmicu() GET

        [HttpPost]
        public ActionResult ObrisiUtakmicu(UtakmicaBO utakmica)
        {
            if (ModelState.IsValid)
            {
                utakmicaRepozitorijum.ObrisiUtakmicu(utakmica);
                TempData["Success"] = "Uspešno ste obrisali utakmicu između " + utakmica.Klubovi + ".";
            }
            return View("Index");
        }//ObrisiUtakmicu() POST

        [HttpGet]
        public ActionResult DodajUtakmicu()
        {
            return View("DodajUtakmicu");
        }//DodajUtakmicu() GET

        [HttpPost]
        public ActionResult DodajUtakmicu(UtakmicaBO utakmica)
        {
            if (ModelState.IsValid)
            {
                utakmicaRepozitorijum.DodajUtakmicu(utakmica);
                TempData["Success"] = "Uspešno ste dodali utakmicu između " + utakmica.Klubovi + ".";
            }
            return RedirectToAction("Index", "Utakmica");
        }//DodajUtakmicu() POST

        public ActionResult AzurirajUtakmicu(int id)
        {
            UtakmicaBO utakmicaBO = utakmicaRepozitorijum.VratiUtakmicuPoId(id);
            return View(utakmicaBO);
        }//AzurirajUtakmicu() GET

        [HttpPost]
        public ActionResult AzurirajUtakmicu(UtakmicaBO utakmica)
        {
            if(ModelState.IsValid)
            {
                utakmicaRepozitorijum.AzurirajUtakmicu(utakmica);
                TempData["Success"] = "Uspešno ste ažurirali utakmicu između " + utakmica.Klubovi + ".";
            }
            return RedirectToAction("Index");
        }//AzurirajUtakmicu() POST
    }
}