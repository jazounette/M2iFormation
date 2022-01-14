namespace SQL.Classes;

internal class Operation {
   private DateTime date;
   private float montant;

   public Operation() {   }//hévite le warning dans la classe banquecompte

   public Operation(DateTime date, float montant)   {
      Date = date;
      Montant = montant;
   }

   public DateTime Date { get => date; set => date = value; }
   public float Montant { get => montant; set => montant = value; }
}