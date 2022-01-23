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
public partial class BanqueOpéWin : Window   {
   string typeOpé = "";

   public BanqueOpéWin(string TypeOpé)    {
      InitializeComponent();
      typeOpé = TypeOpé;
      TitreFenêtre.Title = $"{typeOpé} Opération";
      GroupLabelOpé.Content = $"Montant du {typeOpé}: ";
      if (typeOpé == "Dépot") {  GroupTitreOpé.Header = $"Déposer des fonds";  }
      if (typeOpé == "Retrait") {  GroupTitreOpé.Header = $"Retirer des fonds";  }
      YvesMontand.Focus();
   }

   private void Orangina() {
      try {
         float somme = Convert.ToSingle(YvesMontand.Text);
         if (somme >=0)  {  
            MessageBox.Show ($"Le {typeOpé} de {YvesMontand.Text}€ a été effectué.", $"{typeOpé} éffectué", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();  }
         else MessageBox.Show ("Entré une valeur positive.", "Erreur de saisi", MessageBoxButton.OK, MessageBoxImage.Stop);   } 
      catch {  MessageBox.Show ("Entré une valeur numérique.", "Erreur de saisi", MessageBoxButton.OK, MessageBoxImage.Stop); }
   }
   private void Click_Valider(object sender, RoutedEventArgs e)    {  Orangina();  }
   private void Press_Entrée(object sender, KeyEventArgs e)   {  if (e.Key == Key.Enter) Orangina();   }

   private void Click_Annuler(object sender, RoutedEventArgs e)    {
      this.Close();
   }

   // private void Click_AjoutAnnul(object sender, RoutedEventArgs e)    {
   // }

   // private void Quitter_Click(object sender, RoutedEventArgs e)    {
   //    Environment.Exit(0);
   // }
   private void OnKeyDownHandler(object sender, KeyEventArgs e)     {
      if (e.Key == Key.Escape)  {  Environment.Exit(0);    }
   }
}
