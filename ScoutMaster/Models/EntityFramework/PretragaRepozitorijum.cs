using ScoutMaster.Models.Interfaces; // Zbog interfejsa pretraga
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoutMaster.Models.EntityFramework
{
    public class PretragaRepozitorijum : IPretragaRepozitorijum
    {

        #region Polja

        ScoutMasterEntiteti pretragaEntiteti = new ScoutMasterEntiteti();


        #endregion

        public IEnumerable<IgracBO> VratiRezultatePretrage(IgracBO igracBO)
        {
            var result = (
                from i in pretragaEntiteti.Igrac
                orderby i.ime
                select new IgracBO
                {
                    IdIgraca = i.IDigraca,
                    Ime = i.ime,
                    Prezime = i.prezime,
                    Pozicija = i.pozicija,
                    Nacionalnost = i.nacionalnost,
                    Godiste = i.godiste,
                    Klub = i.klub,
                    Visina = i.visina,
                    YoutubeLink = i.youtubeLink
                }).Where(
                x => (igracBO.Ime == null || x.Ime == igracBO.Ime) && 
                     (x.Prezime == igracBO.Prezime || igracBO.Prezime == null) &&
                     (x.Pozicija == igracBO.Pozicija || igracBO.Pozicija == null) &&
                     (x.Godiste >= igracBO.GodisteOd || igracBO.GodisteOd == 0) &&
                     (x.Godiste <= igracBO.GodisteDo || igracBO.GodisteDo == 0) &&
                     (x.Nacionalnost == igracBO.Nacionalnost || igracBO.Nacionalnost == null) &&
                     (x.Visina >= igracBO.VisinaOd || igracBO.VisinaOd == 0) &&
                     (x.Visina <= igracBO.VisinaDo || igracBO.VisinaDo == 0) &&
                     (x.Klub == igracBO.Klub || igracBO.Klub == null)
                ).ToList();
            return result;


            }
        }

    }//class
//namespace