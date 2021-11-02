using ScoutMaster.Models;
using ScoutMaster.Models.EntityFramework; // Zbog klase KorisnikRepozitorijum
using ScoutMaster.Models.Interfaces; // Zbog IKorisnikRepozitorijum
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScoutMaster.Controllers
{
    public class OmiljeniController : Controller

    {

        ScoutMasterEntiteti korisnikEntiteti = new ScoutMasterEntiteti();
        #region Polja
        IKorisnikRepozitorijum korisnikRepozitorijum;
        IIgracRepozitorijum igracRepozitorijum;

        #endregion

        public OmiljeniController()
        {
            korisnikRepozitorijum = new KorisnikRepozitorijum();
            igracRepozitorijum = new IgracRepozitorijum();
        }


         public ActionResult Index()
        {
            ViewBag.Omiljeni = korisnikRepozitorijum.VratiOmiljeneIgrace();
            ViewBag.Igrac = igracRepozitorijum.VratiSve();
            string mejl = Session["Email"].ToString();
            Korisnik korisnik = korisnikEntiteti.Korisnik.Where(k => k.email == mejl).FirstOrDefault();
            ViewBag.Id = korisnik.IDKorisnika;
              
            return View();
        }//Index() Za prikaz svih omiljenih igrača u zavisnosti od ulogovanog korisnika

        public ActionResult DodajUOmiljene(int id)
        {
            Igrac igrac = korisnikEntiteti.Igrac.Where(i => i.IDigraca == id).FirstOrDefault();
            string mejl = Session["Email"].ToString();
            Korisnik korisnik = korisnikEntiteti.Korisnik.Where(k => k.email == mejl).FirstOrDefault();

            if (korisnikEntiteti.OmiljeniIgraci.Any(o => o.IDIgraca == igrac.IDigraca && o.IDKorisnika == korisnik.IDKorisnika) == true)
            {
                TempData["Error"] = "Igrač " + igrac.ime + " " + igrac.prezime + " se već nalazi u listi omiljenih.";
                return RedirectToAction("Index", "Igrac");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    korisnikRepozitorijum.DodajUOmiljene(igrac, korisnik);
                    TempData["Success"] = "Uspešno ste dodali " + igrac.ime + " " + igrac.prezime + " u listu omiljenih igrača!";
                    return RedirectToAction("Index", "Igrac");
                }
            }
            return RedirectToAction("Index", "Korisnik");
        }//DodajUOmiljene()

        public ActionResult DodajUOmiljeneIzPretrage(int id)
        {
            Igrac igrac = korisnikEntiteti.Igrac.Where(i => i.IDigraca == id).FirstOrDefault();
            string mejl = Session["Email"].ToString();
            Korisnik korisnik = korisnikEntiteti.Korisnik.Where(k => k.email == mejl).FirstOrDefault();

            if (korisnikEntiteti.OmiljeniIgraci.Any(o => o.IDIgraca == igrac.IDigraca && o.IDKorisnika == korisnik.IDKorisnika) == true)
            {
                TempData["Error"] = "Igrač " + igrac.ime + " " + igrac.prezime + " se već nalazi u listi omiljenih.";
                return RedirectToAction("RezultatiPretrage", "Pretraga");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    korisnikRepozitorijum.DodajUOmiljene(igrac, korisnik);
                    TempData["Success"] = "Uspešno ste dodali " + igrac.ime + " " + igrac.prezime + " u listu omiljenih igrača!";
                    return RedirectToAction("RezultatiPretrage", "Pretraga");
                }
            }
            return RedirectToAction("Index", "Korisnik");
        }//DodajUOmiljene()

        public ActionResult BrisiOmiljene(int id)
        {
            Igrac igrac = korisnikEntiteti.Igrac.Where(o => o.IDigraca == id).FirstOrDefault();
            string mejl = Session["Email"].ToString();
            Korisnik korisnik = korisnikEntiteti.Korisnik.Where(k => k.email == mejl).FirstOrDefault();

           // OmiljeniIgraci igracO = korisnikEntiteti.OmiljeniIgraci.Where(o => o.IDIgraca == igrac.IDigraca && o.IDKorisnika == korisnik.IDKorisnika).FirstOrDefault();

            korisnikRepozitorijum.BrisiOmiljene(igrac, korisnik);
            TempData["Success"] = "Uspešno ste obrisali " + igrac.ime + " " + igrac.prezime + " igrača iz omiljenih.";
            return RedirectToAction("Index", "Omiljeni");
        }//BrisiOmiljene()

    }
}