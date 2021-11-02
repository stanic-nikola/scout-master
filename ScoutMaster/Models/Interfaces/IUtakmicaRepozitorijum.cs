using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoutMaster.Models.Interfaces
{
    interface IUtakmicaRepozitorijum
    {
        void DodajUtakmicu(UtakmicaBO utakmica); //Dodaje novu utakmicu u bazu
        void AzurirajUtakmicu(UtakmicaBO utakmica); //Azurira utakmicu u bazi
        void ObrisiUtakmicu(UtakmicaBO utakmica); //Brise utakmicu iz baze
        UtakmicaBO VratiUtakmicuPoId(int id); //Vraca utakmicu po Idu
        IEnumerable<UtakmicaBO> VratiSveUtakmice(); //Vraca sve utakmice
    }//Interface
}//namespace
