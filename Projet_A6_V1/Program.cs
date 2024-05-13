using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_A6_V1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Adresse adressea = new Adresse(205, "rue", "ville");
            //Adresse adresseb = new Adresse(205, "rue", "ville");
            //Livraison liv = new Livraison(adresseb,adressea);
            //Commande test = new Commande(1, 12, liv, 124, 3, DateTime.Now);

            //test.Ecrire_commande_excel();

            //Commande test2 = Commande.Lire_excel()[0];
            //test2.idcommande = 3;
            //test2.Ecrire_commande_excel();

            //Client client = new Client(1, "dfvr","sdvsv",DateTime.Now,new Adresse(205,"qsrfv","eqrv"),"qsrv","&é'&é'&é", new List<int> { 1, 2, 3, 4 });
            //client.Ecrire_client_excel();
            //List<Client> client2 = Client.Lire_excel();

            //Client.Affiche_Client(client2[0]);
            //Client.Afficher();


            //Test supp client
            /*
            Client client10 = new Client(
            num_ss: 123456789,
            nom: "Dupont",
            prenom: "Alice",
            date_naissance: new DateTime(1990, 5, 15),
            adresse: new Adresse(numero: 10, rue: "Rue de la Liberté", ville: "Paris"),
            mail: "alice.dupont@example.com",
            telephone: "01 23 45 67 89",
            num_commande: new List<int> { 1001, 1002 });

            Client client11 = new Client(
                num_ss: 987654321,
                nom: "Durand",
                prenom: "Bob",
                date_naissance: new DateTime(1985, 8, 21),
                adresse: new Adresse(numero: 5, rue: "Avenue des Roses", ville: "Lyon"),
                mail: "bob.durand@example.com",
                telephone: "06 12 34 56 78",
                num_commande: new List<int> { 1003 });

            Client client12 = new Client(
                num_ss: 456123789,
                nom: "Martin",
                prenom: "Carole",
                date_naissance: new DateTime(1978, 3, 10),
                adresse: new Adresse(numero: 20, rue: "Boulevard des Alpes", ville: "Marseille"),
                mail: "carole.martin@example.com",
                telephone: "03 45 67 89 12",
                num_commande: new List<int> { 1004, 1005, 1006 }
            );
            client10.Ecrire_client_excel();
            client11.Ecrire_client_excel();
            client12.Ecrire_client_excel();*/


            //Client.Supprimer_client(987654321);
            //Client.Modifier_client(123456789);
            //List<Client> list = Client.Lire_excel_trier();
            //Client.Affiche_List(list);
            /*
            Salarie sal1 = new Salarie(123456789, "Dupont", "Jean", new DateTime(1980, 5, 15), new Adresse(1, "75001", "Paris"), "jean.dupont@example.com", "0123456789", "a", new DateTime(2010, 7, 1), "Directeur", 50000);
            Salarie sal2 = new Salarie(987654321, "Martin", "Sophie", new DateTime(1985, 10, 20), new Adresse(5, "69002", "Lyon"), "sophie.martin@example.com", "0987654321", "aa", new DateTime(2015, 3, 10), "Directeur commercial", 40000);
            Salarie sal3 = new Salarie(555666777, "Garcia", "Pierre", new DateTime(1990, 8, 8), new Adresse(5, "33000", "Bordeaux"), "pierre.garcia@example.com", "0456789123", "aaa", new DateTime(2018, 1, 5), "commercial", 35000);
            Salarie sal4 = new Salarie(444555666, "Leclerc", "Marie", new DateTime(1982, 9, 25), new Adresse(10, "13001", "Marseille"), "marie.leclerc@example.com", "0234567890", "ab", new DateTime(2012, 6, 20), "dir op", 60000);
            Salarie sal5 = new Salarie(888999000, "Dubois", "Thomas", new DateTime(1975, 4, 10), new Adresse(20, "67000", "Strasbourg"), "thomas.dubois@example.com", "0789456123", "aba", new DateTime(2005, 8, 15), "chef opérationnel", 70000);
            Salarie sal6 = new Salarie(222333444, "Moreau", "Céline", new DateTime(1988, 12, 5), new Adresse(30, "44000", "Nantes"), "celine.moreau@example.com", "0369852147", "abb", new DateTime(2016, 9, 30), "chef opérationnel", 55000);
            Salarie sal7 = new Salarie(555666777, "Garcia", "Pierre", new DateTime(1990, 8, 8), new Adresse(5, "33000", "Bordeaux"), "pierre.garcia@example.com", "0456789123", "ac", new DateTime(2018, 1, 5), "directeur RH", 35000);
            Salarie sal8 = new Salarie(444555666, "Leclerc", "Marie", new DateTime(1982, 9, 25), new Adresse(10, "13001", "Marseille"), "marie.leclerc@example.com", "0234567890", "aca", new DateTime(2012, 6, 20), "RH", 60000);
            Salarie sal9 = new Salarie(888999000, "Dubois", "Thomas", new DateTime(1975, 4, 10), new Adresse(20, "67000", "Strasbourg"), "thomas.dubois@example.com", "0789456123", "abaa", new DateTime(2005, 8, 15), "chef opérationnel", 70000);
            Salarie sal10 = new Salarie(222333444, "Moreau", "Céline", new DateTime(1988, 12, 5), new Adresse(30, "44000", "Nantes"), "celine.moreau@example.com", "0369852147", "abab", new DateTime(2016, 9, 30), "chef opérationnel", 55000);
            Salarie sal11 = new Salarie(444555666, "Leclerc", "Marie", new DateTime(1982, 9, 25), new Adresse(10, "13001", "Marseille"), "marie.leclerc@example.com", "0234567890", "aab", new DateTime(2012, 6, 20), "commercial 2", 60000);
            List<Salarie> list = new List<Salarie>();
            
            list.Add(sal1);
            list.Add(sal2);
            list.Add(sal3);
            list.Add(sal4);
            list.Add(sal5);
            list.Add(sal6);
            list.Add(sal7);
            list.Add(sal8);
            list.Add(sal9);
            list.Add(sal10);
            list.Add(sal11);

            

            Noeud<Salarie> racine = CreationArbre(list);

            ParcourirArbre(racine);*/
            /*
            //Calcul prix
            Livraison livraison = new Livraison(new Adresse(3, "allee", "Paris"), new Adresse(6, "rue", "Lyon"));
            Commande commande1 = new Commande(101, 123456, livraison, 123, DateTime.Now);
            double prix = livraison.Calcul_prix();
            Console.WriteLine(prix);
            //
            

            Commande c = Commande.Nouvelle_commande();
            //Commande.Affiche_commande(c);
            List<Commande> list = Commande.Lire_excel();
            Commande.Affiche_List_Commande(list);
            
            */
            /*
            Noeud<Salarie> racine = CreationArbre(list);
            
            ;*/




            //Commande c = Commande.Nouvelle_commande();
            //Livraison l = new Livraison();
            //l.Distancepluscourte("Toulouse", "Montpellier");
            //Commande.Affiche_commande(c);
            //Commande.Modifier_commande(1);
            //List<Commande> list = Commande.Lire_excel();
            //Commande.Affiche_List_Commande(list);
            //Adresse adresseDepart = new Adresse(1, "Rue de la Liberté", "Paris");
            //Adresse adresseArrivee = new Adresse(10, "Avenue des Champs-Élysées", "Paris");
            //Livraison livraison = new Livraison(adresseDepart, adresseArrivee, 50, "2 heures");
            //livraison.Distancepluscourte();
            ModuleAcceuil();
            Console.ReadKey();
        }

        
        static void ModuleClient_patron()
        {
            Console.WriteLine("\nClient\n\t1. Ajouter un client\n\t2. Supprimer un client\n\t3. Modifier un client\n\t4. Afficher les clients triés");
            int rep_client = Convert.ToInt32(Console.ReadLine());
            switch (rep_client)
            {
                case 1:
                    Client.Ajoute();
                    break;
                case 2:
                    Console.Write("Num SS du client à supprimer : ");
                    int rep_num = Convert.ToInt32(Console.ReadLine());
                    Client.Supprimer_client(rep_num);
                    break;
                case 3:
                    Console.Write("Num SS du client à modifier : ");
                    int rep_num2 = Convert.ToInt32(Console.ReadLine());
                    Client.Modifier_client(rep_num2);
                    break;
                case 4:
                    List<Client> list = Client.Lire_excel_trier();
                    Client.Affiche_List(list);
                    break;
            }

        }

        static void ModuleClient_client()
        {
            Console.Write("Quel est votre numéro de sécurité sociale : ");
            int num_ss = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nClient\n\t1. Ajouter son compte\n\t2. Modifier son compte");
            int rep_client = Convert.ToInt32(Console.ReadLine());
            switch (rep_client)
            {
                case 1:
                    Client.Ajoute();
                    break;
                case 2:
                    Client.Modifier_client(num_ss);
                    break;
            }
        }


        static void ModuleAcceuil()
        {
            Console.WriteLine("Qui êtes vous ?\n\t1. Patron/chef\n\t2.Client");
            int rep_acceuil = Convert.ToInt32(Console.ReadLine());
            switch (rep_acceuil)
            {
                case 1:
                    ModulePatron();
                    break;
                case 2:
                    ModuleClient_client();
                    break;
            }

        }

        static void ModulePatron()
        {
            Console.Write("Voulez-vous accéder aux clients (1), aux salariés (2), aux commandes (3), aux statistiques (4) : ");
            string reponse = Console.ReadLine();
            if(reponse == "1")
            {
                ModuleClient_patron();
            }
            else if(reponse == "2")
            {
                ModuleSalarie();
            }
            else if (reponse == "3")
            {
                ModuleCommandes();
            }
            else if (reponse == "4")
            {
                ModuleStatistiques();
            }
        }

        static void ModuleStatistiques()
        {
            Console.WriteLine("\nStatistique\n\t1. Afficher par chauffeur le nombre de livraisons effectuées\n\t2. Afficher les commandes selon une période de temps\n\t3. Afficher la moyenne des prix des commandes\n\t4. Afficher la moyenne des comptes clients\n\t5. Afficher la liste des commandes pour un client");
            int rep_stats = Convert.ToInt32(Console.ReadLine());
            List<Commande> listeCommandes = Commande.Lire_excel();
            switch (rep_stats)
            {
                case 1:
                    int[] nombreLivraisonsParChauffeur = Commande.GetNombreLivraisonsParChauffeur(listeCommandes);

                    for (int i = 0; i < nombreLivraisonsParChauffeur.Length; i++)
                    {
                        if (nombreLivraisonsParChauffeur[i] != 0)
                            Console.WriteLine($"Le chauffeur avec l'ID {i} a effectué {nombreLivraisonsParChauffeur[i]} livraisons.");
                    }
                    break;
                case 2:

                    break;
                case 3:
                     
                    double moyennePrix = Commande.MoyennePrixCommandes(listeCommandes);
                    Console.WriteLine($"La moyenne des prix des commandes est : {moyennePrix}€");
                    break;
                case 4:

                    break;
                case 5:
                    Console.Write("Statistique pour quel numéro SS : ");
                    int numeroSSClient = Convert.ToInt32(Console.ReadLine()); 
                    Commande.AfficherCommandesClient(numeroSSClient, listeCommandes);
                    break;
            }
        }

        static void ModuleCommandes()
        {
            Console.Write("\nCommande\n\t1. Ajouter une commande\n\t2. Modifier une commande\n\t3. Afficher les commandes : ");
            int rep_commande = Convert.ToInt32(Console.ReadLine());
            switch (rep_commande)
            {
                case 1:
                    Commande c = Commande.Nouvelle_commande();
                    break;
                case 2:

                    break;
                case 3:
                    List<Commande> list = Commande.Lire_excel();
                    Commande.Affiche_List_Commande(list);
                    break;
            }
        }

        static void ModuleSalarie()
        {
            Console.Write("Voulez-vous afficher l'organigramme (1), licensier (2), ajouter un salarié (3), affichier la liste des salariés (4) : ");
            string reponse = Console.ReadLine();
            if (reponse == "1")
            {
                List<Salarie> list = Salarie.Lire_csv();
                Noeud<Salarie> racine = CreationArbre(list);
                ParcourirArbre(racine);
            }
            else if (reponse == "2")
            {
               
            }
            else if(reponse=="3")
            {

            }

        }


        public static Noeud<Salarie> CreationArbre(List<Salarie> organigramme)
        {
            organigramme = Salarie.TrieNiveau(organigramme);
            
            // Création du nœud racine
            Noeud<Salarie> racine = new Noeud<Salarie>(organigramme[0]);
            Noeud<Salarie> dernierParent = racine;

            // Parcours des salariés pour les ajouter à l'arbre
            for (int i = 1; i < organigramme.Count; i++)
            {
                
                Noeud<Salarie> nouveauNoeud = new Noeud<Salarie>(organigramme[i]);
                // Calcul du niveau du salarié actuel
                int niveauSalarie = organigramme[i].niveau.Length;
                // Calcul du niveau du dernier parent
                int niveauDernierParent = dernierParent.Valeur.niveau.Length;
                // Si le niveau du salarié est inférieur ou égal au niveau du dernier parent,
                // on remonte dans l'arbre jusqu'à trouver un parent de même niveau ou un parent de niveau inférieur
                while (niveauSalarie <= niveauDernierParent && dernierParent.Frere != null)
                {
                    dernierParent = dernierParent.Frere;
                    niveauDernierParent = dernierParent.Valeur.niveau.Length;
                }
                // Si le niveau du salarié est supérieur au niveau du dernier parent,
                // on l'ajoute comme fils du dernier parent
                if (niveauSalarie > niveauDernierParent)
                {
                    dernierParent.Fils = nouveauNoeud;
                }
                // Sinon, le salarié est ajouté comme frère du dernier parent
                else
                {
                    dernierParent.Frere = nouveauNoeud;
                }
                // Le dernier parent devient le salarié actuel
                dernierParent = nouveauNoeud;
            }

            return racine;
        }



        static void ParcourirArbre(Noeud<Salarie> noeud)
        {
            if (noeud == null)
                return;

            for(int i = 1; i < noeud.Valeur.niveau.Length; i++)
            {
                if (i == noeud.Valeur.niveau.Length - 1)
                { Console.Write("└─ "); }
                else
                { Console.Write("     "); }
            }

            Console.WriteLine($"{noeud.Valeur.poste}");

            ParcourirArbre(noeud.Fils);

            ParcourirArbre(noeud.Frere);

            
        }

    }
}
