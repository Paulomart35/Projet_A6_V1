using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_A6_V1
{
    internal class CamionCiterne : PoidsLourd
    {
        public string type_cuve;

        public CamionCiterne(double volume, List<string> matiere, string type_cuve) : base(volume, matiere)
        {
            this.type_cuve=type_cuve;
        }
    }
}
