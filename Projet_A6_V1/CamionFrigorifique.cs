using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_A6_V1
{
    internal class CamionFrigorifique : PoidsLourd
    {
        public int grp_electrogene;

        public CamionFrigorifique(int volume, List<string> matiere, int grp_electrogene) : base(volume, matiere)
        {
            this.grp_electrogene=grp_electrogene;
        }
    }
}
