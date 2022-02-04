////////////////////////////////////////////////////////////////////////////////////////////// Version2
namespace FilRouge.Classes;
using MySql.Data.MySqlClient;
using UtilitaireJC;
using System.Security.Cryptography;
using System.Text;


internal static class Dbm {
   static string chaineDeConne = "server=localhost;database=m2iformation;uid=root;pwd=toto;"; // c'est des connes et elles sont à la queueleuleu
   static MySqlConnection conne = new MySqlConnection(chaineDeConne);
   static MySqlCommand requête;
   static MySqlDataReader lecteur;

   public class Donnée {
      private string langage="", nom_topic="", description="", nom="", prénom="", pseudo="", message="", courriel="", tél="";
      private DateTime date_top=DateTime.Now, date_pub=DateTime.Now, date_user=DateTime.Now;
      private int id_topic=-1, id_user=-1, id_pub=-1, nb_rep=-1, accès=-1;
      private bool arch_top, arch_pub, vali_top, vali_pub;
      private string nomprén = "", accèsinfo = "";

      public string Langage { get=>langage; set=>langage = value; }
      public string Nom_topic { get=>nom_topic; set=>nom_topic  = value; }
      public string Description  { get=>description; set=>description  = value; }
      public string Nom { get=>nom; set=>nom  = value; }
      public string Prénom { get=>prénom; set=>prénom  = value; }
      public string Pseudo { get=>pseudo; set=>pseudo  = value; }
      public string Message { get=>message; set=>message  = value; }
      public string Courriel { get=>courriel; set=>courriel  = value; }
      public string Tél { get=>tél; set=>tél  = value; }
      public string Nomprén { get=>nomprén; set=>nomprén  = value; }
      public string Accèsinfo { get=>accèsinfo; set=>accèsinfo  = value; }

      public DateTime Date_top { get=>date_top; set=>date_top  = value; }
      public DateTime Date_pub { get=>date_pub; set=>date_pub  = value; }
      public DateTime Date_user { get=>date_user; set=>date_user  = value; }

      public int Id_topic { get=>id_topic; set=>id_topic  = value; }
      public int Id_user { get=>id_user; set=>id_user  = value; }
      public int Id_pub { get=>id_pub; set=>id_pub  = value; }
      public int Nb_rep { get=>nb_rep; set=>nb_rep  = value; }
      public int Accès { get=>accès; set=>accès  = value; }

      public bool Arch_top { get=>arch_top; set=>arch_top = value; }
      public bool Arch_pub { get=>arch_pub; set=>arch_pub = value; }
      public bool Vali_top { get=>vali_top; set=>vali_top = value; }
      public bool Vali_pub { get=>vali_pub; set=>vali_pub = value; }

      public Donnée (int Id_topic, DateTime Date_top, int Id_user, string Langage, string Nom_topic, string Description, int Nb_rep, bool Arch_top, bool Vali_top, string Nom, string Prénom, string Pseudo) {
         id_topic = Id_topic;                            ///conctructeur pour le retour lit topic
         date_top = Date_top;
         id_user = Id_user;
         langage = Langage;
         nom_topic = Nom_topic;
         description = Description;
         nb_rep = Nb_rep;
         arch_top = Arch_top;
         vali_top = Vali_top;
         nom = Nom;
         prénom = Prénom;
         pseudo = Pseudo;
      }
      public Donnée (int Id_pub, DateTime Date_pub, bool Arch_pub, bool Vali_pub, string Message, string Nom, string Prénom, string Pseudo){
         id_pub = Id_pub;                                ///constructeur pour le retour lit publication
         date_pub = Date_pub;
         arch_pub = Arch_pub;
         vali_pub = Vali_pub;
         message = Message;
         nom = Nom;
         prénom = Prénom;
         pseudo = Pseudo;
      }
      public Donnée (int Id_user, DateTime Date_user, string Nom, string Prénom, string Courriel, string Tél, string Pseudo, int Accès){
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
      /////////////mettre une alerte box en lieu et place du Konzolo///////////////////////////////////////////
   }
   private static void FermeDBM(){    conne.Dispose();    conne.Close();    }
///////////////////////////////////////////////////////////////////////////////////////////////lit un/des utilisateur(s)
   public static int LireUtil(List<Donnée> concombre, string champ = "*", string valeur = "*") { //valeur: ce que l'on cherche  /  champ: où on cherche
      string nom, prénom, courriel, tél, pseudo, skøll;
      int id_user, accès;
      DateTime date_user;
      try {
         OuvreDBM();
         skøll = !(champ=="*" && valeur=="*") ? $" where {champ}=\"{valeur}\"" : "";
         requête = conne.CreateCommand();
         requête.CommandText = $"select * from utilisateur{skøll};";   //fonctionne pas avec les alias, sais pas pourquoi??? lié au faite que les paramètres champ et valeur sont des chaines, surement à cause de mysql.
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
            concombre.Add(new Donnée(id_user, date_user, nom, prénom, courriel, tél , pseudo, accès));
         }
         lecteur.Close();      FermeDBM();
         return 0;
      } catch {  return 1;  }
   }
///////////////////////////////////////////////////////////////////////////////////////////////////lit les topics
   public static int LireTopic(List<Donnée> concombre, int début=-1, int fin=-1) {
      string langage, nom_topic, description, nom, prénom, pseudo;
      int id_topic, id_user, nb_rep;
      DateTime date_top;
      bool arch_top, vali_top;

      try {
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
            arch_top = lecteur.GetBoolean(7);
            vali_top = lecteur.GetBoolean(8);
            nom = lecteur.GetString(11);
            prénom = lecteur.GetString(12);
            pseudo = lecteur.GetString(15);
            concombre.Add(new Donnée(id_topic, date_top, id_user, langage, nom_topic, description, nb_rep, arch_top, vali_top, nom , prénom, pseudo));
         }
         lecteur.Close();      FermeDBM();
         return 0;
      } catch {  return 1;  }
   }
///////////////////////////////////////////////////////////////////////////////////////////////lit les publications
   public static int LirePubli(int pubNum, List<Donnée> mandarine, int début=-1, int fin=-1) {
      string message, nom, prénom, pseudo;
      int id_pub;
      DateTime date_pub;
      bool arch_pub, vali_pub;

      //select * from publication 
      //join topic on publication.id_topic=topic.id_topic
      //join utilisateur on publication.id_user=utilisateur.id_user 
      //where publication.id_topic=6     //remplacer 6 par @Choix
      //limit 2,2;                       //remplacer 2,2 par @Deb,@Fin
      try {
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
            arch_pub = lecteur.GetBoolean(4);
            vali_pub = lecteur.GetBoolean(5);
            message = lecteur.GetString(6);
            nom = lecteur.GetString(18);
            prénom = lecteur.GetString(19);
            pseudo = lecteur.GetString(22);
            mandarine.Add(new Donnée(id_pub, date_pub, arch_pub, vali_pub, message, nom, prénom, pseudo));
         }
         lecteur.Close();      FermeDBM();
         return 0;
      } catch {  return 1;  }
   }
////////////////////////////////////////////////////////injecte/update un utilisateur dans la base de donnée
   public static int InjectUtil(string quoiquonfaitchef, int id_user, string email, string pseudo, string mdp, string nom="", string prénom="", string tel="", string avatURL="", int accès = 2) {
      string reukékette = "";
      if (quoiquonfaitchef=="nouv") reukékette = "insert into utilisateur values (NULL, CURRENT_TIMESTAMP, @Nom, @Prenom, @eMail, @Tel, @Pseudo, @MDP, @AvatURL, @Acces);";
      if (quoiquonfaitchef=="maj") reukékette = "update utilisateur set nom=@Nom, prenom=@Prenom, email=@eMail, telephone=@Tel, pseudo=@Pseudo, avatar=@AvatURL, acces=@Acces where id_user=@ID;";
      OuvreDBM();
      requête = conne.CreateCommand();
      requête.CommandText = reukékette;
      requête.Parameters.Add(new MySqlParameter("@ID", id_user));
      requête.Parameters.Add(new MySqlParameter("@Nom", nom));
      requête.Parameters.Add(new MySqlParameter("@prenom", prénom));
      requête.Parameters.Add(new MySqlParameter("@eMail", email));
      requête.Parameters.Add(new MySqlParameter("@Tel", tel));
      requête.Parameters.Add(new MySqlParameter("@Pseudo", pseudo));
      requête.Parameters.Add(new MySqlParameter("@MDP", mdp));//////////////hash mot de passe à prévoir
      requête.Parameters.Add(new MySqlParameter("@AvatURL", avatURL));
      requête.Parameters.Add(new MySqlParameter("@Acces", accès));//////////2 par défaut car pas encore comfirmé par l'admin au moment de l'inscription
      int nbLigne = requête.ExecuteNonQuery();
      FermeDBM();
      return nbLigne;
   }
////////////////////////////////////////////////////////////////injecte/update un topic dans la base de donnée
   public static int InjectTopic(string quoiquonfaitchef, int id_user, int id_topic=-1, string lang="", string nomtop="", string descrip="", int nb_rep=0){
      string reukékette = "";
      if (quoiquonfaitchef=="nouv") reukékette = "insert into topic values (NULL, CURRENT_TIMESTAMP, @IdUser, @Lang, @NomTop, @Descrip, @NbRep, @Archive, @Valide);";
      if (quoiquonfaitchef=="maj") reukékette = "update topic set langage=@Lang, nom_topic=@NomTop, description=@Descrip where id_topic=@IdTopic;";
      OuvreDBM();
      requête = conne.CreateCommand();
      requête.CommandText = reukékette;
      requête.Parameters.Add(new MySqlParameter("@IdUser", id_user));
      requête.Parameters.Add(new MySqlParameter("@IdTopic", id_topic));
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
///////////////////////////////////////////////////////////injecte/update une publication dans la base de donnée
   public static int InjectPubli(string quoiquonfaitchef, int id_topic, int id_user, int id_pub, string message) {
      string reukékette = "";
      if (quoiquonfaitchef=="nouv") reukékette = "insert into publication values (NULL, CURRENT_TIMESTAMP, @IdTopic, @IdUser, @Archive, @Valide, @Message);";
      if (quoiquonfaitchef=="maj") reukékette = "update publication set message=@Message where id_pub=@IdPub;";
      OuvreDBM();
      requête = conne.CreateCommand();
      requête.CommandText = reukékette;
      requête.Parameters.Add(new MySqlParameter("@IdTopic", id_topic));
      requête.Parameters.Add(new MySqlParameter("@IdUser", id_user));
      requête.Parameters.Add(new MySqlParameter("@IdPub", id_pub));
      requête.Parameters.Add(new MySqlParameter("@Archive", false));/////////par défaut non archivé à la création
      requête.Parameters.Add(new MySqlParameter("@Valide", false));//////////une publication être validé par admin, donc false à la création
      requête.Parameters.Add(new MySqlParameter("@Message", message));
      int nbLigne = requête.ExecuteNonQuery();
      FermeDBM();
      return nbLigne;
   }
////////////////////////////////////////////////////////////////////////////archive/delete une publication
   public static int ArchivPubli(int id_publication, bool archiv = true, bool vrai=true){//archive par défaut, si archive vaut false alors delete definitif
      string reukékette=(archiv) ? "update publication set arch_pub=@Vrai where id_pub=@CelleLà;" : "delete from publication where id_pub=@CelleLà;";
      try {
         OuvreDBM();
         requête = conne.CreateCommand();
         requête.CommandText = reukékette;
         requête.Parameters.Add(new MySqlParameter("@CelleLà", id_publication));
         requête.Parameters.Add(new MySqlParameter("@Vrai", vrai));
         int nbLigne = requête.ExecuteNonQuery();
         FermeDBM();
         return 0;
      } catch {  return 1; }
   }
/////////////////////////////////////////archive où delete un topic et archive où delete toutes ses publications
   public static int ArchivTopic(int id_topic, bool archiv=true, bool vrai=true){//archive par défaut, si archive vaut false alors delete définitif
      (string nom, string champ)[] titotable = {  ("publication", "arch_pub"), ("topic", "arch_top")  };
      string reukékette="";
      try {
         OuvreDBM();
         foreach((string nom, string champ) table in titotable) {
            reukékette=(archiv) ? $"update {table.nom} set {table.champ}=@Vrai where id_topic=@CelleLà;" : $"delete from {table.nom} where id_topic=@CelleLà;";
            // Konzolo.Affiche($"{reukékette}\n");
            requête = conne.CreateCommand();
            requête.CommandText = reukékette;
            requête.Parameters.Add(new MySqlParameter("@CelleLà", id_topic));
            requête.Parameters.Add(new MySqlParameter("@Vrai", vrai));
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
////////////////////////////////////////////////////////////////////////change mot de passe d'un utilisateur
   public static int MDPupdate(int id_utilisateur, string MDP){
      OuvreDBM();
      requête = conne.CreateCommand();
      requête.CommandText = $"update utilisateur set motdepasse=\"{MDP}\" where id_user=@CeluiCi";
      requête.Parameters.Add(new MySqlParameter("@CeluiCi", id_utilisateur));
      requête.ExecuteNonQuery();
      FermeDBM();
      return 0; 
   }
////////////////////////////////////////////////////////verifi le couple login (pseudo/email) - mot de passe
//select id_user, acces from utilisateur where (pseudo="jazounette" or email="cham.gero@gmail.com") and motdepasse="toto";
   public static int VerifLogin(string login, string mdp, ref int id, ref int accès){
      string[] titotable = { "pseudo", "email" };
      OuvreDBM();
      foreach (string table in titotable){
         requête = conne.CreateCommand();
         requête.CommandText = $"select id_user, acces from utilisateur where {table}=\"{login}\" and motdepasse=\"{mdp}\"";
         lecteur = requête.ExecuteReader();
         while (lecteur.Read()) {
            id = lecteur.GetInt16(0);
            accès = lecteur.GetInt16(1);     }
         lecteur.Close();      }
      FermeDBM();
      return 0;
   }
////////////////////////////////////////////////////////////////////////////valide une publication où un topic
   public static int ValideTruc(string àtable, int id_software, bool état){
      string genou = "", hibou = "";
      if (àtable == "publication" ) {  hibou = "id_pub"; genou = "vali_pub";  }
      if (àtable == "topic") {  hibou = "id_topic"; genou = "vali_top";  }
      try {
         OuvreDBM();
         requête = conne.CreateCommand();
         requête.CommandText = $"update {àtable} set {genou}=@Etat where {hibou}=@ID";
         requête.Parameters.Add(new MySqlParameter("@Etat", état));
         requête.Parameters.Add(new MySqlParameter("@ID", id_software));
         requête.ExecuteNonQuery();
         FermeDBM();
         return 0;
      } catch { return 1; }
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
///////////////////////////////////////////////////////////////////mise à jour du nombre de publication d'un sujet
   public static void MajPubNombre (int heidi) {
      int résultat = 0;
      OuvreDBM();
      requête = conne.CreateCommand();
      requête.CommandText = $"select count(id_pub) from publication where id_topic=@IdToupic;";
      requête.Parameters.Add(new MySqlParameter("@IdToupic", heidi));
      lecteur = requête.ExecuteReader();
      while (lecteur.Read()) résultat = lecteur.GetInt16(0);
      lecteur.Close();

      requête = conne.CreateCommand();
      requête.CommandText = $"update topic set nb_rep=@Result where id_topic=@IdToupic;";
      requête.Parameters.Add(new MySqlParameter("@Result", résultat));
      requête.Parameters.Add(new MySqlParameter("@IdToupic", heidi));
      requête.ExecuteNonQuery();
      FermeDBM();
   }
////////////////////////////////////////test si le pseudo ou le mot de passe existe déjà dans la base de donnée
   public static bool UtilDéjàExist (int id_user, string courriel, string pseudo) {
      bool jaiTrouvéChef = false;
      OuvreDBM();
      requête = conne.CreateCommand();
      requête.CommandText = $"select id_user from utilisateur where email=\"{courriel}\" or pseudo=\"{pseudo}\";";
      lecteur = requête.ExecuteReader();
      while (lecteur.Read())    if (lecteur.GetInt16(0) != id_user) jaiTrouvéChef = true;
      lecteur.Close();
      FermeDBM();
      return (jaiTrouvéChef);
   }
///////////////////////////////////////////////////////////////////////////////////////////hash mot de passe
   public static string EncodePassword(string password){
      byte[] bytes   = Encoding.Unicode.GetBytes(password);
      byte[] inArray = HashAlgorithm.Create("SHA1").ComputeHash(bytes);
      return Convert.ToBase64String(inArray);
   }



///////////////////////////////////compose la chaine qui limite le nombre de ligne renvoyé par la requête
   static string Limite(ref int début, int fin){
      if (début>=0 && fin<0) return " limit @Deb"; //un seul param, limite au N première ligne
      if (début>0 && fin>=0) {   début--;   return " limit @Deb,@Fin";   } //deux param, nombre de ligne à partir d'index(commence à zêro)
      return "";  //aucun param valide, pas de limite
   }

}