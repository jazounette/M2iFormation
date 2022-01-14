namespace SQL.Classes;
using UtilitaireJC;

internal class Compte {
   private float solde;
   private Client client = new Client(); //si pas de instanciation alors program fonctionne mais warming sur conctructeur
   private Operation[] operation = new Operation[99];
   private int numéro = 1111;         //le numéro du compte
   private static int nombre = 0;     //le nombre de compte
   private int opéNbre =0;            //le nombre d'opération sur le compte

   public Compte(Client client)   {
      numéro += nombre;
      nombre++;
      Client = client;
      solde = 0;
   }

   public float Solde { get => solde; set => solde = value; }
   public int Numéro { get => numéro; set => numéro = value; }
   public static int Nombre { get => nombre; set => nombre = value; }
   internal Client Client { get => client; set => client = value; }
   internal Operation[] Operation { get => operation; set => operation = value; }

   public bool Opération(float argent)  {
      if (Client.Type == 3) {// compte payant, toutes les opérations son payante en fonction de la valeur de taux du compte
         float tuCasque;
         tuCasque = (argent<0) ? argent * -1 : argent;
         tuCasque *= Client.Taux / 100;
         argent -= tuCasque;
         Konzolo.Affiche($"compte PAYANT\n", "rouge");
         Konzolo.Affiche($"taux: {Client.Taux:0.00}%\ncoup de l'opération: {tuCasque:0.00}\nOpération sur le compte: {argent:0.00}\n", "blanc");
      }
      if ((solde + argent) >= 0) {
         DateTime tatadadate = DateTime.Now;
         solde += argent;
         operation[opéNbre] = new Operation(tatadadate, argent);
         operation[opéNbre].Date = tatadadate;
         operation[opéNbre].Montant = argent;
         opéNbre++;
         return true;
      }
      return false;
   }

   public void ListOpé(){
      Konzolo.Couleur("gris");
      for (int i=0; i<opéNbre; i++) {
         Console.WriteLine($"{i+1,3}- {operation[i].Date}.{operation[i].Montant,10:0.00}");
      }
   }



}