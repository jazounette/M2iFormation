namespace POO.Classes;

internal class Personne {
   private string titre = "-"; // monsieur, madamme.
   private string nom = "-";
   private string prenom = "-";
   private int age = -1;
   private string courriel = "-";
   private string telephone = "-";

   public Personne() {   }

   public Personne(string nom, string prenom)   {
      this.nom = nom;
      this.prenom = prenom;
   }

   public Personne(string titre, string nom, string prenom, int age, string courriel)   {
      this.titre = titre;
      this.nom = nom;
      this.prenom = prenom;
      this.age = age;
      this.courriel = courriel;
   }

   public override string ToString()   {
      return $"titre:{titre}\nnom:{nom}\nprenom:{prenom}\nage:{age}\ncourriel:{courriel}\ntéléphone:{telephone}\n";
   }
}