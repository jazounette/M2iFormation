using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpTheGreatTpList.Classes
{
    internal class Tirage
    {
        private List<string> liste;
        private List<string> deja;

        public List<string> Liste { get => liste; }
        public List<string> Deja { get => deja; }

        public Tirage()
        {
            liste = new List<string>() { "Fabien", "Meriem", "Tarik", "Olive", "Patrick", "Jérôme", "Corentin", "Mickaël", "Youness", "Jamila", "Wildrid" };
            deja = new List<string>();
            Init();
        }
        private void Init()
        {

        }

        private void Save()
        {

        }

        public string Pull()
        {
            Random rand = new Random();
            string prenom;
            do
            {
                prenom = liste[rand.Next(liste.Count)];
            } while (deja.Find(x => x == prenom)==prenom);
            
            return prenom;
        }

        public void AddPulled(string prenom)
        {
            deja.Add(prenom);
            Save();

            if (deja.Count == liste.Count)
            {
                deja.Clear();
                Save();
            }
        }
    }
}
