﻿using System;
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
            /*List<Client> clients = Client.Lire_excel();
            Client ceclient = clients.Find(c => c.num_ss == 123456789);
            int nbCommande = ceclient.num_commande.Count();
            Console.WriteLine(nbCommande);*/
            
            bool end = true;
            while (end != false)
            {
                end = ModuleAcceuil();
            }
            Console.Clear();
            Console.WriteLine("En revoir");
            Console.ReadKey();
        }

        /// <summary>
        /// Module de la console permettant au patron d'accéder aux clients de son entreprise
        /// </summary>
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

        /// <summary>
        /// Module de la console qui permet à un client de se connecter ou de créer un nouveau compte
        /// </summary>
        /// <returns></returns>
        static bool ModuleClient_client()
        {
            Console.Clear();
            Console.WriteLine("Souhaitez-vous vous connecter pour accéder à vos informations ou créée un compte chez nous ?" +
                "\n\t1.Se connecter" +
                "\n\t2.Créer un compte");
            int reponse = Convert.ToInt32(Console.ReadLine());
            bool end = false;
            if(reponse == 1)
            {
                Console.Clear();
                List<Client> Clients = Client.Lire_excel();
               
                Console.WriteLine("Pour vous connectez, saissisez votre numéro de sécurité sociale ainsi que votre nom :");
                Console.Write("Numéro de sécurité sociale : ");
                int num_ss = Convert.ToInt32(Console.ReadLine());
                Client connecte = Clients.Find(c => c.Num_ss == num_ss);
                while ( connecte == null)
                {
                    Console.WriteLine("Numéro de sécurité sociale introuvable, réessayez (si vous souhaiter quitter : q) : ");
                    string rep = Console.ReadLine();
                    if(rep == "q") { return false;}
                    num_ss = Convert.ToInt32(rep);
                    connecte = Clients.Find(c => c.Num_ss == num_ss);
                }
                while(end != true)
                {
                    end = ModuleCompte(connecte);
                }
                
            }
            else if(reponse == 2)
            {
                Console.Clear();
                List<Client> Clients = Client.Lire_excel();
                Console.WriteLine("Vérifions que vous n'avez pas déjà un compte chez nous :");
                Console.Write("Numéro de sécurité sociale : ");
                int num_ss = Convert.ToInt32(Console.ReadLine());
                Client connecte = Clients.Find(c => c.Num_ss == num_ss);
                if(connecte != null)
                {
                    Console.WriteLine("Oh mais vous posséder déjà un compte ! Cliquez sur une touche pour y accéder !");
                    Console.ReadKey();
                    while(end != true)
                    {
                        end = ModuleCompte(connecte);
                    }
                }
                else
                {
                    Client nouveau = Client.AjouteUtilisateur();
                    while (end != true)
                    {
                        end = ModuleCompte(nouveau);
                    }
                }
            }
            else
            {
                Console.WriteLine("Réponse non utilisable, appuyez sur une touche pour revenir à l'acceuil...");
                Console.ReadKey(); 
            }


            Console.WriteLine("\nSouhaitez-vous continuer dans le partie Client ? y/n");
            string fin = Console.ReadLine();
            if (fin == "y") { end = true; }
            return end;

            
        }
        /// <summary>
        /// Module de la console utilisé une fois que le client est connecté pour accéder à ses actions (Commander, voir infos)
        /// </summary>
        /// <param name="connecte"></param>
        /// <returns></returns>
        static bool ModuleCompte(Client connecte)
        {
            bool end = false;
            Console.Clear();
            Console.WriteLine("Bonjour " + connecte.Prenom + " ! Que voulez-vous faire ?" +
                "\n\t1.Voir mes infos" +
                "\n\t2.Modifier mon compte" +
                "\n\t3.Passer une commande" +
                "\n\t4.Voir mes commandes" +
                "\n\t5.Retour");
            int rep_client = Convert.ToInt32(Console.ReadLine());
            switch (rep_client)
            {
                case 1:
                    Console.Clear();
                    Client.Affiche_Client(connecte);
                    break;
                case 2:
                    Console.Clear();
                    Client.Modifier_client(connecte.num_ss);
                    break;
                case 3:
                    Console.Clear();
                    Commande.Nouvelle_commande();
                    break;
                case 4:
                    Console.Clear();
                    if (connecte.num_commande.Count != 0)
                    {
                        List<Commande> Commandes = Commande.Lire_excel();
                        Commande.AfficherCommandesClient(connecte.num_ss, Commandes);
                    }
                    else
                    {
                        Console.WriteLine($"Vous n'avez pas effectué de commande");
                    }
                    break;
                case 5:
                    return true;
            }
            Console.WriteLine("\nSouhaitez-vous continuer sur votre compte ? y/n");
            string fin = Console.ReadLine();
            if (fin == "n") { end = true; }
            return end;
     
        }

        /// <summary>
        /// Module de la console correspondant au lancement du site
        /// </summary>
        /// <returns></returns>
        static bool ModuleAcceuil()
        {
            Console.Clear();
            Console.WriteLine("Bienvenue chez Trans-Connect !\n");
            Console.WriteLine("Qui êtes-vous ?\n" +
                "\n\t1.Administrateur" +
                "\n\t2.Client\n");
            
            int rep_acceuil = Convert.ToInt32(Console.ReadLine());

            bool end = false;
            switch (rep_acceuil)
            {
                case 1:
                    Console.Clear();
                    Console.Write("Entrez le mot de passe administrateur : ");
                    string reponse = Console.ReadLine();
                    while (reponse != "patron")
                    {
                        Console.Write("Mot de passe incorrect, réessayez : ");
                        reponse = Console.ReadLine();
                    }
                    while (end != true)
                    {
                        end = ModulePatron();
                    }
                    break;
                
                case 2:
                    while(end != true)
                    {
                        end = ModuleClient_client();
                    }
                    break;
                
                default:
                    Console.WriteLine("Réponse non utilisable");
                    
                    break;
                    
                
            }
            Console.WriteLine("\nSouhaitez-vous quitter l'interface ? y/n");
            string fin = Console.ReadLine();
            if (fin == "y") { end = true; }
            return end;

        }

        /// <summary>
        /// Module de la console réservé au patron depjuis lequel il pourra accéder aux différents modules de son entreprise (Salarié,Client,etc...)
        /// </summary>
        /// <returns></returns>
        static bool ModulePatron()
        {
            Console.Clear();
            Console.WriteLine("Voulez-vous accéder : \n" +
                "\n\t1.Aux clients " +
                "\n\t2.Aux salariés " +
                "\n\t3.Aux commandes " +
                "\n\t4.Aux statistiques" +
                "\n\t5.Retour\n");
            string reponse = Console.ReadLine();
            bool end = false;  
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
            else if(reponse == "5")
            {
                return true;
            }
            Console.WriteLine("\nSouhaitez-vous continuer dans le partie Administrateur ? y/n");
            reponse = Console.ReadLine();
            if( reponse == "n") { end = true;}
            return end;
        }

        /// <summary>
        /// Module de la console permettant au patron d'accéder à plusieurs statistiques sur son entreprise
        /// </summary>
        static void ModuleStatistiques()
        {
            Console.Clear();
            Console.WriteLine("Que souhiatez-vous savoir : \n" +
                "\n\t1.Afficher par chauffeur le nombre de livraisons effectuées" +
                "\n\t2.Afficher les commandes selon une période de temps" +
                "\n\t3.Afficher la moyenne des prix des commandes" +
                "\n\t4.Afficher la moyenne des comptes clients" +
                "\n\t5.Afficher la liste des commandes pour un client\n");
            int rep_stats = Convert.ToInt32(Console.ReadLine());
            List<Commande> listeCommandes = Commande.Lire_excel();
            switch (rep_stats)
            {
                case 1:
                    Console.Clear();
                    int[] nombreLivraisonsParChauffeur = Commande.GetNombreLivraisonsParChauffeur(listeCommandes);

                    for (int i = 0; i < nombreLivraisonsParChauffeur.Length; i++)
                    {
                        if (nombreLivraisonsParChauffeur[i] != 0)
                            Console.WriteLine($"Le chauffeur avec l'ID {i} a effectué {nombreLivraisonsParChauffeur[i]} livraisons.");
                    }
                    break;
                case 2:
                    Console.Clear();
                    List<Commande> Command = Commande.Lire_excel();
                    Dictionary<int,int> countByYear = Command.GroupBy(obj => obj.date.Year).ToDictionary(group => group.Key, group => group.Count());
                    foreach (var i in countByYear)
                    {
                        Console.WriteLine($"Année: {i.Key}, Nombre de dates: {i.Value}");
                    }
                    break;
                case 3:
                    Console.Clear();
                    double moyennePrix = Commande.MoyennePrixCommandes(listeCommandes);
                    Console.WriteLine($"La moyenne des prix des commandes est : {moyennePrix}€");
                    break;
                case 4:
                    Console.Clear();
                    List<Client> Clients = Client.Lire_excel();
                    List<Commande> Commandes = Commande.Lire_excel();
                    for(int i = 0; i < Clients.Count;i++)
                    {
                        Client client = Clients[i];
                        if(client.num_commande.Count != 0)
                        {
                            float moy = 0;
                            Commande mem = new Commande();
                            for(int j = 0; j < client.num_commande.Count;j++)
                            {
                                mem = Commandes.Find(c => c.idcommande == client.num_commande[j]);
                                moy += (float)mem.prix;

                            }
                            moy = moy / client.num_commande.Count;
                            Console.WriteLine($"{client.Nom} {client.Prenom} a commandé pour {moy}euros en moyenne par commande");
                        }
                        else
                        {
                            Console.WriteLine($"{client.Nom} {client.Prenom} n'a pas effectué de commande");
                        }
                    }
                    break;
                case 5:
                    Console.Clear();
                    Console.Write("Statistique pour quel numéro SS : ");
                    int numeroSSClient = Convert.ToInt32(Console.ReadLine()); 
                    Commande.AfficherCommandesClient(numeroSSClient, listeCommandes);
                    break;
            }
        }

        /// <summary>
        /// Module de la console permettant au patron de gérer plusieurs chose sur les commandes passées à son entreprise
        /// </summary>
        static void ModuleCommandes()
        {
            Console.Clear();
            Console.WriteLine("Voulez-vous :\n" +
                "\n\t1.Ajouter une commande" +
                "\n\t2.Modifier une commande" +
                "\n\t3.Afficher les commandes" +
                "\n\t4.Afficher le plan de route \n");
            int rep_commande = Convert.ToInt32(Console.ReadLine());
            switch (rep_commande)
            {
                case 1:
                    Commande.Nouvelle_commande();
                    break;
                case 2:
                    Console.Write("Quel numéro de commande souhaitez vous modifier ?");
                    int num = Convert.ToInt32(Console.ReadLine());
                    Commande.Modifier_commande(num);
                    break;
                case 3:
                    List<Commande> list = Commande.Lire_excel();
                    Commande.Affiche_List_Commande(list);
                    break;
                case 4:
                    Console.Clear();
                    Console.Write("Id du chauffeur : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    Chauffeur.plan_route(id);
                    break;
            }
        }

        /// <summary>
        /// Module de la console permettant au patron de gérer plusieurs chose sur ses salariés comme l'ajout le licenciment ou l'afffichage de ces derniers
        /// </summary>
        static void ModuleSalarie()
        {
            Console.Clear();
            Console.WriteLine("Voulez-vous : \n" +
                "\n\t1.Afficher l'organigramme " +
                "\n\t2.Ajouter un salarié " +
                "\n\t3.Licencier" +
                "\n\t4.Modifier les infos d'un salarié" +
                "\n\t5.Afficher la liste des salariés" +
                "\n\t6.Retour\n");
            int reponse = Convert.ToInt32(Console.ReadLine());
            switch(reponse)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Voici l'organigramme de l'entreprise");
                    AfficherOrga();
                    break;
                case 2:
                    Console.Clear();
                    AfficherOrgaetNum();
                    List<Salarie> salaries = Salarie.Lire_csv();
                    Console.Write("Quelle est le num_SS du supérieur de votre nouveau salarié : ");
                    int num_SS = Convert.ToInt32(Console.ReadLine());
                    Salarie salariesup = salaries.Find(s => s.num_ss == num_SS);
                    if (salariesup != null)
                    {
                        Salarie salnv = Salarie.Création();
                        Salarie.AjouterNouveauSalarie(salaries, salnv, salariesup);
                        Salarie.Updatecsv(salaries);
                        Chauffeur c = new Chauffeur();
                        c.Ajout();
                        Console.WriteLine("Salarie Ajouté");
                    }
                    else
                    {
                        Console.WriteLine("Le num_SS que vous chercher n'est pas attribué");
                    }
                    break;
                case 3:
                    Console.Clear();
                    

                    Console.WriteLine("Voici l'organigramme de l'entreprise");
                    AfficherOrga();

                    List<Salarie> sasa = Salarie.Lire_csv();
                    Console.Write("Quelle est le num_SS du salarié que vous souhaitez licenscier : ");
                    int Num_SS = Convert.ToInt32(Console.ReadLine());
                    Salarie salarielic = sasa.Find(s => s.num_ss == Num_SS);
                    if (salarielic != null)
                    {          
                        sasa.Remove(salarielic);
                        Console.WriteLine("Salarie licencié");
                    }
                    else
                    {
                        Console.WriteLine("Le num_SS que vous chercher n'est pas attribué");
                    }

                    Noeud<Salarie> rac = CreationArbre(sasa);
                    Console.WriteLine("Voici le nouvel organigramme de l'entreprise");
                    ParcourirArbre(rac);
                    break;
                case 4:
                    Console.Clear();
                    AfficherOrgaetNum();
                    Console.Write("Num SS du salarié à modifier : ");
                    int rep_num2 = Convert.ToInt32(Console.ReadLine());
                    Salarie.Modifier_Salarie(rep_num2);
                    break;
                case 5:
                    Console.Clear();
                    List<Salarie> Salaries = Salarie.Lire_csv();
                    Salaries.ForEach(c => Console.WriteLine(c.ToString()));
                    break;
                case 6:
                    break;
            }

        }

        /// <summary>
        /// Crée un arbre n-aire à partir d'une liste de Salariés triés par niveau 
        /// </summary>
        /// <param name="organigramme"></param>
        /// <returns></returns>
        public static Noeud<Salarie> CreationArbre(List<Salarie> organigramme)
        {
            organigramme = Salarie.TrieNiveau(organigramme);
            
            Noeud<Salarie> racine = new Noeud<Salarie>(organigramme[0]);
            Noeud<Salarie> dernierParent = racine;

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

        /// <summary>
        /// affiche l'abre n-aire qui représente l'ogranigramme (nom,prénom) dont le noeud racine est placé en paramètre
        /// </summary>
        /// <param name="noeud"></param>
        static void ParcourirArbre(Noeud<Salarie> noeud)
        {
            if (noeud == null)
                return;

            for (int i = 1; i < noeud.Valeur.niveau.Length; i++)
            {
                if (i == noeud.Valeur.niveau.Length - 1)
                { Console.Write("└─ "); }
                else
                { Console.Write("     "); }
            }

            Console.WriteLine($"{noeud.Valeur.Nom} {noeud.Valeur.Prenom}");

            ParcourirArbre(noeud.Fils);

            ParcourirArbre(noeud.Frere);


        }

        /// <summary>
        /// affiche l'abre n-aire qui représente l'ogranigramme (nom,prénom,Num_SS) dont le noeud racine est placé en paramètre
        /// </summary>
        /// <param name="noeud"></param>
        static void ParcourirArbreNum(Noeud<Salarie> noeud)
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

            Console.WriteLine($"{noeud.Valeur.Nom} {noeud.Valeur.Prenom} {noeud.Valeur.Num_ss}");

            ParcourirArbreNum(noeud.Fils);

            ParcourirArbreNum(noeud.Frere);

            
        }

        /// <summary>
        /// Lis les Salaries dans le CSV, crée puis affiche l'abre n-aire qui représente l'ogranigramme (nom,prénom)
        /// </summary>
        static void AfficherOrga()
        {
            List<Salarie> list = Salarie.Lire_csv();
            list = Salarie.TrieNiveau(list);
            Noeud<Salarie> racine = CreationArbre(list);
            ParcourirArbre(racine);
        }

        /// <summary>
        /// Lis les Salaries dans le CSV, crée puis affiche l'abre n-aire qui représente l'ogranigramme (nom,prénom,Num_SS)
        /// </summary>
        static void AfficherOrgaetNum()
        {
            List<Salarie> list = Salarie.Lire_csv();
            list = Salarie.TrieNiveau(list);
            Noeud<Salarie> racine = CreationArbre(list);
            ParcourirArbreNum(racine);
        }

    }
}
