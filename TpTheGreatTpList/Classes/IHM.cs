using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpTheGreatTpList.Classes
{
    internal class IHM
    {
        Tirage tirage;

        public IHM()
        {
            tirage = new Tirage();
        }

        public void Start()
        {
            bool confirm = false;
            do
            {
                Console.Clear();
                MainMenu();
                string choix = Choice();
                switch (choix)
                {
                    case "1":
                        Console.Clear();
                        Tirer();
                        break;
                    case "2":
                        Console.Clear();
                        PulledList();
                        break;
                    case "3":
                        Console.Clear();
                        PullList();
                        break;
                    case "0":
                        confirm = true;
                        break;
                    default:
                        Console.WriteLine("Erreur de saisie, verifiez votre choix.");
                        break;

                }
            } while (!confirm);
        }

        public void MainMenu()
        {
            Console.WriteLine("------------------- Grande Ordinatrice -------------------\n");
            Console.WriteLine("\t1-- Effectuer un tirage");
            Console.WriteLine("\t2-- Afficher la liste des personnes déjà tirées");
            Console.WriteLine("\t3-- Affiche la liste des personnes restantes");
            Console.WriteLine("\t0-- Quitter\n");

        }
        public string Choice()
        {
            Console.Write("Veuillez faire votr choix : ");
            return Console.ReadLine();
        }

        public void Tirer()
        {
            string prenom;
            string confirm;

            do
            {
                prenom = tirage.Pull();
                PullDisplay(prenom);

                Console.WriteLine("\n\tEnregistrer ce choix ? Oui / Non : ");

                confirm = Console.ReadLine().ToLower();
            } while (confirm != "oui");

            tirage.AddPulled(prenom);
            Console.ForegroundColor = ConsoleColor.Green;           
            Console.WriteLine($"\n\tLe tirage a été sauvegardé...\n");           
            Console.ForegroundColor = ConsoleColor.White;

            // On laisse le temps de lire à l'utilisateur qui appuiera sur ENTER pour continuer
            Console.WriteLine("Appuyez sur ENTER pour retourner au menu principal...");
            Console.ReadLine();
            Console.Clear();

        }

        public void PulledList()
        {
            string chaine = "";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("------------------ Afficher la liste des personnes déjà tirées ------------------\n");
            Console.ForegroundColor = ConsoleColor.White;

            // Boucle itération pour l'affichage des personnes déja tirées
            foreach (string s in tirage.Deja)
            {
                Console.WriteLine(chaine+s);
                chaine += "   ";
            }

            // On laisse le temps de lire à l'utilisateur qui appuiera sur ENTER pour continuer
            Console.WriteLine("\nAppuyez sur ENTER pour retourner au menu principal...");
            Console.ReadLine();
            Console.Clear();
        }

        public void PullList()
        {
            string chaine = "";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("------------------ Afficher la liste des personnes à venir ------------------\n");
            Console.ForegroundColor = ConsoleColor.White;

            // Boucle itération pour l'affichage des personnes déja tirées
            foreach (string s in tirage.Liste)
            {
                if (!tirage.Deja.Contains(s))
                {
                    Console.WriteLine(chaine + s);
                    chaine += "   ";
                }
            }

            // On laisse le temp de lire à l'utilisateur qui appuiera sur ENTER pour continuer
            Console.WriteLine("\nAppuyez sur ENTER pour retourner au menu principal...");
            Console.ReadLine();
            Console.Clear();
        }

        public void PullDisplay(string Prenom)
        {
            string chaine = "";
            foreach (char c in Prenom)
                chaine += "!";
            Console.WriteLine("------------------ Effectuer un tirage ------------------");
            Console.WriteLine(" Oh grande Ordinatrice...\n\t\tQui va venir corriger au tableau ? \n");
            Console.WriteLine(" Appuyez sur ENTER pour effectuer le tirage... \n");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  Le/La chanceuse est {Prenom}");
            Console.WriteLine("\n\t!!!!!!!!!!!!!!!!!!"+chaine);
            Console.WriteLine($"\t! ! ! BRAVO {Prenom.ToUpper()} ! ! !");
            Console.WriteLine("\t!!!!!!!!!!!!!!!!!!"+chaine);
            Console.ForegroundColor = ConsoleColor.White;

        }
    }
}
