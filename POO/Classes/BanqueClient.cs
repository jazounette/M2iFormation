namespace POO.Classes;

internal class Client {
   private string? nom = "";
   private string? prénom = "";
   private string? tel = "";

   public Client() {     }// obligatoire sinon warning dans banquecompte.cs

   public Client(string? nom, string? prénom, string? tel)   {
      Nom = nom;
      Prénom = prénom;
      Tel = tel;
   }

   public string? Nom { get => nom; set => nom = value; }
   public string? Prénom { get => prénom; set => prénom = value; }
   public string? Tel { get => tel; set => tel = value; }
}