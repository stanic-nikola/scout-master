//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ScoutMaster.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations; // Anotacije

    public partial class Korisnik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Korisnik()
        {
            this.OmiljeniIgraci = new HashSet<OmiljeniIgraci>();
        }
    
        public int IDKorisnika { get; set; }

        [Required]
        [Display(Name = "Korisnicko ime: ")]
        public string korisnickoIme { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(150)]
        [Display(Name = "Email Address:")]
        public string email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(150, MinimumLength = 6)]
        [Display(Name = "Password: ")]
        public string lozinka { get; set; }
        [Required]
        [Display(Name = "Ime: ")]
        public string ime { get; set; }
        [Required]
        [Display(Name = "Prezime: ")]
        public string prezime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OmiljeniIgraci> OmiljeniIgraci { get; set; }
    }
}
