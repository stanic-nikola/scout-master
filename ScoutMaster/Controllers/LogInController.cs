using ScoutMaster.Models; //Zbog korisnika i admina
using ScoutMaster.Models.EntityFramework; //Klasa KorisnikRepozitorijum
using ScoutMaster.Models.Interfaces; //Zbog interfejsa IKorisnikRepozitorijum
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScoutMaster.Controllers
{
    public class LogInController : Controller
    {

        IKorisnikRepozitorijum korisnikRepozitorijum;
        ScoutMasterEntiteti korisnikEntiteti = new ScoutMasterEntiteti();

        public LogInController()
        {
            korisnikRepozitorijum = new KorisnikRepozitorijum();
        }
        // GET: LogIn
        public ActionResult Index()
        {
            ViewBag.Korisnik = korisnikRepozitorijum.VratiSveKorisnike();
            return View();
        }//Index prikaz svih korisnika GET

        public ActionResult VratiKorisnikePoId(int id)
        {
            if (id == 0)
            {
                return PartialView("_ListaKorisnika", korisnikRepozitorijum.VratiSveKorisnike());
            }
            return PartialView("_ListaKorisnika", korisnikRepozitorijum.VratiPoId(id));
        }//VratiIgracePoId GET

        public ActionResult ObrisiKorisnika(int id)
        {
            KorisnikBO korisnikBO = korisnikRepozitorijum.VratiPoId(id);
            return View(korisnikBO);
        }//ObrisiKorisnika() GET

        [HttpPost]
        public ActionResult ObrisiKorisnika(KorisnikBO korisnik)
        {
                korisnikRepozitorijum.ObrisiKorisnika(korisnik);
            TempData["Success"] = "Uspešno ste obrisali korisnika " + korisnik.Ime + " " + korisnik.Prezime + ".";
            return RedirectToAction("Index");
        }//ObrisiKorisnika() POST

        [HttpGet]
        public ActionResult Login()
        {
            LoginModel loginModel = new LoginModel();
            return View(loginModel);
        }//Login() GET

        [HttpPost]
        public ActionResult Login(LoginModel login)
        {
           if(ModelState.IsValid)
            {
                
                if (korisnikEntiteti.Korisnik.Where(m => m.email == login.Email && m.lozinka == login.Lozinka).FirstOrDefault() != null)
                {
                    Session["Email"] = login.Email;
                    Session["Admin"] = login.Admin;
                    return RedirectToAction("Index", "Igrac");
                }else if (korisnikEntiteti.Admin.Where(m => m.korisnickoIme == login.Email && m.lozinka == login.Lozinka).FirstOrDefault() != null)
                {
                    Session["Email"] = login.Email;
                    Session["Admin"] = true;
                    return RedirectToAction("Index", "Igrac");

                }
                else
                {
                    ModelState.AddModelError("Greska", "Email i lozinka se ne poklapaju");
                    return View();
                }
                
             
            }
            return View();
        }//Login()

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "LogIn");
        }//Logout() GET

        [HttpGet]
        public ActionResult Registracija()
        {
            return View();
        }//Registracija() GET

        [HttpPost]
        public ActionResult Registracija(KorisnikBO korisnik)
        {

                if(!korisnikEntiteti.Korisnik.Any(m => m.email == korisnik.Email))
                {
                    korisnikRepozitorijum.RegistrujKorisnika(korisnik);
                    TempData["Success"] = "Uspešno ste se registrovali!";
                }
                else
                {
                    ModelState.AddModelError("Greska", "Korisnik sa tim email-om vec postoji");
                    return View();
                }

                return RedirectToAction("Login", "LogIn");
        }//Registracija() POST

        [HttpGet]
        public ActionResult AzurirajKorisnika(int id)
        {
            KorisnikBO korisnikBO = korisnikRepozitorijum.VratiPoId(id);
            return View(korisnikBO);
        }//AzurirajKorisnika() GET

        [HttpPost]
        public ActionResult AzurirajKorisnika(KorisnikBO korisnik)
        {
           // if (ModelState.IsValid)
           // {
                korisnikRepozitorijum.AzurirajKorisnika(korisnik);
                TempData["Success"] = "Uspešno ste ažurirali korisnika: " + korisnik.Ime + " " + korisnik.Prezime + ".";
            //}
            return RedirectToAction("Index");
        }//AzurirajKorisnika() POST

        public ActionResult AzurirajNalog(int id)
        {
            KorisnikBO korisnikBO = korisnikRepozitorijum.VratiPoId(id);
            return View(korisnikBO);
        }//AzurirajNalog() GET

        [HttpPost]
        public ActionResult AzurirajNalog(KorisnikBO korisnik)
        {
            // if (ModelState.IsValid)
            // {
            korisnikRepozitorijum.AzurirajKorisnika(korisnik);
            TempData["Success"] = "Uspešno ste ažurirali nalog.";
            //}
            return RedirectToAction("VratiKorisnikaPoEmail", "LogIn", new { email = korisnik.Email });
        }//AzurirajNalog() POST

        /*public ActionResult AzurirajNalogAdmin(string korisnickoIme)
        {
            AdminBO adminBO = korisnikRepozitorijum.VratiPoKorisnickom(korisnickoIme);
            return View(adminBO);
        }//AzurirajNalogAdmin() GET

        [HttpPost]
        public ActionResult AzurirajNalogAdmin(AdminBO admin)
        {
            // if (ModelState.IsValid)
            // {
            korisnikRepozitorijum.AzurirajNalogAdmin(admin);
            TempData["Success"] = "Uspešno ste ažurirali nalog.";
            //}
            return RedirectToAction("Index", "Igrac");
        }//AzurirajNalogAdmin() POST*/

        public ActionResult PromeniLozinku(int id)
        {
            KorisnikBO korisnikBO = korisnikRepozitorijum.VratiPoId(id);
            return View(korisnikBO);
        }//PromeniLozinku() GET

        [HttpPost]
        public ActionResult PromeniLozinku(KorisnikBO korisnik)
        {
            if (korisnik.StaraLozinka != null && korisnik.NovaLozinka != null && korisnik.PotvrdaNoveLozinke != null)
            {
                if (korisnik.StaraLozinka == korisnik.Lozinka)
                {
                    if (korisnik.NovaLozinka == korisnik.PotvrdaNoveLozinke)
                    {
                        korisnikRepozitorijum.PromeniLozinku(korisnik);
                        TempData["Success"] = "Uspešno ste promenili lozinku.";
                        return RedirectToAction("VratiKorisnikaPoEmail", "LogIn", new { email = Session["Email"] });
                    }else
                    {
                        TempData["Error"] = "Lozinke se ne podudaraju.";
                        return RedirectToAction("PromeniLozinku", "LogIn", new { IdKorisnika = korisnik.IdKorisnika });
                    }
                }
                else
                {
                    TempData["Error"] = "Stara lozinka nije ispravna.";
                    return RedirectToAction("PromeniLozinku", "LogIn", new { IdKorisnika = korisnik.IdKorisnika });
                }
            }else
            {
                TempData["Error"] = "Morate popuniti sva polja.";
                return RedirectToAction("PromeniLozinku", "LogIn", new { IdKorisnika = korisnik.IdKorisnika });
            }
           // return RedirectToAction("VratiKorisnikaPoEmail", "LogIn", new { email = Session["Email"] });
        }//PromeniLozinku() POST

        public ActionResult VratiKorisnikaPoEmail(string email)
        {
                return View("PrikazKorisnika", korisnikRepozitorijum.VratiPoEmail(email));     
            
        }//VratiIgracePoEmail-u GET

        public ActionResult VratiKorisnikaPoKorisnickom(string korisnickoIme)
        {
            return View("PrikazAdmina", korisnikRepozitorijum.VratiPoKorisnickom(korisnickoIme));

        }//VratiIgracePoEmail-u GET

    }
}