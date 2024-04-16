using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Projet_A6_V1
{
    abstract class Personne
    {
        private int num_ss;
        protected string nom;
        private string prenom;
        private DateTime date_naissance;
        protected string adresse;
        protected string mail;
        protected string telephone;



        protected Personne(int num_ss, string nom, string prenom, DateTime date_naissance, string adresse, string mail, string telephone)
        {
            this.num_ss=num_ss;
            this.nom=nom;
            this.prenom=prenom;
            this.date_naissance=date_naissance;
            this.adresse=adresse;
            this.mail = mail;
            this.telephone=telephone;
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public string Adresse
        {
            get { return adresse; }
            set { adresse = value; }
        }

        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }

        public string Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }
    }
}
