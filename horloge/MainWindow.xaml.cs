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

namespace horloge;

public partial class MainWindow : Window{
   Line aiguilleSec = new Line();
   Ellipse aiguilleSec2 = new Ellipse();
   Line aiguilleMin = new Line();
   Line aiguilleHeu1 = new Line();
   Line aiguilleHeu2 = new Line();
   int secMem = 0;
   float secRad, minRad, heuRad;
   string doudot = "";

   public MainWindow(){
      InitializeComponent();

      DispatcherTimer timer = new DispatcherTimer();
      timer.Interval = TimeSpan.FromMilliseconds(100);
      timer.Tick += MonProgrammeEn3Points;
      timer.Start();

      matoile.Children.Add(aiguilleSec);
      matoile.Children.Add(aiguilleMin);
      matoile.Children.Add(aiguilleHeu1);
      matoile.Children.Add(aiguilleHeu2);

      TraceCadran();

   }//fin constructeur

   void MonProgrammeEn3Points(object sender, EventArgs e) {

      DateTime ilEst = DateTime.Now;

      if (ilEst.Second != secMem) {
         secRad = (float)(ilEst.Second * Math.PI / 30);
         minRad = (float)((ilEst.Minute * Math.PI / 30) + (secRad / 60));
         heuRad = (float)((ilEst.Hour * Math.PI / 6) + (minRad / 12));
         secRad -= (float)Math.PI/2; //sur le cadran midi ce trouve en -PI/2
         minRad -= (float)Math.PI/2;
         heuRad -= (float)Math.PI/2;

         aiguilleSec = LigneMov(aiguilleSec, 200 - Math.Cos(secRad) * 40, 200 - Math.Sin(secRad) * 40, 200 + Math.Cos(secRad) * 155, 200 + Math.Sin(secRad) * 155, 3);
         aiguilleSec2 = CercleMov(aiguilleSec2, 200 + Math.Cos(secRad) * 140, 200 + Math.Sin(secRad) * 140, 15);
         aiguilleMin = LigneMov(aiguilleMin, 200, 200, 200 + Math.Cos(minRad) * 140, 200 + Math.Sin(minRad) * 140, 4);
         aiguilleHeu1 = LigneMov(aiguilleHeu1, 200, 200, 200 + Math.Cos(heuRad) * 100, 200 + Math.Sin(heuRad) * 100, 5);
         aiguilleHeu2 = LigneMov(aiguilleHeu2, 200 + Math.Cos(heuRad) * 100, 200 + Math.Sin(heuRad) * 100, 200 + Math.Cos(heuRad) * 120, 200 + Math.Sin(heuRad) * 120, 5, "#FF0000");

         doudot = ((secMem % 2) == 0) ? ":": " ";
         digitheure.Text = $"{ilEst.ToString($"HH{doudot}mm{doudot}ss")}";
         digitcalen.Text = $"{ilEst.ToString("dddd, dd MMMM yyyy")}";

         choupinette.Text = $"{ilEst.ToString()}  ██████████████████████";
         secMem = ilEst.Second;
      }
      else  choupinette.Text = $"{ilEst.ToString()}";
   }
   void TraceCadran(){
      int j=0;
      (int mu, int ep) vk;
      CercleAdd (200, 200, 20);
      for (double i=0; i<(10*Math.PI); i+=(Math.PI/30) ) {
         (vk.mu, vk.ep) = (j%5 == 0) ? (180,4) : (170,2);
         LigneAdd(200 + Math.Cos(i) * 160, 200 + Math.Sin(i) * 160, 200 + Math.Cos(i) * vk.mu, 200 + Math.Sin(i) * vk.mu, vk.ep);
         j++;
      }
   }
   Line LigneAdd(double X1, double Y1, double X2, double Y2, int épais, string coul = "#FFFFFF"){
      Line ligne = new Line();
      ligne.Stroke = (SolidColorBrush)new BrushConverter().ConvertFrom(coul);
      // ligne.Stroke = Brushes.White;
      // ligne.Fill = Brushes.Red;
      ligne.StrokeThickness = épais;
      ligne.X1 = X1;
      ligne.Y1 = Y1;
      ligne.X2 = X2;
      ligne.Y2 = Y2;
      matoile.Children.Add(ligne);
      return ligne;
   }
   Line LigneMov(Line ligne, double X1, double Y1, double X2, double Y2, int épais, string coul = "#FFFFFF"){
      matoile.Children.Remove(ligne);
      return LigneAdd ( X1,  Y1,  X2,  Y2,  épais, coul );
   }
   Ellipse CercleAdd(double X, double Y, double rayon, string coul = "#FFFFFF"){
      Ellipse cercle = new Ellipse();
      cercle.Stroke = Brushes.Black;
      cercle.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(coul);
      // cercle.Fill = Brushes.DarkBlue;
      // cercle.HorizontalAlignment = HorizontalAlignment.Left;
      // cercle.VerticalAlignment = VerticalAlignment.Center;
      Canvas.SetLeft(cercle, X-rayon/2);
      Canvas.SetTop(cercle, Y-rayon/2);
      Canvas.SetZIndex(cercle,1);
      cercle.Width = rayon;
      cercle.Height = rayon;
      matoile.Children.Add(cercle);
      return cercle;
   }
   Ellipse CercleMov(Ellipse cercle, double X, double Y, double rayon, string coul = "#FFFFFF"){
      matoile.Children.Remove(cercle);
      return CercleAdd ( X,  Y,  rayon,  coul );
   }

   void ToucheRelachage(object sender, KeyEventArgs e)  {
      if (e.Key == Key.Escape)  Environment.Exit(0);
   }


}//fin mainwindow

