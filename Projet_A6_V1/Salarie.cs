using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace Projet_A6_V1
{
    internal class Salarie : Personne
    {
        public string niveau;
        public DateTime entree_societe;
        public string poste;
        public int salaire;

        public Salarie(int num_ss, string nom, string prenom, DateTime date_naissance, Adresse adresse, string mail, string telephone,string niveau, DateTime entree_societe, string poste, int salaire) 
            : base(num_ss, nom, prenom, date_naissance, adresse, mail, telephone)
        {
            this.niveau = niveau;
            this.entree_societe = entree_societe;
            this.poste = poste;
            this.salaire = salaire;
        }

        public Salarie(int num_ss, string nom, string poste) : base(num_ss, nom)
        {
            this.poste = poste;
        }

        public Salarie() :base() { }

       /// <summary>
       /// Renvoie un Salarié créé par l'utilisateur
       /// </summary>
       /// <returns></returns>
       public static Salarie Création()
        {
            Console.WriteLine("Entrez le numéro de sécurité sociale : ");
            int num_ss = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Entrez le nom du salarié : ");
            string nom = Console.ReadLine();

            Console.WriteLine("Entrez le prénom du salarié : ");
            string prenom = Console.ReadLine();

            Console.WriteLine("Entrez la date de naissance (format : AAAA-MM-JJ) : ");
            DateTime date_naissance = Convert.ToDateTime(Console.ReadLine());


            Adresse adresse = new Adresse(0, "", "");
            adresse = adresse.Demander_adresse();
            // Vous pouvez réutiliser votre fonction de création d'adresse ici

            Console.WriteLine("Entrez l'adresse email du salarié : ");
            string mail = Console.ReadLine();

            Console.WriteLine("Entrez le numéro de téléphone du salarié : ");
            string telephone = Console.ReadLine();

            
            DateTime entree_societe = DateTime.Now;

            Console.WriteLine("Entrez le poste du salarié : ");
            string poste = Console.ReadLine();

            Console.WriteLine("Entrez le salaire du salarié : ");
            int salaire = Convert.ToInt32(Console.ReadLine());

            // Création et retour de l'objet Salarie avec les informations saisies
            return new Salarie(num_ss, nom, prenom, date_naissance, adresse, mail, telephone, "", entree_societe, poste, salaire);
        }


       /// <summary>
       /// écris le salarié dans le fichier CSV "Salarie_Transconnect"
       /// </summary>
       /// <exception cref="ApplicationException"></exception>
       public void Ecrire_salarie_csv()
        {
            string path = "Salarie_Transconnect.csv";
            try
            {
                string text = $"{num_ss},{nom},{prenom},{date_naissance},{adresse},{mail},{telephone},{niveau},{entree_societe},{poste},{salaire}";

                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine(text);
                }
                Console.WriteLine($"Salarie {num_ss} ajouté au fichier CSV");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erreur dans le programme :", ex);
            }
        }

        /// <summary>
        /// Renvoie une Liste de salarié à partir d'un CSV "Salarie_Transconnect" présent dans le debug du projet
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public static List<Salarie> Lire_csv()
        {
            string path = "Salarie_Transconnect.csv";
            List<Salarie> lecture_salaries = new List<Salarie>();
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
                        Adresse adresse = new Adresse(int.Parse(values[4]), values[5], values[6]); // Assurez-vous que le constructeur de l'adresse accepte les paramètres nécessaires
                        string mail = values[7];
                        string telephone = values[8];
                        string niveau = values[9];
                        DateTime entree_societe = DateTime.Parse(values[10]);
                        string poste = values[11];
                        int salaire = int.Parse(values[12]);

                        Salarie salarie = new Salarie(num_ss, nom, prenom, date_naissance, adresse, mail, telephone, niveau, entree_societe, poste, salaire);
                        lecture_salaries.Add(salarie);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erreur dans le programme :", ex);
            }
            return lecture_salaries;
        }

        /// <summary>
        /// Renvoie la liste de salariés mise en paramètre trier par le niveau de ces derniers
        /// </summary>
        /// <param name="orga"></param>
        /// <returns></returns>
        public static List<Salarie> TrieNiveau(List<Salarie> orga)
        {
            return orga.OrderBy(o => o.niveau).ToList();
        }

        /// <summary>
        /// Permet à l'utilisateur de mofidier dont le numéro ss est mis en paramètre
        /// </summary>
        /// <param name="num_ss"></param>
        /// <exception cref="ApplicationException"></exception>
        public static void Modifier_Salarie(int num_ss)
        {
            string path = "Salarie_Transconnect.csv";
            try
            {
                List<Salarie> salaries = Lire_csv();

                Salarie salarieAModifier = salaries.Find(s => s.Num_ss == num_ss);

                if (salarieAModifier != null)
                {
                    Console.WriteLine("Informations actuelles du salarié :");
                    Console.WriteLine(salarieAModifier.ToString());

                    Console.WriteLine("Saisissez les nouvelles informations :");
                    Console.Write("Voulez-vous modifier le nom (y/n) : ");
                    char a1 = Console.ReadKey().KeyChar;
                    if (a1 == 'y')
                    {
                        Console.Write("\nNouveau nom : ");
                        salarieAModifier.Nom = Console.ReadLine();
                    }
                    Console.Write("\nVoulez-vous modifier le prénom (y/n) : ");
                    char a2 = Console.ReadKey().KeyChar;
                    if (a2 == 'y')
                    {
                        Console.Write("\nNouveau prénom : ");
                        salarieAModifier.Prenom = Console.ReadLine();
                    }
                    Console.Write("\nVoulez-vous modifier l'adresse (y/n) : ");
                    char a3 = Console.ReadKey().KeyChar;
                    if (a3 == 'y')
                    {
                        Console.Write("\nNouvelle adresse : ");
                        Adresse adresse = new Adresse(0, "", "");
                        salarieAModifier.Adresse = adresse.Demander_adresse();
                    }
                    Console.Write("\nVoulez-vous modifier le mail (y/n) : ");
                    char a4 = Console.ReadKey().KeyChar;
                    if (a4 == 'y')
                    {
                        Console.Write("\nNouveau mail : ");
                        salarieAModifier.Mail = Console.ReadLine();
                    }
                    Console.Write("\nVoulez-vous modifier le salaire (y/n) : ");
                    char a5 = Console.ReadKey().KeyChar;
                    if (a5 == 'y')
                    {
                        Console.Write("\nNouveau salaire : ");
                        salarieAModifier.Salaire = int.Parse(Console.ReadLine());
                    }
                    Console.WriteLine("\n");
                    using (StreamWriter writer = new StreamWriter(path))
                    {
                        foreach (Salarie salarie in salaries)
                        {
                            string text = $"{salarie.Num_ss},{salarie.Nom},{salarie.Prenom},{salarie.Date_naissance},{salarie.Adresse.Numero},{salarie.Adresse.Rue},{salarie.Adresse.Ville},{salarie.Mail},{salarie.Telephone},{salarie.niveau},{salarie.entree_societe},{salarie.Poste},{salarie.Salaire}";
                            writer.WriteLine(text);
                        }
                    }

                    Console.WriteLine($"Le salarié avec le numéro de sécurité sociale {num_ss} a été modifié avec succès.");
                }
                else
                {
                    Console.WriteLine($"Aucun salarié trouvé avec le numéro de sécurité sociale {num_ss}.");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erreur dans le programme :", ex);
            }
        }

        /// <summary>
        /// Permet de déterminer le niveau "aba..." du nouveau salarié en fonction de celui de son supérieur "ab..."
        /// </summary>
        /// <param name="salaries"></param>
        /// <param name="nouveau"></param>
        /// <param name="sup"></param>
        /// <returns></returns>
        public static List<Salarie> AjouterNouveauSalarie(List<Salarie> salaries, Salarie nouveau,Salarie sup)
        {
            List<Salarie> memniveau = salaries.FindAll(c => (c.niveau.Length == (sup.niveau.Length +1) && c.niveau.StartsWith(sup.niveau)));
            if(memniveau.Count != 0)
            {
                memniveau.OrderBy(c => c.niveau).ToList();
                Salarie dernier = memniveau.Last();
                char derder = dernier.niveau[dernier.niveau.Length - 1];
                int ascii = (int)derder;
                ascii++;
                derder = (char)ascii;
                nouveau.niveau = dernier.niveau.Substring(0, dernier.niveau.Length - 1) + derder;
                
            }
            else
            {
                nouveau.niveau = sup.niveau + "a";
            }
            salaries.Add(nouveau);
            nouveau.Ecrire_salarie_csv();
            return salaries;
        }

        /// <summary>
        /// Ecris la liste de Salarié passé en paramètre dans le CSV "Salarie_Transconnect"
        /// </summary>
        /// <param name="salaries"></param>
        public static void Updatecsv(List<Salarie> salaries)
        {
            string path = "Salarie_Transconnect.csv";
            File.WriteAllText(path,string.Empty);

            salaries.ForEach(c => c.Ecrire_salarie_csv());
        }

        public string Poste
        {
            get { return poste; }
            set { poste = value; }
        }

        public int Salaire
        {
            get { return salaire; }
            set { salaire = value; }
        }

        public override string ToString()
        {
            return base.ToString() +
                   //$"Niveau: {niveau}\n" +
                   $"Date d'entrée dans la société: {entree_societe}\n" +
                   $"Poste: {poste}\n" +
                   $"Salaire: {salaire}\n";
        }
    }
}
