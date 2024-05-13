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
            Console.Write("Voulez-vous : " +
                "\n\t1.afficher l'organigramme " +
                "\n\t2.ajouter un salarié " +
                "\n\t3.licensier" +
                "\n\t4.Changer le post d'un salarié" +
                "\n\t5.affichier la liste des salariés");
            int reponse = Convert.ToInt32(Console.ReadLine());
            switch(reponse)
            {
                case 1:
                    List<Salarie> list = Salarie.Lire_csv();
                    list = Salarie.TrieNiveau(list);
                    Noeud<Salarie> racine = CreationArbre(list);
                    ParcourirArbre(racine);
                    break;
                case 2:
                    List<Salarie> salaries = Salarie.Lire_csv();
                    Console.Write("Quelle est le num_SS du supérieur de votre nouveau salarié : ");
                    int num_SS = Convert.ToInt32(Console.ReadLine());
                    Salarie salariesup = salaries.Find(s => s.num_ss == num_SS);
                    if (salariesup != null)
                    {
                        Salarie salnv = Salarie.Création();
                        Salarie.AjouterNouveauSalarie(salaries, salnv, salariesup);
                        Salarie.Updatecsv(salaries);
                        Console.WriteLine("Salarie Ajouté");
                    }
                    else
                    {
                        Console.WriteLine("Le num_SS que vous chercher n'est pas attribué");
                    }
                    break;
                case 3:
                    break;
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

            Console.WriteLine($"{noeud.Valeur.niveau}");

            ParcourirArbre(noeud.Fils);

            ParcourirArbre(noeud.Frere);

            
        }

    }
}
