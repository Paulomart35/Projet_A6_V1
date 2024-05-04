using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace Projet_A6_V1
{
    internal class Commande
    {
        private static int derniernumcom = 0;
        
        public int idcommande;
        public int num_ss;
        public Livraison livraison;
        public double prix;
        public int idchauffeur;
        //public List<vehicule> véhicules;
        public DateTime date;

        public Commande(int idcommande, int num_ss, Livraison livraison, double prix, int chauffeur, DateTime date)
        {
            this.idcommande = idcommande;
            this.num_ss=num_ss;
            this.livraison=livraison;
            this.prix=prix;
            this.idchauffeur=chauffeur;
            this.date=date;
        }

        public Commande(int num_ss, Livraison livraison, double prix, int chauffeur, DateTime date)
        {
            this.idcommande = ++derniernumcom;
            this.num_ss=num_ss;
            this.livraison=livraison;
            this.prix=prix;
            this.idchauffeur=chauffeur;
            this.date=date;
        }
        public Commande(int num_ss, Livraison livraison, int chauffeur, DateTime date)
        {
            this.idcommande = ++derniernumcom;
            this.num_ss=num_ss;
            this.livraison=livraison;
            this.prix=0;
            this.idchauffeur=chauffeur;
            this.date=date;
        }
        


        public static List<Commande> Lire_excel()
        {
            string path = "Commande_Transconnect.csv";
            List<Commande> lecture_commandes = new List<Commande>();
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] values = line.Split(',');
                        
                        int idcommande = int.Parse(values[0]);
                        int num_ss = int.Parse(values[1]);
                        
                        Adresse adressed = new Adresse(int.Parse(values[2]), values[3], values[4]);
                        Adresse adressea = new Adresse(int.Parse(values[5]), values[6], values[7]);
                        Livraison livraison = new Livraison(adressed, adressea);
                        double prix = double.Parse(values[8]);
                        int idchauffeur = int.Parse(values[9]);
                        DateTime data = DateTime.Parse(values[10]);

                        Commande commande = new Commande(idcommande,num_ss, livraison, prix,idchauffeur,data );
                        lecture_commandes.Add(commande);
                    }
                }
                

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erreur dans le programme :", ex);
            }
            return lecture_commandes;
        }
        public void Ecrire_commande_excel()
        {
            string path = "Commande_Transconnect.csv";
            try
            {
                string text = (this.idcommande + "," + this.num_ss + "," + this.livraison.ToString() + "," + this.prix + "," + this.idchauffeur + "," + this.date);
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine(text);
                }
                Console.WriteLine("Commande" + this.idcommande + " ajouté à la base de donné");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erreur dans le programme :", ex);
            }

        }



        public static Commande Nouvelle_commande()
        {
            Console.WriteLine($"Saisir les informations pour la commande:");
            //Console.Write("Id_commande : ");
            //int idcommande = Convert.ToInt32(Console.ReadLine());

            Console.Write("Num SS : ");
            int num_ss = Convert.ToInt32(Console.ReadLine());

            Console.Write("Livraison : ");
            Livraison livraison = new Livraison(null, null);
            livraison = livraison.Demander_Livraison();

            Console.Write("Id chauffeur : ");
            int id_chauffeur = Convert.ToInt32(Console.ReadLine());

            Console.Write("Date (AAAA-MM-JJ) : ");
            DateTime date = DateTime.Parse(Console.ReadLine());

            double prix = livraison.Calcul_prix();

            Commande nv_commande = new Commande(num_ss, livraison, prix, id_chauffeur, date);

            nv_commande.Ecrire_commande_excel();
            return nv_commande;

        }

        public static void Affiche_commande(Commande commande)
        {
            Console.WriteLine($"ID commande : {commande.idcommande}");
            Console.WriteLine($"Numéro SS : {commande.num_ss}");
            Console.WriteLine($"Livraison : Départ - {commande.livraison.départ.Ville}, Arrivée - {commande.livraison.arrivee.Ville}");
            Console.WriteLine($"Prix : {commande.prix}");
            Console.WriteLine($"ID chauffeur : {commande.idchauffeur}");
            Console.WriteLine($"Date : {commande.date}");

            Console.WriteLine();
        }

        public static void Affiche_List_Commande(List<Commande> lecture_commandes)
        {
            foreach (Commande commande in lecture_commandes)
            {
                Affiche_commande(commande);
            }
        }
    }
}
