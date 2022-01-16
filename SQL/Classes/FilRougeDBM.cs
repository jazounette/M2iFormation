namespace SQL.Classes;
using MySql.Data.MySqlClient;
using UtilitaireJC;


internal static class Dbm {
   static string chaineDeConne = "server=localhost;database=m2iformation;uid=root;pwd=toto;";
   static MySqlConnection conne = new MySqlConnection(chaineDeConne);
   static MySqlCommand requête;
   static MySqlDataReader lecteur;

   public struct donnée {
      public string langage="", nom_topic="", description="", nom="", prénom="", pseudo="", message="";
      public DateTime date_top=DateTime.Now, date_pub=DateTime.Now;
      public int id_topic=-1, id_user=-1, id_pub=-1, nb_rep=-1;

      public donnée (int Id_topic, DateTime Date_top, int Id_user, string Langage, string Nom_topic, string Description, int Nb_rep, string Nom, string Prénom, string Pseudo) {
         id_topic = Id_topic;                               ///conctructeur pour le retour lit topic
         date_top = Date_top;
         id_user = Id_user;
         langage = Langage;
         nom_topic = Nom_topic;
         description = Description;
         nb_rep = Nb_rep;
         nom = Nom;
         prénom = Prénom;
         pseudo = Pseudo;
      }
      public donnée (int Id_pub, DateTime Date_pub, string Message, string Nom, string Prénom, string Pseudo){
         id_pub = Id_pub;                                ///constructeur pour le retour lit publication
         date_pub = Date_pub;
         message = Message;
         nom = Nom;
         prénom = Prénom;
         pseudo = Pseudo;
      }
   }

   private static void OuvreDBM(){
      try{  conne.Open();  }
      catch (Exception ex){   Konzolo.Affiche($"croustonne? ici base de donnée, ya un problème!!!\n{ex}\n");   }
   }
   private static void FermeDBM(){    conne.Dispose();    conne.Close();    }
///////////////////////////////////////////////////////////////////////////////////////////////////lit les topics
   public static void LireTopic(List<donnée> concombre) {
      string langage, nom_topic, description, nom, prénom, pseudo;
      int id_topic, id_user, nb_rep;
      DateTime date_top;

      OuvreDBM();
      requête = conne.CreateCommand();
      requête.CommandText = "select * from topic join utilisateur on topic.id_user=utilisateur.id_user;";
      lecteur = requête.ExecuteReader();
      while (lecteur.Read()) {
         id_topic =  lecteur.GetInt16(0);
         date_top =  lecteur.GetDateTime(1);
         id_user =  lecteur.GetInt16(2);
         langage =  lecteur.GetString(3);
         nom_topic =  lecteur.GetString(4);
         description =  lecteur.GetString(5);
         nb_rep =  lecteur.GetInt16(6);
         nom = lecteur.GetString(9);
         prénom = lecteur.GetString(10);
         pseudo = lecteur.GetString(13);
         concombre.Add(new donnée(id_topic, date_top, id_user, langage, nom_topic, description, nb_rep, nom , prénom, pseudo));
      }
      lecteur.Close();      FermeDBM();
   }
//////////////////////////////////////////////////////////////////////////////////////////////lit le nombre de topic
   public static int CompteTopic () {
      int topicMax = 0;
      OuvreDBM();
      requête.CommandText = "SELECT COUNT(id_topic) FROM topic;";
      lecteur = requête.ExecuteReader();
      while (lecteur.Read()) topicMax = lecteur.GetInt16(0);
      lecteur.Close();      FermeDBM();
      return topicMax;
   }
/////////////////////////////////////////////////////////////////////////////////////////////////lit les publications
   public static void LirePubli(int pubNum, List<donnée> mandarine) {
      string message, nom, prénom, pseudo;
      int id_pub;
      DateTime date_pub;

      //select * from publication 
      //join topic on publication.id_topic=topic.id_topic 
      //join utilisateur on publication.id_user=utilisateur.id_user 
      //where publication.id_topic=6;     //remplacer 6 par @Choix

      OuvreDBM();
      requête = conne.CreateCommand();
      requête.CommandText = "select * from publication join topic on publication.id_topic=topic.id_topic join utilisateur on publication.id_user=utilisateur.id_user where publication.id_topic=@Choix;";
      requête.Parameters.Add(new MySqlParameter("@Choix", pubNum));
      lecteur = requête.ExecuteReader();
      while (lecteur.Read()) {
         id_pub = lecteur.GetInt16(0);
         date_pub = lecteur.GetDateTime(1);
         message = lecteur.GetString(4);
         nom = lecteur.GetString(14);
         prénom = lecteur.GetString(15);
         pseudo = lecteur.GetString(18);
         mandarine.Add(new donnée(id_pub, date_pub, message, nom, prénom, pseudo));
      }
      lecteur.Close();      FermeDBM();
   }
////////////////////////////////////////////////////////injecte un utilisateur dans la base de donnée
   public static int InjectUtil(string email, string pseudo, string mdp, string nom="", string prénom="", string tel="", string avatURL="") {
      OuvreDBM();
      requête = conne.CreateCommand();
      requête.CommandText = "insert into utilisateur values (NULL, CURRENT_TIMESTAMP, @Nom, @Prenom, @eMail, @Tel, @Pseudo, @MDP, @AvatURL);";
      requête.Parameters.Add(new MySqlParameter("@Nom", nom));
      requête.Parameters.Add(new MySqlParameter("@prenom", prénom));
      requête.Parameters.Add(new MySqlParameter("@eMail", email));
      requête.Parameters.Add(new MySqlParameter("@Tel", tel));
      requête.Parameters.Add(new MySqlParameter("@Pseudo", pseudo));
      requête.Parameters.Add(new MySqlParameter("@MDP", mdp));
      requête.Parameters.Add(new MySqlParameter("@AvatURL", avatURL));
      int nbLigne = requête.ExecuteNonQuery();
      FermeDBM();
      return nbLigne;
   }
////////////////////////////////////////////////////////////////injecte un topic dans la base de donnée
   public static int InjectTopic(int id_user, string lang="", string nomtop="", string descrip="", int nb_rep=0){
      OuvreDBM();
      requête = conne.CreateCommand();
      requête.CommandText = "insert into topic values (NULL, CURRENT_TIMESTAMP, @IdUser, @Lang, @NomTop, @Descrip, @NbRep);";
      requête.Parameters.Add(new MySqlParameter("@IdUser", id_user));
      requête.Parameters.Add(new MySqlParameter("@Lang", lang));
      requête.Parameters.Add(new MySqlParameter("@NomTop", nomtop));
      requête.Parameters.Add(new MySqlParameter("@Descrip", descrip));
      requête.Parameters.Add(new MySqlParameter("@NbRep", nb_rep));
      int nbLigne = requête.ExecuteNonQuery();
      FermeDBM();
      return nbLigne;
   }
///////////////////////////////////////////////////////////injecte une publication dans la base de donnée
   public static int InjectPubli(int id_topic, int id_user, string message) {
      OuvreDBM();
      requête = conne.CreateCommand();
      requête.CommandText = "insert into publication values (NULL, CURRENT_TIMESTAMP, @IdTopic, @IdUser, @Message);";
      requête.Parameters.Add(new MySqlParameter("@IdTopic", id_topic));
      requête.Parameters.Add(new MySqlParameter("@IdUser", id_user));
      requête.Parameters.Add(new MySqlParameter("@Message", message));
      int nbLigne = requête.ExecuteNonQuery();
      FermeDBM();
      return nbLigne;
   }

}