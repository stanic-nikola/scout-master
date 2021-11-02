using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoutMaster.Models
{
    public class AdminBO
    {
        #region Polja 
        public int IdAdmina { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }

        #endregion
    }//class
}//namespace