using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_A6_V1
{
    internal class Chauffeur : Salarie
    {
        protected int idchauffeur;
        protected bool dispo;
        protected int nievau_anciennete; //1 à 5

        public Chauffeur(int num_ss, string nom, string prenom, DateTime date_naissance, Adresse adresse, string mail, string telephone,
             string niveau, DateTime entree_societe, string poste, int salaire, int idchauffeur, bool dispo, int nievau_anciennete)
            : base(num_ss, nom, prenom, date_naissance, adresse, mail, telephone, niveau, entree_societe, poste, salaire)
        {
            this.idchauffeur = idchauffeur;
            this.dispo = dispo;
            this.nievau_anciennete=nievau_anciennete;
        }



    }
}
