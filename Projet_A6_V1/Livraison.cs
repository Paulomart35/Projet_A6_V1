using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_A6_V1
{
    internal class Livraison
    {
        public Adresse départ;
        public Adresse arrivee;

        public Livraison(Adresse départ, Adresse arrivee)
        {
            this.départ=départ;
            this.arrivee=arrivee;
        }

        public Livraison()
        {
            this.arrivee = null;
            this.départ = null;
        }

        public string toString()
        {
            return this.départ.toString() + "," + this.arrivee.toString();
        }

    }

}
