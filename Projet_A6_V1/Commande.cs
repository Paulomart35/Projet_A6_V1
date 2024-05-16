using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using static System.Net.Mime.MediaTypeNames;

namespace Projet_A6_V1
{
    internal class Commande
    {
        private static int derniernumcom = 0;
        
        public int idcommande;
        public int num_ss;
        public Livraison livraison;
        public double prix;
        public int idchauffeur;
        public int kilometrage;
        public List<string> ville_traverse;
        public DateTime date;
        public Vehicule vehicule;

        #region Constructeurs
        public Commande(int idcommande, int num_ss, Livraison livraison, double prix, int chauffeur, int kilometrage, List<string> ville_traverse, DateTime date, Vehicule vehicule)
        {
            this.idcommande = idcommande;
            this.num_ss=num_ss;
            this.livraison=livraison;
            this.prix=prix;
            this.idchauffeur=chauffeur;
            this.date=date;
            this.vehicule=vehicule;
            this.kilometrage=kilometrage;
            this.ville_traverse=ville_traverse;
        }
        public Commande(int num_ss, Livraison livraison, double prix, int chauffeur, int kilometrage, List<string> ville_traverse, DateTime date, Vehicule vehicule)
        {
            this.idcommande = ++derniernumcom;
            this.num_ss=num_ss;
            this.livraison=livraison;
            this.prix=prix;
            this.idchauffeur=chauffeur;
            this.vehicule=vehicule;
            this.date=date;
            this.kilometrage=kilometrage;
            this.ville_traverse=ville_traverse;
        }
        public Commande(int num_ss, Livraison livraison, int chauffeur, int kilometrage, List<string> ville_traverse, DateTime date, Vehicule vehicule)
        {
            this.idcommande = ++derniernumcom;
            this.num_ss=num_ss;
            this.livraison=livraison;
            this.prix=0;
            this.idchauffeur=chauffeur;
            this.vehicule=vehicule;
            this.date=date;
            this.kilometrage=kilometrage;
            this.ville_traverse=ville_traverse;
        }
        public Commande() { }
        #endregion

        /// <summary>
        /// Lis le csv Commande lis par ligne séparée par une virgule
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public static List<Commande> Lire_excel()
        {
            string path = "Commande_Transconnect.csv";
            List<Commande> lecture_commandes = new List<Commande>();
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] values = line.Split(',');
                        
                        int idcommande = int.Parse(values[0]);
                        int num_ss = int.Parse(values[1]);
                        
                        Adresse adressed = new Adresse(int.Parse(values[2]), values[3], values[4]);
                        Adresse adressea = new Adresse(int.Parse(values[5]), values[6], values[7]);
                        Livraison livraison = new Livraison(adressed, adressea);
                        double prix = double.Parse(values[8]);
                        int idchauffeur = int.Parse(values[9]);
                        int kilometrage = int.Parse(values[10]);
                        List<string> ville_traverse = new List<string>();
                        string[] vt = values[11].Split('/');
                        foreach (string v in vt)
                        {
                            ville_traverse.Add(v);
                        }
                        DateTime data = DateTime.Parse(values[12]);
                        string vehicule = values[13];
                        double volume = 0;
                        List<string> matiere = new List<string>();
                        Commande commande = new Commande();
                        switch (vehicule)
                        {
                            case "Voiture":
                                int nbPassagers = int.Parse(values[14]); 
                                Vehicule voiture = new Voiture(nbPassagers);
                                commande = new Commande(idcommande, num_ss, livraison, prix, idchauffeur, kilometrage, ville_traverse, data, voiture);
                                break;
                            case "Camionnette":
                                string usage = values[14];
                                Vehicule camionnette = new Camionnette(usage);
                                commande = new Commande(idcommande, num_ss, livraison, prix, idchauffeur, kilometrage, ville_traverse, data, camionnette);
                                break;
                            case "CamionFrigorifique":
                                volume = double.Parse(values[14]);
                                string[] matieres = values[15].Split('/');
                                foreach (string m in matieres)
                                {
                                    matiere.Add(m);
                                }
                                int nbGrpElectrogene = int.Parse(values[16]); 
                                Vehicule camionFrigorifique = new CamionFrigorifique(volume, matiere, nbGrpElectrogene);
                                commande = new Commande(idcommande, num_ss, livraison, prix, idchauffeur, kilometrage, ville_traverse, data, camionFrigorifique);
                                break;
                            case "CamionCiterne":
                                volume = double.Parse(values[14]); 
                                string[] matieres2 = values[15].Split('/'); 
                                foreach (string m in matieres2)
                                {
                                    matiere.Add(m);
                                }
                                string typeCuve = values[16]; 
                                Vehicule camionCiterne = new CamionCiterne(volume, matiere, typeCuve);
                                commande = new Commande(idcommande, num_ss, livraison, prix, idchauffeur, kilometrage, ville_traverse, data, camionCiterne);
                                break;
                            case "CamionBenne":
                                volume = double.Parse(values[14]); 
                                string[] matieres3 = values[15].Split('/'); 
                                foreach (string m in matieres3)
                                {
                                    matiere.Add(m);
                                }
                                string typeTravaux = values[16]; 
                                List<string> equipements = new List<string>();
                                string[] equipementsArray = values[17].Split('/'); 
                                foreach (string e in equipementsArray)
                                {
                                    equipements.Add(e);
                                }
                                int nbBennes = int.Parse(values[18]); 
                                bool grue = bool.Parse(values[19]); 
                                Vehicule camionBenne = new CamionBenne(volume, matiere, typeTravaux, equipements, nbBennes, grue);
                                commande = new Commande(idcommande, num_ss, livraison, prix, idchauffeur, kilometrage, ville_traverse, data, camionBenne);
                                break;
                            case null:
                                Vehicule v = new Vehicule();
                                commande = new Commande(idcommande, num_ss, livraison, prix, idchauffeur, kilometrage, ville_traverse, data, v);
                                break;
                        }
                        lecture_commandes.Add(commande);
                    }
                }
                

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erreur dans le programme :", ex);
            }
            return lecture_commandes;
        }

        /// <summary>
        /// Ecris dans le csv en fonction du type de voiture
        /// </summary>
        /// <exception cref="ApplicationException"></exception>
        public void Ecrire_commande_excel()
        {
            string path = "Commande_Transconnect.csv";
            List<Commande> list = Lire_excel();
            if (list.Count > 0)
            {
                derniernumcom = list.Last().idcommande;
            }
            try
            {
                string str = "";
                str = this.ville_traverse[0];
                for (int i = 1; i < this.ville_traverse.Count; i++)
                {
                    str += "/" + this.ville_traverse[i];
                }
                string text = (++derniernumcom + "," + this.num_ss + "," + this.livraison.ToString() + "," + this.prix + "," + this.idchauffeur + "," + this.kilometrage + "," + str + "," + this.date + "," + this.vehicule.GetType().Name);
                switch (this.vehicule.GetType().Name)
                {
                    case "Voiture":
                        Voiture v = (Voiture)this.vehicule;
                        text += "," + v.ecriture_attributs();
                        break;
                    case "Camionnette":
                        Camionnette c = (Camionnette)this.vehicule;
                        text += "," + c.ecriture_attributs();
                        break;
                    case "CamionFrigorifique":
                        CamionFrigorifique f = (CamionFrigorifique)this.vehicule;
                        text += "," + f.ecriture_attributs();
                        break;
                    case "CamionCiterne":
                        CamionCiterne ci = (CamionCiterne)this.vehicule;
                        text += "," + ci.ecriture_attributs();
                        break;
                    case "CamionBenne":
                        CamionBenne b = (CamionBenne)this.vehicule;
                        text += "," + b.ecriture_attributs();
                        break;
                }
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine(text);
                }
                Console.WriteLine("Commande" + ++derniernumcom + " ajouté à la base de donné");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erreur dans le programme :", ex);
            }

        }

        /// <summary>
        /// Demande de rentrer manuelleùment une nouvelle commande qui l'écrirera dans le csv grace à la fonction ci-dessus
        /// </summary>
        /// <returns>retourne une commande complète</returns>
        public static Commande Nouvelle_commande()
        {
            Commande nv_commande = new Commande();
            Console.WriteLine($"Saisir les informations pour la commande:");

            Console.Write("Num SS : ");
            int num_ss = Convert.ToInt32(Console.ReadLine());

            if(Client.Lire_si_client_existe(num_ss))
            {
                Console.Write("Livraison : ");
                Livraison livraison = new Livraison(null, null);
                livraison = livraison.Demander_Livraison();

                int id_chauffeur = Chauffeur.choisir_chauffeur();

                Console.Write("Date (AAAA-MM-JJ) : ");
                DateTime date = DateTime.Parse(Console.ReadLine());


                Console.Write("Type de véhicule (Voiture, Camionnette, CamionFrigorifique, CamionCiterne, CamionBenne) : ");
                string rep = Console.ReadLine();
                List<string> v_t = livraison.Demander_ville_traverse(livraison.départ.ville, livraison.arrivee.ville);
                int km = livraison.Demander_kilometrage(livraison.départ.ville, livraison.arrivee.ville);
                double prix = livraison.Calcul_prix(rep, id_chauffeur, km);
                switch (rep)
                {
                    case "Voiture":
                        Voiture voiture = new Voiture();
                        voiture = voiture.demander_attribut();
                        nv_commande = new Commande(num_ss, livraison, prix, id_chauffeur, km, v_t, date, voiture);
                        break;
                    case "Camionnette":
                        Camionnette camionnette = new Camionnette();
                        camionnette = camionnette.demander_attribut();
                        nv_commande = new Commande(num_ss, livraison, prix, id_chauffeur, km, v_t, date, camionnette);
                        break;
                    case "CamionFrigorifique":
                        CamionFrigorifique camionFrigorifique = new CamionFrigorifique();
                        camionFrigorifique = camionFrigorifique.demander_attribut();
                        nv_commande = new Commande(num_ss, livraison, prix, id_chauffeur, km, v_t, date, camionFrigorifique);
                        break;
                    case "CamionCiterne":
                        CamionCiterne camionCiterne = new CamionCiterne();
                        camionCiterne = camionCiterne.demander_attribut();
                        nv_commande = new Commande(num_ss, livraison, prix, id_chauffeur, km, v_t, date, camionCiterne);
                        break;
                    case "CamionBenne":
                        CamionBenne camionBenne = new CamionBenne();
                        camionBenne = camionBenne.demander_attribut();
                        nv_commande = new Commande(num_ss, livraison, prix, id_chauffeur, km, v_t, date, camionBenne);
                        break;
                }
                nv_commande.Ecrire_commande_excel();
            }
            else
            {
                Console.WriteLine("Il faut d'abord ajouter le client");
            }
            return nv_commande;

        }

        /// <summary>
        /// Affiche une seule commande en fonction des ses attributs
        /// </summary>
        /// <param name="commande"></param>
        public static void Affiche_commande(Commande commande)
        {
            Console.WriteLine($"ID commande : {commande.idcommande}");
            Console.WriteLine($"Numéro SS : {commande.num_ss}");
            Console.WriteLine($"Livraison : Départ - {commande.livraison.départ.Ville}, Arrivée - {commande.livraison.arrivee.Ville}");
            Console.WriteLine($"Prix : {commande.prix}");
            Console.WriteLine($"ID chauffeur : {commande.idchauffeur}");
            Console.WriteLine($"Kilometrage : {commande.kilometrage}");
            Console.WriteLine($"Ville traversée : {string.Join(", ", commande.ville_traverse)}");
            Console.WriteLine($"Date : {commande.date}");

            // Affichez les informations du véhicule
            Console.WriteLine($"Type de véhicule : {commande.vehicule.GetType().Name}");
            if (commande.vehicule is Voiture voiture)
            {
                Console.WriteLine($"Nombre de passagers : {voiture.nb_passager}");
            }
            else if (commande.vehicule is Camionnette camionnette)
            {
                Console.WriteLine($"Usage : {camionnette.usage}");
            }
            else if (commande.vehicule is CamionFrigorifique camionFrigorifique)
            {
                Console.WriteLine($"Volume : {camionFrigorifique.volume}");
                Console.WriteLine($"Matières : {string.Join(", ", camionFrigorifique.matiere)}");
                Console.WriteLine($"Nombre de groupes électrogènes : {camionFrigorifique.nb_grp_electrogene}");
            }
            else if (commande.vehicule is CamionCiterne camionCiterne)
            {
                Console.WriteLine($"Volume : {camionCiterne.volume}");
                Console.WriteLine($"Matières : {string.Join(", ", camionCiterne.matiere)}");
                Console.WriteLine($"Type de cuve : {camionCiterne.type_cuve}");
            }
            else if (commande.vehicule is CamionBenne camionBenne)
            {
                Console.WriteLine($"Volume : {camionBenne.volume}");
                Console.WriteLine($"Matières : {string.Join(", ", camionBenne.matiere)}");
                Console.WriteLine($"Type de travaux : {camionBenne.type_travaux}");
                Console.WriteLine($"Équipements : {string.Join(", ", camionBenne.equipements)}");
                Console.WriteLine($"Nombre de bennes : {camionBenne.nb_bennes}");
                Console.WriteLine($"Grue : {camionBenne.grue}");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Affiche toutes les commandes en appelant la fonction Affiche_commande
        /// </summary>
        /// <param name="lecture_commandes"></param>
        public static void Affiche_List_Commande(List<Commande> lecture_commandes)
        {
            foreach (Commande commande in lecture_commandes)
            {
                Affiche_commande(commande);
            }
        }

        /// <summary>
        /// Permets de supprmier une commande en écransant le csv et le réecrire sans la commande en paramètre
        /// </summary>
        /// <param name="idcommande"></param>
        /// <exception cref="ApplicationException"></exception>
        public static void Supprimer_commande(int idcommande)
        {
            try
            {
                List<Commande> commandes = Lire_excel();

                Commande commandeASupprimer = commandes.Find(c => c.idcommande == idcommande);

                if (commandeASupprimer != null)
                {
                    commandes.Remove(commandeASupprimer);
                    string path = "Commande_Transconnect.csv";
                    File.Delete(path);
                    using (StreamWriter writer = new StreamWriter(path, false))
                    {
                        writer.Write(string.Empty);
                    }
                    foreach (Commande commande in commandes)
                    {
                        commande.Ecrire_commande_excel();
                    }

                    Console.WriteLine($"La commande avec le numéro de commande {idcommande} a été supprimée avec succès.");
                }
                else
                {
                    Console.WriteLine($"Aucune commande trouvée avec le numéro de commande {idcommande}.");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erreur dans le programme :", ex);
            }
        }

        /// <summary>
        /// Modification des attributs Livraison, Vehucule et date en demandant à l'utilsateur et le réecris dans le csv
        /// </summary>
        /// <param name="idcommande"></param>
        /// <exception cref="ApplicationException"></exception>
        public static void Modifier_commande(int idcommande)
        {
            string path = "Commande_Transconnect.csv";
            try
            {
                List<Commande> commandes = Lire_excel();
                
                Commande commandeAModifier = commandes.Find(c => c.idcommande == idcommande);

                if (commandeAModifier != null)
                {
                    Console.WriteLine("Informations actuelles de la commande :");
                    Affiche_commande(commandeAModifier);

                    Console.WriteLine("Saisissez les nouvelles informations :");
                    Console.Write("Voulez-vous modifier la livraison (y/n) : ");
                    char a1 = Console.ReadKey().KeyChar;
                    if (a1 == 'y')
                    {
                        Console.Write("\nNouvelle livraison : ");
                        Livraison nouvelleLivraison = new Livraison();
                        nouvelleLivraison = nouvelleLivraison.Demander_Livraison();
                        commandeAModifier.livraison = nouvelleLivraison;
                        Console.Write("\nNouveau véhicule (Voiture, Camionnette, CamionFrigorifique, CamionCiterne, CamionBenne) : ");
                        string veh = Console.ReadLine();
                        commandeAModifier.kilometrage = nouvelleLivraison.Demander_kilometrage(nouvelleLivraison.départ.ville, nouvelleLivraison.arrivee.ville);
                        commandeAModifier.prix = nouvelleLivraison.Calcul_prix(veh, commandeAModifier.idchauffeur, commandeAModifier.kilometrage);
                        commandeAModifier.ville_traverse = nouvelleLivraison.Demander_ville_traverse(nouvelleLivraison.départ.ville, nouvelleLivraison.arrivee.ville);
                        switch (veh)
                        {
                            case "Voiture":
                                Voiture voiture = new Voiture();
                                voiture = voiture.demander_attribut();
                                commandeAModifier.vehicule = voiture;
                                break;
                            case "Camionnette":
                                Camionnette camionnette = new Camionnette();
                                camionnette = camionnette.demander_attribut();
                                commandeAModifier.vehicule = camionnette;
                                break;
                            case "CamionFrigorifique":
                                CamionFrigorifique camionFrigorifique = new CamionFrigorifique();
                                camionFrigorifique = camionFrigorifique.demander_attribut();
                                commandeAModifier.vehicule = camionFrigorifique;
                                break;
                            case "CamionCiterne":
                                CamionCiterne camionCiterne = new CamionCiterne();
                                camionCiterne = camionCiterne.demander_attribut();
                                commandeAModifier.vehicule = camionCiterne;
                                break;
                            case "CamionBenne":
                                CamionBenne camionBenne = new CamionBenne();
                                camionBenne = camionBenne.demander_attribut();
                                commandeAModifier.vehicule = camionBenne;
                                break;
                        }

                    }
                    Console.Write("\nVoulez-vous modifier la date (y/n) : ");
                    char a3 = Console.ReadKey().KeyChar;
                    if (a3 == 'y')
                    {
                        Console.Write("\nNouvelle date (AAAA-MM-JJ) : ");
                        commandeAModifier.date = DateTime.Parse(Console.ReadLine());
                    }

                    Console.WriteLine("\n");
                    using (StreamWriter writer = new StreamWriter(path))
                    {
                        foreach (Commande commande in commandes)
                        {
                            string str = "";
                            str = commande.ville_traverse[0];
                            for (int i = 1; i < commande.ville_traverse.Count; i++)
                            {
                                str += "/" + commande.ville_traverse[i];
                            }
                            string text = $"{commande.idcommande},{commande.num_ss},{commande.livraison.ToString()},{commande.prix},{commande.idchauffeur},{commande.kilometrage}," +
                                $"{str},{commande.date},{commande.vehicule.GetType().Name}";
                            switch (commande.vehicule.GetType().Name)
                            {
                                case "Voiture":
                                    Voiture v = (Voiture)commande.vehicule;
                                    text += "," + v.ecriture_attributs();
                                    break;
                                case "Camionnette":
                                    Camionnette c = (Camionnette)commande.vehicule;
                                    text += "," + c.ecriture_attributs();
                                    break;
                                case "CamionFrigorifique":
                                    CamionFrigorifique f = (CamionFrigorifique)commande.vehicule;
                                    text += "," + f.ecriture_attributs();
                                    break;
                                case "CamionCiterne":
                                    CamionCiterne ci = (CamionCiterne)commande.vehicule;
                                    text += "," + ci.ecriture_attributs();
                                    break;
                                case "CamionBenne":
                                    CamionBenne b = (CamionBenne)commande.vehicule;
                                    text += "," + b.ecriture_attributs();
                                    break;
                            }

                            writer.WriteLine(text);
                        }
                    }

                    Console.WriteLine($"La commande avec le numéro de commande {idcommande} a été modifiée avec succès.");
                }
                else
                {
                    Console.WriteLine($"Aucune commande trouvée avec le numéro de commande {idcommande}.");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erreur dans le programme :", ex);
            }
        }

        /// <summary>
        /// Appelle les méthodes demander_attribut pour les différents véhicules
        /// </summary>
        /// <param name="type"></param>
        /// <returns>return un Vehicule avec les paramètres que l'utilisateur entrera</returns>
        /// <exception cref="ArgumentException"></exception>
        private static Vehicule Demander_vehicule(string type)
        {
            switch (type)
            {
                case "Voiture":
                    return new Voiture().demander_attribut();
                case "Camionnette":
                    return new Camionnette().demander_attribut();
                case "CamionFrigorifique":
                    return new CamionFrigorifique().demander_attribut();
                case "CamionCiterne":
                    return new CamionCiterne().demander_attribut();
                case "CamionBenne":
                    return new CamionBenne().demander_attribut();
                default:
                    throw new ArgumentException("Type de véhicule non valide");
            }
        }


        #region Statistique
        public static double MoyennePrixCommandes(List<Commande> commandes)
        {
            if (commandes.Count == 0)
            {
                return 0;
            }
            double sommePrix = 0;
            foreach (Commande commande in commandes)
            {
                sommePrix += commande.prix;
            }
            double moyenne = sommePrix / commandes.Count;

            return moyenne;
        }

        public static void AfficherCommandesClient(int numSS, List<Commande> commandes)
        {
            List<Commande> commandesClient = commandes.Where(c => c.num_ss == numSS).ToList();

            if (commandesClient.Count == 0)
            {
                Console.WriteLine("Aucune commande trouvée pour ce client.");
                return;
            }

            Console.WriteLine($"Liste des commandes pour le client avec le numéro de sécurité sociale {numSS} :");
            foreach (Commande commande in commandesClient)
            {
                Affiche_commande(commande); 
            }
        }

        public static int[] GetNombreLivraisonsParChauffeur(List<Commande> commandes)
        {
            int nombreChauffeurs = commandes.Max(c => c.idchauffeur) + 1; // Nombre de chauffeurs
            int[] nombreLivraisonsParChauffeur = new int[nombreChauffeurs]; // Tableau pour stocker le nombre de livraisons pour chaque chauffeur

            foreach (Commande commande in commandes)
            {
                int idChauffeur = commande.idchauffeur;
                nombreLivraisonsParChauffeur[idChauffeur]++;
            }

            return nombreLivraisonsParChauffeur;
        }
        #endregion



    }
}
