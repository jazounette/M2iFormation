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
using System.Collections.ObjectModel;

namespace wpf;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class NombreMystère : Window   {
   Random thierryHazard = new Random();
   int nombreÀTrouver;
   int nombreEssai = 0;

   public NombreMystère()    {
      InitializeComponent();
      nombreÀTrouver = thierryHazard.Next(1, 51);
      // Message.Text = nombreÀTrouver.ToString();
      Message.Text = "Veuillez saisir un nombre";
      NombreEss.Text = "Nombre d'éssai: 0";
   }

   private void Click_Valider(object sender, RoutedEventArgs e)    {
      // MessageBox.Show(Essais.Text);
      int toto = Convert.ToInt32( Essais.Text );
      if (toto > nombreÀTrouver ) {  
         Résultat.Text = "C'est moins....";  
         nombreEssai++; 
         // Nombre d'Éssais : 
         NombreEss.Text = $"Nombre d'éssai{((nombreEssai<=1) ? "" : "s")}: {Convert.ToString(nombreEssai)}";    }
      else if (toto < nombreÀTrouver) {  
         Résultat.Text = "C'est plus....";  
         nombreEssai++; 
         NombreEss.Text = $"Nombre d'éssai{((nombreEssai<=1) ? "" : "s")}: {Convert.ToString(nombreEssai)}";    }
      else {
         Résultat.Text = $"Bravo!!! Vouz avez trouvé en {nombreEssai} coups!";
         Message.Text = $"Le nombre mystère était {nombreÀTrouver}";
      }
   }

   private void Click_Nouvelle(object sender, RoutedEventArgs e)    {
      // MessageBox.Show("prout");
      nombreÀTrouver = thierryHazard.Next(1, 51);
      nombreEssai = 0;
      Message.Text = "Veuillez saisir un nombre";
      NombreEss.Text = "Nombre d'éssai: 0";
      Essais.Text = "";
      Résultat.Text = "";

   }

   private void OnKeyDownHandler(object sender, KeyEventArgs e)     {
      if (e.Key == Key.Escape)  {  Environment.Exit(0);    }
   }
}
