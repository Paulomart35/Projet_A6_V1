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

        #region Constructeur
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
        #endregion
        public override string ToString()
        {
            return this.départ.ToString() + "," + this.arrivee.ToString();
        }

        /// <summary>
        /// Calcul le prix en fonction des différents paramètres.
        /// Initialise des tarifs de prix que nous avons décidé et calcul le montant total
        /// </summary>
        /// <param name="vehicule"></param>
        /// <param name="idchauffeur"></param>
        /// <param name="km"></param>
        /// <returns></returns>
        public double Calcul_prix(string vehicule, int idchauffeur, int km)
        {
            double montant_total = 0;
            double tarif_kilometre = 1;
            double tarif_vehicule = 0;
            switch (vehicule)
            {
                case "Voiture":
                    tarif_vehicule = 100;
                    break;
                case "Camionnette":
                    tarif_vehicule = 200;
                    break;
                case "CamionFrigorifique":
                    tarif_vehicule = 300;
                    break;
                case "CamionCiterne":
                    tarif_vehicule = 400;
                    break;
                case "CamionBenne":
                    tarif_vehicule = 500;
                    break;

            }
            int anciennette_chauffeur = Chauffeur.Lire_anciennete(idchauffeur);
            int cout_anciennete = 0;
            switch(anciennette_chauffeur)
            {
                case 1:
                    cout_anciennete = 20;
                    break;
                case 2:
                    cout_anciennete = 40;
                    break;
                case 3:
                    cout_anciennete = 60;
                    break;
            }
            montant_total = km * tarif_kilometre + tarif_vehicule + cout_anciennete;
            return montant_total;
        }

        /// <summary>
        /// Lis le fichier distance
        /// </summary>
        /// <returns>return une liste de liste comprenant la ville1, la ville2, le km et la durée</returns>
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

        /// <summary>
        /// Créer une liste des villes unique présent dans le csv
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Transforme les données de distance en une matrice représentant les distances entre les villes.
        /// </summary>
        /// <returns>Une matrice d'entiers représentant les distances entre les villes. La valeur à l'indice [i, j] représente la distance entre la ville i et la ville j.</returns>
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

        /// <summary>
        /// Implémente l'algorithme de Dijkstra pour trouver le chemin le plus court entre deux villes dans un graphe pondéré.
        /// </summary>
        /// <param name="graph">La matrice d'adjacence représentant le graphe pondéré. Chaque valeur [i, j] représente la distance entre les villes i et j.</param>
        /// <param name="startVertex">L'indice de la ville de départ dans le graphe.</param>
        /// <param name="endVertex">L'indice de la ville d'arrivée dans le graphe.</param>
        /// <returns>Une liste contenant le chemin le plus court entre la ville de départ et la ville d'arrivée.</returns>
        public List<string> Dijkstra2(int[,] graph, int ville_de_depart, int villearrive)
        {
            // Récupère la liste des villes. Supposons que chaque indice de sommet correspond à une ville dans cette liste.
            List<string> liste_ville = Liste_ville();
            // Liste pour stocker les noms des villes traversées par l'algorithme.
            var traversedCities = new List<string>();
            // Nombre total de sommets dans le graphe (nombre de villes).
            int nbsommet = graph.GetLength(0);
            // Tableau pour stocker les distances minimales depuis ville_de_depart à chaque sommet.
            var distances = new int[nbsommet];
            // Tableau pour marquer les sommets visités.
            var visited = new bool[nbsommet];
            // Tableau pour stocker le sommet précédent sur le chemin optimal pour atteindre chaque sommet.
            var previous = new int[nbsommet];
            // Liste pour stocker le chemin optimal en termes d'indices de sommets.
            var path = new List<int>();
            // Liste pour stocker le chemin optimal en termes de noms de villes.
            List<string> path_villes = new List<string>();

            // Initialisation des distances à l'infini, des sommets comme non visités et des précédents à -1.
            for (int i = 0; i < nbsommet; i++)
            {
                distances[i] = int.MaxValue;  // Distance initiale infinie pour représenter l'inaccessible.
                visited[i] = false;           // Aucun sommet n'est visité au début.
                previous[i] = -1;             // Aucun sommet précédent au début.
            }

            // La distance du sommet de départ à lui-même est de 0.
            distances[ville_de_depart] = 0;

            // Boucle principale de l'algorithme de Dijkstra pour trouver le plus court chemin vers tous les sommets.
            for (int count = 0; count < nbsommet - 1; count++)
            {
                int minDistance = int.MaxValue;  // Distance minimale initialement infinie.
                int minIndex = -1;  // Indice du sommet avec la distance minimale.

                // Boucle pour trouver le sommet avec la distance minimale parmi les sommets non visités.
                // Cette partie de l'algorithme sélectionne le prochain sommet à explorer en Dijkstra.

                for (int v = 0; v < nbsommet; v++) // Parcours de tous les sommets du graphe.
{
                // Si le sommet v n'a pas encore été visité et que la distance actuelle à ce sommet
                // est inférieure ou égale à la distance minimale trouvée jusqu'à présent,
                // alors ce sommet devient le candidat pour le prochain sommet à explorer.
                if (!visited[v] && distances[v] <= minDistance)
    {
                    minDistance = distances[v]; // Met à jour la distance minimale trouvée.
                    minIndex = v; // Met à jour l'indice du sommet avec cette distance minimale.
                }
            }

            int u = minIndex;  // Sommet avec la distance minimale.
                visited[u] = true; // Marquer ce sommet comme visité.
                // Ajouter la ville correspondante au sommet visité à la liste des villes traversées.
                traversedCities.Add(liste_ville[u]);

                // Mettre à jour les distances des sommets adjacents.
                for (int v = 0; v < nbsommet; v++)
                {
                    // Conditions :
                    // 1. Le sommet v n'est pas visité.
                    // 2. Il y a une arête entre u et v (graph[u, v] != 0).
                    // 3. La distance du sommet de départ à u n'est pas infinie.
                    // 4. Le nouveau chemin proposé (distances[u] + graph[u, v]) est plus court que la distance actuelle à v.
                    if (!visited[v] && graph[u, v] != 0 &&
                        distances[u] != int.MaxValue &&
                        distances[u] + graph[u, v] < distances[v])
                    {
                        distances[v] = distances[u] + graph[u, v];  // Mettre à jour la distance.
                        previous[v] = u; // Mettre à jour le sommet précédent pour atteindre v.
                    }
                }
            }


            // Reconstruire le chemin optimal en partant de villearrive et en remontant jusqu'à ville_de_depart.
            int current = villearrive;
            while (current != -1)
            {
                path.Add(current); // Ajouter le sommet actuel au chemin.
                current = previous[current]; // Passer au sommet précédent sur le chemin.
            }
            path.Reverse(); // Inverser le chemin pour qu'il aille de startVertex à villearrive.

            // Convertir le chemin des indices de sommets en noms de villes.
            int compteur = 0;
            do
            {
                path_villes.Add(liste_ville[path[compteur]]); // Ajouter le nom de la ville correspondant à l'indice du sommet.
                compteur++;
            } while (compteur < path.Count);

            // Retourner le chemin sous forme de liste de noms de villes.
            return path_villes;

        }


        /// <summary>
        /// Implémente l'algorithme de Dijkstra pour calculer les distances les plus courtes entre une ville de départ et toutes les autres villes dans un graphe pondéré.
        /// </summary>
        /// <param name="graph">La matrice d'adjacence représentant le graphe pondéré. Chaque valeur [i, j] représente la distance entre les villes i et j.</param>
        /// <param name="startVertex">L'indice de la ville de départ dans le graphe.</param>
        /// <param name="endVertex">L'indice de la ville d'arrivée dans le graphe.</param>
        /// <returns>Une liste contenant les distances les plus courtes entre la ville de départ et toutes les autres villes.</returns>
        public List<int> Dijkstra1(int[,] graph, int ville_de_depart, int villearrive)
        {
            List<string> liste_ville = Liste_ville();
            var traversedCities = new List<string>();
            int nbsommets = graph.GetLength(0);
            var distances = new int[nbsommets];
            var visited = new bool[nbsommets];
            var path = new List<int>();
            

            for (int i = 0; i < nbsommets; i++)
            {
                distances[i] = int.MaxValue;
                visited[i] = false;
            }

            distances[ville_de_depart] = 0;

            for (int count = 0; count < nbsommets - 1; count++)
            {
                int minDistance = int.MaxValue;
                int minIndex = -1;

                for (int v = 0; v < nbsommets; v++)
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

                for (int v = 0; v < nbsommets; v++)
                {
                    if (!visited[v] && graph[u, v] != 0 &&
                        distances[u] != int.MaxValue &&
                        distances[u] + graph[u, v] < distances[v])
                    {
                        distances[v] = distances[u] + graph[u, v];
                    }
                }
            }


            for (int i = 0; i < nbsommets; i++)
            {
                path.Add(distances[i]);
            }

            return path;
           
        }

        /// <summary>
        /// Convertit le nom d'une ville en un entier correspondant à son index dans une liste prédéfinie.
        /// </summary>
        /// <param name="ville">Le nom de la ville à convertir en entier.</param>
        /// <returns>L'index de la ville dans la liste préétablie. Si la ville n'est pas trouvée dans la liste, retourne -1.</returns>
        public static int Convert_toint(string ville)
        {
            List<string> list = new List<string> { "Paris", "Rouen", "Lyon", "Angers", "La Rochelle", "Bordeaux", "Biarritz", "Toulouse", "Pau", "Nimes", "Montpellier", "Marseilles", "Monaco", "Toulon", "Avignon"};
            int index = list.IndexOf(ville);
            if (index == -1)
            {
                Console.WriteLine("City not found");
            }
            return index;
        }

        /// <summary>
        /// Calcule et retourne la liste des villes traversées pour se rendre de la ville de départ à la ville d'arrivée.
        /// </summary>
        /// <param name="ville_depart">Le nom de la ville de départ.</param>
        /// <param name="ville_arrivee">Le nom de la ville d'arrivée.</param>
        /// <returns>Une liste des noms des villes traversées.</returns>
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

        /// <summary>
        /// Calcule et retourne la distance en kilomètres entre la ville de départ et la ville d'arrivée.
        /// </summary>
        /// <param name="ville_depart">Le nom de la ville de départ.</param>
        /// <param name="ville_arrivee">Le nom de la ville d'arrivée.</param>
        /// <returns>La distance en kilomètres entre les deux villes.</returns>
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

        /// <summary>
        /// Appelle les fonctions demander adresse 
        /// </summary>
        /// <returns>Retourne une livraison</returns>
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
