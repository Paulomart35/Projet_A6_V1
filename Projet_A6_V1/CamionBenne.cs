using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_A6_V1
{
    internal class CamionBenne : PoidsLourd
    {
        public string type_travaux;
        public List<string> equipements;
        public int nb_bennes;
        public bool grue;

        public CamionBenne(double volume, List<string> matiere, string type_travaux, List<string> equipements, int nb_bennes, bool grue)
            : base(volume, matiere)
        {
            this.type_travaux=type_travaux;
            this.equipements=equipements;
            this.nb_bennes=nb_bennes;
            this.grue=grue;
        }
    }
}
