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
      DateTime ilEstExactement = DateTime.Now;
      this.quoiquonfaitchef = quoiquonfaitchef;
      this.id_user = id_user;
      if (quoiquonfaitchef =="nouv") UtilWin.Text = "AJOUT D'UN UTILISATEUR";
      if (quoiquonfaitchef =="maj") UtilWin.Text = "MODIFICATION D'UN UTILISATEUR";
      UtilCou.Text = courriel;
      UtilPse.Text = pseudo;
      UtilNom.Text = nom;
      UtilPré.Text = prénom;
      UtilTél.Text = tél;
      UtilAva.Text = avatar;
      UtilAcc.Text = Convert.ToString(accès);
   }
   private void Click_UtilBoutVal(object sender, RoutedEventArgs e)    {
      if (UtilCou.Text=="" || UtilPse.Text=="" || UtilPss.Text=="") 
         MessageBox.Show("Les Champs Pseudo, Courriel et Mot de passe ne peuvent pas être nul");
      else {
         Dbm.InjectUtil(quoiquonfaitchef, id_user, UtilCou.Text, UtilPse.Text, UtilPss.Text, UtilNom.Text, UtilPré.Text, UtilTél.Text, UtilAva.Text, Convert.ToInt16(UtilAcc.Text));
         (Application.Current.MainWindow as MainWindow).RefreshUtilList();
         this.Close();
      }
   }
   private void Click_UtilBoutAnu(object sender, RoutedEventArgs e)    {
      this.Close();
   }
   private void OnKeyDownHandler(object sender, KeyEventArgs e)     {
      if (e.Key == Key.Escape)  {  Environment.Exit(0);    }
   }
}
