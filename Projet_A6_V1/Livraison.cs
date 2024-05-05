using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Projet_A6_V1
{
    internal class Livraison
    {
        public Adresse départ;
        public Adresse arrivee;
        public int kilometrage;
        public string duree;

        public Livraison(Adresse départ, Adresse arrivee, int kilometrage, string duree)
        {
            this.départ=départ;
            this.arrivee=arrivee;
            this.kilometrage=kilometrage;
            this.duree=duree;
        }

        public Livraison(Adresse départ, Adresse arrivee)
        {
            this.départ=départ;
            this.arrivee=arrivee;
            this.kilometrage=0;
            this.duree=null;
        }

        public override string ToString()
        {
            return this.départ.ToString() + "," + this.arrivee.ToString();
        }

        public double Calcul_prix()
        {
            string path = "Distances.csv";
            double montant_total = 0;
            double tarif_kilometre = 10; //à définir ??
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split(';');
                    Adresse adresse_départ = new Adresse(0, null, null);
                    adresse_départ.Ville = values[0];
                    Adresse adresse_arrivee = new Adresse(0, null, null);
                    adresse_arrivee.Ville = values[1];
                    int kilometrage = int.Parse(values[2]);
                    string duree = values[3];

                    if (adresse_départ.Ville == this.départ.Ville && adresse_arrivee.Ville == this.arrivee.Ville || adresse_arrivee.Ville == this.départ.Ville && adresse_départ.Ville == this.arrivee.Ville)
                    {
                        montant_total = kilometrage * tarif_kilometre;
                    }
                }
            }
            //ajouté au calcul véhicule loué
            return montant_total;
        }

        public List<List<string>> Fichier_distance()
        {
            List<List<string>> distances = new List<List<string>>();
            string path = "Distances.csv";
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split(';');
                    List<string> distance = new List<string>(values);
                    distances.Add(distance);
                }
            }

            return distances;
        }

        public List<string> Liste_ville()
        {
            List<List<string>> list = Fichier_distance();
            for (int i = 0; i < list.Count; i++)
            {
                list[i].RemoveAt(list[i].Count - 1);
            }
            List<string> villes = new List<string>();
            foreach (var ligne in list)
            {
                if (!villes.Contains(ligne[0]))
                {
                    villes.Add(ligne[0]);
                }
                if (!villes.Contains(ligne[1]))
                {
                    villes.Add(ligne[1]);
                }
            }
            return villes;
        }

        public int[,] Transformation_matrice()
        {
            List<List<string>> list = Fichier_distance();
            for (int i = 0; i < list.Count; i++)
            {
                list[i].RemoveAt(list[i].Count - 1);
            }
            List<string> villes = Liste_ville();
            int n = villes.Count;
            int[,] distances = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    distances[i, j] = 0;
                }
            }

            foreach (var ligne in list)
            {
                int depart = villes.IndexOf(ligne[0]);
                int arrivee = villes.IndexOf(ligne[1]);
                int distance = int.Parse(ligne[2]);
                distances[depart, arrivee] = distance;
                distances[arrivee, depart] = distance;
            }

            // Afficher la matrice de distances
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(distances[i, j] + " ");
                }
                Console.WriteLine();
            }

            return distances;
        }

        public List<int> Dijkstra(int[,] graph, int startVertex, int endVertex)
        {
            List<string> liste_ville = Liste_ville();
            var traversedCities = new List<string>();
            int verticesCount = graph.GetLength(0);
            var distances = new int[verticesCount];
            var visited = new bool[verticesCount];
            var path = new List<int>();
            

            for (int i = 0; i < verticesCount; i++)
            {
                distances[i] = int.MaxValue;
                visited[i] = false;
            }

            distances[startVertex] = 0;

            for (int count = 0; count < verticesCount - 1; count++)
            {
                int minDistance = int.MaxValue;
                int minIndex = -1;

                for (int v = 0; v < verticesCount; v++)
                {
                    if (!visited[v] && distances[v] <= minDistance)
                    {
                        minDistance = distances[v];
                        minIndex = v;
                    }
                }

                int u = minIndex;
                visited[u] = true;
                traversedCities.Add(liste_ville[u]);

                for (int v = 0; v < verticesCount; v++)
                {
                    if (!visited[v] && graph[u, v] != 0 &&
                        distances[u] != int.MaxValue &&
                        distances[u] + graph[u, v] < distances[v])
                    {
                        distances[v] = distances[u] + graph[u, v];
                    }
                }
            }

            for (int i = 0; i < verticesCount; i++)
            {
                path.Add(distances[i]);
            }

            Console.WriteLine("Villes traversées : ");
            int compteur = 0;
            do
            {
                Console.WriteLine(traversedCities[compteur]);
                compteur++;
            } while (traversedCities[compteur] != liste_ville[endVertex]);
            Console.WriteLine(liste_ville[endVertex]); 

            return path;
        }


        public void Distancepluscourte()
        {
            List<string> liste_ville = Liste_ville();
            int[,] mat = Transformation_matrice();
            int startVertex = 0; //ville départ
            int endVertex = 0; //ville arrivée

            Console.Write("Ville départ : ");
            string ville_depart = Console.ReadLine();
            Console.Write("Ville arrivée : ");
            string ville_arrivee = Console.ReadLine();

            for (int i = 0; i < liste_ville.Count; i++)
            {
                if (ville_depart == liste_ville[i])
                    startVertex = i;

            }
            for (int j = 0; j < liste_ville.Count; j++)
            {
                if (ville_arrivee == liste_ville[j])
                    endVertex = j;

            }
            List<int> distances = Dijkstra(mat, startVertex, endVertex);
            Console.WriteLine($"La distance la plus courte entre {ville_depart} et {ville_arrivee} est de {distances[endVertex]}km");
        }


        public Livraison Demander_Livraison()
        {
            Adresse départ = new Adresse(0, "", "");
            départ = départ.Demander_adresse();
            Adresse arrivee = new Adresse(0, "", "");
            arrivee = arrivee.Demander_adresse();
            return new Livraison(départ, arrivee);
        }

    }

}
