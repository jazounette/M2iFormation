// See https://aka.ms/new-console-template for more information
using UtilitaireJC;

Konzolo.Affiche($"tout marche bien navette\n");

ConsoleKey prout;
Random hazard = new Random();
bool triche = true;
int curseurX=0, curseurY=0;
byte noirNbre=0, blanNbre=0;
sbyte coulChoix=0;
string[] coulPion = {"jaune", "bleu", "rouge", "vert", "cyan", "magenta"};
sbyte[,] plateau = new sbyte[12,4];
sbyte[] secret = new sbyte[4] ;
for(int i=0; i<4; i++) {  secret[i] = (sbyte)hazard.Next(0,6);    for (int j=0; j<12; j++)  plateau[j,i] = -1;    }

Console.SetWindowSize(88, 33);
Konzolo.Couleur("magentapale", true);//couleur du fond
Konzolo.Couleur("blanc");//couleur du texte
Console.Clear();

Affiche.Grille();

Affiche.Curseur (curseurX, curseurY, "chevron");
Affiche.ResetConsCur();

while (true) {
   if (Console.KeyAvailable) {
      prout = Console.ReadKey().Key;

      if (prout == ConsoleKey.Escape) { break;  }
      if (prout == ConsoleKey.Spacebar) {
         for(int i=0; i<4; i++) Affiche.Pion(i, 12, (triche) ? coulPion[secret[i]] : Affiche.sauveCoulFond.ToString());
         triche = (triche) ? false : true;      }
      if (prout == ConsoleKey.Enter) {

         VérifCodeSicréte(secret, plateau, curseurY, ref noirNbre, ref blanNbre);

         // Affiche.PionFin(curseurX, curseurY, "noir");
         for (int i=0; i<noirNbre; i++) Affiche.PionFin(i,curseurY, "noir");
         for (int i=noirNbre; i<noirNbre+blanNbre; i++) Affiche.PionFin(i, curseurY, "blanc");

         if (noirNbre == 4  || curseurY >= 11) {
            string hermionegranger = (noirNbre == 4) ? "TU AS VINGTCUL LE MASTER MIND" : "LE MASTER MIND TA VINGTCUL";
            string harrypotter = " ";
            for (int i=0; i<((Affiche.xMax - hermionegranger.Length) / 2); i++) harrypotter += " ";
            hermionegranger = harrypotter + hermionegranger + harrypotter;
            Konzolo.Couleur("blanc", true);
            Console.SetCursorPosition(0, 0);
            Konzolo.Affiche($"{hermionegranger}", "noir");
            for(int i=0; i<4; i++) Affiche.Pion(i, 12, coulPion[secret[i]]);
            Console.SetCursorPosition(0, Affiche.yMax-1);
            Affiche.RestaureCouleur();
            Environment.Exit(0);
         }

         Affiche.Curseur(curseurX, curseurY, "efface");
         curseurX = 0;   curseurY++;
         Affiche.Curseur(curseurX, curseurY, "chevron"); 
      }
      if (prout == ConsoleKey.UpArrow) {
         coulChoix++; if (coulChoix > 5) coulChoix = 0;
         Affiche.Pion(curseurX, curseurY, coulPion[coulChoix]);
         plateau[curseurY, curseurX] = coulChoix;
      }
      if (prout == ConsoleKey.DownArrow) { 
         coulChoix--; if (coulChoix < 0) coulChoix = 5;
         Affiche.Pion(curseurX, curseurY, coulPion[coulChoix]);    
         plateau[curseurY, curseurX] = coulChoix;
      }
      if (prout == ConsoleKey.RightArrow) { 
         Affiche.Curseur(curseurX, curseurY, "efface");
         curseurX++; if (curseurX > 3) curseurX = 0; 
         Affiche.Curseur(curseurX, curseurY, "chevron");           }
      if (prout == ConsoleKey.LeftArrow) {
         Affiche.Curseur(curseurX, curseurY, "efface");
         curseurX--; if (curseurX < 0) curseurX = 3;
         Affiche.Curseur(curseurX, curseurY, "chevron");           }

      // Affiche.Test01(plateau, curseurY);

      Affiche.ResetConsCur();
   }


}



Affiche.RestaureCouleur();



void VérifCodeSicréte(sbyte[] secret, sbyte[,] plateau, int cy, ref byte noire, ref byte blanc ){
   sbyte[] cache = (sbyte[])secret.Clone();
   sbyte[] essai = new sbyte[4];
   for (int i=0; i<4; i++) essai[i] = plateau[cy, i];

   noire = 0;
   for (int i=0; i<4; i++) {
      if (cache[i] == essai[i]) {
         noire++;
         cache[i] = 99;
         essai[i] = -1;
      }
   }
   // Affiche.test02(secret, cache, essai);
   // Konzolo.Attendre("");
   blanc = 0;
   for (int iess=0; iess<4; iess++) {
      for (int iche=0; iche<4; iche++)
         if (essai[iess] == cache[iche]) {
            blanc++;
            cache[iche] = 99;
            essai[iess] = -1;
         }
   }

   // Affiche.test02(secret, cache, essai);
}



static class Affiche {
   public static int xMax = Console.WindowWidth;
   public static int yMax = Console.WindowHeight;
   public static int xRef = xMax/2 - 11;
   public static int yRef = yMax-4;
   static public ConsoleColor sauveCoulTexte;
   static public ConsoleColor sauveCoulFond;
   static string régles = "Régles:\nTrouvé les quatres couleurs\ncaché par le Master Mind\n\n" +
   "Le Master Mind vous aide\nlorsque vous faite un essai.\n\n"+
   "S'il répond noir:\nl'une des couleurs de votre\nessai est bien placée\n\n"+
   "S'il répond blanc:\nune couleur est présente\nmais au mauvaise emplacement\n\n"+
   "Haut/Bas: change couleur\nGauche/Droite: change position\nEntré: valider\nEspace: tricher\n";

   static Affiche(){
      sauveCoulTexte = Console.ForegroundColor;
      sauveCoulFond = Console.BackgroundColor;
   }

   static public void test02(sbyte[] tabA, sbyte[] tabB, sbyte[] tabC){
      Console.SetCursorPosition(0, 3);
      Konzolo.Affiche($"origin: ");
      for (int i=0; i<4; i++) Konzolo.Affiche($"{tabA[i],4}");
      Konzolo.Affiche($"\nsecret: ");
      for (int i=0; i<4; i++) Konzolo.Affiche($"{tabB[i],4}");
      Konzolo.Affiche($"\n essai: ");
      for (int i=0; i<4; i++) Konzolo.Affiche($"{tabC[i],4}");
   }

   static public void Test01(sbyte[,] tab, int curY){
      Console.SetCursorPosition(0,7);
      for (int i =0; i<12; i++) Konzolo.Affiche($"{tab[i,0],4}{tab[i,1],4}{tab[i,2],4}{tab[i,3],4}\n");
   }

   public static void Curseur(int curX, int curY, string type){
      string charA="",   charB="";
      if (type=="chevron") {  charA=">";  charB="<";  }
      if (type=="efface")  {  charA=" ";  charB=" ";  }
      Konzolo.Couleur(sauveCoulFond.ToString(), true);
      Console.SetCursorPosition(xRef + curX*4 -1, yRef - curY*2);
      Konzolo.Affiche($"{charA}", "blanc");
      Console.SetCursorPosition(xRef + curX*4 +2, yRef - curY*2);
      Konzolo.Affiche($"{charB}");
   }

   public static void Pion(int x, int y, string coul){
      Console.SetCursorPosition(xRef + x*4, yRef - y*2);
      Konzolo.Couleur(coul, true);
      Konzolo.Affiche($"  ");
   }
   public static void PionFin(int x, int y, string coul){
         Console.SetCursorPosition(xRef + x + 17, yRef - y*2);
         Konzolo.Couleur(coul, true);
         Konzolo.Affiche($" ");
   }

   public static void Grille(){
      Konzolo.Couleur("noir", true);
      Console.SetCursorPosition(xRef-1, 1);      Konzolo.Affiche($"                       ");
      Console.SetCursorPosition(xRef-1, 2);      Konzolo.Affiche($" M A S T E R   M I N D ");
      Console.SetCursorPosition(xRef-1, 3);      Konzolo.Affiche($"                       ");
      for (int i=0; i<12; i++)  for (int j=0; j<4; j++) { 
         Affiche.Pion (j, i, "grispale");
         Affiche.PionFin(j, i, "grispale");     }
      Konzolo.Couleur(sauveCoulFond.ToString(), true);
      Console.SetCursorPosition(0, 3);
      Konzolo.Affiche($"{régles}");
   }

   public static void RestaureCouleur(){
      Console.ForegroundColor = sauveCoulTexte;
      Console.BackgroundColor = sauveCoulFond;
   }

   public static void ResetConsCur(){
      Console.SetCursorPosition(0,0);
      Konzolo.Couleur(sauveCoulFond.ToString(), true);
   }



}

