using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoutMaster.Models.Interfaces
{
    interface IIgracRepozitorijum
    {
        IEnumerable<IgracBO> VratiSve(); //Vraca sve igraca
        IgracBO VratiPoId(int igracId); //Vraca igrace po Idu
        void Dodaj(IgracBO igrac); //Dodaje igraca u bazu
        void Azuriraj(IgracBO igrac); //Azurira igraca u bazi
        void Obrisi(IgracBO igrac); //Brise igraca iz baze
        OmiljeniIgraciBO VratiPoIdOmiljeni(int igracId); // Vraca omiljenog igraca
    }//interface    
}//namespace
