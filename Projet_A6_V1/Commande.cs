using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_A6_V1
{
    internal class Commande
    {
        public int Idcommande;
        public Client client;
        public Livraison livraison;
        public double prix;
        public List<Salarie> chauffeurs;
        //public List<vehicule> véhicules;
        public DateTime date;

        public Commande(Client client, Livraison livraison, double prix, Salarie chauffeur, DateTime date)
        {
            this.client=client;
            this.livraison=livraison;
            this.prix=prix;
            this.chauffeur=chauffeur;
            this.date=date;
        }
    }
}
