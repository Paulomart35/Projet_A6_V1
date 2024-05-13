using System;
using System.Collections.Generic;
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




            Commande c = Commande.Nouvelle_commande();
            //Livraison l = new Livraison();
            //l.Distancepluscourte("Toulouse", "Montpellier");
            Commande.Affiche_commande(c);
            //Commande.Modifier_commande(1);
            //List<Commande> list = Commande.Lire_excel();
            //Commande.Affiche_List_Commande(list);
            //Adresse adresseDepart = new Adresse(1, "Rue de la Liberté", "Paris");
            //Adresse adresseArrivee = new Adresse(10, "Avenue des Champs-Élysées", "Paris");
            //Livraison livraison = new Livraison(adresseDepart, adresseArrivee, 50, "2 heures");
            //livraison.Distancepluscourte();
            Console.ReadKey();
        }

        
        static void ModuleClient()
        {
            Console.Write("Voulez-vous Ajouter une nouveau client ? Si non, cela affichera la liste pour effectuer une modification ou une suppresion. y/n ?");
            string answer = Console.ReadLine();
            if(answer == "y")
            {
                List<Client> ListedesClients = Client.Lire_excel();
                Client.Affiche_List(ListedesClients);



            }
            else if (answer == "n")
            {
                
            }
            else
            {
                Console.Write("Selection non valide, réesayer : ");
                answer = Console.ReadLine();
            }

        }

        static void ModulePatron()
        {
            Console.Write("Voulez-vous accéder aux client (1), aux salariés (2) ou aux commandes (3) : ");
            string reponse = Console.ReadLine();
            if(reponse == "1")
            {
                ModuleClient();
            }
            else if(reponse == "2")
            {
                ModuleSalarie();
            }
        }

        static void ModuleSalarie()
        {
            Console.WriteLine("Voulez-vous affciher l'organigramme (1), licensier (2) ou ajouter un salarié (3) ? : ");
            string reponse = Console.ReadLine();
            if (reponse == "1")
            {
                List<Salarie> list = Salarie.Lire_csv();
                Noeud<Salarie> racine = CreationArbre(list);
                ParcourirArbre(racine);
            }
            else if (reponse == "2")
            {
                List<Salarie> list = Salarie.Lire_csv();
                Salarie salnv = Salarie.Création();

                Console.Write("Quelle est le num_SS du supérieur de votre nouveau salarié : ");
                int num_SS = Convert.ToInt32(Console.ReadLine());
                Salarie slarariesup = list.Find(s => s.num_ss == num_SS);

                Salarie.AjouterNouveauSalarie(list, salnv, slarariesup);

                Salarie.Updatecsv(list);
                Console.WriteLine("Salarie Ajouté");
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
