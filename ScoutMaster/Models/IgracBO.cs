using ScoutMaster.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ScoutMaster.Models
{
    public class IgracBO
    {
        #region Polja

        public int IdIgraca { get; set; }

        [Display(Name = "Ime")]
        public string Ime { get; set; }
        public string Prezime { get; set; }

        [Display(Name = "Godište")]
        public int Godiste { get; set; }
        public int GodisteOd { get; set; }
        public int GodisteDo { get; set; }
        public string Pozicija { get; set; }
        public string Klub { get; set; }
        public int Visina { get; set; }
        public int VisinaOd { get; set; }
        public int VisinaDo { get; set; }
        public string Nacionalnost { get; set; }
        public string YoutubeLink { get; set; }


        ////kolekcija Ucinaka za odredjenog igraca
        //public ICollection<UcinakBO> UcinakIgraca { get; set; }

        ////kolekcija za skladistenje omiljenih igraca
        //public ICollection<OmiljeniIgraciBO> OmiljeniIgraci { get; set; }

        #endregion
    }//class
}//namespace