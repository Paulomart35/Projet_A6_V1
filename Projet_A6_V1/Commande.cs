﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_A6_V1
{
    internal class Commande
    {
        private static int derniernumcom = 1;
        
        public int Idcommande;
        public int Idclient;
        public Livraison livraison;
        public double prix;
        public List<Salarie> chauffeurs;
        //public List<vehicule> véhicules;
        public DateTime date;

        public Commande(int idclient, Livraison livraison, double prix, List<Salarie> chauffeur, DateTime date)
        {
            this.Idcommande = derniernumcom;
            derniernumcom++;
            this.Idclient=idclient;
            this.livraison=livraison;
            this.prix=prix;
            this.chauffeurs=chauffeur;
            this.date=date;
        }
    }
}
