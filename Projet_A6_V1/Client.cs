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
        //peut-être mettre ça en List car un client plusieurs module(mais j'ai eu la flemme pour l'instant)

        public List<int> num_commande;

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

            Client nvclient = new Client(num_ss, nom, prenom, date_naissance, adresse, mail, telephone, num_commande);

            nvclient.Ecrire_client_excel();
            
            
            
            return nvclient;

        }

        //Historique pour le module client
        public void Ecrire_client_excel()
        {
            string path = "Client_Transconnect.csv";
            try
            {
                string text = (this.num_ss + "," + this.nom + "," + this.prenom + "," + this.date_naissance + "," + this.adresse + "," + this.mail + "," + this.telephone + "," + this.num_commande);
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine(text);
                }
                Console.WriteLine("Client" + this.num_ss +" ajouté à la base de donné");
            }
            catch(Exception ex) 
            {
                throw new ApplicationException("Erreur dans le programme :", ex);
            }

        }

        public static void Afficher()
        {
            string path = "Client_Transconnect.csv";
            List<Client> lecture_clients = new List<Client>();
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] values = line.Split(',');

                        int num_ss = int.Parse(values[0]);
                        string nom = values[1];
                        string prenom = values[2];
                        DateTime date_naissance = DateTime.Parse(values[3]);
                        string adresse = values[4];
                        string mail = values[5];
                        string telephone = values[6];
                        int num_commande = int.Parse(values[7]);

                        Client client = new Client(num_ss, nom, prenom, date_naissance, adresse, mail, telephone, num_commande);
                        lecture_clients.Add(client);
                    }
                }

                lecture_clients = lecture_clients.OrderBy(c => c.Nom).ThenBy(c => c.Prenom).ToList();

                foreach (Client client in lecture_clients)
                {
                    Console.WriteLine($"Numéro SS : {client.Num_ss}, Nom : {client.nom}, Prénom : {client.Prenom}, Date de naissance : {client.Date_naissance}, Adresse : {client.adresse}, Email : {client.mail}, Téléphone : {client.telephone}, Numéro de commande : {client.num_commande}");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erreur dans le programme :", ex);
            }
        }
    }
}
