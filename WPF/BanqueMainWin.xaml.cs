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
public partial class BanqueMainWin : Window   {

   public BanqueMainWin()    {
      InitializeComponent();
   }

   private void Création_Click(object sender, RoutedEventArgs e)    {
      BanqueAjoutWin winAjout = new BanqueAjoutWin();
      winAjout.Show();
   }

   private void Recherche_Click(object sender, RoutedEventArgs e)    {
   }

   private void Click_Dépôt(object sender, RoutedEventArgs e)    {
      BanqueOpéWin winDépot = new BanqueOpéWin("Dépot");
      winDépot.Show();
   }

   private void Click_Retrait(object sender, RoutedEventArgs e)    {
      BanqueOpéWin winRetrait = new BanqueOpéWin("Retrait");
      winRetrait.Show();
   }

   private void Quitter_Click(object sender, RoutedEventArgs e)    {
      Environment.Exit(0);
   }

   private void OnKeyDownHandler(object sender, KeyEventArgs e)     {
      if (e.Key == Key.Escape)  {  Environment.Exit(0);    }
   }
}
