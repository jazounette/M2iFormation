namespace POO.Classes;

internal static class LePendu {
   private static byte nbEssai;
   private static string masque = "";
   private static string motATrouve = "";
   private static string[] mot = {"savonette", "kangourou", "crocodile", "anticonstitutionnellement", "anthonydipersio", "trompette", "porteavion", "camenbert", "superman", "spiderman", "vilebrequin", "bruxelles", "correspondence", "colique", "informatique", "laquais", "dictionnaire", "vignoble", "pakistan", "braquage"};
   private static char[] lettre = new char[26];
   private static byte lettreID = 0;
   private static Random hazard = new Random();
   private static int xMax = Console.WindowWidth;
   private static int yMax = Console.WindowHeight;
   // les constructeurs c'est pour les faibles, no need here.
   // public LePendu(byte nbEssai, string masque, string motATrouve)   {  NbEssai = nbEssai;  Masque = masque; MotATrouve = motATrouve;  }

   public static byte NbEssai { get => nbEssai; set => nbEssai = value; }
   public static string Masque { get => masque; set => masque = value; }
   public static string MotATrouve { get => motATrouve; set => motATrouve = value; }
   public static char[] Lettre { get => lettre; }
   public static byte LettreID { get => lettreID; }
   
   public static void MotGenerator()  {  MotATrouve = mot[hazard.Next(0, mot.Length)];  }

   public static bool TestWin()  {  return (masque == motATrouve);  }

   public static bool TestChar(char momot, ref int combien) {
      combien = 0;
      bool vraifaux = false;
      for (int i=0; i<motATrouve.Length; i++) {  if (momot == motATrouve[i]) {  vraifaux = true; combien++; }  }
      return vraifaux;
   }

   public static bool CharStack(char prout) {
      bool jaiTrouvéChef = false;
      int lettreIDmax = lettre.Length;
      for (int i=0; i<lettreIDmax; i++)  if (prout == lettre[i]) {  jaiTrouvéChef = true;  }
      if (!jaiTrouvéChef) {  lettre[lettreID] = prout; lettreID++;  }
      return jaiTrouvéChef;
   }

   public static void GenererMasque()  {
      string retournage = "";
      bool jaiTrouvéChef;
      for(int i=0; i<motATrouve.Length; i++) {
         jaiTrouvéChef = false;
         for(int j=0; j<lettreID; j++) {
            if (motATrouve[i] == lettre[j]) { retournage += motATrouve[i]; jaiTrouvéChef = true; break; }
         }
         if (!jaiTrouvéChef) retournage += "*";
      }
      masque = retournage;
   }

   public static void DessineMoiUnPendu(){
      int nbPart = 10;
      (int xSavePos, int ySavePos) = Console.GetCursorPosition();

      void printXY (int x, int y, string message) {    Console.SetCursorPosition(x, y);   Console.Write(message);      }
      void ligneVert (int x, int y, int yNbr, string message) {  for(int iy = 0; iy<yNbr; iy++) printXY(x, y+iy, message);   }
      void ligneDiag (int x, int y, int Nbr, string message) {
         int pente = (Nbr<0) ? -1 : 1;    for(int i = 0; i<(Nbr*pente); i++) printXY(x+i, y+i*pente, message);     }

      printXY(xMax/2-15, yMax, "XXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
      ligneVert(xMax/2-10, yMax-20, 20, "X");
      printXY(xMax/2-10, yMax-20, "XXXXXXXXXXXXXXXX");
      ligneDiag(xMax/2-9, yMax-15, -5, "X");
      if (nbEssai <= (nbPart-1))  ligneVert(xMax/2+4, yMax-19, 3, "X");    // la corde
      if (nbEssai <= (nbPart-2))  {  printXY(xMax/2+3, yMax-17, "XXX");   printXY(xMax/2+3, yMax-16, "XXX");  } // la tête
      if (nbEssai <= (nbPart-3))  ligneVert(xMax/2+4, yMax-15, 8, "X");    // le corp
      if (nbEssai <= (nbPart-4))  ligneDiag(xMax/2-1, yMax-4, -5, "X");    // jambe 1
      if (nbEssai <= (nbPart-5))  ligneDiag(xMax/2+5, yMax-8, +5, "X");    // jambe 2
      if (nbEssai <= (nbPart-6))  ligneDiag(xMax/2-1, yMax-10, -5, "X");   // bras 1
      if (nbEssai <= (nbPart-7))  ligneDiag(xMax/2+5, yMax-14, +5, "X");   // bras 2
      if (nbEssai == (nbPart-8))  printXY(xMax/2+8, yMax-17, "Outch! ça fait mal!");
      if (nbEssai == (nbPart-9))  printXY(xMax/2+8, yMax-17, "J'veux pas mourir, bhouhouhou 8.(");
      if (nbEssai == (nbPart-10))  printXY(xMax/2+8, yMax-17, "HAAAAAAaaaaaaa..... (j'chui mourru)");
      Console.SetCursorPosition(xSavePos, ySavePos);
   }



}