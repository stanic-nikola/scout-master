using ScoutMaster.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoutMaster.Models.Interfaces
{
    interface IKorisnikRepozitorijum
    {
        void RegistrujKorisnika(KorisnikBO korisnikBO); //Upis registrovanog korisnika u bazu
        IEnumerable<KorisnikBO> VratiSveKorisnike(); //Vraca sve igraca
        KorisnikBO VratiPoId(int id); //Vraca korisnika po Id
        void ObrisiKorisnika(KorisnikBO korisnikBO); // Brise ucinak iz baze
        IEnumerable<OmiljeniIgraciBO> VratiOmiljeneIgrace(); //Vraca sve omiljene igrace
        void DodajUOmiljene(Igrac igrac, Korisnik korisnik); //Za dodavanje omiljenih igraca
        void AzurirajKorisnika(KorisnikBO korisnik); //Za azuriranje korisnika
        KorisnikBO VratiPoEmail(string email); //Vraca korisnika po Email-u
        AdminBO VratiPoKorisnickom(string email); //Vraca korisnika po korisnickom imenu
        void AzurirajNalog(KorisnikBO korisnik); //Za azuriranje naloga
                                                 // void AzurirajNalogAdmin(AdminBO admin);//Za azuriranje naloga admina
        void PromeniLozinku(KorisnikBO korisnik); //Za promenu lozinke
        KorisnikBO VratiPoIdKorisnika(int IdKorisnika); //Vraca korisnika po ID
        void BrisiOmiljene(Igrac omiljeni, Korisnik korisnik); //Brise igraca iz liste omiljenih
    }//interface
}//namespace
