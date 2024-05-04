using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_A6_V1
{
    internal class Noeud
    {
        public int Valeur { get; set; }
        public Noeud Fils { get; set; }
        public Noeud Frere { get; set; }

        public Noeud(int valeur)
        {
            Valeur = valeur;
            Fils = null;
        }

        public void AjouterFils(Noeud fils)
        {
            Fils = fils;
        }

        public void AjouterFrere(Noeud frere)
        {
            Frere = frere;
        }
    }
}
