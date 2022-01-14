namespace SQL.Classes;

internal class Client {
   private string? nom = "";
   private string? prénom = "";
   private string? tel = "";
   private sbyte type = -1;     //compte gratuit(1), épargne(2) ou payant(3)
   private float taux = 1;


   public Client() {     }// obligatoire sinon warning dans banquecompte.cs

   public Client(string? nom, string? prénom, string? tel, sbyte type, float taux)   {
      Nom = nom;
      Prénom = prénom;
      Tel = tel;
      Type = type;
      Taux = taux;
   }

   public string? Nom { get => nom; set => nom = value; }
   public string? Prénom { get => prénom; set => prénom = value; }
   public string? Tel { get => tel; set => tel = value; }
   public sbyte Type { get => type; set => type = value; }
   public float Taux { get => taux; set => taux = value; }
}