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
   byte bodyActive = 1;/////1-utilisateur 2-topiclist 3-publilist

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
   public void RefreshTopicList(){
      fourreTout = new List<Dbm.Donnée>();
      Dbm.LireTopic(fourreTout);
      faireNomPrén(fourreTout);
      ListeTopic.ItemsSource = fourreTout;
   }
   public void RefreshPubliList(){
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
   private void Click_ListeUtil(object sender, RoutedEventArgs e)    {
      BarreÉtat.Text = "Rose: utilisateur non validé - Bleu: Admin - Éditer: double click sur un utilisateur";
      PanneauUtil.Visibility = Visibility.Visible;
      PanneauTopic.Visibility = Visibility.Collapsed;
      PanneauPubli.Visibility = Visibility.Collapsed;
      bodyActive = 1;
      RefreshUtilList();
   }
   private void Click_ListeTopic(object sender, RoutedEventArgs e)    {
      BarreÉtat.Text = "ROSE: sujet non validé - VERT: sujet archivé - Ctrl+click:valider - Atl+click:archier";
      PanneauUtil.Visibility = Visibility.Collapsed;
      PanneauTopic.Visibility = Visibility.Visible;
      PanneauPubli.Visibility = Visibility.Collapsed;
      bodyActive = 2;
      RefreshTopicList();
   }
   private void DoubleClick_Topic(object sender, RoutedEventArgs e)    {
      BarreÉtat.Text = "ROSE: publication non validée - VERT: publication archivée - Ctrl+click:valider - Atl+click:archier";
      PanneauUtil.Visibility = Visibility.Collapsed;
      PanneauTopic.Visibility = Visibility.Collapsed;
      PanneauPubli.Visibility = Visibility.Visible;
      bodyActive = 3;
      RefreshPubliList();
   }
   private void DoubleClick_Util(object sender, RoutedEventArgs e)    {
      Dbm.Donnée toto = (Dbm.Donnée)ListeUtil.SelectedItem;
      UtilWindow winAjout = new UtilWindow("maj", toto.Id_user, toto.Courriel, toto.Pseudo, toto.Nom, toto.Prénom, toto.Tél, "", toto.Accès );
      winAjout.Show();
   }
   private void DoubleClick_Publi(object sender, RoutedEventArgs e)    {
   }
   private void Click_AjoutUtil(object sender, RoutedEventArgs e)    {
      UtilWindow winAjout = new UtilWindow("nouv");
      winAjout.Show();
   }
   private void Click_Édit(object sender, RoutedEventArgs e)    {
   }
   private void Click_Arch(object sender, RoutedEventArgs e)    {
      Dbm.Donnée toto;
      switch (bodyActive) {
         case 2: toto = (Dbm.Donnée)ListeTopic.SelectedItem;
            if (toto!=null) {
               Dbm.ArchivTopic(toto.Id_topic, true, !toto.Arch_top);//// int ArchivTopic(int id_topic, bool archiv=true, bool vrai=true)
               RefreshTopicList();     }
         break;
         case 3: toto = (Dbm.Donnée)ListePubli.SelectedItem;
            if (toto!=null) {
               Dbm.ArchivPubli(toto.Id_pub, true, !toto.Arch_pub);////// int ArchivPubli(int id_publication, bool archiv = true, bool vrai=true)
               RefreshPubliList();     }
         break;
      }
   }
   private void Click_Supp(object sender, RoutedEventArgs e)    {
      Dbm.Donnée toto;
      string alertMess = "";
      switch (bodyActive) {
         case 1:  toto = (Dbm.Donnée)ListeUtil.SelectedItem;
            if (toto != null) {
               alertMess = $"Attention, l'utilisateur N°{toto.Id_user}\n{toto.Nomprén}\n(ainsi que toutes ses publications)\nva être supprimé";
               MessageBoxResult résultat = MessageBox.Show(alertMess, "Suppression Utilisateur", MessageBoxButton.YesNo, MessageBoxImage.Information);
               if (résultat == MessageBoxResult.Yes) Dbm.EffaceUtil(toto.Id_user);
               RefreshUtilList();      }
         break;
         case 2: toto = (Dbm.Donnée)ListeTopic.SelectedItem;
            if (toto!=null) {
               alertMess = $"Attention, le sujet N°{toto.Id_topic}\n{toto.Nom_topic}\n(ainsi que toutes les publications le concernant)\nva être supprimé";
               MessageBoxResult résultat = MessageBox.Show(alertMess, "Suppression Sujet", MessageBoxButton.YesNo, MessageBoxImage.Information);
               if (résultat == MessageBoxResult.Yes) Dbm.ArchivTopic(toto.Id_topic, false);//// int ArchivTopic(int id_topic, bool archiv = true)
               RefreshTopicList();     }
         break;
         case 3: toto = (Dbm.Donnée)ListePubli.SelectedItem;
            if (toto!=null) {
               alertMess = $"Attention, la publication N°{toto.Id_pub}\nde {toto.Nomprén}\nva être supprimée";
               MessageBoxResult résultat = MessageBox.Show(alertMess, "Suppression Publication", MessageBoxButton.YesNo, MessageBoxImage.Information);
               if (résultat == MessageBoxResult.Yes) Dbm.ArchivPubli(toto.Id_pub, false);////// int ArchivPubli(int id_publication, bool archiv = true)
               RefreshPubliList();     }
         break;
      }
   }
   private void Click_Vali(object sender, RoutedEventArgs e)    {
      Dbm.Donnée toto;
      switch (bodyActive) {
         case 1:  toto = (Dbm.Donnée)ListeUtil.SelectedItem;
            if (toto != null) {
               if (toto.Accès==0) MessageBox.Show("Cet utilisateur est un administrateur\nil posséde déjà un niveau d'accès plus fort", "Validation Impossible", MessageBoxButton.OK, MessageBoxImage.Information);
               else if (toto.Accès==1) MessageBox.Show("Cet utilisateur a déjà été validé", "Validation Impossible", MessageBoxButton.OK, MessageBoxImage.Information);
               else Dbm.AccésUtil(toto.Id_user, 1);//////// int AccésUtil(int id_utilisateur, int droitAccés)
               RefreshUtilList();     }
         break;
         case 2: toto = (Dbm.Donnée)ListeTopic.SelectedItem;
            if (toto!=null) {
               Dbm.ValideTruc("topic", toto.Id_topic, !toto.Vali_top);/// int ValideTruc(string àtable, int id_software, bool état)
               RefreshTopicList();
            }
         break;
         case 3: toto = (Dbm.Donnée)ListePubli.SelectedItem;
            if (toto!=null) {
               Dbm.ValideTruc("publication", toto.Id_pub, !toto.Vali_pub);/// int ValideTruc(string àtable, int id_software, bool état)
               RefreshPubliList();
            }
         break;
      }
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
            case 0: toto[i].Accèsinfo = "Administrateur"; break;
            case 1: toto[i].Accèsinfo = "Utilisateur"; break;
            case 2: toto[i].Accèsinfo = "Enreg. en attente"; break;
            default: toto[i].Accèsinfo = "Circulez, ya rien à voir"; break;         }         }
   }
}
