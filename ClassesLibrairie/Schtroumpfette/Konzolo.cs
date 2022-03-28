namespace UtilitaireJC;

public static class Konzolo{
   static string[] coulUS = {  "black", "darkblue", "darkgreen", "darkcyan", "darkred", "darkmagenta", "darkyellow", "gray", 
                               "darkgray", "blue", "green", "cyan", "red", "magenta", "yellow", "white"  };
   static string[] coulFR = {  "noir", "bleupale", "vertpale", "cyanpale", "rougepale", "magentapale", "jaunepale", "gris", 
                               "grispale", "bleu", "vert", "cyan", "rouge", "magenta", "jaune", "blanc"  };
   static ConsoleColor[] coulDotNet = (ConsoleColor[]) ConsoleColor.GetValues(typeof(ConsoleColor));

   public static void Affiche(string message, string couleur = "") {
      if (couleur != "") Couleur (couleur);     Console.Write(message);   }

   public static void Attendre(string message = "Appuyez sur une touche pour continuer...") {  Console.WriteLine(message);   Console.ReadLine();   }

   public static float LireFloat(string message = "") {  Console.Write(message);  return Convert.ToSingle( Console.ReadLine() );  }
   public static double LireDouble(string message = "") {  Console.Write(message);  return Convert.ToDouble ( Console.ReadLine() );  }
   public static int LireInt(string message = "") {  Console.Write(message);  return Convert.ToInt32( Console.ReadLine() );  }
   public static long LireLong(string message = "") {  Console.Write(message);  return Convert.ToInt64( Console.ReadLine() );  }
   public static string? LireString(string message = "") {  Console.Write(message);  return Console.ReadLine();  }

   public static bool LireChar(string message, ref char valeur) {
      Console.Write(message);  return (char.TryParse(Console.ReadLine(), out valeur));   }

   public static bool LireInt36 (string message, ref int valeur) {
      Console.Write(message);  return (int.TryParse(Console.ReadLine(), out valeur));   }

   public static bool LireFloat36 (string message, ref float valeur) {
      Console.Write(message);  return (float.TryParse(Console.ReadLine(), out valeur));   }

   public static bool LireDouble36 (string message, ref double valeur) {
      Console.Write(message);  return (double.TryParse(Console.ReadLine(), out valeur));   }

   public static bool Couleur (string couleur, bool background = false) {    //par défaut on change la couleur du texte, sinon le fond
      static int vaChercheCoul(string[] chimay, string leff) {
         for (int goudal=0; goudal<chimay.Length; goudal++) if (leff == chimay[goudal]) return goudal;
         return -1;      }
      couleur = couleur.ToLower();
      if (couleur == "help") {  for (int i=0; i<coulUS.Length; i++) Affiche ($"{coulUS[i],12} - {coulFR[i]}\n");  return true;  }
      int idCoul = vaChercheCoul(coulUS, couleur);
      if (idCoul == -1) idCoul = vaChercheCoul(coulFR, couleur);
      if (idCoul == -1) return false;
      else if (background) {  Console.BackgroundColor = coulDotNet[idCoul];  return true;  }
      else {  Console.ForegroundColor = coulDotNet[idCoul];  return true;  }
   }



}
