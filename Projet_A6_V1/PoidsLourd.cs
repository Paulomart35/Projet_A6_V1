using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_A6_V1
{
    internal class PoidsLourd : Vehicule
    {
        public double volume;
        public List<string> matiere;

        public PoidsLourd(double volume, List<string> matiere) : base()
        {
            this.volume=volume;
            this.matiere=matiere;
            //
        }

        public PoidsLourd() { }
    }
}
