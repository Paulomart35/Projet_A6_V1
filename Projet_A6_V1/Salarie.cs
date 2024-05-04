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


    }
}
