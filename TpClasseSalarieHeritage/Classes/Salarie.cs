// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;

namespace TpClasseSalarieHeritage.Classes;

    internal class Salarie
    {
        string matricule;
        string categorie;
        string service;
        string nom;
        double salaire;
        private static int compteur = 0;

        public Salarie()
        {
            compteur++;
        }
        public Salarie(string matricule, string categorie, string service, string nom, double salaire):this()
        {
            Matricule=matricule;
            Categorie=categorie;
            Service=service;
            Nom=nom;
            Salaire=salaire;
        }

        public string Matricule { get => matricule; set => matricule=value; }
        public string Categorie { get => categorie; set => categorie=value; }
        public string Service { get => service; set => service=value; }
        public string Nom { get => nom; set => nom=value; }
        public double Salaire { get => salaire; set => salaire=value; }
        //public static int Compteur { get => compteur; }

       
        public static void ModifierCompteur(int value)
        {
            compteur = value;
        }

        public virtual void CalculerSalaire()
        {
            Console.WriteLine($"Le salaire fixe de {Nom} est de {Salaire} euros");
        }

        public static void AfficherCompteur()
        {
            Console.WriteLine($"Le compteur d'instance affiche : {compteur}");
        }

        public void Afficher()
        {
            Console.WriteLine($"Le salaire fixe de {Nom} est de {Salaire} Euros");
        }

        public override string ToString()
        {
            return $"Le suis salarié";
        }
    }
