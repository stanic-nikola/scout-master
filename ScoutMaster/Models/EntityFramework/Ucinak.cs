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
    
    public partial class Ucinak
    {
        public int IDUcinka { get; set; }
        public int IDutakmice { get; set; }
        public int IDigraca { get; set; }
        public Nullable<int> golovi { get; set; }
        public Nullable<int> asistencije { get; set; }
        public Nullable<int> zutiKartoni { get; set; }
        public Nullable<int> crveniKartoni { get; set; }
        public Nullable<int> dodavanja { get; set; }
        public Nullable<int> uspesnaDodavanja { get; set; }
        public Nullable<int> prekrsaji { get; set; }
        public int minuti { get; set; }
    
        public virtual Igrac Igrac { get; set; }
        public virtual Utakmica Utakmica { get; set; }
    }
}
