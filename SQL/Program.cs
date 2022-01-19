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
////////////// methode pour suprimer une publi et un topic avec l'ensemble de ses publi (modération)
////////////// methode pour lire utilisateur, pour pouvoir modifier ces informations
////////////// methode recherche utilisateur, par nom ou pseudo, renvoi l'id des utilisateurs dont le nom ou pseudo corresponde
////////////// ajouter à la table utilisateur le champ niveau d'accès

Console.BackgroundColor = ConsoleColor.DarkCyan;
Console.Clear();

////////////////////////////////////test methode liretopic
List<Dbm.donnée> prout = new List<Dbm.donnée>();
Dbm.LireTopic(prout); //////////////lit tous les topics
// Dbm.LireTopic(prout, 3,3); //////lit 3 topics à partir du topic 3
string nomprén = "";
foreach (Dbm.donnée val in prout ) {
   nomprén = $"{val.nom}, {val.prénom} dit {val.pseudo}";
   Console.BackgroundColor = ConsoleColor.Black;
   Console.WriteLine($"   {val.id_topic,3} - {nomprén,-55} {val.date_top} {val.langage,16}   ");
   Console.BackgroundColor = ConsoleColor.DarkCyan;
   Console.WriteLine($"\t{val.nom_topic}");
   Console.WriteLine($"\t{val.description}\n");
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
   nomprén = $"{val.nom}, {val.prénom} dit {val.pseudo}";
   Console.BackgroundColor = ConsoleColor.Black;
   Console.WriteLine($"    pub:{val.id_pub:000} - {val.date_pub}{nomprén,66}    ");
   Console.BackgroundColor = ConsoleColor.DarkCyan;
   Console.WriteLine($"{val.message}\n");
}

// /////////////////////////////////////////test methode utilInject
// Dbm.InjectUtil("tramiel.jakotte@atari.net", "thejack", "toto", "tramiel", "jack");

// /////////////////////////////////////////test methode injecttopic
// Dbm.InjectTopic(4, "proutoQ", "ça va les gens?", "comment ça avance pour vous ce fil rouge? bien? ou bien?", 11);

// /////////////////////////////////////////test methode injectpubli
// Dbm.InjectPubli(1, 4, "il fait super chaud ici, heuresement que j'ai de quoi me désaltéré...");





