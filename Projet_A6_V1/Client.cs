using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace Projet_A6_V1
{
    internal class Client : Personne
    {
       

        public List<int> num_commande;

        public Client(int num_ss, string nom, string prenom, DateTime date_naissance, Adresse adresse, string mail, string telephone, List<int> num_commande) 
            : base(num_ss, nom, prenom, date_naissance, adresse, mail, telephone)
        {
            this.num_commande = num_commande;
        }

        public static Client Ajoute()
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

            Adresse adresse = new Adresse(0, "", "");
            adresse = adresse.Demander_adresse();

            Console.Write("Email : ");
            string mail = Console.ReadLine();

            Console.Write("Téléphone : ");
            string telephone = Console.ReadLine();

            Console.Write("Numéro de commande : ");
            List<int> num_commande = new List<int>();
            num_commande.Add(Convert.ToInt32(Console.ReadLine()));

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
                string text = (this.num_ss + "," + this.nom + "," + this.prenom + "," + this.date_naissance + "," + this.adresse.Numero + "," + this.adresse.Rue + ',' 
                    + this.adresse.Ville + "," + this.mail + "," + this.telephone);
                for (int i = 0; i < this.num_commande.Count; i++)
                {
                    string mem = "," + num_commande[i];
                    text += mem;
                }
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

        public static List<Client> Lire_excel()
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
                        Adresse adresse = new Adresse(int.Parse(values[4]), values[5], values[6]); 
                        string mail = values[7];
                        string telephone = values[8];
                        List<int> num_commande = new List<int>();
                        for(int i = 9; i < values.Length; i++)
                        {
                            num_commande.Add(int.Parse(values[i])); 
                        }
                       

                        Client client = new Client(num_ss, nom, prenom, date_naissance, adresse, mail, telephone, num_commande);
                        lecture_clients.Add(client);
                    }
                }

                Console.WriteLine("Trier par ordre alphabétique (1)\nTrier par ville (2)\nTrier par montant des achats cumulé(3)");
                int choix = Convert.ToInt32(Console.ReadLine());
                switch (choix)
                {
                    case 1:
                        lecture_clients = lecture_clients.OrderBy(c => c.Nom).ThenBy(c => c.Prenom).ToList();
                        break;
                    case 2:
                        lecture_clients = lecture_clients.OrderBy(c => c.Adresse).ToList();
                        break;
                    //case 3:
                    //    lecture_clients = lecture_clients.OrderBy(c => c.Num_commande).ToList();
                    //    break;
                }

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erreur dans le programme :", ex);
            }
            return lecture_clients;
        }

        public static void Affiche_List(List<Client> lecture_clients)
        {
            foreach (Client client in lecture_clients)
            {
                Affiche_Client(client);
            }
        }

        public static void Affiche_Client(Client client)
        {
            Console.WriteLine($"Numéro SS : {client.Num_ss}, Nom : {client.nom}, Prénom : {client.Prenom}, Date de naissance : {client.Date_naissance}, Adresse : {client.adresse}, Email : {client.mail}, Téléphone : {client.telephone}, Numéro de commande : {client.num_commande[0]}");
        }


    }
}
