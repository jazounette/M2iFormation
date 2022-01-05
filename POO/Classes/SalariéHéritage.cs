namespace POO.Classes;
using UtilitaireJC;

internal class SalariéHéritage {
   private int matricule = 0;
   private byte categorie = 0;
   private byte service = 0;
   private string? nom = "totoN";
   private string? prenom = "totoP";
   private float salaire = 1F;
   private static float salaireSom = 0;
   private static int compteur;

   public SalariéHéritage() {
      // matricule=0; categorie=0; service=0; nom=""; salaire=-1F;
      // SalaireSom += Salaire;
      Compteur++;
   }

   public SalariéHéritage(int matricule, byte categorie, byte service, string? nom, string? prenom, float salaire) : this ()  {
      Matricule = matricule;
      Categorie = categorie;
      Service = service;
      Nom = nom;
      Prenom = prenom;
      Salaire = salaire;
      SalaireSom += salaire;
   }

   public int Matricule { get => matricule; set => matricule = value; }
   public byte Categorie { get => categorie; set => categorie = value; }
   public byte Service { get => service; set => service = value; }
   public string? Nom { get => nom; set => nom = value; }
   public string? Prenom { get => prenom; set => prenom = value; }
   public float Salaire { get => salaire; set => salaire = value; }
   public static float SalaireSom { get => salaireSom; set => salaireSom = value; }
   public static int Compteur { get => compteur; set => compteur = value; }

   public virtual string AfficherSalaire(){ return $"{Prenom} {Nom} - Salaire: {Salaire:F2}E";  }
   public static void ResetCompteur() { compteur = 0; }

   //// override permet de changer la method par defaut ToString
   public override string ToString() { return $"{matricule}\n{categorie}\n{service}\n{nom}\n{prenom}\n{salaire}\n";  }
}

////////////////////////////////////////////////////////////////////classe commercial
internal class Commerciale : SalariéHéritage {
   private float commission;
   private float chiffreAff;

   public Commerciale(int mat, byte cat, byte ser, string? nom, string? pré, float sal, float commission, float chiffreAff) : base (mat, cat, ser, nom, pré, sal)
   {
      Salaire += chiffreAff * commission / 100F;
      SalaireSom += chiffreAff * commission / 100F;
      Commission = commission;
      ChiffreAff = chiffreAff;
   }

   public override string AfficherSalaire(){ return $"{Prenom} {Nom} - Salaire: {Salaire:F2}E (commission:{Commission:F2}%, chiffre d'affaire:{chiffreAff:F2}E)";  }

   public float Commission { get => commission; set => commission = value; }
   public float ChiffreAff { get => chiffreAff; set => chiffreAff = value; }
}

//////////////////////////////////////////////////////////////////////classe IHM
internal static class IHMsalarié {
   public static int MenuPrincipal() {
      int choix = 0;
      Console.Clear();
      Konzolo.Affiche($"==== Gestion des employés ====\n\n");
      Konzolo.Affiche($"1- Ajouter un employé\n");
      Konzolo.Affiche($"2- Afficher le salaire des employés\n");
      Konzolo.Affiche($"3- Rechercher un employé\n");
      Konzolo.Affiche($"0- Quitter\n\n");
      while (!Konzolo.LireInt36("Entrez votre choix: ", ref choix));
      return choix;
   }

   public static int MenuAjouter() {
      int choix = 0;
      Console.Clear();
      Konzolo.Affiche($"==== Ajouter un employé ====\n\n");
      Konzolo.Affiche($"1- Salarié\n");
      Konzolo.Affiche($"2- Commerciale\n");
      Konzolo.Affiche($"0- Retour\n\n");
      while (!Konzolo.LireInt36("Entrez votre choix: ", ref choix));
      return choix;
   }
}
