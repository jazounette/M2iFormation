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
using FilRouge.Classes;
using System.Collections.ObjectModel;

namespace filrouge;

public partial class ConnexWindow : Window   {
   int admin_id = -1;

   public ConnexWindow()  {
      InitializeComponent();
   }

   private void Logingage(){
      int id=-1, accès=-1;
      Dbm.VerifLogin(Login.Text, MDP.Password, ref id, ref accès);////int VerifLogin(string login, string mdp, ref int id, ref int accès)

      if (id == -1) MessageBox.Show("Login où mot de passe incorrect", "Erreur", MessageBoxButton.OK, MessageBoxImage.Information);
      else if (accès != 0) MessageBox.Show("Privilège trop faible\nseule un administrateur peut utiliser cette application", "Erreur", MessageBoxButton.OK, MessageBoxImage.Information);
      else {
         admin_id = id;
         (Application.Current.MainWindow as MainWindow).SetAdmin(admin_id);
         this.Close();
      }
   }

   private void Click_LoginBoutVali (object sender, RoutedEventArgs e) {  Logingage();  }

   private void Click_LoginBoutQuit (object sender, RoutedEventArgs e)   {  Environment.Exit(0);  }
   private void Fermeture_Fenêtre(object sender, System.ComponentModel.CancelEventArgs e) {  if (admin_id == -1) Environment.Exit(0); }
   private void OnKeyDownHandler(object sender, KeyEventArgs e)     {
      if (e.Key == Key.Escape)  {  Environment.Exit(0);  }
      if (e.Key == Key.Enter)   {  Logingage();          }
   }
}
