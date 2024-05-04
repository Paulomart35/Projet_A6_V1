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
            Client.Modifier_client(123456789);
            List<Client> list = Client.Lire_excel_trier();
            Client.Affiche_List(list);
            

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
