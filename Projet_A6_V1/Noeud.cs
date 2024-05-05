using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_A6_V1
{
    internal class Noeud<T>
    {
        public T Valeur { get; set; }
        public Noeud<T> Fils { get; set; }
        public Noeud<T> Frere { get; set; }

        public Noeud(T valeur)
        {
            Valeur = valeur;
            //Fils = new Noeud<T>();
        }

        public void AjouterFils(Noeud<T> fils)
        {
            this.Fils = fils;
        }

        public void AjouterFrere(Noeud<T> frere)
        {
            Frere = frere;
        }
    }
}
