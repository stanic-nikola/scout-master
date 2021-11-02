using ScoutMaster.Models.Interfaces; // interfejs IIgracRepozitorijum
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoutMaster.Models.EntityFramework
{
    public class IgracRepozitorijum : IIgracRepozitorijum
    {
        #region Polja

        private ScoutMasterEntiteti igracEntiteti = new ScoutMasterEntiteti(); 

        #endregion 
        public void Azuriraj(IgracBO igrac)
        {

            Igrac igracZaAzuriranje = igracEntiteti.Igrac.Where(i => i.IDigraca == igrac.IdIgraca).FirstOrDefault();
           //igracZaAzuriranje.IDigraca = igrac.IdIgraca;
            igracZaAzuriranje.ime = igrac.Ime;
            igracZaAzuriranje.prezime = igrac.Prezime;
            igracZaAzuriranje.godiste = igrac.Godiste;
            igracZaAzuriranje.pozicija = igrac.Pozicija;
            igracZaAzuriranje.nacionalnost = igrac.Nacionalnost;
            igracZaAzuriranje.klub = igrac.Klub;
            igracZaAzuriranje.visina = igrac.Visina;
            igracZaAzuriranje.youtubeLink = igrac.YoutubeLink;
            igracEntiteti.SaveChanges();
        }//AzurirajIgraca()
        public void Dodaj(IgracBO igrac)
        {
            Igrac igracZaDodavanje = new Igrac();
            //igracZaDodavanje.IDigraca = igrac.IdIgraca;
            igracZaDodavanje.ime = igrac.Ime;
            igracZaDodavanje.prezime = igrac.Prezime;
            igracZaDodavanje.godiste = igrac.Godiste;
            igracZaDodavanje.pozicija = igrac.Pozicija;
            igracZaDodavanje.nacionalnost = igrac.Nacionalnost;
            igracZaDodavanje.klub = igrac.Klub;
            igracZaDodavanje.visina = igrac.Visina;
            igracZaDodavanje.youtubeLink = igrac.YoutubeLink;

            igracEntiteti.Igrac.Add(igracZaDodavanje);

            try
            {
                igracEntiteti.SaveChanges();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

        }//DodajIgraca()
        public void Obrisi(IgracBO igrac)
        {
            Igrac igracZaBrisanje = igracEntiteti.Igrac.Where(t => t.IDigraca == igrac.IdIgraca).FirstOrDefault();
            Queue<Ucinak> ucinciZaBrisanje = new Queue<Ucinak>();
            Queue<OmiljeniIgraci> omiljeniZaBrisanje = new Queue<OmiljeniIgraci>();

            foreach(Ucinak ucinak in igracEntiteti.Ucinak.Where(u => u.IDigraca == igracZaBrisanje.IDigraca))
            {
                ucinciZaBrisanje.Enqueue(ucinak);
            }
            foreach(OmiljeniIgraci omiljeni in igracEntiteti.OmiljeniIgraci.Where(o => o.IDIgraca == igracZaBrisanje.IDigraca))
            {
                omiljeniZaBrisanje.Enqueue(omiljeni);
            }

            if (igracZaBrisanje != null)
            {
                igracEntiteti.Igrac.Remove(igracZaBrisanje);
                if (ucinciZaBrisanje != null && ucinciZaBrisanje.Count != 0)
                {
                    foreach (Ucinak ucinak in ucinciZaBrisanje)
                    {
                        igracEntiteti.Ucinak.Remove(ucinak);

                    }
                }
                if (omiljeniZaBrisanje.Count != 0)
                {
                    foreach (OmiljeniIgraci om in omiljeniZaBrisanje)
                    {
                        igracEntiteti.OmiljeniIgraci.Remove(om);
                    }
                }
            }
            try
            {
                igracEntiteti.SaveChanges();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Greska!", ex);
            }
        }//ObrisiIgraca()

        public IgracBO VratiPoId(int igracId)
        {
            Igrac igrac = igracEntiteti.Igrac.Where(t => t.IDigraca == igracId).FirstOrDefault();
            IgracBO igracBO = new IgracBO();
            if(igrac != null)
            {
                igracBO.IdIgraca = igrac.IDigraca;
                igracBO.Ime = igrac.ime;
                igracBO.Prezime = igrac.prezime;
                igracBO.Godiste = igrac.godiste;
                igracBO.Pozicija = igrac.pozicija;
                igracBO.Nacionalnost = igrac.nacionalnost;
                igracBO.Klub = igrac.klub;
                igracBO.Visina = igrac.visina;
                igracBO.YoutubeLink = igrac.youtubeLink;
            }
            return igracBO;
        }//VratiPoId()

        public OmiljeniIgraciBO VratiPoIdOmiljeni(int igracId)
        {
            OmiljeniIgraci igrac = igracEntiteti.OmiljeniIgraci.Where(t => t.IDIgraca == igracId).FirstOrDefault();
            OmiljeniIgraciBO igracBO = new OmiljeniIgraciBO();
            if (igrac != null)
            {
                igracBO.IdIgraca = igrac.IDIgraca;
                igracBO.IDOmiljenogIgraca = igrac.IDOmiljenogIgraca;
                igracBO.IdKorisnika = igrac.IDKorisnika;
            }
            return igracBO;
        }//VratiPoId()
        public IEnumerable<IgracBO> VratiSve()
        {
            List<IgracBO> igraci = new List<IgracBO>();

            foreach(Igrac igrac in igracEntiteti.Igrac)
            {
                IgracBO igracBO = new IgracBO();
                igracBO.IdIgraca = igrac.IDigraca;
                igracBO.Ime = igrac.ime;
                igracBO.Prezime = igrac.prezime;
                igracBO.Godiste = igrac.godiste;
                igracBO.Pozicija = igrac.pozicija;
                igracBO.Nacionalnost = igrac.nacionalnost;
                igracBO.Klub = igrac.klub;
                igracBO.Visina = igrac.visina;
                igracBO.YoutubeLink = igrac.youtubeLink;

                igraci.Add(igracBO);
            }
            return (igraci);
        }//VratiSve()

    }//class
}//namespace