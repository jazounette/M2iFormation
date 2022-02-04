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
using FilRouge.Classes;
using System.Collections.ObjectModel;

namespace filrouge;

public partial class MainWindow : Window   {
   internal List<Dbm.Donnée> fourreTout;
   byte bodyActive = 1;/////1-utilisateurlist 2-topiclist 3-publilist
   int admin_id = -1;

   public MainWindow()  {
      InitializeComponent();
      ConnexWindow winConnex = new ConnexWindow();////décommenter après les tests
      winConnex.ShowDialog();////////////////////////décommenter après les tests
      // admin_id = 4;////////////////////////////////////commenter après les tests

      DispatcherTimer LiveTime = new DispatcherTimer();
      LiveTime.Interval = TimeSpan.FromSeconds(1);
      LiveTime.Tick += timer_Tick;
      LiveTime.Start();      

      WelcomeSir();

      RefreshUtilList();
   }
   void timer_Tick(object sender, EventArgs e){  IlEstExactement.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy - HH:mm:ss");  }
   public void SetAdmin(int admin_id){   this.admin_id = admin_id;   }
   public void WelcomeSir(){
      string logtime = DateTime.Now.ToString("HH:mm:ss");
      fourreTout = new List<Dbm.Donnée>();
      Dbm.LireUtil(fourreTout, "id_user", admin_id.ToString());
      faireAccèsInfo (fourreTout);
      BarreÉtat.Text = $"{fourreTout[0].Prénom} {fourreTout[0].Nom} ({fourreTout[0].Pseudo}) - {fourreTout[0].Accèsinfo} - logger à: {logtime}";
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
   private void AfficheListeUtil(){
      BarreÉtat.Background = Brushes.Black;  IlEstExactement.Background =  Brushes.Black;
      PanneauUtil.Visibility = Visibility.Visible;
      PanneauTopic.Visibility = Visibility.Collapsed;
      PanneauPubli.Visibility = Visibility.Collapsed;
      bodyActive = 1;
      RefreshUtilList();
   }
   private void AfficheListeTopic(){
      BarreÉtat.Background = Brushes.MidnightBlue;  IlEstExactement.Background =  Brushes.MidnightBlue;
      PanneauUtil.Visibility = Visibility.Collapsed;
      PanneauTopic.Visibility = Visibility.Visible;
      PanneauPubli.Visibility = Visibility.Collapsed;
      bodyActive = 2;
      RefreshTopicList();
   }
   private void DoubleClick_Topic(object sender, RoutedEventArgs e)    {
      BarreÉtat.Background = Brushes.Indigo;  IlEstExactement.Background =  Brushes.Indigo;
      PanneauUtil.Visibility = Visibility.Collapsed;
      PanneauTopic.Visibility = Visibility.Collapsed;
      PanneauPubli.Visibility = Visibility.Visible;
      bodyActive = 3;
      RefreshPubliList();
   }
   private void ÉditUtil(){
      Dbm.Donnée toto = (Dbm.Donnée)ListeUtil.SelectedItem;
      if (toto!=null) {
         UtilWindow winAjout = new UtilWindow("maj", toto.Id_user, toto.Courriel, toto.Pseudo, toto.Nom, toto.Prénom, toto.Tél, "", toto.Accès );
         winAjout.ShowDialog();
      }
   }
   private void ÉditPubli(){
      Dbm.Donnée ct = (Dbm.Donnée)ListeTopic.SelectedItem;
      Dbm.Donnée cp = (Dbm.Donnée)ListePubli.SelectedItem;
      if (ct!=null && cp!=null) {
         PubliWindow winAjoutPubli = new PubliWindow("maj", admin_id, ct.Id_topic, ct.Nom_topic, ct.Langage, ct.Date_top.ToString(), cp.Id_pub, cp.Nomprén, cp.Message);
         winAjoutPubli.ShowDialog();
      }        
   }
   private void Click_Édit(object sender, RoutedEventArgs e)    {
   Dbm.Donnée toto;
      switch (bodyActive) {
         case 1: ÉditUtil();  break;
         case 2: toto = (Dbm.Donnée)ListeTopic.SelectedItem;
            if (toto!=null) {
               TopicWindow winAjoutTopic = new TopicWindow("maj", admin_id, toto.Id_topic, toto.Date_top.ToString(), toto.Nomprén, toto.Nom_topic, toto.Description, toto.Langage, toto.Nb_rep);
               winAjoutTopic.ShowDialog();            }
         break;
         case 3: ÉditPubli();  break;
      }
   }
   private void Click_Ajout(object sender, RoutedEventArgs e)    {
      switch (bodyActive) {
         case 1: UtilWindow winAjoutUtil = new UtilWindow("nouv");
                 winAjoutUtil.ShowDialog();
         break;
         case 2: TopicWindow winAjoutTopic = new TopicWindow("nouv", admin_id);
                 winAjoutTopic.ShowDialog();
         break;
         case 3: Dbm.Donnée ct = (Dbm.Donnée)ListeTopic.SelectedItem;
            if (ct!=null) {
               PubliWindow winAjoutPubli = new PubliWindow("nouv", admin_id, ct.Id_topic, ct.Nom_topic, ct.Langage, ct.Date_top.ToString());
               winAjoutPubli.ShowDialog();         }
         break;
      }
   }
   private void Click_Conn(object sender, RoutedEventArgs e)    {
      ConnexWindow winConnex = new ConnexWindow();
      winConnex.ShowDialog();
      WelcomeSir();
   }
   private void Archivage(){
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
   private void Suppression() {
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
   private void Validation(){
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
   private void Aidationage(){
      string textAide = System.IO.File.ReadAllText(@".\Aide.txt");
      MessageBox.Show(textAide);
   }
   private void DoubleClick_Util(object sender, RoutedEventArgs e)    {   ÉditUtil();   }
   private void DoubleClick_Publi(object sender, RoutedEventArgs e)   {   ÉditPubli();  }
   private void Click_ListeUtil(object sender, RoutedEventArgs e)  {  AfficheListeUtil();   }
   private void Click_ListeTopic(object sender, RoutedEventArgs e) {  AfficheListeTopic();  }
   private void Click_Arch(object sender, RoutedEventArgs e)       {  Archivage();    }
   private void Click_Supp(object sender, RoutedEventArgs e)       {  Suppression();  }
   private void Click_Vali(object sender, RoutedEventArgs e)       {  Validation();   }
   private void Click_Aide(object sender, RoutedEventArgs e)       {  Aidationage();  }
   private void Click_Quit(object sender, RoutedEventArgs e)       {  Environment.Exit(0);  }

   private void RetourArrière(object sender, MouseButtonEventArgs e) {
      if(e.ChangedButton==MouseButton.XButton1 && bodyActive==3) AfficheListeTopic();
      e.Handled = true;
   }
   private void OnKeyDownHandler(object sender, KeyEventArgs e) {
      if (e.Key == Key.Escape)  Environment.Exit(0);
      if (e.Key == Key.Back)    Archivage();
      if (e.Key == Key.Delete)  Suppression();
      if (e.Key == Key.Enter)   Validation();
      if (e.Key == Key.F1)      Aidationage();
      if (e.Key == Key.F2)      AfficheListeUtil();
      if (e.Key == Key.F3)      AfficheListeTopic();
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
