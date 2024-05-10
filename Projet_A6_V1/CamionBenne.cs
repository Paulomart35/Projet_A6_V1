using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_A6_V1
{
    internal class CamionBenne : PoidsLourd
    {
        public string type_travaux;
        public List<string> equipements;
        public int nb_bennes;
        public bool grue;

        public CamionBenne(double volume, List<string> matiere, string type_travaux, List<string> equipements, int nb_bennes, bool grue)
            : base(volume, matiere)
        {
            this.type_travaux=type_travaux;
            this.equipements=equipements;
            this.nb_bennes=nb_bennes;
            this.grue=grue;
        }

        public CamionBenne() : base() { }

        public CamionBenne demander_attribut()
        {
            Console.Write("Volume en L : ");
            int vol = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nombre de matière : ");
            int long_list = Convert.ToInt32(Console.ReadLine());
            List<string> list = new List<string>();
            string mat = null;
            for (int i = 1; i < long_list+1; i++)
            {
                Console.Write($"Matière {i} : ");
                mat = Console.ReadLine();
                list.Add(mat);
            }
            Console.Write("Type de travaux : ");
            string type = Console.ReadLine();
            Console.Write("Nombre de d'équipements : ");
            int long_list2 = Convert.ToInt32(Console.ReadLine());
            List<string> list2 = new List<string>();
            string mat2 = null;
            for (int i = 1; i < long_list2+1; i++)
            {
                Console.Write($"Equipement {i} : ");
                mat2 = Console.ReadLine();
                list2.Add(mat2);
            }
            Console.Write("Nombre de bennes (max 3) : ");
            int nb_ben = Convert.ToInt32(Console.ReadLine());
            Console.Write("Besoin d'une grue (y/n) : ");
            bool b = false;
            char rep = Console.ReadKey().KeyChar;
            if (rep == 'y')
                b = true;
            return new CamionBenne(vol, list, type, list2, nb_ben, b);
        }

        public string ecriture_attributs()
        {
            string str = Convert.ToString(volume) + ",";
            foreach (string m in this.matiere)
            {
                str += m + "/";
            }
            str += "," + type_travaux + ","; 
            foreach (string e in this.equipements)
            {
                str += e + "/";
            }
            str += "," + Convert.ToString(nb_bennes) + ","; 
            str += Convert.ToString(grue);
            return str;
        }
    }
}
