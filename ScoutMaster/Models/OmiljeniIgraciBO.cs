using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema; //Anotacija za spoljni kljuc Korisnika i Igraca
using System.Linq;
using System.Web;

namespace ScoutMaster.Models
{
    public class OmiljeniIgraciBO
    {
        #region Polja

        public int IDOmiljenogIgraca { get; set; }

        [ForeignKey("Korisnik")]
        public int IdKorisnika { get; set; }
        public KorisnikBO Korisnik { get; set; }

        [ForeignKey("Igrac")]
        public int IdIgraca { get; set; }
        public IgracBO Igrac { get; set; }

        #endregion
    }//class
}//namespace