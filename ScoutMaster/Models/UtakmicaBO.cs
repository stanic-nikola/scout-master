using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoutMaster.Models
{
    public class UtakmicaBO
    {
        #region Polja

        public int IdUtakmice { get; set; }
        public DateTime Datum { get; set; }
        public string Mesto { get; set; }
        public string Klubovi { get; set; }
        public string Rezultat { get; set; }

        //Kolekcija za ucinak igraca
        public ICollection<UcinakBO> UcinakIgraca { get; set; }

        #endregion
    }//class
}//namespace