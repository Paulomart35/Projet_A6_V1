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

        public static List<Salarie> TrieNiveau(List<Salarie> orga)
        {
            return orga.OrderBy(o => o.niveau).ToList();
        }

        public static void MettreAJourNiveaux(List<Salarie> salaries, Salarie salarieSupprime)
        {
            foreach (var salarie in salaries)
            {
                if (salarie.Poste.StartsWith(salarieSupprime.Poste))
                {
                    // Mettre à jour le niveau du salarié
                    salarie.Poste = salarie.Poste.Remove(0, salarieSupprime.Poste.Length);
                    
                }
            }
        }

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
