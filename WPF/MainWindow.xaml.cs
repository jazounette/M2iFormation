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
public partial class MainWindow : Window   {
   internal ObservableCollection<Personne> monNomEst;
   int editHeidi = -1;

   public MainWindow()    {
      InitializeComponent();
      monNomEst = new ObservableCollection<Personne>();
      monNomEst.Add(new Personne { Titre = "M.", Nom = "David", Prenom = "Jordannatte", Courriel = "jj.dav@caramail.fr", Tel = "03.23.67.45.18" });
      monNomEst.Add(new Personne { Titre = "M.", Nom = "Lagaffe", Prenom = "Gaston", Courriel = "gaston.l@gmail.com", Tel = "06.12.65.78.56" });
      monNomEst.Add(new Personne { Titre = "Mlle.", Nom = "Chirac", Prenom = "Bernadette", Courriel = "labernadette.l@gmail.com", Tel = "06.14.18.91.65" });
      ListeEnBoite.ItemsSource = monNomEst;

   }

   private void Ajouter_Contact(object sender, RoutedEventArgs e)    {
      string titre = "";
      if(RadBoutMons.IsChecked == true) titre = "M.";
      if(RadBoutMamm.IsChecked == true) titre = "Mme.";
      if(RadBoutMlle.IsChecked == true) titre = "Mlle.";

      if (editHeidi == -1) {
         monNomEst.Add(new Personne { Titre = titre, Nom = NomTextBox.Text, Prenom = PrenomTextBox.Text, Courriel = CourrielTextBox.Text, Tel = TelTextBox.Text });
      }
      else {
         monNomEst[editHeidi] = new Personne { Titre = titre, Nom = NomTextBox.Text, Prenom = PrenomTextBox.Text, Courriel = CourrielTextBox.Text, Tel = TelTextBox.Text };
         editHeidi = -1;
      }
      ListeEnBoite.ItemsSource = monNomEst;
   }

   private void Modifier_Contact(object sender, RoutedEventArgs e)    {
      try {
         Personne titi = (Personne)ListeEnBoite.SelectedItem;
         NomTextBox.Text = titi.Nom;
         PrenomTextBox.Text = titi.Prenom;
         CourrielTextBox.Text = titi.Courriel;
         TelTextBox.Text = titi.Tel;
         if (titi.Titre == "M.") RadBoutMons.IsChecked = true;
         if (titi.Titre == "Mme.") RadBoutMamm.IsChecked = true;
         if (titi.Titre == "Mlle.") RadBoutMlle.IsChecked = true;
         editHeidi = ListeEnBoite.SelectedIndex;
      } catch {}

   }

   private void Supprimer_Contact(object sender, RoutedEventArgs e)    {
      // MessageBox.Show(ListeEnBoite.SelectedIndex.ToString());
      try {
         monNomEst.RemoveAt(ListeEnBoite.SelectedIndex);
         ListeEnBoite.ItemsSource = monNomEst;
      } catch {}

   }

   private void OnKeyDownHandler(object sender, KeyEventArgs e)     {
      if (e.Key == Key.Escape)  {  Environment.Exit(0);    }
   }

   private void ListeEnBoite_SizeChanged(object sender, SizeChangedEventArgs e)   {
      ListView listView = sender as ListView;
      GridView gView = listView.View as GridView;
      var workingWidth = listView.ActualWidth - SystemParameters.VerticalScrollBarWidth -10; // take into account vertical scrollbar
      gView.Columns[0].Width = workingWidth*0.05;
      gView.Columns[1].Width = workingWidth*0.2;
      gView.Columns[2].Width = workingWidth*0.2;
      gView.Columns[3].Width = workingWidth*0.3;
      gView.Columns[4].Width = workingWidth*0.25;
   }

   public struct PersonneBis {
      public string titre, nom, prenom, courriel, tel;
      public PersonneBis (string Titre, string Nom, string Prénom, string Courriel, string Tél){
         titre = Titre;
         nom = Nom;
         prenom = Prénom;
         courriel = Courriel;
         tel = Tél;
      }
      public string Titre { get => titre; set =>  titre = value; }
      public string Nom { get => nom; set => nom = value; }
      public string Prenom { get => prenom; set => prenom = value; }
      public string Courriel { get => courriel; set => courriel = value; }
      public string Tel { get => tel ; set => tel = value; }
   }

   public struct Personne   {
      // public Personne (string Titre, string Nom, string Prenom, string Courriel, string Tel) {
      //    this.Titre=Titre;  this.Nom=Nom;   this.Prenom=Prenom;   this.Courriel=Courriel;  this.Tel=Tel;  }
      public string Titre { get; set; }
      public string Nom { get; set; }
      public string Prenom { get; set; }
      public string Courriel { get; set; }
      public string Tel { get; set; }
   }

   // {Binding Titre}
   // {Binding Nom}
   // {Binding Prenom}
   // {Binding Courriel}
   // {Binding Tel}

}
