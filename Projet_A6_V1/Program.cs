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

            //List<Client> liste_clients = new List<Client>();

            //liste_clients[0] = new Client(123456789, "Dupont", "Jean", new DateTime(1990, 5, 15), "1 rue de la Liberté", "jean.dupont@example.com", "01 23 45 67 89", 01);
            //liste_clients[1] = new Client(987654321, "Martin", "Sophie", new DateTime(1985, 9, 20), "5 avenue des Roses", "sophie.martin@example.com", "06 12 34 56 78", 02);
            //liste_clients[2] = new Client(456123789, "Leclerc", "Pierre", new DateTime(1978, 3, 10), "10 rue de la Paix", "pierre.leclerc@example.com", "02 34 56 78 90", 03);
            //liste_clients[3] = new Client(789456123, "Lefebvre", "Marie", new DateTime(1982, 11, 25), "8 boulevard Voltaire", "marie.lefebvre@example.com", "03 45 67 89 01", 04);
            //liste_clients[4] = new Client(321654987, "Dubois", "Pauline", new DateTime(1995, 7, 8), "15 rue du Commerce", "pauline.dubois@example.com", "04 56 78 90 12", 05);
            //liste_clients[5] = new Client(654987321, "Moreau", "Thomas", new DateTime(1980, 1, 30), "20 avenue Foch", "thomas.moreau@example.com", "05 67 89 01 23", 06);
            //liste_clients[6] = new Client(987321654, "Roux", "Isabelle", new DateTime(1973, 6, 12), "25 rue des Lilas", "isabelle.roux@example.com", "06 78 90 12 34", 07);
            //liste_clients[7] = new Client(234567891, "Fournier", "Luc", new DateTime(1993, 4, 3), "30 avenue Gambetta", "luc.fournier@example.com", "07 89 01 23 45", 08);
            //liste_clients[8] = new Client(789123456, "Girard", "Elodie", new DateTime(1988, 8, 18), "35 rue de la République", "elodie.girard@example.com", "08 90 12 34 56", 09);
            //liste_clients[9] = new Client(567891234, "Garnier", "Antoine", new DateTime(1975, 12, 28), "40 boulevard Haussmann", "antoine.garnier@example.com", "09 01 23 45 67", 10);


            //Salarie directeurGeneral = new Salarie(1, "Dupond", "Jean", new DateTime(1960, 1, 1), "1 rue de la Paix, Paris", "jean.dupont@entreprise.com", "01 02 03 04 05", new DateTime(2000, 1, 1), "Directeur Général", 100000);
            //Salarie directriceCommerciale = new Salarie(2, "Fiesta", "Marie", new DateTime(1965, 2, 2), "2 rue de la République, Paris", "marie.fiesta@entreprise.com", "01 06 07 08 09", new DateTime(2005, 2, 2), "Directrice Commerciale", 80000);
            //Salarie directeurOperations = new Salarie(3, "Fetard", "Pierre", new DateTime(1970, 3, 3), "3 rue de la Liberté, Paris", "pierre.fetard@entreprise.com", "01 10 11 12 13", new DateTime(2010, 3, 3), "Directeur des Opérations", 90000);
            //Salarie directriceRH = new Salarie(4, "Joyeuse", "Anne", new DateTime(1975, 4, 4), "4 rue de l'Egalité, Paris", "anne.joyeuse@entreprise.com", "01 14 15 16 17", new DateTime(2015, 4, 4), "Directrice des RH", 70000);
            //Salarie directeurFinancier = new Salarie(5, "GripSous", "Robert", new DateTime(1980, 5, 5), "5 rue de la Fraternité, Paris", "robert.gripsous@entreprise.com", "01 18 19 20 21", new DateTime(2020, 5, 5), "Directeur Financier", 85000);

            //Client client = new Client();
            //Client client = new Client(123456789, "Dupont", "Jean", new DateTime(1990, 5, 15), "1 rue de la Liberté", "jean.dupont@example.com", "01 23 45 67 89", 01);
            Client nouveauClient = Client.Ajoute();

            nouveauClient.Ecrire_client_excel();
            
            //Client.Afficher();


            Console.ReadKey();

        }

        static void ModuleClient()
        {
            Console.Write("Voulez-vous Ajouter une nouveau client ? Si non, cela affichera la liste pour effectuer une modification ou une suppresion. y/n ?");
            string answer = Console.ReadLine();
            if(answer == "y")
            {
                List<Client> ListdesClients = Client.Ajoute();

            }
            if else(answer == "n")
            {

            }
            else
            {
                Console.Write("Selection non valide, réesayer : ");
                answer = Console.ReadLine();
            }

        }

        static List<Client> GetClientFromExcel()
        {

        }

    }
}
