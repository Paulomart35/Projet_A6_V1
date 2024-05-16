using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_A6_V1
{
    internal class Voiture : Vehicule, IVehicule
    {
        public int nb_passager;

        public Voiture(int nb_passager) : base()
        {
            this.nb_passager=nb_passager;
        }

        public Voiture() : base()
        {

        }

        public Voiture demander_attribut()
        {
            Console.Write("Nombre de passagers : ");
            int nb = Convert.ToInt32(Console.ReadLine());
            return new Voiture(nb);
        }

        public string ecriture_attributs()
        {
            string str = Convert.ToString(this.nb_passager);
            return str;
            
        }

        public override string ToString()
        {
            return base.ToString() + ", " + nb_passager; 
        }


    }
}
