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

        /// <summary>
        /// Ajoute au CSV "Client-TransConnect" un Client créé par l'utilisateur
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Ajoute au CSV "Client-TransConnect" un Client créé par l'utilisateur qui est client de TransConnect (Personnalisé)
        /// </summary>
        /// <returns></returns>
        public static Client AjouteUtilisateur()
        {
            Console.WriteLine($"Veuillez entrer vos informations :");
            Console.Write("Numéro de sécurité sociale: ");
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

            
            List<int> num_commande = new List<int>();
            

            Client nvclient = new Client(num_ss, nom, prenom, date_naissance, adresse, mail, telephone, num_commande);

            nvclient.Ecrire_client_excel();



            return nvclient;

        }

        /// <summary>
        /// écris le client dans le fichier CSV "Client_TransConnect"
        /// </summary>
        /// <exception cref="ApplicationException"></exception>
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
                Console.WriteLine($"Le client avec le numéro de sécurité sociale {num_ss} a été ajouté avec succès.");
            }
            catch(Exception ex) 
            {
                throw new ApplicationException("Erreur dans le programme :", ex);
            }

        }

        /// <summary>
        /// Renvoie une liste de Client récupérée sur le CSV "Client_TransConnect", qui est triée selon un paramètre choisi par l'utilisateur
        /// </summary>
        /// <returns></returns>
        public static List<Client> Lire_excel_trier()
        {
            List<Client> lecture_clients = Lire_excel();
            Console.Write("Trier par ordre alphabétique (1)\nTrier par ville (2)\nTrier par montant des achats cumulés(3) : ");
            int choix = Convert.ToInt32(Console.ReadLine());
            switch (choix)
            {
                case 1:
                    lecture_clients = lecture_clients.OrderBy(c => c.Nom).ThenBy(c => c.Prenom).ToList();
                    break;
                case 2:
                    lecture_clients = lecture_clients.OrderBy(c => c.Adresse.Ville).ToList();
                    break;
                case 3:
                    List<Commande> list = Commande.Lire_excel();
                    lecture_clients = lecture_clients.OrderBy(c => CalculerMontantTotalAchats(c)).ToList();
                    break;
            }
            return lecture_clients;

        }

        private static double CalculerMontantTotalAchats(Client client)
        {
            List<Commande> commandesClient = Commande.Lire_excel().Where(c => c.num_ss == client.Num_ss).ToList();

            double montantTotal = 0;

            foreach (Commande commande in commandesClient)
            {
                montantTotal += commande.prix;
            }

            return montantTotal;
        }

        /// <summary>
        /// Vérfie si le client portant le numéro SS mit en paramètre existe dans le CSV
        /// </summary>
        /// <param name="num_ss_a_verif"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public static bool Lire_si_client_existe(int num_ss_a_verif)
        {
            string path = "Client_Transconnect.csv";
            bool client_existe = false;
            List<int> list_num_ss = new List<int>();
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] values = line.Split(',');

                        int num_ss = int.Parse(values[0]);
                        list_num_ss.Add(num_ss);
                    }
                }
                if (list_num_ss.Contains(num_ss_a_verif))
                {
                    client_existe = true;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erreur dans le programme :", ex);
            }
            return client_existe;
        }

        /// <summary>
        /// Renvoie une Liste de Client à partir d'un CSV "Client_TransConnect" présent dans le debug du projet
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
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
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erreur dans le programme :", ex);
            }
            return lecture_clients;
        }

        /// <summary>
        /// Permet de supprimer un Client du CSV "Client_TransConnect" dont le numéro SS est passé en paramètre
        /// </summary>
        /// <param name="num_ss"></param>
        /// <exception cref="ApplicationException"></exception>
        public static void Supprimer_client(int num_ss)
        {
            string path = "Client_Transconnect.csv";
            try
            {
                List<Client> clients = Lire_excel();

                Client clientASupprimer = clients.Find(c => c.Num_ss == num_ss);

                if (clientASupprimer != null)
                {
                    clients.Remove(clientASupprimer);

                    using (StreamWriter writer = new StreamWriter(path))
                    {
                        foreach (Client client in clients)
                        {
                            string text = $"{client.Num_ss},{client.Nom},{client.Prenom},{client.Date_naissance},{client.Adresse.Numero},{client.Adresse.Rue},{client.Adresse.Ville},{client.Mail},{client.Telephone}";
                            foreach (int num_commande in client.num_commande)
                            {
                                text += $",{num_commande}";
                            }
                            writer.WriteLine(text);
                        }
                    }

                    Console.WriteLine($"Le client avec le numéro de sécurité sociale {num_ss} a été supprimé avec succès.");
                }
                else
                {
                    Console.WriteLine($"Aucun client trouvé avec le numéro de sécurité sociale {num_ss}.");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erreur dans le programme :", ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lecture_clients"></param>
        public static void Affiche_List(List<Client> lecture_clients)
        {
            foreach (Client client in lecture_clients)
            {
                Affiche_Client(client);
            }
        }

        /// <summary>
        /// Permet à l'utilisateur de mofidier le Client dont le numéro SS est passé en paramètre
        /// </summary>
        /// <param name="num_ss"></param>
        /// <exception cref="ApplicationException"></exception>
        public static void Modifier_client(int num_ss)
        {
            string path = "Client_Transconnect.csv";
            try
            {
                List<Client> clients = Lire_excel();

                Client clientAModifier = clients.Find(c => c.Num_ss == num_ss);

                if (clientAModifier != null)
                {
                    Console.WriteLine("Informations actuelles du client :");
                    Affiche_Client(clientAModifier);

                    Console.WriteLine("Saisissez les nouvelles informations :");
                    Console.Write("Voulez-vous modifier le nom (y/n) : ");
                    char a1 = Console.ReadKey().KeyChar;
                    if (a1 == 'y')
                    {
                        Console.Write("\nNouveau nom : ");
                        clientAModifier.Nom = Console.ReadLine();
                    }
                    Console.Write("\nVoulez-vous modifier le prénom (y/n) : ");
                    char a2 = Console.ReadKey().KeyChar;
                    if (a2 == 'y')
                    {
                        Console.Write("\nNouveau prénom : ");
                        clientAModifier.Prenom = Console.ReadLine();
                    }
                    Console.Write("\nVoulez-vous modifier la date de naissance (y/n) : ");
                    char a3 = Console.ReadKey().KeyChar;
                    if (a3 == 'y')
                    {
                        Console.Write("\nNouvelle la date de naissance (AAAA-MM-JJ) : ");
                        clientAModifier.Date_naissance = DateTime.Parse(Console.ReadLine());
                    }
                    Console.Write("\nVoulez-vous modifier l'adresse (y/n) : ");
                    char a4 = Console.ReadKey().KeyChar;
                    if (a4 == 'y')
                    {
                        Console.Write("\nNouvelle adresse : ");
                        Adresse adresse = new Adresse(0, "", "");
                        clientAModifier.adresse = adresse.Demander_adresse();
                    }
                    Console.Write("\nVoulez-vous modifier le mail (y/n) : ");
                    char a5 = Console.ReadKey().KeyChar;
                    if (a5 == 'y')
                    {
                        Console.Write("\nNouveau mail : ");
                        clientAModifier.Mail = Console.ReadLine();
                    }
                    Console.Write("\nVoulez-vous modifier le téléphone (y/n) : ");
                    char a6 = Console.ReadKey().KeyChar;
                    if (a6 == 'y')
                    {
                        Console.Write("\nNouveau téléphone : ");
                        clientAModifier.Telephone = Console.ReadLine();
                    }
                    Console.WriteLine("\n");
                    using (StreamWriter writer = new StreamWriter(path))
                    {
                        foreach (Client client in clients)
                        {
                            string text = $"{client.Num_ss},{client.Nom},{client.Prenom},{client.Date_naissance},{client.Adresse.Numero},{client.Adresse.Rue},{client.Adresse.Ville},{client.Mail},{client.Telephone}";
                            foreach (int num_commande in client.num_commande)
                            {
                                text += $",{num_commande}";
                            }
                            writer.WriteLine(text);
                        }
                    }

                    Console.WriteLine($"Le client avec le numéro de sécurité sociale {num_ss} a été modifié avec succès.");
                }
                else
                {
                    Console.WriteLine($"Aucun client trouvé avec le numéro de sécurité sociale {num_ss}.");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erreur dans le programme :", ex);
            }
        }

        /// <summary>
        /// Affiche les infos du Client dans la console
        /// </summary>
        /// <param name="client"></param>
        public static void Affiche_Client(Client client)
        {
            Console.Write($"Numéro SS : {client.Num_ss}\n\tNom : {client.nom}\n\tPrénom : {client.Prenom}\n\tDate de naissance : {client.Date_naissance}\n\tAdresse : {client.adresse.ToString()}\n\tEmail : {client.mail}\n\tTéléphone : {client.telephone}\n\tNuméro(s) de commande : ");

            client.num_commande.ForEach(commande =>
            {
                Console.Write(commande+", ");
            });
            Console.WriteLine("\n");
        }
        public static void UpdateCSV(List<Client> clients)
        {
            string path = "Client_Transconnect.csv";
            File.WriteAllText(path, string.Empty);
            clients.ForEach(c => c.Ecrire_client_excel());
        }
    }
}
