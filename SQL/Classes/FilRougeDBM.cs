namespace SQL.Classes;
using MySql.Data.MySqlClient;
using UtilitaireJC;


internal static class Dbm {
   static string chaineDeConne = "server=localhost;database=m2iformation;uid=root;pwd=toto;"; // c'est des connes et elles sont à la queueleuleu
   static MySqlConnection conne = new MySqlConnection(chaineDeConne);
   static MySqlCommand requête;
   static MySqlDataReader lecteur;

   public struct donnée {
      private string langage="", nom_topic="", description="", nom="", prénom="", pseudo="", message="", courriel="", tél="";
      private DateTime date_top=DateTime.Now, date_pub=DateTime.Now, date_user=DateTime.Now;
      private int id_topic=-1, id_user=-1, id_pub=-1, nb_rep=-1, accès=-1;
      ///////////faire geteur, seteur sinon problème avec la listview xaml
      public string Langage { get=>langage; set=>langage = value; }
      public string Nom_topic { get=>nom_topic; set=>nom_topic  = value; }
      public string Description  { get=>description; set=>description  = value; }
      public string Nom { get=>nom; set=>nom  = value; }
      public string Prénom { get=>prénom; set=>prénom  = value; }
      public string Pseudo { get=>pseudo; set=>pseudo  = value; }
      public string Message { get=>message; set=>message  = value; }
      public string Courriel { get=>courriel; set=>courriel  = value; }
      public string Tél { get=>tél; set=>tél  = value; }

      public DateTime Date_top { get=>date_top; set=>date_top  = value; }
      public DateTime Date_pub { get=>date_pub; set=>date_pub  = value; }
      public DateTime Date_user { get=>date_user; set=>date_user  = value; }

      public int Id_topic { get=>id_topic; set=>id_topic  = value; }
      public int Id_user { get=>id_user; set=>id_user  = value; }
      public int Id_pub { get=>id_pub; set=>id_pub  = value; }
      public int Nb_rep { get=>nb_rep; set=>nb_rep  = value; }
      public int Accès { get=>accès; set=>accès  = value; }

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
      public donnée (int Id_user, DateTime Date_user, string Nom, string Prénom, string Courriel, string Tél, string Pseudo, int Accès){
         id_user = Id_user;                              ///constructeur pour le retour lit utilisateur
         date_user = Date_user;
         nom = Nom;
         prénom = Prénom;
         courriel = Courriel;
         tél = Tél;
         pseudo = Pseudo;
         accès = Accès;
      }
   }
////////////////////////////////////////////////////////////////////////////////////////ouvre,ferme la connexion
   private static void OuvreDBM(){
      try{  conne.Open();  }
      catch (Exception ex){   Konzolo.Affiche($"croustonne? ici base de donnée, ya un problème!!!\n{ex}\n");   }
   }
   private static void FermeDBM(){    conne.Dispose();    conne.Close();    }
///////////////////////////////////////////////////////////////////////////////////////////lit le nombre de topic
   public static int CompteTopic () {
      int topicMax = 0;
      OuvreDBM();
      requête.CommandText = "SELECT COUNT(id_topic) FROM topic;";
      lecteur = requête.ExecuteReader();
      while (lecteur.Read()) topicMax = lecteur.GetInt16(0);
      lecteur.Close();      FermeDBM();
      return topicMax;
   }
///////////////////////////////////////////////////////////////////////////////////////////////lit un utilisateur
   public static int LireUtil(List<donnée> concombre, string champ, string valeur) { //valeur: ce que l'on cherche  /  champ: où on cherche
      string nom, prénom, courriel, tél, pseudo;
      int id_user, accès;
      DateTime date_user;
      try {
         OuvreDBM();
         requête = conne.CreateCommand();
         requête.CommandText = $"select * from utilisateur where {champ}=\"{valeur}\";";   //fonctionne pas avec les alias, sais pas pourquoi??? lié au faite que les paramètres champ et valeur sont des chaines
         lecteur = requête.ExecuteReader();
         while (lecteur.Read()) {
            id_user =  lecteur.GetInt16(0);
            date_user =  lecteur.GetDateTime(1);
            nom =  lecteur.GetString(2);
            prénom =  lecteur.GetString(3);
            courriel =  lecteur.GetString(4);
            tél =  lecteur.GetString(5);
            pseudo =  lecteur.GetString(6);
            accès = lecteur.GetInt16(9);
            concombre.Add(new donnée(id_user, date_user, nom, prénom, courriel, tél , pseudo, accès));
         }
         lecteur.Close();      FermeDBM();
         return 0;
      } catch {  return 1;  }
   }
///////////////////////////////////////////////////////////////////////////////////////////////////lit les topics
   public static void LireTopic(List<donnée> concombre, int début=-1, int fin=-1) {
      string langage, nom_topic, description, nom, prénom, pseudo;
      int id_topic, id_user, nb_rep;
      DateTime date_top;

      OuvreDBM();
      requête = conne.CreateCommand();
      requête.CommandText = $"select * from topic join utilisateur on topic.id_user=utilisateur.id_user{Limite(ref début, fin)} order by id_topic;";
      requête.Parameters.Add(new MySqlParameter("@Deb", début));
      requête.Parameters.Add(new MySqlParameter("@Fin", fin));

      lecteur = requête.ExecuteReader();
      while (lecteur.Read()) {
         id_topic =  lecteur.GetInt16(0);
         date_top =  lecteur.GetDateTime(1);
         id_user =  lecteur.GetInt16(2);
         langage =  lecteur.GetString(3);
         nom_topic =  lecteur.GetString(4);
         description =  lecteur.GetString(5);
         nb_rep =  lecteur.GetInt16(6);

         nom = lecteur.GetString(11);
         prénom = lecteur.GetString(12);
         pseudo = lecteur.GetString(15);
         concombre.Add(new donnée(id_topic, date_top, id_user, langage, nom_topic, description, nb_rep, nom , prénom, pseudo));
      }
      lecteur.Close();      FermeDBM();
   }
///////////////////////////////////////////////////////////////////////////////////////////////lit les publications
   public static void LirePubli(int pubNum, List<donnée> mandarine, int début=-1, int fin=-1) {
      string message, nom, prénom, pseudo;
      int id_pub;
      DateTime date_pub;

      //select * from publication 
      //join topic on publication.id_topic=topic.id_topic
      //join utilisateur on publication.id_user=utilisateur.id_user 
      //where publication.id_topic=6     //remplacer 6 par @Choix
      //limit 2,2;                       //remplacer 2,2 par @Deb,@Fin

      OuvreDBM();
      requête = conne.CreateCommand();
      requête.CommandText = $"select * from publication join topic on publication.id_topic=topic.id_topic join utilisateur on publication.id_user=utilisateur.id_user where publication.id_topic=@Choix{Limite(ref début, fin)};";
      requête.Parameters.Add(new MySqlParameter("@Choix", pubNum));
      requête.Parameters.Add(new MySqlParameter("@Deb", début));
      requête.Parameters.Add(new MySqlParameter("@Fin", fin));
      lecteur = requête.ExecuteReader();
      while (lecteur.Read()) {
         id_pub = lecteur.GetInt16(0);
         date_pub = lecteur.GetDateTime(1);
         message = lecteur.GetString(6);
         nom = lecteur.GetString(18);
         prénom = lecteur.GetString(19);
         pseudo = lecteur.GetString(22);
         mandarine.Add(new donnée(id_pub, date_pub, message, nom, prénom, pseudo));
      }
      lecteur.Close();      FermeDBM();
   }
////////////////////////////////////////////////////////injecte un utilisateur dans la base de donnée
   public static int InjectUtil(string email, string pseudo, string mdp, string nom="", string prénom="", string tel="", string avatURL="") {
      OuvreDBM();
      requête = conne.CreateCommand();
      requête.CommandText = "insert into utilisateur values (NULL, CURRENT_TIMESTAMP, @Nom, @Prenom, @eMail, @Tel, @Pseudo, @MDP, @AvatURL, @Acces);";
      requête.Parameters.Add(new MySqlParameter("@Nom", nom));
      requête.Parameters.Add(new MySqlParameter("@prenom", prénom));
      requête.Parameters.Add(new MySqlParameter("@eMail", email));
      requête.Parameters.Add(new MySqlParameter("@Tel", tel));
      requête.Parameters.Add(new MySqlParameter("@Pseudo", pseudo));
      requête.Parameters.Add(new MySqlParameter("@MDP", mdp));///////////////////hash mot de passe à prévoir
      requête.Parameters.Add(new MySqlParameter("@AvatURL", avatURL));
      requête.Parameters.Add(new MySqlParameter("@Acces", 2));///////////////////2 car pas encore comfirmé par l'admin au moment de l'inscription
      int nbLigne = requête.ExecuteNonQuery();
      FermeDBM();
      return nbLigne;
   }
////////////////////////////////////////////////////////////////injecte un topic dans la base de donnée
   public static int InjectTopic(int id_user, string lang="", string nomtop="", string descrip="", int nb_rep=0){
      OuvreDBM();
      requête = conne.CreateCommand();
      requête.CommandText = "insert into topic values (NULL, CURRENT_TIMESTAMP, @IdUser, @Lang, @NomTop, @Descrip, @NbRep, @Archive, @Valide);";
      requête.Parameters.Add(new MySqlParameter("@IdUser", id_user));
      requête.Parameters.Add(new MySqlParameter("@Lang", lang));
      requête.Parameters.Add(new MySqlParameter("@NomTop", nomtop));
      requête.Parameters.Add(new MySqlParameter("@Descrip", descrip));
      requête.Parameters.Add(new MySqlParameter("@NbRep", nb_rep));
      requête.Parameters.Add(new MySqlParameter("@Archive", false));////////////par défaut non archivé à la création
      requête.Parameters.Add(new MySqlParameter("@Valide", true));//////////////le topic est valide à la création, l'admin peut la déactiver plus tard
      int nbLigne = requête.ExecuteNonQuery();
      FermeDBM();
      return nbLigne;
   }
///////////////////////////////////////////////////////////injecte une publication dans la base de donnée
   public static int InjectPubli(int id_topic, int id_user, string message) {
      OuvreDBM();
      requête = conne.CreateCommand();
      requête.CommandText = "insert into publication values (NULL, CURRENT_TIMESTAMP, @IdTopic, @IdUser, @Archive, @Valide, @Message);";
      requête.Parameters.Add(new MySqlParameter("@IdTopic", id_topic));
      requête.Parameters.Add(new MySqlParameter("@IdUser", id_user));
      requête.Parameters.Add(new MySqlParameter("@Archive", false));/////////par défaut non archivé à la création
      requête.Parameters.Add(new MySqlParameter("@Valide", false));//////////une publication être validé par admin, donc false à la création
      requête.Parameters.Add(new MySqlParameter("@Message", message));
      int nbLigne = requête.ExecuteNonQuery();
      FermeDBM();
      return nbLigne;
   }
////////////////////////////////////////////////////////////////////////////archive/delete une publication
   public static int ArchivPubli(int id_publication, bool archiv = true){//archive par défaut, si archive vaut false alors delete definitif
      string reukékette=(archiv) ? "update publication set arch_pub=true where id_pub=@CelleLà;" : "delete from publication where id_pub=@CelleLà;";
      try {
         OuvreDBM();
         requête = conne.CreateCommand();
         requête.CommandText = reukékette;
         requête.Parameters.Add(new MySqlParameter("@CelleLà", id_publication));
         int nbLigne = requête.ExecuteNonQuery();
         FermeDBM();
         return 0;
      } catch {  return 1; }
   }
/////////////////////////////////////////archive/delete un topic et archive/delete toutes ses publications
   public static int ArchivTopic(int id_topic, bool archiv = true){//archive par défaut, si archive vaut false alors delete définitif
      (string nom, string champ)[] titotable = {  ("publication", "arch_pub"), ("topic", "arch_top")  };
      string reukékette="";
      try {
         OuvreDBM();
         foreach((string nom, string champ) table in titotable) {
            reukékette=(archiv) ? $"update {table.nom} set {table.champ}=true where id_topic=@CelleLà;" : $"delete from {table.nom} where id_topic=@CelleLà;";
            // Konzolo.Affiche($"{reukékette}\n");
            requête = conne.CreateCommand();
            requête.CommandText = reukékette;
            requête.Parameters.Add(new MySqlParameter("@CelleLà", id_topic));
            requête.ExecuteNonQuery();            }
         FermeDBM();
         return 0;
      } catch {  return 1;  }
   }
////////////////change le droit d'accés d'un utilisateur (0:admin, 1:utilisateur, 2:inscription non validé)
   public static int AccésUtil(int id_utilisateur, int droitAccés){
      if (droitAccés>2 && droitAccés<0) return 1;////////erreur 1: droit accès valide: 0, 1, 2.
      OuvreDBM();
      requête = conne.CreateCommand();
      requête.CommandText = "update utilisateur set acces=@DroitAc where id_user=@CeluiCi";
      requête.Parameters.Add(new MySqlParameter("@CeluiCi", id_utilisateur));
      requête.Parameters.Add(new MySqlParameter("@DroitAc", droitAccés));
      requête.ExecuteNonQuery();
      FermeDBM();
      return 0;
   }
//////////////////efface (definitivement) un utilisateur et toutes ses publication/topic (because clée étrangère)
////////////////////////////doit-on effacer les topic/publications quand on efface l'utilisateur qui les a crées?
/////////////////////////////////////////////////////quand on vire un utilisateur, ses topics/publications reste?
   public static void EffaceUtil(int id_utilisateur){
      string[] reukêkette = { "set foreign_key_checks=0;",
                              "delete from publication where id_user=@CeluiCi;",
                              "delete from topic where id_user=@CeluiCi;",
                              "delete from utilisateur where id_user=@CeluiCi;",
                              "set foreign_key_checks=1;"   };
      OuvreDBM();
      foreach(string req in reukêkette) {
         requête = conne.CreateCommand();
         requête.CommandText = req;
         requête.Parameters.Add(new MySqlParameter("@CeluiCi", id_utilisateur));
         requête.ExecuteNonQuery();      }
      FermeDBM();
   }


///////////////////////////////////compose la chaine qui limite le nombre de ligne renvoyé par la requête
   static string Limite(ref int début, int fin){
      if (début>=0 && fin<0) return " limit @Deb"; //un seul param, limite au N première ligne
      if (début>0 && fin>=0) {   début--;   return " limit @Deb,@Fin";   } //deux param, nombre de ligne à partir d'index(commence à zêro)
      return "";  //aucun param valide, pas de limite
   }

}