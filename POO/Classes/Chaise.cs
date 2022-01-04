namespace POO.Classes;

internal class Chaise {
   private int nbPied;
   private string couleur;
   private string material;

   public Chaise() {
      nbPied = 4;
      couleur = "blanc";
      material = "carton";
   }

   public Chaise(int P, string C, string M) {
      nbPied = P;
      couleur = C;
      material = M;
   }

   public int NbPied { get => nbPied; set => nbPied = value; }
   public string Couleur { get => couleur; set => couleur = value; }
   public string Material { get => material; set => material = value; }

   public override string ToString()
   {
      return $"nombre de pieds: {nbPied}, couleur: {couleur}, matierial:{material}\n";
   }

}