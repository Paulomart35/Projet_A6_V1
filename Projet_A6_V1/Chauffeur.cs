﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_A6_V1
{
    internal class Chauffeur : Salarie
    {
        protected int idchauffeur;
        protected bool dispo;
        protected int niveau_anciennete; 

        public Chauffeur(int num_ss, string nom, string prenom, DateTime date_naissance, Adresse adresse, string mail, string telephone,
             string niveau, DateTime entree_societe, string poste, int salaire, int idchauffeur, bool dispo, int niveau_anciennete)
            : base(num_ss, nom, prenom, date_naissance, adresse, mail, telephone, niveau, entree_societe, poste, salaire)
        {
            this.idchauffeur = idchauffeur;
            this.dispo = dispo;
            this.niveau_anciennete=niveau_anciennete;
        }

        public Chauffeur(int num_ss, string nom, string poste, int idchauffeur, bool dispo, int niveau_anciennete) : base(num_ss, nom, poste)
        {
            this.idchauffeur = idchauffeur;
            this.dispo = dispo;
            this.niveau_anciennete=niveau_anciennete;
        }

        public Chauffeur() : base() { }

        public void plan_route(int idchauffeur)
        {
            string path = "Commande_Transconnect.csv";
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] values = line.Split(',');
                        int chauffeur = int.Parse(values[9]);
                        Console.WriteLine("idchauffeur " + chauffeur);
                        List<string> ville_traverse = new List<string>();
                        string[] vt = values[11].Split('/');
                        foreach (string v in vt)
                        {
                            ville_traverse.Add(v);
                            Console.WriteLine(v +", ");
                        }
                        DateTime data = DateTime.Parse(values[12]);
                        Console.WriteLine(data);
                        string vehicule = values[13];
                        Console.WriteLine("Vehicule " + vehicule);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erreur dans le programme :", ex);
            }


        }

        public int lire_idchauffeur()
        {
            List<int> list_id = new List<int>();
            try
            {
                using (StreamReader reader = new StreamReader("Chauffeur_Transconnect.csv"))
                {
                    string line;
                    int idchauffeur = 0;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] values = line.Split(',');

                        idchauffeur = int.Parse(values[3]);
                        list_id.Add(idchauffeur);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erreur dans le programme :", ex);
            }
            return list_id.Last();
        }

        public List<int> lire_num_ss()
        {
            List<int> list_num_ss = new List<int>();
            try
            {
                using (StreamReader reader = new StreamReader("Chauffeur_Transconnect.csv"))
                {
                    string line;
                    int num_ss = 0;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] values = line.Split(',');
                        num_ss = int.Parse(values[0]);
                        list_num_ss.Add(num_ss);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erreur dans le programme :", ex);
            }
            return list_num_ss;
        }

        public void Ajout()
        {
            string path = "Salarie_Transconnect.csv";
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] values = line.Split(',');
                        poste = values[11];
                        if (poste == "chauffeur")
                        {
                            num_ss = int.Parse(values[0]);
                            nom = values[1];
                            niveau_anciennete = 0;
                            DateTime entree_societe = DateTime.Parse(values[10]);
                            int anc = DateTime.Now.Year - entree_societe.Year;
                            if (anc < 5)
                            {
                                niveau_anciennete = 1;
                            }
                            else if (anc >= 5 && anc < 10)
                            {
                                niveau_anciennete = 2;
                            }
                            else
                            {
                                niveau_anciennete = 3;
                            }
                            Chauffeur chauff = new Chauffeur(num_ss, nom, poste, lire_idchauffeur() + 1, true, niveau_anciennete);
                            List<int> list = lire_num_ss(); 
                            if (!list.Contains(num_ss))
                            {
                                chauff.Ecrire_chauffeur_excel();
                            }
                                
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erreur dans le programme :", ex);
            }
        }

        public void Ecrire_chauffeur_excel()
        {
            string path2 = "Chauffeur_Transconnect.csv";
            try
            {
                string text = (num_ss + "," + nom + "," + poste + "," + idchauffeur + "," + dispo + "," + niveau_anciennete);
                using (StreamWriter writer = new StreamWriter(path2, true))
                {
                    writer.WriteLine(text);
                }
                Console.WriteLine($"Le chauffeur avec le numéro d'identité {idchauffeur} a été ajouté avec succès.");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erreur dans le programme :", ex);
            }

        }


    }
}
