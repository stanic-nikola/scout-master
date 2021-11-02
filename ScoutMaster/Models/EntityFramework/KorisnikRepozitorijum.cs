using ScoutMaster.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ScoutMaster.Models.EntityFramework
{
    public class KorisnikRepozitorijum : IKorisnikRepozitorijum
    {
        #region Polja

        ScoutMasterEntiteti korisnikEntiteti = new ScoutMasterEntiteti();

        #endregion
        public void RegistrujKorisnika(KorisnikBO korisnikBO)
        {
            Korisnik registrovan = new Korisnik();
            registrovan.korisnickoIme = korisnikBO.KorisnickoIme;
            registrovan.IDKorisnika = korisnikBO.IdKorisnika;
            registrovan.email = korisnikBO.Email;
            registrovan.lozinka = korisnikBO.Lozinka;
            registrovan.ime = korisnikBO.Ime;
            registrovan.prezime = korisnikBO.Prezime;
           // registrovan.Rola

            korisnikEntiteti.Korisnik.Add(registrovan);

            try
            {
                korisnikEntiteti.SaveChanges();
            }
            catch
            {

            }
        }//RegistrujKorisnika()

        public KorisnikBO VratiPoId(int id)
        {
            Korisnik korisnik = korisnikEntiteti.Korisnik.Where(t => t.IDKorisnika == id).FirstOrDefault();
            KorisnikBO korisnikBO = new KorisnikBO();
            if (korisnik != null)
            {
                korisnikBO.IdKorisnika = korisnik.IDKorisnika;
                korisnikBO.Ime = korisnik.ime;
                korisnikBO.Email = korisnik.email;
                korisnikBO.Prezime = korisnik.prezime;
                korisnikBO.KorisnickoIme = korisnik.korisnickoIme;
                korisnikBO.Lozinka = korisnik.lozinka;
                //korisnikBO.NovaLozinka = korisnik.
                
            }
            return korisnikBO;
        }//VratiPoId

        public AdminBO VratiPoKorisnickom(string korisnickoIme)
        {
            Admin admin = korisnikEntiteti.Admin.Where(t => t.korisnickoIme == korisnickoIme).FirstOrDefault();
            AdminBO adminBO = new AdminBO();
            if (admin != null)
            {
                adminBO.IdAdmina = admin.IDAdmina;
                adminBO.KorisnickoIme = admin.korisnickoIme;
                adminBO.Lozinka = admin.lozinka;
            }
            return adminBO;

        }//VratiPoKorisnickom

        public void ObrisiKorisnika(KorisnikBO korisnikBO)
        {
            List<OmiljeniIgraci> omiljeniZaBrisanje = new List<OmiljeniIgraci>();
            Korisnik korisnikZaBrisanje = korisnikEntiteti.Korisnik.Where(t => t.IDKorisnika == korisnikBO.IdKorisnika).FirstOrDefault();
            foreach(OmiljeniIgraci omiljeni in korisnikEntiteti.OmiljeniIgraci.Where(o => o.IDKorisnika == korisnikZaBrisanje.IDKorisnika))
            {
                omiljeniZaBrisanje.Add(omiljeni);
            }

            if(korisnikZaBrisanje != null)
            {
                korisnikEntiteti.Korisnik.Remove(korisnikZaBrisanje);
                if(omiljeniZaBrisanje.Count != 0)
                {
                    foreach(OmiljeniIgraci om in omiljeniZaBrisanje)
                    {
                        korisnikEntiteti.OmiljeniIgraci.Remove(om);
                    }
                }
            }
            try
            {
                korisnikEntiteti.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Greska!", ex);
            }
        }//ObrisiKorisnika()

        public IEnumerable<KorisnikBO> VratiSveKorisnike()
        {
            List<KorisnikBO> korisnici = new List<KorisnikBO>();
            foreach (Korisnik korisnik in korisnikEntiteti.Korisnik)
            {
                KorisnikBO korisnikBO = new KorisnikBO();
                korisnikBO.IdKorisnika = korisnik.IDKorisnika;
                korisnikBO.Ime = korisnik.ime;
                korisnikBO.Email = korisnik.email;
                korisnikBO.Prezime = korisnik.prezime;
                korisnikBO.KorisnickoIme = korisnik.korisnickoIme;
                korisnikBO.Lozinka = korisnik.lozinka;

                korisnici.Add(korisnikBO);
            }
            return korisnici;
        }//VratiSveKorisnike()

        public IEnumerable<OmiljeniIgraciBO> VratiOmiljeneIgrace()
        {
            List<OmiljeniIgraciBO> omiljeni = new List<OmiljeniIgraciBO>();
            foreach (OmiljeniIgraci omiljeniIgraci in korisnikEntiteti.OmiljeniIgraci)
            {
                OmiljeniIgraciBO omiljeniIgraciBO = new OmiljeniIgraciBO();
                omiljeniIgraciBO.IdIgraca = omiljeniIgraci.IDIgraca;
                omiljeniIgraciBO.IdKorisnika = omiljeniIgraci.IDKorisnika;
                omiljeniIgraciBO.IDOmiljenogIgraca = omiljeniIgraci.IDOmiljenogIgraca;

                omiljeni.Add(omiljeniIgraciBO);
            }
            return omiljeni;
        }//VratiOmiljeneIgrace

        public void DodajUOmiljene(Igrac igrac, Korisnik korisnik)
        {
            //int max = korisnikEntiteti.OmiljeniIgraci.Max(o => o.IDOmiljenogIgraca);

                OmiljeniIgraci noviOmiljeni = new OmiljeniIgraci();
                noviOmiljeni.IDIgraca = igrac.IDigraca;
                noviOmiljeni.IDKorisnika = korisnik.IDKorisnika;
                //noviOmiljeni.IDOmiljenogIgraca = max + 1;

                korisnikEntiteti.OmiljeniIgraci.Add(noviOmiljeni);
                try
                {
                    korisnikEntiteti.SaveChanges();
                }
                catch
                {

                }
        }//DodajUOmiljene()

        public void BrisiOmiljene(Igrac igrac, Korisnik korisnik)
        {
            OmiljeniIgraci igracO = korisnikEntiteti.OmiljeniIgraci.Where(o => o.IDIgraca == igrac.IDigraca && o.IDKorisnika == korisnik.IDKorisnika).FirstOrDefault();

            korisnikEntiteti.OmiljeniIgraci.Remove(igracO);
            try
            {
                korisnikEntiteti.SaveChanges();
            }
            catch
            {

            }
        }//BrisiOmiljene()

        public void AzurirajKorisnika(KorisnikBO korisnik)
        {
            Korisnik korisnikZaAzuriranje = korisnikEntiteti.Korisnik.Where(i => i.IDKorisnika == korisnik.IdKorisnika).FirstOrDefault();
            //korisnikZaAzuriranje.IDKorisnika = korisnik.IdKorisnika;
            korisnikZaAzuriranje.ime = korisnik.Ime;
            korisnikZaAzuriranje.prezime = korisnik.Prezime;
            korisnikZaAzuriranje.email = korisnik.Email;
            //korisnikZaAzuriranje.lozinka = korisnik.Lozinka;
            korisnikZaAzuriranje.korisnickoIme = korisnik.KorisnickoIme;
            korisnikEntiteti.SaveChanges();
        }//AzurirajKorisnika()

        public void AzurirajNalog(KorisnikBO korisnik)
        {
            Korisnik korisnikZaAzuriranje = korisnikEntiteti.Korisnik.Where(i => i.IDKorisnika == korisnik.IdKorisnika).FirstOrDefault();
            //korisnikZaAzuriranje.IDKorisnika = korisnik.IdKorisnika;
            korisnikZaAzuriranje.ime = korisnik.Ime;
            korisnikZaAzuriranje.prezime = korisnik.Prezime;
            korisnikZaAzuriranje.email = korisnik.Email;
            //korisnikZaAzuriranje.lozinka = korisnik.Lozinka;
            korisnikZaAzuriranje.korisnickoIme = korisnik.KorisnickoIme;
            korisnikEntiteti.SaveChanges();
        }//AzurirajNalog()

        /*public void AzurirajNalogAdmin(AdminBO admin)
        {
            Admin korisnikZaAzuriranje = korisnikEntiteti.Admin.Where(i => i.korisnickoIme == admin.KorisnickoIme).FirstOrDefault();
            //korisnikZaAzuriranje.IDAdmina = admin.IdAdmina;
            korisnikZaAzuriranje.korisnickoIme = admin.KorisnickoIme;
            korisnikZaAzuriranje.lozinka = admin.Lozinka;

            korisnikEntiteti.SaveChanges();
        }//AzurirajNalogAdmin()*/

        public void PromeniLozinku(KorisnikBO korisnik)
        {
            Korisnik korisnikZaAzuriranje = korisnikEntiteti.Korisnik.Where(i => i.IDKorisnika == korisnik.IdKorisnika).FirstOrDefault();
            //if(korisnik.NovaLozinka == korisnik.PotvrdaNoveLozinke && korisnik.Lozinka == korisnik.StaraLozinka)
            //{ 
                //korisnikZaAzuriranje.IDKorisnika = korisnik.IdKorisnika;
                korisnikZaAzuriranje.lozinka = korisnik.NovaLozinka;
                korisnikEntiteti.SaveChanges();
            //}
        }//PromeniLozinku()

        public KorisnikBO VratiPoEmail(string email)
        {   
            Korisnik korisnik = korisnikEntiteti.Korisnik.Where(t => t.email == email).FirstOrDefault();
            KorisnikBO korisnikBO = new KorisnikBO();
            if (korisnik != null)
            {
                korisnikBO.IdKorisnika = korisnik.IDKorisnika;
                korisnikBO.Ime = korisnik.ime;
                korisnikBO.Email = korisnik.email;
                korisnikBO.Prezime = korisnik.prezime;
                korisnikBO.KorisnickoIme = korisnik.korisnickoIme;
                korisnikBO.Lozinka = korisnik.lozinka;
            }
            return korisnikBO;

        }//VratiPoEmail-u

        public KorisnikBO VratiPoIdKorisnika(int IdKorisnika)
        {
            Korisnik korisnik = korisnikEntiteti.Korisnik.Where(t => t.IDKorisnika == IdKorisnika).FirstOrDefault();
            KorisnikBO korisnikBO = new KorisnikBO();
            if (korisnik != null)
            {
                korisnikBO.IdKorisnika = korisnik.IDKorisnika;
                korisnikBO.Ime = korisnik.ime;
                korisnikBO.Email = korisnik.email;
                korisnikBO.Prezime = korisnik.prezime;
                korisnikBO.KorisnickoIme = korisnik.korisnickoIme;
                korisnikBO.Lozinka = korisnik.lozinka;
            }
            return korisnikBO;

        }//VratiPoId-u

    }//class
}//namespace