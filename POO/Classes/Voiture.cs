namespace POO.Classes;

internal class Voiture {

   ///////////////////// les attributs (toujour en privé)
   private string model = "";
   private string couleur = "";
   private int reservoir;
   private int autonomie;
   private bool demaree;

   public Voiture() {
      //constructeur vide
      //le compilateur chosi le bon constructeur en fonction des paramétres qui lui sont passé.
      demaree = false;
   }

   //deuxieme constructeur, si on passe des paramètres lorsque l'on instancie
   //on peux générer automatiquement le constructeur en cliquant sur l'ampoule
   public Voiture(string model, string couleur, int reservoir, int autonomie) : base()  //avec base(), on hérite du constructeur vide
   {
      Model = model;
      Couleur = couleur;
      Reservoir = reservoir;
      Autonomie = autonomie;
   }

   /////////propriétés
   public string Model { get => model; set => model = value; }
   public string Couleur { get => couleur; set => couleur = value; }
   public int Reservoir { get => reservoir; set => reservoir = value; }
   public int Autonomie { get => autonomie; set => autonomie = value; }
   public bool Demaree { get => demaree; }

   public void Demarrer () {
      if (!demaree) {  demaree = true; Console.WriteLine("La voiture démarre");  } else Console.WriteLine("La voiture est déjà en marche");
   }
   public void Arreter () {
      if (demaree) {  demaree = false; Console.WriteLine("Le moteur s'arrête");  } else Console.WriteLine("La voiture est déjà arrêter");
   }
   public void Klaxxon (string toto){
      Console.Beep();
      Console.WriteLine(toto);
   }
}