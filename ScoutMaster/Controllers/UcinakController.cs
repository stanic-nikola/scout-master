using ScoutMaster.Models; // Zbog Modela
using ScoutMaster.Models.EntityFramework; // Zbog klase UcinakRepozitorijum
using ScoutMaster.Models.Interfaces; // Zbog interfejsa IUcinakRepozitorijum
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScoutMaster.Controllers
{
    public class UcinakController : Controller
    {
        #region Polja 
        IUcinakRepozitorijum ucinakRepozitorijum;
        IUtakmicaRepozitorijum utakmicaRepozitorijum;
        IIgracRepozitorijum igracRepozitorijum;
        #endregion 
        public UcinakController()
        {
            ucinakRepozitorijum = new UcinakRepozitorijum();
            utakmicaRepozitorijum = new UtakmicaRepozitorijum();
            igracRepozitorijum = new IgracRepozitorijum();
        }//ctor

        public ActionResult Ucinak(int id)
        {
            ViewBag.Ucinak = ucinakRepozitorijum.VratiSveUcinke();
            ViewBag.Utakmica = utakmicaRepozitorijum.VratiSveUtakmice();
            ViewBag.Igrac = igracRepozitorijum.VratiPoId(id);
            return View();
        }//Ucinak() Vraca ucinak po Id

        public ActionResult DodajUcinak(int id)
        {
            ViewBag.Igrac = igracRepozitorijum.VratiPoId(id);
            ViewBag.Utakmice = utakmicaRepozitorijum.VratiSveUtakmice();
            return View();
        }//DodajUcinak()
        
        [HttpPost]
        public ActionResult DodajUcinak(UcinakBO ucinak)
        {
            if (ModelState.IsValid)
            {
                ucinakRepozitorijum.DodajUcinak(ucinak);
                TempData["Success"] = "Uspešno ste dodali novi učinak!";
            }
            return RedirectToAction("Ucinak", "Ucinak", new { id = ucinak.RefIdIgraca });
        }//DodajUcinak() POST

        public ActionResult ObrisiUcinak(int id)
        {
            UcinakBO ucinakBO = ucinakRepozitorijum.VratiUcinakPoId(id);
            //ViewBag.Ucinak = ucinakRepozitorijum.VratiUcinakPoId(id);
            return View(ucinakBO);
        }//ObrisiUcinak()

        [HttpPost]
        public ActionResult ObrisiUcinak(UcinakBO ucinak)
        {
            if (ModelState.IsValid)
            {
                ucinakRepozitorijum.ObrisiUcinak(ucinak);
                TempData["Success"] = "Uspešno ste obrisali učinak!";
            }
            return RedirectToAction("Ucinak", "Ucinak", new { id = ucinak.RefIdIgraca });
        }//ObrisiUcinak() POST

        public ActionResult AzurirajUcinak(int id)
        {
            UcinakBO ucinakBO = ucinakRepozitorijum.VratiUcinakPoId(id);
            return View(ucinakBO);
        }//UcinakNalog() GET

        [HttpPost]
        public ActionResult AzurirajUcinak(UcinakBO ucinak)
        {
            // if (ModelState.IsValid)
            // {
            ucinakRepozitorijum.AzurirajUcinak(ucinak);
            TempData["Success"] = "Uspešno ste ažurirali učinak.";
            //}
            return RedirectToAction("Ucinak", "Ucinak", new { id = ucinak.RefIdIgraca });
        }//AzurirajNalog() POST
    }//controller
}//namespace