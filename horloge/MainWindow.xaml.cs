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
   Path chronoArc = new Path();
   Line[] chronoGra = new Line[12];
   int secMem = 0;
   float secRad, minRad, heuRad;
   string doudot = "", boudot = ":";
   bool ionoChrono = false, affInfo = false;
   DateTime ilEstMem, affInfoSec;
   long unixTimeDeb, unixTimeFin;
   double chronoRadDeb, chronoRadFin;
   int délai = 30;

   public MainWindow(){
      InitializeComponent();

      DispatcherTimer timer = new DispatcherTimer();
      timer.Interval = TimeSpan.FromMilliseconds(100);
      timer.Tick += MonProgrammeEn3Points;
      timer.Start();

      TraceCadran();

   }//fin constructeur

   void MonProgrammeEn3Points(object sender, EventArgs e) {

      DateTime ilEst = DateTime.Now;

      if (ilEst < affInfoSec) {
         affInfo = true;
         digitHeure.TextAlignment = TextAlignment.Right;
         digitHeure.Text = $"DC:{délai}";
      } else {  affInfo = false; digitHeure.TextAlignment = TextAlignment.Center;  }

      if (ionoChrono) {
         unixTimeFin = ((DateTimeOffset)ilEst).ToUnixTimeMilliseconds();//unixTimeDeb et chronoRadDeb sont calculés une seul fois quand la touche espace est relaché
         if (!affInfo) {
            double chrono = (unixTimeFin - unixTimeDeb*1000.0) / 1000.0;
            boudot = (boudot == ":") ? " ": ":";
            digitHeure.Text = TimeSpan.FromSeconds(chrono).ToString(@$"h\{boudot}mm\{boudot}ss\.f");//here backslash is must to tell that colon is not the part of format, it just a character that we want in output
         }
      }
      if (ilEst.Second != secMem) {
         if (ionoChrono) {
            unixTimeFin /= 1000;
            chronoRadFin = (ilEstMem.Minute * Math.PI / 30) + (ilEstMem.Second + unixTimeFin-unixTimeDeb) * Math.PI / 1800 - Math.PI/2;
            matoile.Children.Remove(chronoArc);
            if (chronoRadDeb<chronoRadFin) {
               chronoArc = ArcAdd(200, 200, chronoRadDeb, chronoRadFin, 150, "#118811");
            } else { 
               long unixTimeDebSec = ((DateTimeOffset)ilEst).ToUnixTimeSeconds();
               long unixTimeFinSec = ((DateTimeOffset)ilEstMem).ToUnixTimeSeconds();
               double arcRadDeb = ilEst.Second * Math.PI / 30 - Math.PI/2;
               double arcRadFin = (ilEst.Second + unixTimeFinSec-unixTimeDebSec) * Math.PI / 30 - Math.PI/2;
               chronoArc = ArcAdd(200, 200, arcRadDeb, arcRadFin, 150, "#881111");
            }

            choupinette.Text = $"{((chronoRadFin-chronoRadDeb)%(2*Math.PI))}  ";

            int j=0; double k;
            for (int l=0; l<12; l++) matoile.Children.Remove(chronoGra[l]);
            for (double i=0; i<((chronoRadFin-chronoRadDeb)%(2*Math.PI)); i+=Math.PI/6)  {
               k = i + chronoRadDeb;
               if (j>11) break;// si ça dépasse quand plus de 60minutes, sécurité pour être sûr de na pas taper en dehors du tableau
               chronoGra[j] = LigneAdd(200 + Math.Cos(k)*140, 200 + Math.Sin(k)*140, 200 + Math.Cos(k)*170, 200 + Math.Sin(k)*170, 1);
               choupinette.Text += $"{j} ";
               j++;
            }
         }

         secRad = (float)(ilEst.Second * Math.PI / 30);
         minRad = (float)((ilEst.Minute * Math.PI / 30) + (secRad / 60));
         heuRad = (float)((ilEst.Hour * Math.PI / 6) + (minRad / 12));
         secRad -= (float)Math.PI/2; //sur le cadran midi ce trouve en -PI/2
         minRad -= (float)Math.PI/2;
         heuRad -= (float)Math.PI/2;

         aiguilleSec = LigneMov(aiguilleSec, 200 - Math.Cos(secRad) * 40, 200 - Math.Sin(secRad) * 40, 200 + Math.Cos(secRad) * 155, 200 + Math.Sin(secRad) * 155, 3);
         aiguilleSec2 = DisqueMov(aiguilleSec2, 200 + Math.Cos(secRad) * 140, 200 + Math.Sin(secRad) * 140, 15, "#FF0000");
         aiguilleMin = LigneMov(aiguilleMin, 200, 200, 200 + Math.Cos(minRad) * 140, 200 + Math.Sin(minRad) * 140, 4);
         aiguilleHeu1 = LigneMov(aiguilleHeu1, 200, 200, 200 + Math.Cos(heuRad) * 100, 200 + Math.Sin(heuRad) * 100, 5);
         aiguilleHeu2 = LigneMov(aiguilleHeu2, 200 + Math.Cos(heuRad) * 100, 200 + Math.Sin(heuRad) * 100, 200 + Math.Cos(heuRad) * 120, 200 + Math.Sin(heuRad) * 120, 5, "#FF0000");

         if (!ionoChrono && !affInfo) {
            doudot = ((secMem % 2) == 0) ? ":": " ";
            digitHeure.Text = $"{ilEst.ToString($"HH{doudot}mm{doudot}ss")}";
         }
         digitCalen.Text = $"{ilEst.ToString("dddd, d MMMM yyyy")}";
         secMem = ilEst.Second;

         // choupinette.Text = $"{ilEst.ToString()}  {((ionoChrono)?"Chrono":"")}  {ilEstMem.ToString("HH:mm:ss")}  ";
      } //else choupinette.Text += "█";
   }
   void TraceCadran(){
      CercleAdd(200, 200, 344, 2);
      CercleAdd(200, 200, 382, 2);
      int j=0;
      (int mu, int ep, string co) vk;
      DisqueAdd (200, 200, 20);
      for (double i=0; i<(10*Math.PI); i+=(Math.PI/30) ) {
         (vk.mu, vk.ep, vk.co) = (j%5 == 0) ? (156,4,"#FF0000") : (160,2,"#FFFFFF");
         LigneAdd(200 + Math.Cos(i) * vk.mu, 200 + Math.Sin(i) * vk.mu, 200 + Math.Cos(i) * 170, 200 + Math.Sin(i) * 170, vk.ep, vk.co);
         j++;
      }
      double ang = -Math.PI/3;      int angDeg = 30;
      for (int i=1; i<=12; i++){
         TextBlock chiffre = new TextBlock();
         chiffre.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#000000");//#99FF99
         chiffre.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
         chiffre.Height = 20;    chiffre.Width = 20;
         chiffre.TextAlignment = TextAlignment.Center;
         chiffre.FontSize = 16;
         chiffre.FontWeight = FontWeights.UltraBold;;
         chiffre.Text = i.ToString();
         Canvas.SetLeft(chiffre, 200 + Math.Cos(ang)*190 + Math.Sin(ang)*10);
         Canvas.SetTop(chiffre,  200 + Math.Sin(ang)*190 - Math.Cos(ang)*10);
         chiffre.RenderTransform = new RotateTransform(angDeg, 0, 0);
         ang += Math.PI/6;    angDeg +=30;

         matoile.Children.Add(chiffre);
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
   Ellipse CercleAdd(double X, double Y, double diam, int épais, string coul = "#FFFFFF"){
      Ellipse cercle = new Ellipse();
      cercle.Stroke = (SolidColorBrush)new BrushConverter().ConvertFrom(coul);
      cercle.StrokeThickness = épais;
      Canvas.SetLeft(cercle, X-diam/2);
      Canvas.SetTop(cercle, Y-diam/2);
      cercle.Width = diam;
      cercle.Height = diam;
      matoile.Children.Add(cercle);
      return cercle;
   }
   Ellipse DisqueAdd(double X, double Y, double rayon, string coul = "#FFFFFF"){
      Ellipse disque = new Ellipse();
      disque.Stroke = Brushes.Black;
      disque.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(coul);
      // disque.Fill = Brushes.DarkBlue;
      // disque.HorizontalAlignment = HorizontalAlignment.Left;
      // disque.VerticalAlignment = VerticalAlignment.Center;
      Canvas.SetLeft(disque, X-rayon/2);
      Canvas.SetTop(disque, Y-rayon/2);
      Canvas.SetZIndex(disque,1);
      disque.Width = rayon;
      disque.Height = rayon;
      matoile.Children.Add(disque);
      return disque;
   }
   Ellipse DisqueMov(Ellipse disque, double X, double Y, double rayon, string coul = "#FFFFFF"){
      matoile.Children.Remove(disque);
      return DisqueAdd ( X,  Y,  rayon,  coul );
   }
   Path ArcAdd(double cx, double cy, double radDeb, double radFin, double ray, string coul = "#FFFFFF"){
      Path arc_path = new Path();

      arc_path.Stroke = (SolidColorBrush)new BrushConverter().ConvertFrom(coul);
      arc_path.StrokeThickness = 10;
      Canvas.SetLeft(arc_path, 0);
      Canvas.SetTop(arc_path, 0);

      PathGeometry pathGeometry = new PathGeometry();
      PathFigure pathFigure = new PathFigure();
      ArcSegment arcSegment = new ArcSegment();
      arcSegment.IsLargeArc = ((radFin - radDeb + 0.00001)%(2*Math.PI)) > Math.PI;// +0.00001 pour héviter comportement chaotique autour de 2PI
      pathFigure.StartPoint = new Point(cx + Math.Cos(radDeb)*ray, cy + Math.Sin(radDeb)*ray);// point de départ de l'arc
      arcSegment.Point = new Point(cx + Math.Cos(radFin)*ray, cy + Math.Sin(radFin)*ray);// point d'arrivé de l'arc
      arcSegment.Size = new Size(ray, ray);
      arcSegment.SweepDirection = SweepDirection.Clockwise;

      pathFigure.Segments.Add(arcSegment);
      pathGeometry.Figures.Add(pathFigure);
      arc_path.Data = pathGeometry;
      matoile.Children.Add(arc_path);

      return arc_path;
   }
   void ChronoStartStop(){
      if (!affInfo) digitHeure.Text = "--:--:--";
      ionoChrono = (ionoChrono) ? false : true;
      if (ionoChrono) {
         ilEstMem = DateTime.Now.AddSeconds(délai);
         unixTimeDeb = ((DateTimeOffset)ilEstMem).ToUnixTimeSeconds();
         chronoRadDeb = (ilEstMem.Minute * Math.PI / 30) + (ilEstMem.Second * Math.PI / 1800) - Math.PI/2;
         // digitHeure.TextAlignment = TextAlignment.Right;
      } else {  
         matoile.Children.Remove(chronoArc);
         for (int l=0; l<12; l++) matoile.Children.Remove(chronoGra[l]);
         // digitHeure.TextAlignment = TextAlignment.Center;
      }
   }
   void ChronoSetup(int sec){
      délai += sec;
      if (délai<0) délai = 0;
      affInfoSec = DateTime.Now.AddSeconds(3);
   }
   void ToucheRelachage(object sender, KeyEventArgs e)  {
      if (e.Key == Key.Escape)  Environment.Exit(0);
      if (e.Key == Key.Space)   ChronoStartStop();
      if (e.Key == Key.Up)      ChronoSetup(10);
      if (e.Key == Key.Down)    ChronoSetup(-10);
   }


}//fin mainwindow

