using ScoutMaster.Models.Interfaces; // Zbog interfejsa
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoutMaster.Models.EntityFramework
{
    public class UtakmicaRepozitorijum : IUtakmicaRepozitorijum
    {
        #region Polja

        private ScoutMasterEntiteti utakmicaEntiteti = new ScoutMasterEntiteti();

        #endregion
        public void AzurirajUtakmicu(UtakmicaBO utakmica)
        {
            Utakmica utakmicaZaAzuriranje = utakmicaEntiteti.Utakmica.Where(i => i.IDutakmice == utakmica.IdUtakmice).FirstOrDefault();
            //utakmicaZaAzuriranje.IDutakmice = utakmica.IdUtakmice;
            utakmicaZaAzuriranje.klubovi = utakmica.Klubovi;
            utakmicaZaAzuriranje.mesto = utakmica.Mesto;
            utakmicaZaAzuriranje.rezultat = utakmica.Rezultat;
            utakmicaZaAzuriranje.datum = utakmica.Datum;
            utakmicaEntiteti.SaveChanges();
        }//AzurirajUtakmicu()
        public void DodajUtakmicu(UtakmicaBO utakmica)
        {
            Utakmica novaUtakmica = new Utakmica();
            //novaUtakmica.IDutakmice = utakmica.IdUtakmice;
            novaUtakmica.klubovi = utakmica.Klubovi;
            novaUtakmica.mesto = utakmica.Mesto;
            novaUtakmica.rezultat = utakmica.Rezultat;
            novaUtakmica.datum = utakmica.Datum;

            utakmicaEntiteti.Utakmica.Add(novaUtakmica);

            try
            {
                utakmicaEntiteti.SaveChanges(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
           
        }//DodajUtakmicu()
        public void ObrisiUtakmicu(UtakmicaBO utakmica)
        {
            Utakmica utakmicaZaBrisanje = utakmicaEntiteti.Utakmica.Where(t => t.IDutakmice == utakmica.IdUtakmice).FirstOrDefault();
            UtakmicaBO utakmicaBO = new UtakmicaBO();
            utakmicaEntiteti.Utakmica.Remove(utakmicaZaBrisanje);
            try
            {
                utakmicaEntiteti.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Greska!", ex);
            }
        }//ObrisiUtakmicu()
        public IEnumerable<UtakmicaBO> VratiSveUtakmice()
        {
            List<UtakmicaBO> utakmice = new List<UtakmicaBO>();
            foreach(Utakmica utakmica in utakmicaEntiteti.Utakmica)
            {
                UtakmicaBO utakmicaBO = new UtakmicaBO();
                utakmicaBO.IdUtakmice = utakmica.IDutakmice;
                utakmicaBO.Mesto = utakmica.mesto;
                utakmicaBO.Datum = utakmica.datum;
                utakmicaBO.Klubovi = utakmica.klubovi;
                utakmicaBO.Rezultat = utakmica.rezultat;

                utakmice.Add(utakmicaBO);
            }
            return utakmice;
        }//VratiSveUtakmice()
        public UtakmicaBO VratiUtakmicuPoId(int id)
        {
            Utakmica utakmica = utakmicaEntiteti.Utakmica.Where(u => u.IDutakmice == id).FirstOrDefault();
            UtakmicaBO utakmicaBO = new UtakmicaBO();
            if (utakmica != null)
            {
                utakmicaBO.IdUtakmice = utakmica.IDutakmice;
                utakmicaBO.Klubovi = utakmica.klubovi;
                utakmicaBO.Mesto = utakmica.mesto;
                utakmicaBO.Rezultat = utakmica.rezultat;
                utakmicaBO.Datum = utakmica.datum;
            }
            return utakmicaBO;
        }//VratiUtakmicePoId()
    }//class
}//namespace