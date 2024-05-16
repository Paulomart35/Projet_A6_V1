using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_A6_V1
{
    internal class Camionnette : Vehicule, IVehicule
    {
        public string usage;

        public Camionnette(string usage) : base()
        {
            this.usage=usage;
        }

        public Camionnette() : base() { }

        public Camionnette demander_attribut()
        {
            Console.Write("Quel usage : ");
            string us = Console.ReadLine();
            return new Camionnette(us);
        }

        public string ecriture_attributs()
        {
            return this.usage;
        }
    }
}
