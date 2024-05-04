using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Projet_A6_V1
{
    internal class Livraison
    {
        public Adresse départ;
        public Adresse arrivee;
        public int kilometrage;
        public string duree;

        public Livraison(Adresse départ, Adresse arrivee, int kilometrage, string duree)
        {
            this.départ=départ;
            this.arrivee=arrivee;
            this.kilometrage=kilometrage;
            this.duree=duree;
        }

        public Livraison(Adresse départ, Adresse arrivee)
        {
            this.départ=départ;
            this.arrivee=arrivee;
            this.kilometrage=0;
            this.duree=null;
        }

        public override string ToString()
        {
            return this.départ.ToString() + "," + this.arrivee.ToString();
        }

        public double Calcul_prix()
        {
            string path = "Distances.csv";
            double montant_total = 0;
            double tarif_kilometre = 0.1;
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split(';');
                    Adresse adresse_départ = new Adresse(0, null, null);
                    adresse_départ.Ville = values[0];
                    Adresse adresse_arrivee = new Adresse(0, null, null);
                    adresse_arrivee.Ville = values[1];
                    int kilometrage = int.Parse(values[2]);
                    string duree = values[3];

                    if (adresse_départ.Ville == this.départ.Ville && adresse_arrivee.Ville == this.arrivee.Ville)
                    {
                        montant_total = kilometrage * tarif_kilometre;
                    }
                }
            }
            return montant_total;
        }

    }

}
