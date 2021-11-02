using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; //Anotacija za spoljni kljuc Utakmice i Igraca
using System.Linq;
using System.Web;

namespace ScoutMaster.Models
{
    public class UcinakBO
    {

        #region Polja
        public int IDUcinka { get; set; }

        [ForeignKey("Utakmica")]
        public int RefIdUtakmice { get; set; }
        //public UtakmicaBO Utakmica { get; set; }

        [ForeignKey("Igrac")]
        public int RefIdIgraca { get; set; }
        //public IgracBO Igrac { get; set; }

        public int Golovi { get; set; }
        public int Asistencije { get; set; }

        [Display(Name = "Žuti kartoni")]
        public int ZutiKartoni { get; set; }

        [Display(Name = "Crveni kartoni")]
        public int CrveniKartoni { get; set; }
        public int Dodavanja { get; set; }

        [Display(Name = "Uspešna dodavanja")]
        public int UspesnaDodavanja { get; set; }

        [Display(Name = "Prekršaji")]
        public int Prekrsaji { get; set; }
        public int Minuti { get; set; }

        #endregion
    }//class
}//namespace