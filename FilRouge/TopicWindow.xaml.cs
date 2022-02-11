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

public partial class TopicWindow : Window   {
   string quoiquonfaitchef = "";
   int id_user = -1, id_topic = -1;

   public TopicWindow(string quoiquonfaitchef, int id_user, int id_topic=-1, string date="", string nomprén="", string titre="", string descri="", string langage="", int nb_rep=-1)  {
      InitializeComponent();
      this.quoiquonfaitchef = quoiquonfaitchef;
      this.id_user = id_user;
      this.id_topic = id_topic;
      if (quoiquonfaitchef =="nouv") {         
         TitreWin.Text = "NOUVEAU SUJET";
         SousTitreA.Visibility = Visibility.Collapsed;
         SousTitreB.Visibility = Visibility.Collapsed;
         this.Height=180;
      }
      if (quoiquonfaitchef =="maj")  {
         TitreWin.Text = $"MODIFICATION DU SUJET N°{id_topic}";
         SousTitreA.Text = $" Crée par: {nomprén}"; 
         SousTitreB.Text = $"Réponse{((nb_rep>1) ? "s" : "")}: {nb_rep}  -  Date de création: {date}  ";
         ChangeRadioBout(langage);
      }
      TopicTitre.Text = titre;
      TopicDescri.Text = descri;
   }

   private void Validation() {
      string langage = LitRadioBout();
      Dbm.InjectTopic(quoiquonfaitchef, id_user, id_topic, langage, TopicTitre.Text, TopicDescri.Text);
      (Application.Current.MainWindow as MainWindow).RefreshTopicList();
      this.Close();
   }

   private void Click_TopicBoutVal(object sender, RoutedEventArgs e)    {  Validation();  }
   private void Click_TopicBoutAnu(object sender, RoutedEventArgs e)    {  this.Close();  }

   private void OnKeyDownHandler(object sender, KeyEventArgs e)     {
      if (e.Key == Key.Escape)  {  this.Close();  }
      if (e.Key == Key.Enter)   {  Validation();  }
   }

   private void ChangeRadioBout(string langage){
      langage = langage.ToLower();
      switch (langage) {
         case "c#": RadBoutCsharp.IsChecked = true; break;
         case "php": RadBoutPHP.IsChecked = true; break;
         case "javascript": RadBoutJavS.IsChecked = true; break;
         case "html/css": RadBoutHTML.IsChecked = true; break;
         case "java": RadBoutJava.IsChecked = true; break;
         case "cobol": RadBoutCob.IsChecked = true; break;
         case "python": RadBoutPyt.IsChecked = true; break;
         case "lua": RadBoutLua.IsChecked = true; break;
      }
   }

   private string LitRadioBout (){
      string langage = "";
      if (RadBoutCsharp.IsChecked == true) langage = "C#";
      if (RadBoutPHP.IsChecked == true) langage = "PHP";
      if (RadBoutJavS.IsChecked == true) langage = "JavaScript";
      if (RadBoutHTML.IsChecked == true) langage = "HTML/CSS";
      if (RadBoutJava.IsChecked == true) langage = "Java";
      if (RadBoutCob.IsChecked == true) langage = "Cobol";
      if (RadBoutPyt.IsChecked == true) langage = "Python";
      if (RadBoutLua.IsChecked == true) langage = "Lua";
      return langage;
   }
}
