using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_A6_V1
{
    internal class CamionCiterne : PoidsLourd, IVehicule
    {
        public string type_cuve;

        public CamionCiterne(double volume, List<string> matiere, string type_cuve) : base(volume, matiere)
        {
            this.type_cuve=type_cuve;
        }

        public CamionCiterne() : base() { }

        /// <summary>
        /// Demande à l'utilisateur de saisir les attributs d'un camion citerne et crée un nouvel objet CamionCiterne avec ces attributs.
        /// </summary>
        /// <returns>Un nouvel objet de type CamionCiterne avec les attributs saisis par l'utilisateur.</returns>
        public CamionCiterne demander_attribut()
        {
            Console.Write("Volume en L : ");
            int vol = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nombre de matière : ");
            int long_list = Convert.ToInt32(Console.ReadLine());
            List<string> list = new List<string>(long_list);
            string mat = null;
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write($"Matière {i} : ");
                mat = Console.ReadLine();
                list.Add(mat);
            }
            Console.Write("Type cuve : ");
            string type= Console.ReadLine();
            return new CamionCiterne(vol, list, type);
        }

        /// <summary>
        /// Convertit les attributs de l'objet CamionCiterne en une chaîne de caractères.
        /// </summary>
        /// <returns>Une chaîne de caractères représentant les attributs de l'objet CamionCiterne.</returns>
        public string ecriture_attributs()
        {
            string str = Convert.ToString(volume) + ",";
            foreach (string m in matiere)
            {
                str += m + "/";
            }
            str += "," + type_cuve;
            return str;
        }

    }
}
