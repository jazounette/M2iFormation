// See https://aka.ms/new-console-template for more information

var hazard = new Random();
var xMax = Console.WindowWidth;
var yMax = Console.WindowHeight;
int cMax = 10;// hauteur de la colonne de char
int cIndexMem = 0, cIndexTmp = 0;
char toto;
ConsoleKey prout; 
int[] yTable = new int[xMax];
char[,] cTable = new char[xMax,cMax];
for (int i=0; i<xMax; i++) yTable[i] = hazard.Next(-11, 0);

// for (int j=0; j<xMax; j++){
//    for (int i=0; i<10; i++) cTable[j,i] = Convert.ToChar(hazard.Next(65, 90));
//    // cTable[j,9] = ' ';
// }

Console.BackgroundColor = ConsoleColor.Black;
Console.ForegroundColor = ConsoleColor.Green;
while (true) {
   for (int x=0; x<xMax; x++) {
      cTable[x,cIndexMem] = Convert.ToChar(hazard.Next(65, 90));

      for (int j=0; j<cMax; j++) {
         cIndexTmp = (cIndexMem + j > cMax - 1) ? cIndexMem + j - cMax : cIndexMem + j;
         toto = cTable[x, cIndexTmp];
         if ((yTable[x] - j >= 0) && (yTable[x] < yMax+j)) { 
            Console.SetCursorPosition(x, yTable[x] - j);
            if (j == 0) Console.ForegroundColor = ConsoleColor.White;
            else Console.ForegroundColor = (j<4) ? ConsoleColor.Green : ConsoleColor.DarkGreen;
            Console.Write(toto);
         }
      }
      if (yTable[x] - 10 >= 0) { Console.SetCursorPosition(x, yTable[x] - 10);  Console.Write(" "); }
      yTable[x]++;
      if (yTable[x] == yMax + cMax) yTable[x] = hazard.Next(-15, 0);
   }
   // cIndexMem = (cIndexMem >= 10) ? cIndexMem++ : 0;
   if (cIndexMem > 0) cIndexMem--; else cIndexMem = 9;

   if (Console.KeyAvailable) { 
      prout = Console.ReadKey().Key;
      if (prout == ConsoleKey.Escape) break;
   }
   System.Threading.Thread.Sleep(22);
}

Console.ResetColor();
Console.SetCursorPosition(0,0);
