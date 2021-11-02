using ScoutMaster.Models.Interfaces; // Zbog interfejsa IUcinakRepozitorijum
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoutMaster.Models.EntityFramework
{
    public class UcinakRepozitorijum : IUcinakRepozitorijum
    {
        #region Polja

        ScoutMasterEntiteti ucinakEntiteti = new ScoutMasterEntiteti();

        #endregion
        public void DodajUcinak(UcinakBO ucinak)
        {
            Ucinak noviUcinak = new Ucinak();
            noviUcinak.IDigraca = ucinak.RefIdIgraca;
            noviUcinak.IDutakmice = ucinak.RefIdUtakmice;
            noviUcinak.minuti = ucinak.Minuti;
            noviUcinak.golovi = ucinak.Golovi;
            noviUcinak.asistencije = ucinak.Asistencije;
            noviUcinak.zutiKartoni = ucinak.ZutiKartoni;
            noviUcinak.crveniKartoni = ucinak.CrveniKartoni;
            noviUcinak.dodavanja = ucinak.Dodavanja;
            noviUcinak.uspesnaDodavanja = ucinak.UspesnaDodavanja;
            noviUcinak.prekrsaji = ucinak.Prekrsaji;

            ucinakEntiteti.Ucinak.Add(noviUcinak);
            try
            {
                ucinakEntiteti.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Greska!", ex);
            }//catch
        }//DodajUcinak()
        public IgracBO VratiPoId(int IdIgraca)
        {
            Igrac igrac = ucinakEntiteti.Igrac.Where(i => i.IDigraca == IdIgraca).FirstOrDefault();
            IgracBO igracBO = new IgracBO();
            if (igrac != null)
            {
                igracBO.IdIgraca = igrac.IDigraca;
                igracBO.Ime = igrac.ime;
                igracBO.Prezime = igrac.prezime;
            }
            return igracBO;
        }//VratiPoId()
        public IgracBO VratiZaUcinak(int id)
        {
            Igrac igrac = ucinakEntiteti.Igrac.Where(i => i.IDigraca == id).FirstOrDefault();
            IgracBO igracBO = new IgracBO();
            if (igrac != null)
            {
                igracBO.IdIgraca = igrac.IDigraca;
                igracBO.Ime = igrac.ime;
                igracBO.Prezime = igrac.prezime;
            }
            return igracBO;
        }//VratiZaUcinak()
        public IEnumerable<UcinakBO> VratiSveUcinke()
        {
            List<UcinakBO> ucinci = new List<UcinakBO>();

            foreach (Ucinak ucinak in ucinakEntiteti.Ucinak)
            {
                UcinakBO ucinakBO = new UcinakBO();
                ucinakBO.IDUcinka = ucinak.IDUcinka;
                ucinakBO.RefIdIgraca = ucinak.IDigraca;
                ucinakBO.RefIdUtakmice = ucinak.IDutakmice;
                if (ucinak.golovi == null)
                {
                    ucinakBO.Golovi = 0;
                }
                ucinakBO.Golovi = (int)ucinak.golovi;
                if (ucinak.asistencije == null)
                {
                    ucinakBO.Asistencije = 0;
                }
                ucinakBO.Asistencije = (int)ucinak.asistencije;
                if (ucinak.zutiKartoni == null)
                {
                    ucinakBO.ZutiKartoni = 0;
                }
                ucinakBO.ZutiKartoni = (int)ucinak.zutiKartoni;
                if (ucinak.crveniKartoni == null)
                {
                    ucinakBO.CrveniKartoni = 0;
                }
                ucinakBO.CrveniKartoni = (int)ucinak.crveniKartoni;
                if (ucinak.dodavanja == null)
                {
                    ucinakBO.Dodavanja = 0;
                }
                ucinakBO.Dodavanja = (int)ucinak.dodavanja;
                if (ucinak.uspesnaDodavanja == null)
                {
                    ucinakBO.UspesnaDodavanja = 0;
                }
                ucinakBO.UspesnaDodavanja = (int)ucinak.uspesnaDodavanja;
                if (ucinak.prekrsaji == null)
                {
                    ucinakBO.Prekrsaji = 0;
                }
                ucinakBO.Prekrsaji = (int)ucinak.prekrsaji;
                ucinakBO.Minuti = ucinak.minuti;
                
                ucinci.Add(ucinakBO);
            }
            return ucinci;
        }//VratiSveUcinke()
        public void ObrisiUcinak(UcinakBO ucinakBO)
        {
            Ucinak ucinakZaBrisanje = ucinakEntiteti.Ucinak.Where(t => t.IDUcinka == ucinakBO.IDUcinka).FirstOrDefault();
            ucinakEntiteti.Ucinak.Remove(ucinakZaBrisanje);
            try
            {
                ucinakEntiteti.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Greska!", ex);
            }
        }//ObrisiUcinak()
        public UcinakBO VratiUcinakPoId(int id)
        {
            Ucinak ucinak = ucinakEntiteti.Ucinak.Where(u => u.IDUcinka == id).FirstOrDefault();
            UcinakBO ucinakBO = new UcinakBO();
            if(ucinak !=null)
            {
                ucinakBO.RefIdIgraca = ucinak.IDigraca;
                ucinakBO.RefIdUtakmice = ucinak.IDutakmice;
                ucinakBO.Minuti = ucinak.minuti;
                if (ucinak.golovi == null)
                {
                    ucinakBO.Golovi = 0;
                }
                ucinakBO.Golovi = (int)ucinak.golovi;
                if (ucinak.asistencije == null)
                {
                    ucinakBO.Asistencije = 0;
                }
                ucinakBO.Asistencije = (int)ucinak.asistencije;
                if (ucinak.zutiKartoni == null)
                {
                    ucinakBO.ZutiKartoni = 0;
                }
                ucinakBO.ZutiKartoni = (int)ucinak.zutiKartoni;
                if (ucinak.crveniKartoni == null)
                {
                    ucinakBO.CrveniKartoni = 0;
                }
                ucinakBO.CrveniKartoni = (int)ucinak.crveniKartoni;
                if (ucinak.dodavanja == null)
                {
                    ucinakBO.Dodavanja = 0;
                }
                ucinakBO.Dodavanja = (int)ucinak.dodavanja;
                if (ucinak.uspesnaDodavanja == null)
                {
                    ucinakBO.UspesnaDodavanja = 0;
                }
                ucinakBO.UspesnaDodavanja = (int)ucinak.uspesnaDodavanja;
                if (ucinak.prekrsaji == null)
                {
                    ucinakBO.Prekrsaji = 0;
                }
                ucinakBO.Prekrsaji = (int)ucinak.prekrsaji;
                ucinakBO.IDUcinka = ucinak.IDUcinka;
            }
            return ucinakBO;
        }//VratiUcinakPoId

        public void AzurirajUcinak(UcinakBO ucinak)
        {
            Ucinak ucinakZaAzuriranje = ucinakEntiteti.Ucinak.Where(u => u.IDUcinka == ucinak.IDUcinka).FirstOrDefault();
            //ucinakZaAzuriranje.IDUcinka = ucinak.IDUcinka;
            ucinakZaAzuriranje.IDigraca = ucinak.RefIdIgraca;
            ucinakZaAzuriranje.IDutakmice = ucinak.RefIdUtakmice;
            ucinakZaAzuriranje.golovi = ucinak.Golovi;
            ucinakZaAzuriranje.asistencije = ucinak.Asistencije;
            ucinakZaAzuriranje.zutiKartoni = ucinak.ZutiKartoni;
            ucinakZaAzuriranje.crveniKartoni = ucinak.CrveniKartoni;
            ucinakZaAzuriranje.dodavanja = ucinak.Dodavanja;
            ucinakZaAzuriranje.uspesnaDodavanja = ucinak.UspesnaDodavanja;
            ucinakZaAzuriranje.prekrsaji = ucinak.Prekrsaji;
            ucinakZaAzuriranje.minuti = ucinak.Minuti;

            ucinakEntiteti.SaveChanges();
        }//AzurirajUcinak()
    }//class
}//namespace