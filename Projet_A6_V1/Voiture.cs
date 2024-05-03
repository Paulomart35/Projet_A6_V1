using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_A6_V1
{
    internal class Voiture : Vehicule
    {
        public int nb_passager;

        public Voiture(int nb_passager) : base()
        {
            this.nb_passager=nb_passager;
        }
    }
}
