namespace asp.Models
{
   public class  Identifiant
    {
      private string courriel;
      private string motdepasse;
      public static int combien = 0;
      public static List<Identifiant> guendoline = new List<Identifiant>();

      public Identifiant(string Courriel, string Motdepasse)
      {
         courriel = Courriel;
         motdepasse = Motdepasse;
      }

      public string Courriel { get => courriel; set => courriel = value; }
      public string Motdepasse { get => motdepasse; set => motdepasse = value; }
   }
}
