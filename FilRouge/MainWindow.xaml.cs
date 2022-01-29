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

public partial class MainWindow : Window   {
   internal List<Dbm.Donnée> fourreTout;

   public MainWindow()  {
      InitializeComponent();
      DateTime ilEstExactement = DateTime.Now;
      RefreshUtilList();
   }
   public void RefreshUtilList(){
      fourreTout = new List<Dbm.Donnée>();
      Dbm.LireUtil(fourreTout);
      faireNomPrén(fourreTout);    faireAccèsInfo(fourreTout);
      ListeUtil.ItemsSource = fourreTout;
   }
   private void Click_ListeUtil(object sender, RoutedEventArgs e)    {
      PanneauUtil.Visibility = Visibility.Visible;
      PanneauTopic.Visibility = Visibility.Collapsed;
      PanneauPubli.Visibility = Visibility.Collapsed;
      RefreshUtilList();
   }
   private void Click_ListeTopic(object sender, RoutedEventArgs e)    {
      PanneauUtil.Visibility = Visibility.Collapsed;
      PanneauTopic.Visibility = Visibility.Visible;
      PanneauPubli.Visibility = Visibility.Collapsed;
      fourreTout = new List<Dbm.Donnée>();
      Dbm.LireTopic(fourreTout);
      faireNomPrén(fourreTout);
      ListeTopic.ItemsSource = fourreTout;
   }
   private void Click_Topic(object sender, RoutedEventArgs e)    {
      PanneauUtil.Visibility = Visibility.Collapsed;
      PanneauTopic.Visibility = Visibility.Collapsed;
      PanneauPubli.Visibility = Visibility.Visible;
      Dbm.Donnée toto = (Dbm.Donnée)ListeTopic.SelectedItem;
      TitrePubliA.Text = $"   {toto.Nomprén}.";
      TitrePubliB.Text = $"Sujet {toto.Id_topic} - {toto.Langage} - {toto.Nom_topic}";
      TitrePubliC.Text = $"{toto.Date_top}    ";
      TitrePubliD.Text = $"{toto.Description}";
      fourreTout = new List<Dbm.Donnée>();
      Dbm.LirePubli(toto.Id_topic,fourreTout);
      faireNomPrén(fourreTout);
      ListePubli.ItemsSource = fourreTout;
   }
   private void Click_Util(object sender, RoutedEventArgs e)    {
      Dbm.Donnée toto = (Dbm.Donnée)ListeUtil.SelectedItem;
      UtilWindow winAjout = new UtilWindow("maj", toto.Id_user, toto.Courriel, toto.Pseudo, toto.Nom, toto.Prénom, toto.Tél, "", toto.Accès );
      winAjout.Show();
   }
   private void Click_AjoutUtil(object sender, RoutedEventArgs e)    {
      UtilWindow winAjout = new UtilWindow("nouv");
      winAjout.Show();
   }
   private void Click_Publi(object sender, RoutedEventArgs e)    {
   }
   private void Click_Édit(object sender, RoutedEventArgs e)    {
   }
   private void Click_Arch(object sender, RoutedEventArgs e)    {
   }
   private void Click_Supp(object sender, RoutedEventArgs e)    {
   }
   private void Click_Vali(object sender, RoutedEventArgs e)    {
   }
   private void Click_Déco(object sender, RoutedEventArgs e)    {
   }

   private void Click_Quit(object sender, RoutedEventArgs e)    {
      Environment.Exit(0);
   }

   private void OnKeyDownHandler(object sender, KeyEventArgs e)     {
      if (e.Key == Key.Escape)  {  Environment.Exit(0);    }
   }

   private void faireNomPrén(List<Dbm.Donnée> toto){  
      for (int i=0; i<toto.Count; i++) toto[i].Nomprén = $"{toto[i].Prénom} \"{toto[i].Pseudo}\" {toto[i].Nom}";    }

   private void faireAccèsInfo(List<Dbm.Donnée> toto) {
      for (int i=0; i<toto.Count; i++) {
         switch (toto[i].Accès) {
            case 0: toto[i].Accèsinfo = ">> Administrateur <<"; break;
            case 1: toto[i].Accèsinfo = "Utilisateur"; break;
            case 2: toto[i].Accèsinfo = "Enreg. en attente"; break;
            default: toto[i].Accèsinfo = "Circulez, ya rien à voir"; break;         }         }
   }
}
