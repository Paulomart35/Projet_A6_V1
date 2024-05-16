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

        /// <summary>
        /// Demande à l'utilisateur de saisir l'usage d'une camionnette et crée un nouvel objet Camionnette avec cet usage.
        /// </summary>
        /// <returns>Un nouvel objet de type Camionnette avec l'usage saisi par l'utilisateur.</returns>
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
