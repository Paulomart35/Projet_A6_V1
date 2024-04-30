using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Projet_A6_V1
{
    internal class Client : Personne
    {
        //peut-être mettre ça en List car un client plusieurs module
        public int num_commande;

        public Client(int num_ss, string nom, string prenom, DateTime date_naissance, string adresse, string mail, string telephone, int num_commande) 
            : base(num_ss, nom, prenom, date_naissance, adresse, mail, telephone)
        {
            this.num_commande = num_commande;
        }

        public Client Ajoute()
        {
            Console.WriteLine($"Saisir les informations pour le client:");
            Console.Write("Numéro SS : ");
            int num_ss = Convert.ToInt32(Console.ReadLine());

            Console.Write("Nom : ");
            string nom = Console.ReadLine();

            Console.Write("Prénom : ");
            string prenom = Console.ReadLine();

            Console.Write("Date de naissance (AAAA-MM-JJ) : ");
            DateTime date_naissance = DateTime.Parse(Console.ReadLine());

            Console.Write("Adresse : ");
            string adresse = Console.ReadLine();

            Console.Write("Email : ");
            string mail = Console.ReadLine();

            Console.Write("Téléphone : ");
            string telephone = Console.ReadLine();

            Console.Write("Numéro de commande : ");
            int num_commande = Convert.ToInt32(Console.ReadLine());

            Ecrire_client_excel(num_ss, nom, prenom, date_naissance, adresse, mail, telephone, num_commande);

            return new Client(num_ss, nom, prenom, date_naissance, adresse, mail, telephone, num_commande);

        }

        //Historique pour le module client
        public static void Ecrire_client_excel(int num_ss, string nom, string prenom, DateTime date_naissance, string adresse, string mail, string telephone, int num_commande)
        {
            string path = "Client_Transconnect.csv";
            try
            {
                string text = (num_ss + "," + nom + "," + prenom + "," + date_naissance + "," + adresse + "," + mail + "," + telephone + "," + num_commande);
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine(text);
                }
                Console.WriteLine("ok");
            }
            catch(Exception ex) 
            {
                throw new ApplicationException("Erreur dans le programme :", ex);
            }

        }
    }
}
