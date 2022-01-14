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
MySqlConnection? conne;

string chaineDeConne = "server=localhost;database=m2iformation;uid=root;pwd=toto;";
conne = new MySqlConnection(chaineDeConne);
try{  conne.Open();     Konzolo.Affiche($"tout marche bien base de donnée ! \n");   conne.Close();   }
catch (Exception ex){   Konzolo.Affiche($"croustonne? ici base de donnée, ya un problème!!!\n{ex}\n");   }

string date_top, langage, nom_topic, description, nb_rep;
string nom, prenom, pseudo, nompren;
string date_pub, message;
int id_topic, id_user, id_pub;
int choix = 0, choixmax = 0; 

Console.BackgroundColor = ConsoleColor.DarkCyan;
Console.Clear();

conne.Open();                 //////////////lit l'ensemble des topics
MySqlCommand cmd = conne.CreateCommand();
cmd.CommandText = "select * from topic join utilisateur on topic.id_user=utilisateur.id_user;";
MySqlDataReader reader = cmd.ExecuteReader();
while (reader.Read()) {
   id_topic =  reader.GetInt16(0);
   date_top =  reader.GetString(1);
   id_user =  reader.GetInt16(2);
   langage =  reader.GetString(3);
   nom_topic =  reader.GetString(4);
   description =  reader.GetString(5);
   nb_rep =  reader.GetString(6);
   nom = reader.GetString(9);
   prenom = reader.GetString(10);
   pseudo = reader.GetString(13);
   nompren = $"{nom}, {prenom} dit {pseudo}";

   Console.BackgroundColor = ConsoleColor.Black;
   Console.WriteLine($"   {id_topic,3} - {nompren,-55} {date_top} {langage,16}   ");
   Console.BackgroundColor = ConsoleColor.DarkCyan;
   Console.WriteLine($"\t{nom_topic}");
   Console.WriteLine($"\t{description}\n");
}
reader.Close();
conne.Dispose();
conne.Close();

conne.Open();
cmd.CommandText = "SELECT COUNT(id_topic) FROM topic;";//////lit le nombre de topic
reader = cmd.ExecuteReader();
while (reader.Read()) choixmax = reader.GetInt16(0);
reader.Close();
conne.Dispose();
conne.Close();


while (LireInt36("\nquel sujet voulez-vous lire: ", ref choix)) {   if (choix>0  && choix<=choixmax) break;   }
// Konzolo.Affiche($"{choix}\n");
Console.Clear();

// select * from publication where id_topic=@Choix;
// select * from publication join topic on publication.id_topic=topic.id_topic where publication.id_topic=@Choix;

//select * from publication 
//join topic on publication.id_topic=topic.id_topic 
//join utilisateur on publication.id_user=utilisateur.id_user 
//where publication.id_topic=6;     //remplacer 6 par @Choix
conne.Open();
cmd = conne.CreateCommand();
cmd.CommandText = "select * from publication join topic on publication.id_topic=topic.id_topic join utilisateur on publication.id_user=utilisateur.id_user where publication.id_topic=@Choix;";
cmd.Parameters.Add(new MySqlParameter("@Choix", choix));
reader = cmd.ExecuteReader();
while (reader.Read()) {
   id_pub = reader.GetInt16(0);
   date_pub = reader.GetString(1);
   message = reader.GetString(4);
   nom = reader.GetString(14);
   prenom = reader.GetString(15);
   pseudo = reader.GetString(18);
   nompren = $"{nom}, {prenom} dit {pseudo}";
   Console.BackgroundColor = ConsoleColor.Black;
   Console.WriteLine($"    pub:{id_pub:000} - {date_pub}{nompren,66}    ");
   Console.BackgroundColor = ConsoleColor.DarkCyan;
   Console.WriteLine($"{message}\n");
}
reader.Close();
conne.Dispose();
conne.Close();




bool LireInt36 (string message, ref int valeur) {   Console.Write(message);  return (int.TryParse(Console.ReadLine(), out valeur));   }

