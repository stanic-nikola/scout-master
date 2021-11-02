using ScoutMaster.Models; // PretragaBO
using ScoutMaster.Models.EntityFramework;
using ScoutMaster.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScoutMaster.Controllers
{
    public class PretragaController : Controller
    {
        #region Polja

        IPretragaRepozitorijum pretragaRepozitorijum;

        #endregion
        
        public PretragaController()
        {
            pretragaRepozitorijum = new PretragaRepozitorijum();
        }

        [HttpGet]
        public ActionResult Pretraga()
        {
            return View();
        }//Pretraga() GET

        public ActionResult RezultatiPretrage()
        {
            if(IgracBOList.igraci.Count() != 0)
            {
                ViewBag.Igraci = IgracBOList.igraci;
                return View();
            }
            else
            {
                TempData["Error"] = "Ne postoji igrač za ovu pretragu.";
                return RedirectToAction("Pretraga", "Pretraga");
            }
            
        }

        [HttpPost]
        public ActionResult Pretraga(IgracBO igracBO)
        {
            //if(ModelState.IsValid)
            //{
            IgracBOList.igraci = pretragaRepozitorijum.VratiRezultatePretrage(igracBO);
           // ViewBag.Igraci = pretragaRepozitorijum.VratiRezultatePretrage(igracBO);

                return RedirectToAction("RezultatiPretrage", "Pretraga");
            //}
            //return View();
        }//Pretraga() POST

       
    }
}