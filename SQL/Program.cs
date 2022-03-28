// using System.Data.SqlClient;  //version Microsoft
using MySql.Data.MySqlClient;
using UtilitaireJC;
using System.Text.RegularExpressions;
// using SQL.Classes;


// /////////////////////////////////////////////////////TEST madame Gragnanski, TEST!!!
// string connetionString = "server=localhost;database=m2iformation;uid=root;pwd=toto;";
// MySqlConnection conne = new MySqlConnection(connetionString);
// try{  conne.Open();     Konzolo.Affiche($"tout marche bien base de donnée ! \n");   }
// catch (Exception ex){   Konzolo.Affiche($"croustonne? ici base de donnée, ya un problème!!!\n{ex}\n");   }

// // DateTime tatadadate = DateTime.Now;             //pas besoin de faire ça, simplement utiliser CURRENT_TIMESTAMP
// // string tatadadate = "2022-03-03 11:11:11";
// // Konzolo.Affiche($"{tatadadate}\n");

// ////////////////////////////////////////////attention le champ CUST_ID (clé primaire) de la table business n'est pas en auto increment
// string requête = @"INSERT INTO business (INCORP_DATE, NAME, STATE_ID, CUST_ID) VALUES (CURRENT_TIMESTAMP, 'zzzzzzzz', '136497', 22)";
// MySqlCommand commande = new MySqlCommand(requête, conne);
// try {
//    int nbligne = commande.ExecuteNonQuery();
//    Konzolo.Affiche($"tout marche bien navette, {nbligne} modif à été faite\n");
// }
// catch {
//    Konzolo.Affiche($"c'est de la merdoume cette vilaine requête\n");
//    Konzolo.Affiche($"{requête}\n");
// }
// conne.Close(); //////////////penser à bien fermer la connexion après chaque requête


// conne.Open();
// MySqlCommand cmd = conne.CreateCommand();
// cmd.CommandText = "select * from business;";
// MySqlDataReader reader = cmd.ExecuteReader();
// while (reader.Read())   Console.WriteLine($"{reader.GetString(0)} - {reader.GetString(1)} - {reader.GetString(2)} - {reader.GetString(3)}");
// conne.Close();


// //   <ItemGroup>
// //       <PackageReference Include="System.Data.SqlClient" Version="4.6.0" />
// //   </ItemGroup>



///////////////////////////////////////////////////////////TPX1 (la banque peu populaire)version3 (persistance de données)
// List<Compte> clienTest = new List<Compte> { 
//       new Compte(new Client("rodriguez", "raoul", "06.12.33.80.75", 1, 1F)),
//       new Compte(new Client("fabre", "denize", "06.22.33.44.55", 2, 5.5F))    };

// clienTest[0] = new Compte(new Client("rodriguez", "raoul", "06.12.33.80.75", 1, 1F));
// clienTest[1] = new Compte(new Client("fabre", "denize", "06.22.33.44.55", 2, 5.5F));
// clienTest[2] = new Compte(new Client("Lagaffe", "Gaston", "03.32.46.57.39", 3, 2.2F));

// Konzolo.Affiche($"{clienTest[0].Numéro}\n");
// Konzolo.Affiche($"{clienTest[1].Numéro}\n");

//////////////gérer les comptes en négatif
//////////////gérer la persistance avec un fichier json
//////////////mettre dans afficher compte, le taux pour les différents compte
//////////////lire fichier ligne par ligne et bourré le tableau avec jsonconvert (à teste pour recup les données du fichier)


// clienTest[0].Opération(1111.11F);
// clienTest[0].Opération(-222.1234F);
// clienTest[0].Opération(333F);
// clienTest[0].Opération(-11);
// clienTest[1].Opération(3333);
// clienTest[1].Opération(-444);
// clienTest[1].Opération(-55);


// Compte[] clienTest = new Compte[99];

// int choix = -1;
// do {
//    Console.Clear();
//    Konzolo.Couleur("blanc");
//    choix = IHM.Menu();
//    switch (choix) {
//       case 1: IHM.NouveauClient(clienTest); break;
//       case 2: IHM.Opération("dépot", clienTest); break;
//       case 3: IHM.Opération("retrait", clienTest); break;
//       case 4: IHM.AfficherCompte(clienTest); break;
//       case 5: IHM.ListeCompte(clienTest); break;
//       case 6: IHM.CalculInterets(clienTest); break;
//       case 0: IHM.Quitter(clienTest); break;
//       default: Konzolo.Affiche("ya rien à voir ici, circulé\n"); break;
//    }

// } while(true);


///////////////////////////////////////////////////projet fil rouge
////////////// faire des methodes update pour publication (quand un utilisateur modifie une publi dont il est l'auteur)
////////////// éditer un topic: changer description, titre, langage.
////////////// methode pour mettre à jour les infos utilisateur
////////////// methode pour changer mot de passe
////////////// gerer le hash du mot de passe utilisateur


// Console.BackgroundColor = ConsoleColor.DarkCyan;
// Console.Clear();

// ////////////////////////////////////test methode liretopic
// string nomprén = "";
// List<Dbm.donnée> prout = new List<Dbm.donnée>();
// Dbm.LireTopic(prout); //////////////lit tous les topics
// // Dbm.LireTopic(prout, 3,3); //////lit 3 topics à partir du topic 3
// foreach (Dbm.donnée val in prout ) {
//    nomprén = $"{val.Nom}, {val.Prénom} dit {val.Pseudo}";
//    Console.BackgroundColor = ConsoleColor.Black;
//    Console.WriteLine($"   {val.Id_topic,3} - {nomprén,-55} {val.Date_top} {val.Langage,16}   ");
//    Console.BackgroundColor = ConsoleColor.DarkCyan;
//    Console.WriteLine($"\t{val.Nom_topic}");
//    Console.WriteLine($"\t{val.Description}\n");
// }

// /////////////////////////////////////test methode comptetopic
// int choix = 0;
// int choixmax = Dbm.CompteTopic();
// while (Konzolo.LireInt36("\nquel sujet voulez-vous lire: ", ref choix)) {   if (choix>0  && choix<=choixmax) break;   }

// Console.Clear();

// ///////////////////////////////////////test methode LirePubli
// List<Dbm.donnée> géraldine = new List<Dbm.donnée>();
// Dbm.LirePubli(choix, géraldine); //////////////////lit toutes les publications
// // Dbm.LirePubli(choix, géraldine, 2, 2); /////////lit deux publis à partir de la publi 2
// foreach(Dbm.donnée val in géraldine) {
//    nomprén = $"{val.Nom}, {val.Prénom} dit {val.Pseudo}";
//    Console.BackgroundColor = ConsoleColor.Black;
//    Console.WriteLine($"    pub:{val.Id_pub:000} - {val.Date_pub}{nomprén,66}    ");
//    Console.BackgroundColor = ConsoleColor.DarkCyan;
//    Console.WriteLine($"{val.Message}\n");
// }

// ///////////////////////////////////////////test methode LireUtil
// List<Dbm.donnée> guendoline = new List<Dbm.donnée>();
// string typeCompte="";
// int erreur = Dbm.LireUtil(guendoline, "nom", "chamousse");////////////recherche un utilisateur dont le nom est chamousse
// foreach(Dbm.donnée val in guendoline) {
//    nomprén = $"{val.Nom}, {val.Prénom} dit {val.Pseudo}";
//    switch (val.Accès) {
//       case 0: typeCompte="Administrateur"; break;
//       case 1: typeCompte="Utilisateur"; break;
//       case 2: typeCompte="En attente d'enregistrement"; break;
//    }
//    Console.WriteLine($"utilisateur:{val.Id_user:000}\n{nomprén}\nInscrit le: {val.Date_user}\nCourriel: {val.Courriel}\nTéléphone: {val.Tél}");
//    Console.WriteLine($"Niveau d'accès: {typeCompte}\n");
// }

//////////////////////////////////////////test methode archivage publication
// Dbm.ArchivPubli(4);////////////////////////archive la publication 4
// Dbm.ArchivPubli(4, false);///efface définitivement la publication 4

////////////////////////////////////////test methode archivage topic (archive aussi toutes les publis qui en dépende)
// Dbm.ArchivTopic(1);//////////////////archive le topic 1 et toutes les pubications associées
// Dbm.ArchivTopic(1, false);///////////efface le topic 1 et toutes ses publications

//////////////////////////////////test methode change droit acces utilisateur (0:admin, 1:utilisateur, 2:non-enreg)
// Dbm.AccésUtil(2, 0);//////////////change l'accès utilisateur id_user:2 en admin
// Dbm.AccésUtil(9, 1);//////////////change l'accès utilisateur id_user:5 en utilisateur enregistré

//////////////////////////////////test methode efface un utilisateur;
// Dbm.EffaceUtil(1);///////////////efface l'utilisateur id_user=1 ainsi que toutes ses publications/topic

// /////////////////////////////////////////test methode utilInject
// Dbm.InjectUtil("tramiel.jakotte@atari.net", "thejack", "toto", "tramiel", "jack");

// /////////////////////////////////////////test methode injecttopic
// Dbm.InjectTopic(4, "proutoQ", "ça va les gens?", "comment ça avance pour vous ce fil rouge? bien? ou bien?", 11);

// /////////////////////////////////////////test methode injectpubli
// Dbm.InjectPubli(1, 4, "il fait super chaud ici, heureusement que j'ai de quoi me désaltéré...");



/////////////////////////////////////////////////////////////// tp regex valencienne
int id_user;
string prénom, nom, courriel, tél;
int choisir=0, quiçadonc=0, retour=0;
bool quitter = false;

string chaineDeConne = "server=localhost;database=m2iformation;uid=root;pwd=toto;";
MySqlConnection conne = new MySqlConnection(chaineDeConne);
MySqlCommand requête;
MySqlDataReader lecteur;

while (!quitter){
   Console.Clear();
   Menu();
   while (!Konzolo.LireInt36("choix:", ref choisir));
   switch (choisir) {
      case 0: quitter = true; break;////ici faire plutôt un environement.exit comme ça pas besoin de gérer le bool quitter
      case 1: LireUtil();  Konzolo.Attendre();  break;///////////////affiche la liste des gens
      case 2: Konzolo.Affiche($"ajoutage\n"); //////////////////////////////////ajoute une gen
         do {  nom = Konzolo.LireString("Nom: ");  } while (!SuisJe("nom", nom));
         do {  prénom = Konzolo.LireString("Prénom: ");  } while (!SuisJe("prénom", prénom));
         do {  courriel = Konzolo.LireString("Adresse email: ");  } while (!SuisJe("email", courriel));
         do {  tél = Konzolo.LireString("Numéro de téléphone: ");  } while (!SuisJe("tél", tél));
         retour = InjectUtil(prénom, nom, courriel, tél);
         if (retour == -1) Konzolo.Affiche($"Erreur de base de donnée\n");
         else Konzolo.Affiche($"{retour} personne a été ajouté\n");
         Konzolo.Attendre();
      break;
      case 3: Konzolo.Affiche($"supprimage\n"); ////////////////////////////////enléve une gen
         while (!Konzolo.LireInt36("ID de lutilisateur à éffacer: ", ref quiçadonc));
         retour = DelUtil(quiçadonc);
         if (retour == -1) Konzolo.Affiche($"Erreur de base de donnée\n");
         else if (retour == 0) Konzolo.Affiche($"ID introuvable\n");
         else Konzolo.Affiche($"l'Opération éffaçage est un franc succès\n");
         Konzolo.Attendre();
      break;
   }
}
Konzolo.Affiche($"@+ bisou :o)\n");

void Menu(){
   Konzolo.Affiche($"\n\t\tAU MENU DU JOUR\n");
   Konzolo.Affiche($"\t1-affiche toutes les personnes\n");
   Konzolo.Affiche($"\t2-ajoute une personne\n");
   Konzolo.Affiche($"\t3-supprime une personne\n");
   Konzolo.Affiche($"\t0-quitter\n\n");
}

void OuvreDBM(){
   try{  conne.Open();  }
   catch (Exception ex){   Konzolo.Affiche($"croustonne? ici base de donnée, ya un problème!!!\n{ex}\n");   }
}
void FermeDBM(){    conne.Dispose();    conne.Close();    }

int LireUtil() {
   Konzolo.Affiche($" ID         Nom           Prénom                      Courriel               Téléphone\n");
   try {
      OuvreDBM();
      requête = conne.CreateCommand();
      requête.CommandText = $"select * from personne;";
      lecteur = requête.ExecuteReader();
      while (lecteur.Read()) {
         id_user =  lecteur.GetInt16(0);
         // titre =  lecteur.GetString(1);
         prénom =  lecteur.GetString(2);
         nom =  lecteur.GetString(3);
         courriel =  lecteur.GetString(4);
         tél =  lecteur.GetString(5);
         Konzolo.Affiche($"{id_user,4:000} {nom,15} {prénom,15} {courriel,30} {tél,20}\n");
      }
      lecteur.Close();      FermeDBM();
      return 0;
   } catch {  return -1;  }
}

int InjectUtil(string prénom, string nom, string email, string tél) {
   tél = FormatTélStr(tél);////////formatage du num de tél
   try {
      OuvreDBM();
      requête = conne.CreateCommand();
      requête.CommandText = "insert into personne values (NULL, NULL, @Prenom, @Nom, @eMail, @Tel);";
      requête.Parameters.Add(new MySqlParameter("@Prenom", prénom));
      requête.Parameters.Add(new MySqlParameter("@Nom", nom));
      requête.Parameters.Add(new MySqlParameter("@eMail", email));
      requête.Parameters.Add(new MySqlParameter("@Tel", tél));
      int nbLigne = requête.ExecuteNonQuery();
      FermeDBM();
      return nbLigne;
   } catch {  return -1;  }
}

int DelUtil(int id_user){
   try {
      OuvreDBM();
      requête = conne.CreateCommand();
      requête.CommandText = "delete from personne where id=@CeluiLà;";
      requête.Parameters.Add(new MySqlParameter("@CeluiLà", id_user));
      int nbLigne = requête.ExecuteNonQuery();
      FermeDBM();
      return nbLigne;
   } catch {  return -1; }
}

bool SuisJe (string zun, string testmadamegraniansky){
   string patron;
   switch (zun){
      case "nom" : patron = @"^[A-ZÉÈÊÔÖÀÂÎÏ_\s\-]*$"; break;
      case "prénom" : patron = @"^[A-ZÉÈÊËÔÖÀÂÎÏ]{1}[a-zA-Zéèëêôöàâîï_\s\-]*$"; break;
      case "email" : patron =  @"^([a-zA-Z0-9\.\-_]+)@([a-zA-Z0-9\-_]+)(\.)?([a-zA-Z0-9\-_]+)?(\.){1}([a-zA-Z]{2,11})$"; break;
      case "tél" : patron = @"^([0|\+33|33]+)(\.|\-|\s)?([1-9]{1})((\.|\-|\s)?[0-9]{2}){4}$"; break;
      default: return false;
   }
   return Regex.IsMatch(testmadamegraniansky, patron);
}

string FormatTélStr (string titi) {
            // +33 6 59 78 65 32 => Le Bon Format
            // 33 6 59 78 65 32
            // 03 20 45 69 87
            // 06-23-45-69-87
            // 06.23.45.69.87
            // 0723456987
   titi = Regex.Replace(titi, @"[\.\-\s]+", "");
   titi = Regex.Replace(titi, @"^0|^33|^\+33", "+33 ");
   for (int i=5; i<=14; i+=3) titi = titi.Insert(i, " ");
   return titi;
}

string FormatTél (string toto){///////////////marche pas si tel de la forme: 0612345678  donne: +33 612345678   manque les espaces
   List<(string pat, string rep)> titi = new List<(string pat, string rep)> {(@"[\.\-]+", " "), (@"^(0|33)", "+33 "),  (@"\s+", " ")};
   foreach (var S in titi) toto = Regex.Replace(toto, S.pat, S.rep);
   return toto;
}

