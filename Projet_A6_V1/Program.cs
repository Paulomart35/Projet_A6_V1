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

            Client client = new Client(1, "dfvr","sdvsv",DateTime.Now,new Adresse(205,"qsrfv","eqrv"),"qsrv","&é'&é'&é", new List<int> { 1, 2, 3, 4 }) ;
            client.Ecrire_client_excel();
            List<Client> client2 = Client.Lire_excel();

            Client.Affiche_Client(client2[0]);
            //Client.Afficher();


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



    }
}
