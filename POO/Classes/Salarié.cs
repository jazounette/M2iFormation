namespace POO.Classes;

internal class Salarie {
   private int matricule = 0;
   private byte categorie = 0;
   private byte service = 0;
   private string nom = "totoN";
   private string prenom = "totoP";
   private float salaire = 1F;
   private static float salaireSom = 0;
   private static int compteur;

   public Salarie() {
      // matricule=0; categorie=0; service=0; nom=""; salaire=-1F;
      // SalaireSom += Salaire;
      Compteur++;
   }

   public Salarie(int matricule, byte categorie, byte service, string nom, string prenom, float salaire) : this ()  {
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
   public string Nom { get => nom; set => nom = value; }
   public string Prenom { get => prenom; set => prenom = value; }
   public float Salaire { get => salaire; set => salaire = value; }
   public static float SalaireSom { get => salaireSom; set => salaireSom = value; }
   public static int Compteur { get => compteur; set => compteur = value; }

   public string AfficherSalaire(string prepos){ return $"Le salaire {prepos} {prenom} {nom} est de {salaire}";  }
   public static void ResetCompteur() { compteur = 0; }

   //// override permet de changer la method par defaut ToString
   public override string ToString() { return $"{matricule}\n{categorie}\n{service}\n{nom}\n{prenom}\n{salaire}\n";  }

}


