using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_A6_V1
{
    internal class CamionCiterne : PoidsLourd
    {
        public string type_cuve;

        public CamionCiterne(double volume, List<string> matiere, string type_cuve) : base(volume, matiere)
        {
            this.type_cuve=type_cuve;
        }

        public CamionCiterne() : base() { }

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
