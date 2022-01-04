// Le jeu de la vie de Conway
// https://fr.wikipedia.org/wiki/Jeu_de_la_vie
// https://www.youtube.com/watch?v=S-W0NX97DB0


var hazard = new Random();
int xMax = Console.WindowWidth;
int yMax = Console.WindowHeight - 1;
bool[,,] cell = new bool[3,xMax, yMax];
cellule concombre = new cellule(cell);

Console.OutputEncoding = System.Text.Encoding.UTF8;  // marche po, mais laisse quand même on sait jamais

initialise (xMax, yMax, cell, hazard);

int tabOrig=1, tabDest=2;
int cellVoisin;
int compteur = 1;
int delai = 55;
string ligne;
ConsoleKey prout;
Console.Clear();

while (true) {
   // Console.WriteLine(compteur);/////////////////////////////////////////////////////////////bloc de test//////////////
   // Console.WriteLine($"        tableau{tabOrig}                    tableau{tabDest}                 tableau initial");
   // Console.WriteLine("   0123456789012345678901      0123456789012345678901      0123456789012345678901");
   // for (int i=0; i<yMax; i++) {
   //    Console.Write($"{(i),2:00} ");
   //    for (int j=0; j<xMax; j++) if (cell[tabOrig,j,i]) Console.Write("X"); else Console.Write("-");
   //    Console.Write("      ");
   //    for (int j=0; j<xMax; j++) if (cell[tabDest,j,i]) Console.Write("X"); else Console.Write("-");
   //    Console.Write("      ");
   //    for (int j=0; j<xMax; j++) if (cell[0,j,i]) Console.Write("X"); else Console.Write("-");
   //    Console.WriteLine(""); 
   // }
   // Console.WriteLine("   0123456789012345678901      0123456789012345678901      0123456789012345678901");

   Console.SetCursorPosition(0,0);
   for (int iy=0; iy<yMax; iy++) {/////////////////////////////////////////////////////////affichage de la grille
      ligne = "";
      for (int ix=0; ix<xMax; ix++) ligne += (cell[tabOrig,ix,iy]) ? "O" : " ";
      Console.WriteLine(ligne);
   }
   Console.Write($"{compteur,5} space>>pause - escape>>quit - enter>>restart - delete>>newstart - up>>speedup - down>>slowdown. délai:{delai}ms");

   for (int iy=0; iy<yMax; iy++)  for (int ix=0; ix<xMax; ix++) {/////////////////calcul état des prochaines cellules
      cellVoisin = concombre.testCell(ix, iy, cell, tabOrig);
      if (cell[tabOrig,ix,iy]) {
         if (cellVoisin==2 || cellVoisin==3) cell[tabDest,ix,iy] = true; else cell[tabDest,ix,iy] = false;
      } else if (cellVoisin == 3) cell[tabDest,ix,iy] = true; else cell[tabDest,ix,iy] = false ;
   }

   tabOrig = (tabOrig == 1) ? 2 : 1;
   tabDest = (tabDest == 1) ? 2 : 1;
   compteur++;

   if (Console.KeyAvailable) { ////////////////////////////////////////////////////touches, pas touche
      prout = Console.ReadKey().Key;
      if (prout == ConsoleKey.Escape) {  Console.WriteLine(); break;  }
      if (prout == ConsoleKey.Spacebar) {
         while (true) if (Console.KeyAvailable) { if (Console.ReadKey().Key == ConsoleKey.Spacebar) break; }
      }
      if (prout == ConsoleKey.Enter) {
         compteur = 1;
         for(int j=0; j<yMax; j++)   for(int i=0; i<xMax; i++)  cell[tabOrig,i,j] = cell[0,i,j];
      }
      if (prout == ConsoleKey.Delete) { compteur=1; tabOrig=1; tabDest=2;  initialise (xMax, yMax, cell, hazard);  }
      if (prout == ConsoleKey.DownArrow) delai += 10;
      if (prout == ConsoleKey.UpArrow) { delai -= 10; if (delai <0) delai =0;}
   }
   System.Threading.Thread.Sleep(delai);
}


void initialise (int xMax, int yMax, bool [,,] cell, Random  hazard) {
   for(int j=0; j<yMax; j++)   for(int i=0; i<xMax; i++) {
      cell[0,i,j] = !Convert.ToBoolean(hazard.Next(0,6));   // on veux plus de true que de false
      cell[1,i,j] = cell[0,i,j];                            // garde en mémoire le tableau initiale, cell[0,,]
   }
}

class cellule {
   int xMax, yMax;
   int ixStart, ixFinal, iyStart, iyFinal;

   public cellule(bool[,,] cell) {
      xMax = cell.GetLength(1) - 1;
      yMax = cell.GetLength(2) - 1;
   }

   public int testCell(int x, int y, bool[,,] cell, int n) { // x,y: les coords de la cellule à tester. cell: l'adresse des tableaux.
      int compteur = 0;                                      // n: dans quel tableau ce fait le test (le tableau 0 ou le tableau 1)              
      int cx = 0, cy = 0;
      for (int iy = y-1; iy <= y+1; iy++) {
         cy=iy;  if (iy<0) cy=yMax;    if (iy>yMax) cy=0;
         for (int ix = x-1; ix <= x+1; ix++)  {
            cx=ix;    if (ix<0) cx=xMax;      if (ix>xMax) cx=0;
            if ((cell[n,cx,cy]) && (!((cx==x) && (cy==y)))) compteur++;
         }
      }
      // Console.SetCursorPosition(0,22);                 //affiche mini bloc autour de la cellule testé
      // Console.BackgroundColor = ConsoleColor.Black;
      // Console.WriteLine($"x:{x}   y:{y}   ");
      // for (int iy = y-1; iy <= y+1; iy++) {
      //    cy=iy;  if (iy<0) cy=yMax;    if (iy>yMax) cy=0;
      //    for (int ix = x-1; ix <= x+1; ix++)  {
      //       cx=ix;    if (ix<0) cx=xMax;      if (ix>xMax) cx=0;
      //       Console.Write((cell[n,cx,cy]) ? "X" : "-");
      //    }
      //    Console.Write("  \n");
      // }
      // Console.WriteLine(compteur);
      // Console.BackgroundColor = ConsoleColor.DarkBlue;
      // if (Console.ReadLine() == "x") Environment.Exit(0);

      return compteur;
   }
}


      // ancien code
      // int compteur = 0;
      // ixStart=0; ixFinal=xMax; iyStart=0; iyFinal=yMax;
      // if (x>0) ixStart = x-1;
      // if (x<xMax) ixFinal = x+1;
      // if (y>0) iyStart = y-1;
      // if (y<yMax) iyFinal = y+1;

      // for (int iy = iyStart; iy <= iyFinal; iy++)
      //    for (int ix = ixStart; ix <= ixFinal; ix++)
      //       if ((cell[n,ix,iy]) && (!((ix==x) && (iy==y)))) compteur++;




// régles originel du jeu de la vie
// live:	moin que 2 vivant autour:  tu meurs             // vivant avec 2 ou 3 vivant autour >>> tu reste vivant
// live:	plus que 3 vivant autour:  tu meurs             //        sinon tu meurt
// live: avec 2 ou 3 vivant autour: tu vis
// dead:	avec 3 vivant autour:      tu vis               // mort avec 3 vivant autour >>> tu devient vivant
// dead: moin que 3 autour:         tu reste mort        //        sinon tu reste mort
// dead: plus que 3 autour:         tu reste mort


// Console.WriteLine($"booléen: {sizeof(bool)}octet{((sizeof(bool) == 1) ? "" : "s")}");
// Console.WriteLine($"char: {sizeof(char)}octet{((sizeof(char) == 1) ? "" : "s")}");
// Console.WriteLine($"byte: {sizeof(byte)}octet{((sizeof(byte) == 1) ? "" : "s")}");
// Console.WriteLine($"short: {sizeof(short)}octet{((sizeof(short) == 1) ? "" : "s")}");
// Console.WriteLine($"int: {sizeof(int)}octet{((sizeof(int) == 1) ? "" : "s")}");
// Console.WriteLine($"long: {sizeof(long)}octet{((sizeof(long) == 1) ? "" : "s")}");

