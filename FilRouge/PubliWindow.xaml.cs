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

public partial class PubliWindow : Window   {
   string quoiquonfaitchef = "";
   int id_user = -1, id_topic = -1, id_pub = -1;

   public PubliWindow(string quoiquonfaitchef, int id_user, int id_topic, string nomtop, string lang, string date, int id_pub=-1, string nomprém="", string message="")  {
      InitializeComponent();
      this.quoiquonfaitchef = quoiquonfaitchef;
      this.id_user = id_user;
      this.id_topic = id_topic;
      this.id_pub = id_pub;
      SousTitreA.Text = nomtop;
      SousTitreB.Text = $"{lang} - Sujet: {id_topic}";
      SousTitreC.Text = $"{date}  ";
      if (quoiquonfaitchef =="nouv") {         
         TitreWin.Text = "NOUVELLE PUBLICATION";
         Auteur.Visibility = Visibility.Collapsed;
      }
      if (quoiquonfaitchef =="maj")  {
         this.Height+=30;
         TitreWin.Text = $"MODIFICATION DE LA PUBLICATION N°{id_pub}";
         Auteur.Text = $"Auteur: {nomprém}";
         PubliMess.Text = message;
      }
   }

   private void Validation(){
      Dbm.InjectPubli(quoiquonfaitchef, id_topic, id_user, id_pub, PubliMess.Text);
      Dbm.MajPubNombre(id_topic);
      (Application.Current.MainWindow as MainWindow).RefreshPubliList();
      this.Close();
   }

   private void Click_PubliBoutVal(object sender, RoutedEventArgs e)  {  Validation();  }
   private void Click_PubliBoutAnu(object sender, RoutedEventArgs e)  {  this.Close();  }

   private void OnKeyDownHandler(object sender, KeyEventArgs e)     {
      if (e.Key == Key.Escape)  {  this.Close();  }
      if (e.Key == Key.Enter)   {  Validation();  }/////////voir pour faire un controle+entré plutot
   }
}
