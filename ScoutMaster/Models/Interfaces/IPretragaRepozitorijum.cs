using ScoutMaster.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoutMaster.Models.Interfaces
{
    interface IPretragaRepozitorijum
    {
         IEnumerable<IgracBO> VratiRezultatePretrage(IgracBO igracBO); //Vraca rezultate pretrage
    }//interface
}//namespace
