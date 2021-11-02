using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ScoutMaster.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Morate uneti email!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Morate uneti lozinku!")]
        [DataType(DataType.Password)]
        public string Lozinka { get; set; }

        public bool Admin { get; set; }

    }
}