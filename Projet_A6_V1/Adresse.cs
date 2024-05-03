using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_A6_V1
{
    internal class Adresse
    {
        public int numero;
        public string rue;
        public string ville;

        public Adresse(int numero, string rue, string ville)
        {
            this.numero=numero;
            this.rue=rue;
            this.ville=ville;
        }

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public string Rue
        {
            get { return rue; }
            set { rue = value; }
        }

        public string Ville
        {
            get { return ville; }
            set { ville = value; }
        }

        public Adresse Demander_adresse()
        {
            Console.WriteLine("Saisir l'adresse :");

            Console.Write("Numéro : ");
            int numero = Convert.ToInt32(Console.ReadLine());

            Console.Write("Rue : ");
            string rue = Console.ReadLine();

            Console.Write("Ville : ");
            string ville = Console.ReadLine();

            return new Adresse(numero, rue, ville);
        }
    }
}
