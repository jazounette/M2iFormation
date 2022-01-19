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
public partial class BanqueAjoutWin : Window   {

   public BanqueAjoutWin()    {
      InitializeComponent();
   }

   private void Click_AjoutClient(object sender, RoutedEventArgs e)    {
      try {
         if (ClientNom.Text!="" && ClientPrenom.Text!="" && ClientTel.Text!="") {
            MessageBox.Show($"Le Client à été enregistré:\nNom: {ClientNom.Text}\nPrénom: {ClientPrenom.Text}\nTéléphone: {ClientTel.Text}");
            this.Close();     }
         else MessageBox.Show("Erreur de saisi 02\ncomplété tous les champs");
      }  catch  {  MessageBox.Show("Erreur de Saisi 01");  }
   }
   private void Cocacola() {
      try {
         float somme = Convert.ToSingle(Solde.Text);
         if (somme >=0)  {  MessageBox.Show ($"Le Compte à été créé\nSolde: {somme}€", "Succes!");   this.Close();  }
         else {   MessageBox.Show("Erreur de saisi 03\nSolde négatif.");   }
      } catch {   MessageBox.Show("Erreur de création de compte");   }
   }
   private void Click_AjoutCréer(object sender, RoutedEventArgs e)  {   Cocacola();   }
   private void Press_Entrée(object sender, KeyEventArgs e)   {  if (e.Key == Key.Enter) Cocacola();   }

   private void Click_AjoutAnnul(object sender, RoutedEventArgs e)    {
      this.Close();
   }


   // private void Quitter_Click(object sender, RoutedEventArgs e)    {
   //    Environment.Exit(0);
   // }
   private void OnKeyDownHandler(object sender, KeyEventArgs e)     {
      if (e.Key == Key.Escape)  {  Environment.Exit(0);    }
   }
}
