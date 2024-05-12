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

        public Livraison() { }

        public override string ToString()
        {
            return this.départ.ToString() + "," + this.arrivee.ToString();
        }

        public double Calcul_prix(string vehicule)
        {
            string path = "Distances.csv";
            double montant_total = 0;
            double tarif_kilometre = 1;
            double tarif_vehicule = 0;
            switch (vehicule)
            {
                case "Voiture":
                    tarif_vehicule = 10;
                    break;
                case "Camionnette":
                    tarif_vehicule = 20;
                    break;
                case "CamionFrigorifique":
                    tarif_vehicule = 30;
                    break;
                case "CamionCiterne":
                    tarif_vehicule = 40;
                    break;
                case "CamionBenne":
                    tarif_vehicule = 50;
                    break;

            }
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
                        montant_total = kilometrage * tarif_kilometre * tarif_vehicule;
                    }
                }
            }
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

            return distances;
        }

        public List<string> Dijkstra2(int[,] graph, int startVertex, int endVertex)
        {
            List<string> liste_ville = Liste_ville();
            var traversedCities = new List<string>();
            int verticesCount = graph.GetLength(0);
            var distances = new int[verticesCount];
            var visited = new bool[verticesCount];
            var previous = new int[verticesCount];
            var path = new List<int>();
            List<string> path_villes = new List<string>();

            for (int i = 0; i < verticesCount; i++)
            {
                distances[i] = int.MaxValue;
                visited[i] = false;
                previous[i] = -1;
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
                        previous[v] = u;
                    }
                }
            }


            // Reconstruire le chemin
            int current = endVertex;
            while (current != -1)
            {
                path.Add(current);
                current = previous[current];
            }
            path.Reverse();

            //Console.WriteLine("Chemin le plus court\nVilles traversées : ");
            int compteur = 0;
            do
            {
                //Console.Write(liste_ville[path[compteur]] + " ");
                path_villes.Add(liste_ville[path[compteur]]);
                compteur++;
            } while (compteur < path.Count);
            //Console.Write("\n");

            return path_villes;

        }

        public List<int> Dijkstra1(int[,] graph, int startVertex, int endVertex)
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

            return path;
           
        }

        /* 
        0 - Paris
        1 - Rouen
        2 - Lyon
        3 - Angers
        4 - La Rochelle
        5 - Bordeaux
        6 - Biarritz
        7 - Toulouse
        8 - Pau
        9 - Nimes
        10 - Montpellier
        11 - Marseilles
        12 - Marseille
        13 - Avignon
        14 - Monaco
        15 - Marseille
        16 - Toulon
         */

        public static List<string> Liste__des_ville()
        {
            return new List<string> { "Paris", "Rouen", "Lyon", "Angers", "La Rochelle", "Bordeaux", "Biarritz", "Toulouse", "Pau", "Nimes", "Montpellier", "Marseilles", "Marseille", "Avignon", "Monaco", "Marseille", "Toulon" };
        }

        public int Convert_toint(string ville)
        {
            int num = 0;
            switch (ville)
            {
                case "Paris":
                    num = 0;
                    break;
                case "Rouen":
                    num = 1;
                    break;
                case "Lyon":
                    num = 2;
                    break;
                case "Angers":
                    num = 3;
                    break;
                case "La Rochelle":
                    num = 4;
                    break;
                case "Bordeaux":
                    num = 5;
                    break;
                case "Biarritz":
                    num = 6;
                    break;
                case "Toulouse":
                    num = 7;
                    break;
                case "Pau":
                    num = 8;
                    break;
                case "Nimes":
                    num = 9;
                    break;
                case "Montpellier":
                    num = 10;
                    break;
                case "Marseilles":
                    num = 11;
                    break;
                case "Marseille":
                    num = 12;
                    break;
                case "Avignon":
                    num = 13;
                    break;
                case "Monaco":
                    num = 14;
                    break;
                case "Toulon":
                    num = 16;
                    break;
                default:
                    Console.WriteLine("City not found");
                    break;
            }
            return num;
        }

        public void Distancepluscourte(string ville_depart, string ville_arrivee)
        {
            
            List<string> liste_ville = Liste_ville();
            int[,] mat = Transformation_matrice();
            int startVertex = Convert_toint(ville_depart);
            int endVertex = Convert_toint(ville_arrivee);
            

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
            List<int> distances = Dijkstra1(mat, startVertex, endVertex);
            List<string> distances2 = Dijkstra2(mat, startVertex, endVertex);

            Console.WriteLine($"La distance la plus courte entre {ville_depart} et {ville_arrivee} est de {distances[endVertex]}km");

        }

        public List<string> Demander_ville_traverse(string ville_depart, string ville_arrivee)
        {
            List<string> liste_ville = Liste_ville();
            int[,] mat = Transformation_matrice();
            int startVertex = Convert_toint(ville_depart);
            int endVertex = Convert_toint(ville_arrivee);


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
            return Dijkstra2(mat, startVertex, endVertex);
        }

        public int Demander_kilometrage(string ville_depart, string ville_arrivee)
        {
            List<string> liste_ville = Liste_ville();
            int[,] mat = Transformation_matrice();
            int startVertex = Convert_toint(ville_depart);
            int endVertex = Convert_toint(ville_arrivee);


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
            List<int> distances = Dijkstra1(mat, startVertex, endVertex);
            return distances[endVertex];

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
