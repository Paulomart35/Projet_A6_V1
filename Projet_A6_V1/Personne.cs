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
        public int num_ss;
        protected string nom;
        protected string prenom;
        protected DateTime date_naissance;
        protected Adresse adresse;
        protected string mail;
        protected string telephone;



        public Personne(int num_ss, string nom, string prenom, DateTime date_naissance, Adresse adresse, string mail, string telephone)
        {
            this.num_ss=num_ss;
            this.nom=nom;
            this.prenom=prenom;
            this.date_naissance=date_naissance;
            this.adresse=adresse;
            this.mail = mail;
            this.telephone=telephone;
        }

        public Personne(int num_ss, string nom)
        {
            this.num_ss=num_ss;
            this.nom=nom;
        }

        public Personne() { }

        public override string ToString()
        {
            return $"Numéro de sécurité sociale: {num_ss}\n" +
            $"Nom: {nom}\n" +
            $"Prénom: {prenom}\n" +
            $"Date de naissance: {date_naissance}\n" +
            $"Adresse: {adresse}\n" +
            $"Adresse email: {mail}\n" +
            $"Téléphone: {telephone}\n";
        }

        public int Num_ss
        {
            get { return num_ss; }
        }
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }

        public DateTime Date_naissance
        {
            get { return date_naissance; }
            set { date_naissance = value;}
        }

        public Adresse Adresse
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
