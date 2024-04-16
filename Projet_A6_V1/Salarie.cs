using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_A6_V1
{
    internal class Salarie : Personne
    {
        public DateTime entree_societe;
        public string poste;
        public int salaire;

        public Salarie(int num_ss, string nom, string prenom, DateTime date_naissance, string adresse, string mail, string telephone, DateTime entree_societe, string poste, int salaire) 
            : base(num_ss, nom, prenom, date_naissance, adresse, mail, telephone)
        {
            this.entree_societe = entree_societe;
            this.poste = poste;
            this.salaire = salaire;
        }

        public string Poste
        {
            get { return poste; }
            set { poste = value; }
        }

        public int Salaire
        {
            get { return salaire; }
            set { salaire = value; }
        }


    }
}
