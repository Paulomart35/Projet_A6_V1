using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_A6_V1
{
    internal class CamionFrigorifique : PoidsLourd, IVehicule
    {
        public int nb_grp_electrogene;

        public CamionFrigorifique(double volume, List<string> matiere, int nb_grp_electrogene) : base(volume, matiere)
        {
            this.nb_grp_electrogene=nb_grp_electrogene;
        }

        public CamionFrigorifique() : base() { }

        public CamionFrigorifique demander_attribut()
        {
            Console.Write("Volume en L : ");
            double vol = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nombre de matière : ");
            int long_list = Convert.ToInt32(Console.ReadLine());
            List<string> list = new List<string>(long_list);
            string mat = null;
            for(int i  = 0; i < list.Count; i++)
            {
                Console.Write($"Matière {i} : ");
                mat = Console.ReadLine();
                list.Add(mat);
            }
            Console.Write("Nombre de groupe électrogènes : ");
            int nb = Convert.ToInt32(Console.ReadLine());
            return new CamionFrigorifique(vol, list, nb);
        }

        public string ecriture_attributs()
        {
            string str = Convert.ToString(volume) + ","; 
            foreach(string m in matiere)
            {
                str += m + "/";
            }
            str += "," + Convert.ToString(nb_grp_electrogene);
            return str;

        }
    }
}
