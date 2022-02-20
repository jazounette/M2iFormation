using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace conwayWPF;

public partial class MainWindow : Window   {

   static int  L=800, H=400, dpi=64;
   WriteableBitmap wbitmap = new WriteableBitmap(L, H, dpi, dpi, PixelFormats.Indexed8, BitmapPalettes.Halftone256);
   byte[,] pixels = new byte[L, H];
   Image image = new Image();

   Random hazard = new Random();
   static int xMax = L;
   static int yMax = H;
   static bool[,,] cell = new bool[3,xMax, yMax];
   Cellule concombre = new Cellule(cell);

   int tabOrig=1, tabDest=2;
   int cellVoisin;
   int compteur = 1;

   double xold = 0, yold = 0;
   double imgPosX=0, imgPosY=0;
   bool jeBouge = false;
   bool aideBascule = false;

   public MainWindow()    {
      InitializeComponent();

      initialise (xMax, yMax, cell, hazard);

      tartiflette.Text = "AU SECOURS\n\nF1: Vous êtes zici\nMolette Souris: Zoom in/out\nShift/ClickGauche: Déplacement\nEsc: Quitter\n\nJC. FEV2022";

      DispatcherTimer timer = new DispatcherTimer();
      timer.Interval = TimeSpan.FromMilliseconds(50);
      timer.Tick += MonProgrammeEn3Points;
      timer.Start();

      image.Stretch = Stretch.None;
      image.Margin = new Thickness(0);
      matoile.Children.Add(image);
   }

   void MonProgrammeEn3Points(object sender, EventArgs e)  {//premièrement le plein emploi, deuxièmement le plein emploi, troisièmement le plein emploi.
      for (int iy=0; iy<yMax; iy++) {/////////////////////////compose l'image
         for (int ix=0; ix<xMax; ix++) {
            pixels[ix, iy] = (cell[tabOrig,ix,iy]) ? (byte)255 : (byte)0;
         }
      }

      for (int iy=0; iy<yMax; iy++)  for (int ix=0; ix<xMax; ix++) {/////////////////calcul état des prochaines cellules
         cellVoisin = concombre.testCell(ix, iy, cell, tabOrig);
         if (cell[tabOrig,ix,iy]) {
            if (cellVoisin==2 || cellVoisin==3) cell[tabDest,ix,iy] = true; else cell[tabDest,ix,iy] = false;
         } else if (cellVoisin == 3) cell[tabDest,ix,iy] = true; else cell[tabDest,ix,iy] = false ;
      }

      tabOrig = (tabOrig == 1) ? 2 : 1;
      tabDest = (tabDest == 1) ? 2 : 1;

      FaireFromage(pixels);

      Canvas.SetLeft(image, imgPosX);
      Canvas.SetTop(image, imgPosY);

      image.Source = wbitmap;

      compteur++;

   }

   void initialise (int xMax, int yMax, bool [,,] cell, Random  hazard) {
      for(int j=0; j<yMax; j++)   for(int i=0; i<xMax; i++) {
         cell[0,i,j] = !Convert.ToBoolean(hazard.Next(0,6));   // on veux plus de true que de false
         cell[1,i,j] = cell[0,i,j];                            // garde en mémoire le tableau initiale, cell[0,,]
      }
   }

   void FaireFromage(byte[,] pixels){//c'est comme faireimage mais avec un fro
      Int32Rect rect = new Int32Rect(0, 0, L, H);
      int stride = L;
      byte[] pixels1d = new byte[H * L];
      int index = 0;
      for (int row = 0; row < H; row++)  for (int col = 0; col < L; col++)   pixels1d[index++]= pixels[col, row];
      wbitmap.WritePixels(rect, pixels1d, stride, 0);
   }

   void ToucheAppuyage(object sender, KeyEventArgs e)  {
      if (e.Key == Key.LeftShift)  jeBouge=true;
      MajBareÉtat();
   }
   void ToucheRelachage(object sender, KeyEventArgs e)  {
      if (e.Key == Key.Escape)  Environment.Exit(0);
      if (e.Key == Key.LeftShift)  jeBouge=false;
      if (e.Key == Key.F1) AideAffiche();
      MajBareÉtat();
   }
   void ClickGaucheBas(object sender, MouseEventArgs e)  {
      if (e.LeftButton == MouseButtonState.Pressed)  jeBouge=true;
      MajBareÉtat();
   }
   void ClickGaucheHaut(object sender, MouseEventArgs e)  {
      if (e.LeftButton == MouseButtonState.Released)  jeBouge=false;
      MajBareÉtat();
   }
   void ScrollMolette(object sender, MouseWheelEventArgs e)  {
      double décalage = 0, craquette = 0.5;
      if (e.Delta < 0) {  dpi+=8;   décalage = dpi*craquette;   }
      else {   dpi-=8;   décalage = dpi*-craquette;   }
      if (dpi < 24) {  dpi = 24;  décalage=0;  }

      imgPosX += décalage;    imgPosY += décalage/2;

      wbitmap = new WriteableBitmap(L, H, dpi, dpi, PixelFormats.Indexed8, BitmapPalettes.Halftone256);

      MajBareÉtat();
   }

   private void MouvementSouris(object sender, MouseEventArgs e)  {
      Point pos = Mouse.GetPosition(Application.Current.MainWindow);
      double dx = pos.X - xold, dy = pos.Y - yold;
      xold = pos.X;     yold = pos.Y;
      if (jeBouge) {
         imgPosX += dx;    imgPosY += dy;
         Canvas.SetLeft(image, imgPosX);
         Canvas.SetTop(image, imgPosY);
      }
      MajBareÉtat ();
   }

   void MajBareÉtat(){  choupinette.Text = $"X:{xold:F1}  Y:{yold:F1}     DX:{imgPosX:F1}  DY:{imgPosY:F1}     Dpi:{dpi}     F1:Aide     {((jeBouge) ? "MOVING" : "")}";   }
   void AideAffiche(){
      if (aideBascule) {  tartiflette.Visibility = Visibility.Collapsed;     aideBascule = false;   }
      else {  tartiflette.Visibility = Visibility.Visible;    aideBascule = true;      }
   }

}


class Cellule {
   int xMax, yMax;
   // int ixStart, ixFinal, iyStart, iyFinal;

   public Cellule(bool[,,] cell) {
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
      return compteur;
   }
}


      // for (double i=0; i<(2*Math.PI); i+=(Math.PI/6) ) {
      //    Line ligne = new Line();
      //    ligne.Stroke = Brushes.Black;
      //    ligne.Fill = Brushes.Red;
      //    ligne.StrokeThickness = 4;
      //    ligne.X1 = 200;
      //    ligne.Y1 = 200;
      //    ligne.X2 = 200 + Math.Cos(i) * 55;
      //    ligne.Y2 = 200 + Math.Sin(i) * 55;
      //    matoile.Children.Add(ligne);
      // }
