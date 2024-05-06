using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Projet_A6_V1
{
    internal class Vehicule
    {
        public int id_vehicule;

        public Vehicule(int id_vehicule)
        {
            this.id_vehicule=id_vehicule;
        }

        public Vehicule() { }

        public override string ToString()
        {
            return id_vehicule.ToString();
        }

    }
}
