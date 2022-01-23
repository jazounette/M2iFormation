// using System.Data.SqlClient;  //version Microsoft
using MySql.Data.MySqlClient;
using UtilitaireJC;
using SQL.Classes;


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
////////////// faire des methodes update pour les tables utilisateur, publication (quand un utilisateur modifie une publi dont il est l'auteur)
////////////// methode pour mettre à jour les infos utilisateur
////////////// methode pour changer mot de passe
////////////// gerer le hash du mot de passe utilisateur
////////////// ajouter methode pour supprimer(definitivement, pas archivage) utilisateur


Console.BackgroundColor = ConsoleColor.DarkCyan;
Console.Clear();

////////////////////////////////////test methode liretopic
string nomprén = "";
List<Dbm.donnée> prout = new List<Dbm.donnée>();
Dbm.LireTopic(prout); //////////////lit tous les topics
// Dbm.LireTopic(prout, 3,3); //////lit 3 topics à partir du topic 3
foreach (Dbm.donnée val in prout ) {
   nomprén = $"{val.Nom}, {val.Prénom} dit {val.Pseudo}";
   Console.BackgroundColor = ConsoleColor.Black;
   Console.WriteLine($"   {val.Id_topic,3} - {nomprén,-55} {val.Date_top} {val.Langage,16}   ");
   Console.BackgroundColor = ConsoleColor.DarkCyan;
   Console.WriteLine($"\t{val.Nom_topic}");
   Console.WriteLine($"\t{val.Description}\n");
}

/////////////////////////////////////test methode comptetopic
int choix = 0;
int choixmax = Dbm.CompteTopic();
while (Konzolo.LireInt36("\nquel sujet voulez-vous lire: ", ref choix)) {   if (choix>0  && choix<=choixmax) break;   }

Console.Clear();

///////////////////////////////////////test methode LirePubli
List<Dbm.donnée> géraldine = new List<Dbm.donnée>();
Dbm.LirePubli(choix, géraldine); //////////////////lit toutes les publications
// Dbm.LirePubli(choix, géraldine, 2, 2); /////////lit deux publis à partir de la publi 2
foreach(Dbm.donnée val in géraldine) {
   nomprén = $"{val.Nom}, {val.Prénom} dit {val.Pseudo}";
   Console.BackgroundColor = ConsoleColor.Black;
   Console.WriteLine($"    pub:{val.Id_pub:000} - {val.Date_pub}{nomprén,66}    ");
   Console.BackgroundColor = ConsoleColor.DarkCyan;
   Console.WriteLine($"{val.Message}\n");
}

///////////////////////////////////////////test methode LireUtil
List<Dbm.donnée> guendoline = new List<Dbm.donnée>();
string typeCompte="";
int erreur = Dbm.LireUtil(guendoline, "nom", "chamousse");////////////recherche un utilisateur dont le nom est chamousse
foreach(Dbm.donnée val in guendoline) {
   nomprén = $"{val.Nom}, {val.Prénom} dit {val.Pseudo}";
   switch (val.Accès) {
      case 0: typeCompte="Administrateur"; break;
      case 1: typeCompte="Utilisateur"; break;
      case 2: typeCompte="En attente d'enregistrement"; break;
   }
   Console.WriteLine($"utilisateur:{val.Id_user:000}\n{nomprén}\nInscrit le: {val.Date_user}\nCourriel: {val.Courriel}\nTéléphone: {val.Tél}");
   Console.WriteLine($"Niveau d'accès: {typeCompte}\n");
}

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





