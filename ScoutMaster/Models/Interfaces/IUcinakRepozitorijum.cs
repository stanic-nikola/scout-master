using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoutMaster.Models.Interfaces
{
    interface IUcinakRepozitorijum
    {
        void DodajUcinak(UcinakBO ucinak); //Dodaje ucinak u bazu
        IgracBO VratiPoId(int UcinakId); //Vraca igraca po Idu
        IgracBO VratiZaUcinak(int id); //Vraca id igraca za odredjeni ucinak
        IEnumerable<UcinakBO> VratiSveUcinke(); // Vraca sve ucinke
        void ObrisiUcinak(UcinakBO ucinakBO); // Brise ucinak iz baze
        UcinakBO VratiUcinakPoId(int id);//Vraca ucinak po Id
        void AzurirajUcinak(UcinakBO ucinak);//Azurira ucinak
    }//interface
}//class
