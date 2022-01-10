// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;

namespace TpClasseSalarieHeritage.Classes;

internal class IHM
{
    Salarie[] employes;
    int maxEmployes = 20;
    public IHM()
    {
        employes = new Salarie[maxEmployes];
    }

    public void Start()
    {
        string choix = "";
        do
        {
            bool valid = false;
            Console.WriteLine("===== Gestion des employés =====");
            MenuPrincipal();
            Console.Write("Entrez votre choix : ");
            choix = Console.ReadLine();
            while (valid)
            {
                if (choix == "1" && choix == "2" && choix == "3" && choix == "0")
                {
                    valid = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Erreur de saisie, veuillez entrer votre choix.");
                    Console.ForegroundColor = ConsoleColor.White;
                    choix = Console.ReadLine();
                }
            }

            switch (choix)
            {
                case "1":
                    Console.Clear();
                    CreationEmploye();
                    break;
                case "2":
                    Console.Clear();
                    SalaireEmployes();
                    break;
                case "3":
                    Console.Clear();
                    RechercherSalarie();
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
            }

        } while (choix != "0");
    }

    private void MenuPrincipal()
    {
        Console.WriteLine("1-- Ajouter un employé");
        Console.WriteLine("2-- Afficher le salaire des employés");
        Console.WriteLine("3-- Rechercher un employé");
        Console.WriteLine("0-- Quitter");
    }

    private void MenuCreationEmploye()
    {
        Console.WriteLine("=== Ajouter un employé ===");
        Console.WriteLine("1-- Ajouter un Salarié");
        Console.WriteLine("2-- Ajouter un Commercial");
        Console.WriteLine("0-- Retour");
    }

    private void CreationEmploye()
    {
        bool valid = false;
        MenuCreationEmploye();
        Console.Write("Entrez votre choix : ");
        string choix2 = Console.ReadLine();
        while (valid)
        {
            if (choix2 == "1" && choix2 == "2" && choix2 == "0")
            {
                valid = true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erreur de saisie, veuillez entrer votre choix.");
                Console.ForegroundColor = ConsoleColor.White;
                choix2 = Console.ReadLine();
            }
        }
        Salarie s = null;
        switch (choix2)
        {
            case "1":
                s=CreationSalarie();
                break;
            case "2":
                s=CreationCommercial();
                break;
            case "0":
                break;
        }
        if ( s != null)
        {
            for (int i = 0; i < employes.Length; i++)
            {
                if (employes[i]==null)
                {
                    employes[i] = s;
                    break;
                }
            }
        }
        Console.Clear();
    }

    private Salarie CreationSalarie()
    {
        Console.Write("Merci de saisir le nom : ");
        string nom = Console.ReadLine();
        Console.Write("Merci de saisir le matricule : ");
        string matricule = Console.ReadLine();
        Console.Write("Merci de saisir le categorie : ");
        string categorie = Console.ReadLine();
        Console.Write("Merci de saisir le service : ");
        string service = Console.ReadLine();

///////////////////////////////////////////////////////////////////ajout d'un try\catch pour exercise sur le cours des try\catch
        double salaire = 0;
        bool sortir = false;
        while (!sortir) {
            try {
                Console.Write("Merci de saisir le salaire : ");
                salaire = Convert.ToDouble(Console.ReadLine());
                sortir = true;
            }
            catch(Exception e) {
                // Console.WriteLine(e);
                Console.WriteLine("ceci n'est pas un salaire (sans ironie aucune).");
            }
            finally { Console.WriteLine("tout marche bien navette"); Console.ReadLine();}
        }
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        return new Salarie(matricule, categorie, service, nom, salaire);
    }

    private Commercial CreationCommercial()
    {
        Salarie tmp = CreationSalarie();
        Console.Write("Merci de saisir le chiffre d'affaire : ");
        double chiffreAffaire = Convert.ToDouble(Console.ReadLine());
        Console.Write("Merci de saisir le taux de commission : ");
        double commission = Convert.ToDouble(Console.ReadLine());
        return new Commercial(tmp.Matricule,tmp.Categorie,tmp.Service, tmp.Nom,tmp.Salaire,chiffreAffaire, commission); ;
    }

    private void SalaireEmployes()
    {
        Console.WriteLine("=== Salaire des employés ===");
        for (int i = 0; i < employes.Length; i++)
        {
            if (employes[i]!=null)
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine(employes[i].GetType());
                Console.WriteLine(employes[i]);

                if (employes[i] is Commercial c)
                {
                    c.AfficherCommercial();
                }

                employes[i].CalculerSalaire();

                Console.WriteLine("-----------------------");
            }
            else
                break;
        }
    }

    private void RechercherSalarie()
    {
        Console.WriteLine("=== Rechercher un employé par nom ===");
        Console.Write("Veuillez saisir les nom : ");
        string nom = Console.ReadLine();
        Salarie s = null;
        for (int i = 0; i < employes.Length; i++)
        {
            if (employes[i] == null)
            {
                break;
            }
            else if (employes[i].Nom == nom)
            {
                s = employes[i];
                break;
            }                
        }

        if (s != null)
        {
            s.CalculerSalaire();
        }
        else
        {
            Console.WriteLine("Aucun employés avec ce nom.");
        }

    }
}
