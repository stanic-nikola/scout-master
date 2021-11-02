using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // Anotacije
using System.Linq;
using System.Web;

namespace ScoutMaster.Models
{
    public class KorisnikBO
    {
        # region Polja

        public int IdKorisnika { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Morate uneti korisničko ime!")]
        [Display(Name = "Korisničko ime")]
        public string KorisnickoIme { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Morate uneti Email!")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Morate uneti lozinku!")]
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka")]
        public string Lozinka { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Morate uneti potvrdnu lozinku!")]
        [DataType(DataType.Password)]
        [Display(Name = "Potvrdi lozinku")]
        [Compare("Lozinka", ErrorMessage = "Lozinke se ne podudaraju")]
        public string PotvrdaLozinke { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Morate uneti staru lozinku!")]
        [DataType(DataType.Password)]
        [Display(Name = "Stara lozinka")]
        public string StaraLozinka { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Morate uneti novu lozinku!")]
        [DataType(DataType.Password)]
        [Display(Name = "Nova lozinka")]
        public string NovaLozinka { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Morate uneti potvrdnu lozinku!")]
        [DataType(DataType.Password)]
        [Display(Name = "Potvrdi lozinku")]
        [Compare("NovaLozinka", ErrorMessage = "Lozinke se ne podudaraju!")]
        public string PotvrdaNoveLozinke { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Morate uneti Vaše ime!")]
        [Display(Name = "Ime")]
        public string Ime { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Morate uneti Vaše prezime!")]
        [Display(Name = "Prezime")]
        public string Prezime { get; set; }


        //kolekcija za skladistenje omiljenih igraca
        //public ICollection<OmiljeniIgraciBO> OmiljeniIgraci { get; set; }

        //Polje poruka kojom obavestavamo o uspesnoj registraciji
        //public string PorukaOUspehu { get; set; }
        #endregion
    }//class
}//namespace
