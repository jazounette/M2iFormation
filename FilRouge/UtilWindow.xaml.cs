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

public partial class UtilWindow : Window   {
   string quoiquonfaitchef = "";
   int id_user = -1;

   public UtilWindow(string quoiquonfaitchef, int id_user=-1, string courriel="", string pseudo="", string nom="", string prénom="", string tél="", string avatar="", int accès=2)  {
      InitializeComponent();
      // DateTime ilEstExactement = DateTime.Now;
      this.quoiquonfaitchef = quoiquonfaitchef;
      this.id_user = id_user;
      if (quoiquonfaitchef =="nouv") {
         this.Height-=100;
         UtilWin.Text = "AJOUT D'UN UTILISATEUR";
         saisiMDP.Visibility = Visibility.Visible;
         resetMDP.Visibility = Visibility.Collapsed;  }
      if (quoiquonfaitchef =="maj") {
         UtilWin.Text = "MODIFICATION D'UN UTILISATEUR";
         saisiMDP.Visibility = Visibility.Collapsed;
         resetMDP.Visibility = Visibility.Visible;    }
      if (id_user == -1) JeSuisUnNuméro.Visibility = Visibility.Collapsed; else JeSuisUnNuméro.Text = $"Numéro: {id_user}";
      UtilCou.Text = courriel;
      UtilPse.Text = pseudo;
      UtilNom.Text = nom;
      UtilPré.Text = prénom;
      UtilTél.Text = tél;
      UtilAva.Text = avatar;
      UtilAcc.Text = Convert.ToString(accès);
   }
   private void Click_UtilBoutVal(object sender, RoutedEventArgs e)    {
      string ya_un_blem = "";

      if (quoiquonfaitchef == "nouv" && (UtilCou.Text=="" || UtilPse.Text=="" || UtilPss.Text=="")) 
         ya_un_blem = "Les Champs Pseudo, Courriel et Mot de passe\nne peuvent pas être vide";
      if (quoiquonfaitchef == "maj" && (UtilCou.Text=="" || UtilPse.Text=="")) 
         ya_un_blem = "Les Champs Pseudo et Courriel\nne peuvent pas être vide";

      if (Dbm.UtilDéjàExist(id_user, UtilCou.Text, UtilPse.Text)) ya_un_blem = "Ce courriel où ce pseudo existe déjà";

      if (ya_un_blem == "") {
         string mdpHachée = Dbm.EncodePassword(UtilPss.Text);
         Dbm.InjectUtil(quoiquonfaitchef, id_user, UtilCou.Text, UtilPse.Text, mdpHachée, UtilNom.Text, UtilPré.Text, UtilTél.Text, UtilAva.Text, Convert.ToInt16(UtilAcc.Text));
         (Application.Current.MainWindow as MainWindow).RefreshUtilList();
         this.Close();
      } else MessageBox.Show (ya_un_blem, "Crotteux deux biques", MessageBoxButton.OK, MessageBoxImage.Information);
   }
   private void Click_UtilBoutReset(object sender, RoutedEventArgs e)  {
      if (UtilNouvPss.Text == "") MessageBox.Show("Veuillez saisir un mot de passe", "Erreur mot de passe", MessageBoxButton.OK, MessageBoxImage.Information);
      else {
         string mdpHachée = Dbm.EncodePassword(UtilNouvPss.Text);
         Dbm.MDPupdate(id_user, mdpHachée);//////// int MDPupdate(int id_utilisateur, string MDP)
         this.Close();
      }
   }
   private void Click_UtilBoutAnu(object sender, RoutedEventArgs e)    {   this.Close();   }
   private void OnKeyDownHandler(object sender, KeyEventArgs e)     {
      if (e.Key == Key.Escape)  {  this.Close();   }
   }
}
