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

            Client nouveauClient = Client.Ajoute();
            
            //Client.Afficher();
            //Client.Afficher();


            Console.ReadKey();

        }

        /*
        static void ModuleClient()
        {
            Console.Write("Voulez-vous Ajouter une nouveau client ? Si non, cela affichera la liste pour effectuer une modification ou une suppresion. y/n ?");
            string answer = Console.ReadLine();
            if(answer == "y")
            {
                List<Client> ListdesClients = Client.Afficher();

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

        }*/

    }
}
