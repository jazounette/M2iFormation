// See https://aka.ms/new-console-template for more information
// Console.Clear();

using System.Text.RegularExpressions;

static void attendre() { 
   Console.WriteLine("Appuyez sur une touche pour continuer...");
   Console.ReadLine();
}

static void print(string message) { Console.Write(message); }

static float lireFloat(string message = "") {  Console.Write(message);  return Convert.ToSingle( Console.ReadLine() );  }
static double lireDouble(string message = "") {  Console.Write(message);  return Convert.ToDouble ( Console.ReadLine() );  }
static int lireInt(string message = "") {  Console.Write(message);  return Convert.ToInt32( Console.ReadLine() );  }
static long lireLong(string message = "") {  Console.Write(message);  return Convert.ToInt64( Console.ReadLine() );  }
static string lireString(string message = "") {  Console.Write(message);  return Console.ReadLine();  }




//////////////////////////////////////////////////////////exercise 11
   // float capistart=0;
   // float capi=0;
   // float taux=0;
   // int anne=0;
   
   // Console.WriteLine("capital de départ:");
   // capistart = Single.Parse(Console.ReadLine());
   // capi = capistart;
   // Console.WriteLine("taux d'interet: ");
   // taux =  Single.Parse(Console.ReadLine());

   // while(capi <= (capistart * 2)){
   //    capi = capi * (1 + (taux/100));
   //    anne++;
   //    Console.WriteLine(capi);
   // }
   // Console.WriteLine("votre capirale a doublé en " + anne + "année");

//////////////////////////////////////////////////////// exercesi 12
// for (int i=1; i<=9; i++) {
//    Console.WriteLine("9 x " + i + " = " + i*9);
// }

//////////////////////////////////////////////////////// exercise 13
// int nombre = 0;
// int nombreMAX = 0;
// int nombreMIN = 9999;
// float nombreSOM = 0;
// for (int i=1; i<=6; i++) {
//    Console.Write("entier " + i + "= ");
//    nombre =  int.Parse(Console.ReadLine());
//    if (nombre > nombreMAX) { nombreMAX = nombre; }
//    if (nombre < nombreMIN) { nombreMIN = nombre; }
//    nombreSOM += nombre;
// }
// Console.WriteLine("nombre le plus grand: " + nombreMAX);
// Console.WriteLine("le plus petit nombre est: " + nombreMIN);
// Console.WriteLine("la moyenne des nombres est: " + nombreSOM / 6);


//////////////////////////////////////////////////////// exercise 14
// int entierMAX = 0;
// int entierSOM = 0;
// string concombre = "";
// Console.Write("combien de fois je dois tourner? ");
// entierMAX =  int.Parse(Console.ReadLine());
// Console.WriteLine("Somme des entiers de 1 à " + entierMAX + " est de: ");
// for (int i=1; i <= entierMAX; i++) {
//    entierSOM += i;
//    concombre = (i == entierMAX) ? " = " : " + ";
//    Console.Write(i + concombre);
// }
// Console.WriteLine(entierSOM);


//////////////////////////////////////////////////////// exercise 15
// for (int i=1; i<=10; i++) {
//    Console.WriteLine("table des " + i);
//    for (int j=1; j<=9; j++) {
//       Console.WriteLine (i + " x " + j + " = " + i*j);
//    }
// }


////////////////////////////////////////////////////// exercise 15BIS
// double habTourc = 96809;
// double taux = 0.89;
// int habTourcMax = 120_000;
// int anne = 0;
// string s = "";
// while (habTourc < habTourcMax) {
//    habTourc = habTourc * (1 + taux/100);
//    Console.WriteLine (habTourc);
//    // Console.ReadKey();
//    anne++;
// }
// if (anne > 1) { s = "s"; }
// Console.WriteLine("il faudra à la ville de Tourcoing " + anne + "année" + s + " pour atteindre " + habTourcMax + ".");


//////////////////////////////////////////////////////// exercise 16
// int[] note = new int[20] ; 
// var hazard = new Random();
// string choix = "";
// int noteMAX = 0;
// int noteMIN = 0;
// int noteSOM = 0;
// int eleveMAX = 0;
// int eleveMIN = 0;

// for (int i=0; i<20; i++) {
//    note[i] = hazard.Next(0, 200);
//    Console.WriteLine(i + " : " + (float)note[i] / 10);
// }

// do {
//    Console.WriteLine("1-afficher la note la plus basse");
//    Console.WriteLine("2-afficher la note la plus haute");
//    Console.WriteLine("3-afficher la moyenne des notes");
//    Console.WriteLine("0-quitter");
//    Console.Write("choix:");
//    choix = Console.ReadLine();
//    if (choix == "1") {
//       noteMAX = 0; 
//       for (int i=0; i<20; i++) {  
//          if (note[i] > noteMAX) { noteMAX = note[i]; eleveMAX = i; }
//       }
//       Console.WriteLine("élève " + eleveMAX + ": " + (float)noteMAX/10);
//    }
//    if (choix == "2") {
//       noteMIN = 9999;
//       for (int i=0; i<20; i++) {
//          if (note[i] < noteMIN)  { noteMIN = note[i]; eleveMIN = i; }
//       }
//       Console.WriteLine("élève " + eleveMIN + ": " + (float)noteMIN/10);
//    }
//    if (choix == "3") {
//       noteSOM = 0;
//       for (int i=0; i<20; i++) {  noteSOM += note[i];   }
//       Console.WriteLine("moyenne des élèves: " + (float)noteSOM / 200);
//    }
// } while (choix != "0");


//////////////////////////////////////////////////////exercise 17
// string choix; 
// int noteMin = 9999; 
// int noteMax = 0;
// int noteSom = 0;
// int noteNbr = 1;
// int note;
// do {
//    Console.Write("entre une note (q pour quitter): ");
//    choix = Console.ReadLine();
//    if (choix == "q") { break; }
//    else {
//       note = int.Parse(choix);
//       noteSom += note;

//       if (note > noteMax) { noteMax = note; }
//       if (note < noteMin) { noteMin = note; }

//       Console.Write("nombre de note: " + noteNbr);
//       Console.Write(", note maxi: " + noteMax);
//       Console.Write(", note mini: " + noteMin);
//       Console.WriteLine(", moyenne: " + noteSom / noteNbr);
//       noteNbr++;

//    }
// } while (true);


///////////////////////////////////////////////////// exercise 17BIS
// int n = 5;
// for (int i=1; i <= n; i++) {
//    for (int j=1; j <= i; j++) {
//       Console.Write(j);
//    }
//    Console.WriteLine();
// }


///////////////////////////////////////////////////////// test fonction
// static string prout(string toto) {
//    Console.WriteLine("j'ai fait un gros " + toto);
//    return ("ya du caca qui arrive");
// }
// Console.WriteLine(prout("PROUT!!!!"));


////////////////////////////////////////////////////////// exercise 18
// static int cestQuoiLeNombreLePlusGrand(int nombreA, int nombreB) {
//    return (nombreA > nombreB) ? nombreA : nombreB;
// }
// print("premier nombre: ");
// int prems = int.Parse(Console.ReadLine());
// print("deuxieme nombre: ");
// int deuse = int.Parse(Console.ReadLine());
// Console.WriteLine (cestQuoiLeNombreLePlusGrand(prems, deuse));


///////////////////////////////////////////////////////// exercise 19
// int[] monBeauTableau = new int[10];
// var hazard = new Random();
// for (int i=0; i <10; i++) {
//    monBeauTableau[i] = hazard.Next(0, 9999);
// }
// Console.WriteLine(monBeauTableau[9]);


////////////////////////////////////////////////////////// exercise 20
// int[] note = new int[15];
// for (int i=0; i<15; i++) {
//    Console.Write("note " + (i+1) + ": ");
//    note[i] = int.Parse(Console.ReadLine());
// }
// Console.Write(note[0]);
// for (int i=1; i<15; i++) {  Console.Write(", " + note[i]);  }
// print(".\n");


/////////////////////////////////////////////////////////// exercise 21
// int nbEleve = 5;
// int nbMat = 3;
// int[,] note = new int[nbMat, nbEleve]; // creé un tableau de 5 étudiants et de 3 matières
// string[] matiere = {"sport", "informatique", "français"};
// string[] eleve = {"michel", "fabrice", "monique", "gontran", "théodule"};

// for(int i=0; i<nbMat; i++) {
//    Console.WriteLine(matiere[i]);
//    for(int j=0; j<nbEleve; j++) {
//       Console.Write(eleve[j] + " à eu la note de: ");
//       // note[i,j] = int.Parse(Console.ReadLine());
//       note[i,j] = Convert.ToInt32(Console.ReadLine());
//    }
// }

// foreach(int toto in note) {
//    Console.Write(toto + " ");
// }
// faire un tri des notes avant de les afficher


// Console.OutputEncoding = System.Text.Encoding.UTF8;
// print("€€€\n");
// int toto = 55;
// Console.WriteLine("toto: {0}", toto);
// Console.WriteLine($"toto: {toto}");

// object toto1 = "prout au cul";
// object toto2 = "pipi danl po";

// toto1 = toto2;

// toto2 = "ratatouille";

// Console.WriteLine(toto1);
// Console.WriteLine(toto2);

////////////////////////////////////////// exercice anthony C#
// ////////////////////////////////////////// exercice 01
// Console.OutputEncoding = System.Text.Encoding.UTF8;
// Console.WriteLine("*** Ma liste de todo ***");
// Console.WriteLine("Aujourd'hui je dois faire:");
// Console.WriteLine("\t-Apprendre le C#");
// Console.WriteLine("\t-Apprendre à utiliser Visual Studio");
// Console.WriteLine("\t-Comprendre l'affichage \"Console\"");
// Console.WriteLine("\t-Créer mon répertoire \"c:\\MesExercices\\\" pour les ranger");
// Console.WriteLine("Apprécier les fonctionnalités du C#");

// attendre();
// ///////////////////////////////////////////// exercice 02
// string prenom = "";
// Console.Write("Veuillez saisir votre prénom: ");
// prenom = Console.ReadLine();
// Console.WriteLine($"Bonjour {prenom}");
// // Console.WriteLine("Appuyez sur une touche pour fermer le programme...");
// // Console.ReadLine();

// attendre();
// ///////////////////////////////////////////// exercise 03
// string prenom2 = "";
// string nom2 = "";
// Console.Write("Veuillez saisir votre nom: ");
// nom2 = Console.ReadLine();
// Console.Write("Veuillez saisir votre prénom: ");
// prenom2 = Console.ReadLine();
// // Console.WriteLine($"Bonjour {prenom2} {nom2}");
// Console.WriteLine("Bonjour " + prenom2 + " " + nom2);
// // Console.WriteLine("Appuyez sur une touche pour fermer le programme...");
// // Console.ReadLine();

// attendre();
// ////////////////////////////////////////// exercice 04
// string nom3 = "";
// string prenom3 = "";
// short age = 0;
// Console.Write("Veuillez saisir vote nom: ");
// nom3 = Console.ReadLine();
// Console.Write("Veuillez saisir vote prénom: ");
// prenom3 = Console.ReadLine();
// Console.Write("Veuillez saisir vote age: ");
// age = Convert.ToInt16(Console.ReadLine());
// Console.WriteLine("Bonjour {0} {1}, vous avez {2} ans.", prenom3, nom3, age);

// attendre();
// ////////////////////////////////////////////// exercice 05
// int premierNombre = 0;
// int deuxiemeNombre = 0;
// Console.Write("Veuillez saisir un nombre: ");
// premierNombre = Convert.ToInt32(Console.ReadLine());
// Console.Write("Veuillez saisir un nombre: ");
// deuxiemeNombre = Convert.ToInt32(Console.ReadLine());
// Console.WriteLine($"La somme de ces deux nombres est: {premierNombre + deuxiemeNombre}");

// attendre();
// //////////////////////////////////////////// exercice 05BIS
// float premierNombre2 = 0;
// float deuxiemeNombre2 = 0;
// Console.Write("Veuillez saisir un nombre à virgule: ");
// // premierNombre2 = float.Parse(Console.ReadLine());
// premierNombre2 = Convert.ToSingle(Console.ReadLine());
// Console.Write("Veuillez saisir un nombre à virgule: ");
// // deuxiemeNombre2 = float.Parse(Console.ReadLine());
// deuxiemeNombre2 = Convert.ToSingle(Console.ReadLine());
// Console.WriteLine($"La somme de ces deux nombres est: {premierNombre2 + deuxiemeNombre2}");

/////////////////////////////////////////exercice 06
// float carreCote = 0;
// Console.Write("entrez la longeur du côté d'un carré: ");
// carreCote = Convert.ToSingle(Console.ReadLine());
// Console.WriteLine($"le perimétre du carré est: {carreCote * 4}");
// Console.WriteLine($"l'aire du carré est: {carreCote * carreCote}");

// attendre();
// float rectLong, rectLarg;
// Console.Write("entrez la longeur du rectangle: ");
// rectLong = Convert.ToSingle(Console.ReadLine());
// Console.Write("entrez la largeur du rectangle: ");
// rectLarg = Convert.ToSingle(Console.ReadLine());
// Console.WriteLine($"le périmetre du rectangle est: {(rectLong * 2) + (rectLarg * 2)}");
// Console.WriteLine($"l'aire du rectangle est: {rectLong * rectLarg}");

// attendre();
// //////////////////////////////////////exercise 07
// float triCoteA, triCoteB, triCoteC;
// Console.Write("longeur du premier coté: ");
// triCoteA = Convert.ToSingle(Console.ReadLine());
// Console.Write("longeur du deuxieme coté: ");
// triCoteB = Convert.ToSingle(Console.ReadLine());
// triCoteC = Convert.ToSingle(Math.Sqrt( Math.Pow(triCoteA, 2) + Math.Pow(triCoteB, 2)));
// Console.WriteLine($"la longeur de l'hypotalanus est de: {triCoteC}");

// attendre();
// //////////////////////////////////////exercice 08
// float prixHT, tauxTVA, montantTVA;
// Console.Write("entrez le prix HT de votre article: ");
// prixHT = Convert.ToSingle(Console.ReadLine());
// Console.Write("entrez le taux de TuVAbien: ");
// tauxTVA = Convert.ToSingle(Console.ReadLine());
// montantTVA = prixHT * tauxTVA / 100; 
// Console.WriteLine($"Le montant de la TVA pour cette article est de: {montantTVA} Euros");
// Console.WriteLine($"le prix TTC de votre article est de: {prixHT + montantTVA} Euros");


// attendre();
// /////////////////////////////////////exercice 09
// float capitalIni, capitalFin, tauxInt, dureEpa;
// capitalIni = lireFloat("entrez votre capital de départ: ");
// tauxInt = lireFloat("entrez le taux d'intérêt: ");
// dureEpa = lireFloat("entrez la durée de l'épargne: ");

// capitalFin = Convert.ToSingle(capitalIni * Math.Pow((1 + tauxInt/100), dureEpa));
// Console.WriteLine($"Le montant des intérêts sera de {capitalFin - capitalIni} Euros après {dureEpa} ans");
// Console.WriteLine($"Le capital final sera de {capitalFin} Euros");


///////////////////////////////////////exercice 10
// print("--- La lettre est-elle une voyelle? ---\n");
// string lettre = lireString("Entrez une lettre: ");
// lettre = lettre.ToUpper();
// if (lettre == "A" || lettre == "E" || lettre == "I" || lettre == "O" || lettre == "U" || lettre == "Y") {
//    print("Cette lettre EST une voyelle !\n");
// } else {  print ("Cette lettre n'est PAS une voyelle.\n") ;}
// attendre();

//////////////////////////////////////exercise 11
// print("--- Le nombre est-il divisible par? ---\n");
// int chiffreE = lireInt("Entrez un chiffre/nombre entier: ");
// int chiffreD = lireInt("Entrez un chiffre/nombre diviseur: ");
// string toto = (chiffreE > 9) ? "nombre" : "chiffre";
// if (chiffreE % chiffreD == 0) { print($"le {toto} {chiffreE} EST divisible par {chiffreD}.\n"); }
// else { print($"le {toto} {chiffreE} n'est PAS divible par {chiffreD}.\n"); }
// attendre();

//////////////////////////////////////exercice 12
// string[] messCat = {"Baby", "Poussin", "Pupille", "Minime", "Cadet"};
// int categorie = 0;
// print("--- Dans quelle catégorie mon enfant est-il? ---\n");
// int age = lireInt("Entrez l'age de votre enfant: ");
// if (age < 3) { categorie = -1; }
//    else { if ((age >= 3) && (age <= 6)) { categorie = 0; }
//       else { if ((age>= 7) && (age <=8)) { categorie = 1; } 
//          else { if ((age >=9) && (age <=10)) { categorie = 2; } 
//             else { if ((age >= 11) && (age <= 12)) { categorie = 3; } 
//                else { if ((age >= 13) && (age < 18)) { categorie = 4; } 
//                   else { categorie = 99; } } } } } }
// if (categorie == -1) { print("votre enfant est trop jeune\n"); }
//    else { if (categorie == 99) { print("spoiler alerte, ce n'est plus un enfant\n"); }
//       else { print($"Votre enfant est dans la catégorie: {messCat[categorie]}\n"); } }
// attendre();

//////////////////////////////////////exercise 13
// float coteAB, coteBC, coteCA;
// string messageTri = "équilatéral";
// print("--- Quelle est la nature du triangle ABC? ---\n");
// coteAB = lireFloat("Entrez la longeur du segment AB: ");
// coteBC = lireFloat("Entrez la longeur du segment BC: ");
// coteCA = lireFloat("Entrez la longeur du segment CA: ");

// if ((coteAB == coteBC) && (coteBC == coteCA)) { messageTri = "équilateral"; } 
// else {
//    if (coteAB == coteBC) { messageTri = "isocèle en B"; }
//    else {
//       if (coteAB == coteCA) { messageTri = "isocèle en A"; }
//       else {
//          if (coteBC == coteCA) { messageTri = "isocèle en C"; }
//          else { messageTri = "quelconque"; }
//       }
//    }
// }
// print($"Le triangle est {messageTri}.\n");

// attendre();
////////////////////////////////////////exercice 14
// int taille = 0, poid = 0, tailleVet = 0;
// print("--- Quelle taille dois-je prendre? ---\n");
// poid = lireInt("Entrez votre poid (en kg): ");
// taille = lireInt("Entrez votre taille (en cm): ");
// if ((poid >= 43) && (poid <= 47) && (taille >= 145) && (taille <= 169)) tailleVet = 1;
// if ((poid >= 48) && (poid <= 53)) {
//    if ((taille >= 145) && (taille <=166)) tailleVet = 1; 
//       else if ((taille > 166) && (taille <=178)) tailleVet = 2;
// }
// if ((poid >= 54) && (poid <= 59)) {
//    if ((taille >= 145) && (taille <= 163)) tailleVet = 1;
//       else if ((taille > 163) && (taille <=175)) tailleVet = 2;
//          else if ((taille > 175) && (taille <=183)) tailleVet = 3;
// }
// if ((poid >= 60) && (poid <= 65)) {
//    if ((taille >= 145) && (taille <= 160)) tailleVet = 1;
//       else if ((taille > 160) && (taille <= 172)) tailleVet = 2;
//          else if ((taille > 172) && (taille <= 183)) tailleVet = 3;
// }
// if ((poid >= 66) && (poid <= 71)) {
//    if ((taille >= 160) && (taille <= 169)) tailleVet = 2;
//       else if ((taille > 169) && (taille <= 183)) tailleVet = 3;
// }
// if ((poid >= 72) && (poid <= 77) && (taille >= 163) && (taille <= 183)) tailleVet = 3;

// if (tailleVet == 0) {  print("notre boutique n'a pas votre taille, désolé\n");  } 
// else {  print($"votre vêtement est de taille: {tailleVet}\n");  }

// attendre();
///////////////////////////////////////exercice 15
// float prime = 0;
// print("--- Quelle sera le montant de l'indemnité de licenciement? ---\n");
// int salaire = lireInt("Merci de saisir le dernier salaire (en Euros): ");
// int age = lireInt("Merci de saisir votre âge: ");
// int ancien = lireInt("Merci de saisir le nombre d'années d'ancienneté: ");
// prime = (ancien <= 10) ? (salaire/2) * ancien : salaire * ancien;
// if (age > 49) { prime += salaire * 5; } 
// else { if (age > 45) prime += salaire * 2; }
// print($"Votre indemnité est de: {prime} Euro\n");

//////////////////////////////////////exercice 16
// double part, revenuPar, impot = 0;
// print("--- Quelle sera le montant de mes impôts? ---\n");
// float revenuNet = lireFloat("Entrez le montant net imposable du foyer (en Euros): ");
// int adulte = lireInt("Entrez le nombre d'adulte du foyer: ");
// int enfant = lireInt("Entrez le nombre d'enfants du foyer: ");

// if (enfant <= 2) part = adulte + enfant * .5; else part = adulte + enfant - 1;
// revenuPar = revenuNet / part;

// if (revenuPar >= 10084 && revenuPar < 25710)  impot = (revenuPar - 10084) * .11 ;
// if (revenuPar >= 25710 && revenuPar < 73516)  impot = 1718.75 + (revenuPar - 25710) * .30 ;
// if (revenuPar >= 73516 && revenuPar < 158122) impot = 14341.18 + 1718.75 + (revenuPar - 73516) * .41 ;
// if (revenuPar >= 158122) impot = 34688.46 + 14341.18 + 1718.75 + (revenuPar - 158122) * .45 ;

// impot *= part;
// print ($"Vous allez payer:{Math.Round (impot,2)} Euros\n");


/////////////////////////////////////////////exercice 17
// print("--- Quelle boisson souhaitez-vous? ---\n");
// int boisson;
// string [] tableBoiss = {"Eau Plate", "Eau Gazeuze", "Coca-Cola", "Fanta", "Sprinte", "Orangina", "7Up"};
// print("Liste des boissons disponibles: \n");
// for (int i=0; i<tableBoiss.Length; i++) print($"\t{i+1}){tableBoiss[i]}\n");
// int choix = lireInt("Faite votre Choix (1 à 7): ");
// switch (choix) {
//    case 1 : boisson = 0; break;
//    case 2 : boisson = 1; break;
//    case 3 : boisson = 2; break;
//    case 4 : boisson = 3; break;
//    case 5 : boisson = 4; break;
//    case 6 : boisson = 5; break;
//    case 7 : boisson = 6; break;
//    default : boisson = -1; break;
// }
// if (boisson>=0) print($"Votre {tableBoiss[boisson]} est servi...\n");  else { print("Cette boisson n'est pas disponible\n"); }

/////////////////////////////////////////////exercice 18
// print("--- Dans quelle catégorie mon enfant est-il? ---\n");
// int age = lireInt("Entrez l'âge de votre enfant: ");
// string categorie = "";
// switch (age) {
//    case < 3 : categorie = "trop jeune"; break;
//    case int titi when (titi>=3) && (titi <=6): categorie = "Baby"; break;
//    case int tutu when (tutu>=7) && (tutu <=8): categorie = "Poussin"; break;
//    case int tutu when (tutu>=9) && (tutu <=10): categorie = "Pupille"; break;
//    case int tutu when (tutu>=11) && (tutu <=12): categorie = "Mimine"; break;
//    case int tutu when (tutu>=13) && (tutu <=18): categorie = "Cadet"; break;
//    case > 18 : categorie = "trop vieux"; break;
// }
// if (categorie == "trop jeune") print("mais c'est encore un bébé enfin!!!!\n");
// else { if (categorie == "trop vieux") print("c'est enfant n'en est plus un!!!\n") ;
// else { print($"votre enfant est dans la catégorie {categorie}\n"); } }
// attendre();

/////////////////////////////////////////exercice 19
// double part, revenuPar, impot = 0;
// print("--- Quelle sera le montant de mes impôts? ---\n");
// float revenuNet = lireFloat("Entrez le montant net imposable du foyer (en Euros): ");
// int adulte = lireInt("Entrez le nombre d'adulte du foyer: ");
// int enfant = lireInt("Entrez le nombre d'enfants du foyer: ");

// if (enfant <= 2) part = adulte + enfant * .5; else part = adulte + enfant - 1;
// revenuPar = revenuNet / part;

// switch (revenuPar) {
//    case < 10084: impot = 0; break;     // utilisation de la variable temporaire toto, mais sans l'utilisé, c'est zarbi, à voir pourquoi
//    case double toto when (revenuPar >= 10084 && revenuPar < 25710): impot = (revenuPar - 10084) * .11 ; break;
//    case double toto when (revenuPar >= 25710 && revenuPar < 73516):  impot = 1718.75 + (revenuPar - 25710) * .30 ; break;
//    case double toto when (revenuPar >= 73516 && revenuPar < 158122): impot = 14341.18 + 1718.75 + (revenuPar - 73516) * .41 ; break;
//    case double toto when (revenuPar >= 158122): impot = 34688.46 + 14341.18 + 1718.75 + (revenuPar - 158122) * .45 ; break;
//    default : impot = -1; break;
// }

// impot *= part;
// print ($"Vous allez payer:{Math.Round (impot,2)} Euros\n");

//////////////////////////////////exercice 20
// print("Je commence à compter:\n");
// int i;
//  for (i = 1; i <= 10; i++) print($"\t{i}\n");
//  print($"Super! Je sais compter jusqu'à {i-1}\n");

//////////////////////////////////exercice 21
// print("--- Menus et sous-menus ---\n");
// print("Table des matières: \n");
// for (int i = 1; i <= 3; i++) {
//    print($"\tChapitre {i}\n");
//    for (int j = 1; j<= 3; j++) print($"\t\t-Partie {i}.{j}\n");
// }

////////////////////////////////exercice 22
// print("--- Les tables de multiplication ---\n");
// // for (int i = 1; i <=10; i++)  {
// //    print($"Table de {i}:\n");
// //    for (int j = 1; j <= 10; j++)  print($"\t{j} x {i} = {j*i}\n");
// // }

// for (int i = 1; i <=23; i++)  {
//    if (i==1) {  for (int n=1; n<=5; n++) print($"Table de {n}\t"); print("\n");  }
//    if ((i>=2) && (i<=11)) { for (int n=1; n<=5; n++) print($"{n} x {i-1} = {n*(i-1)}\t");  print("\n");  }
//    if (i==12) print("\n");
//    if (i==13) {  for (int n=6; n<=10; n++) print($"Table de {n}\t"); print("\n");  }
//    if ((i>=14) && (i<=23)) { for (int n=6; n<=10; n++) print($"{n} x {i-13} = {n*(i-13)}\t");  print("\n");  }
// }

////////////////////////////////exercice 23
// print("--- Accroissement de population ---\n");
// float population = 96809F;
// int anne;
// int anneDep = 2015;
// for(anne=(anneDep + 1); anne<2199; anne++) {
//    population *= 1.0089F;
//    // print($"{anne} - {population}\n");
//    if (population >= 120000) break;
// }
// print($"Il faudra {anne - anneDep} an{(((anne - anneDep) == 1) ? "" : "s")}, nous serons en {anne}\n");
// print($"Il y aura {population:0} habitants en {anne}\n");

///////////////////////////////exercice 23 BIS
// print("--- Accroissement de population ---\n");
// int anneBIS=0;
// float pop; 
// for (pop = 96809; pop < 120000; pop *= 1.0089F) anneBIS++;
// print($"{anneBIS} - {pop}\n");

///////////////////////////////////exercice 24
// print("--- Les suites chainées de nombres ---\n");
// int toto = lireInt("Merci de saisir un nombre: ");
// int somme;
// string somCh;
// string prout;

// for (int j=1; j<toto; j++) {
// somme = 0;
// somCh = "";
//    for (int i=j; i<toto; i++) {
//       somme += i;
//       prout = Convert.ToString(i);
//       if (somme == toto) { print($"{toto} = {somCh}{prout}\n"); break; }
//          else if (somme>toto) break; 
//             else somCh +=  prout + "+";
//    }
// }

/////////////////////////////////////exercice 25
// print("--- Gestion des notes ---\n");
// print("Veuillez saisir 5 notes: \n");
// float noteMoy=0, noteMax=0, noteMin=20, notenot;
// for(int i=1; i<=5; i++) {
//    notenot = lireFloat($"\tMerci de saisir la note {i} (sur /20): ");
//    if (notenot > noteMax) noteMax = notenot;
//    if (notenot < noteMin) noteMin = notenot;
//    noteMoy += notenot;
// }
// Console.ForegroundColor = ConsoleColor.Green;
// print($"La meilleure note est {noteMax}/20\n");
// Console.ForegroundColor = ConsoleColor.Red;
// print($"La moins bonne note est {noteMin}/20\n");
// Console.ResetColor();
// print($"La moyenne des notes est {noteMoy/5}/20\n");

//////////////////////////////////////exercice 26 (tourcoing avec boucle while)
// print("--- Accroissement de population ---\n");
// float population = 96809F;
// int anne = 2015;
// int anneDep = 2015;
// while (population <= 120000) {
//    population *= 1.0089F;
//    anne++;
//    // print($"{anne} - {population}\n");
// }
// print($"Il faudra {anne - anneDep} an{(((anne - anneDep) == 1) ? "" : "s")}, nous serons en {anne}\n");
// print($"Il y aura {population:0} habitants en {anne}\n");

///////////////////////////////////exercice 27
// print("--- Les suites chainées de nombres ---\n");
// int toto = lireInt("Merci de saisir un nombre: ");
// int somme;
// string somCh;

// int k = 1;
// while (k <= (toto/2 + 1)){
//    int i = k;
//    somme = 0;
//    while (i <= (toto/2 + 1)) {
//       somme += i;
//       if (somme == toto) {
//          somCh = toto + " = " + k;
//          for (int j=(k+1); j<=i; j++) somCh += "+" + j;
//          print($"{somCh}\n");
//          break;
//       } else if (somme > toto) break;
//       i++;
//    }
//    k++;
// }

///////////////////////////////////////exercice 28
// print("--- Trouver le nombre mystère ---\n");
// var hazard = new Random();
// int reponse;
// bool gagne = false;
// int compteur = 1;

// int mystere = hazard.Next(1, 51);
// print($"{mystere}\n");
// do {
//    // Console.ForegroundColor = ConsoleColor.Gray;
//    couleur("white");
   
//    reponse = lireInt("Veuillez saisir un nombre: ");
//    if (reponse < mystere) {
//       // Console.ForegroundColor = ConsoleColor.Yellow;
//       couleur("jaune");
//       print("Le nombre mystere est plus grand\n");
//    } else if (reponse > mystere) {
//       // Console.ForegroundColor = ConsoleColor.Red;
//       couleur("rouge");
//       print("Le nombre mystere est plus petit\n");
//    } else {
//       // Console.ForegroundColor = ConsoleColor.Green;
//       couleur("vert");
//       print("Bravo!!!! Vous avez trouvé le nombre mystère\n");
//       couleur("blanc");
//       print($"Vous avez trouvé en {compteur} coup{((compteur==1) ? "" : "s")}.\n");
//       gagne = true;
//    }
//    compteur++;
// } while (!gagne);



static bool couleur (string couleur) {
   static int vaChercheCoul(string[] chimay, string leff) {
      for (int goudal=0; goudal<chimay.Length; goudal++) if (leff == chimay[goudal]) return goudal;
      return -1;
   }
   couleur = couleur.ToLower();
   ConsoleColor[] coulDotNet = (ConsoleColor[]) ConsoleColor.GetValues(typeof(ConsoleColor));
   string[] coulUS = {"black", "darlblue", "darkgreen", "darkcyan", "darkred", "darkmagenta", "darkyellow", "gray", "darkgray", "blue", "green", "cyan", "red", "magenta", "yellow", "white"};
   string[] coulFR = {"noir", "bleupale", "vertpale", "cyanpale", "rougepale", "magentapale", "jaunepale", "gris", "grispale", "bleu", "vert", "cyan", "rouge", "magenta", "jaune", "blanc"};
   if (couleur == "help") {  for (int i=0; i<coulUS.Length; i++) print ($"{coulUS[i],12} - {coulFR[i]}\n");  return true;  }
   int idCoul = vaChercheCoul(coulUS, couleur);
   if (idCoul == -1) idCoul = vaChercheCoul(coulFR, couleur);
   if (idCoul == -1) return false;
   else {  Console.ForegroundColor = coulDotNet[idCoul];  return true;  }
}
/// voir comment faire si pas de deuxieme param pour la methode, param avec valeur par défaut.

/////////////////////////////////////////////////////////////////////////exercice 29
// print("--- Gestion des notes ---\n");
// print("Veuillez saisir les notes: \n");
// print("(999 pour calculer)\n");
// float note, noteSom = 0, noteMax = 0, noteMin = 20;
// int compteur = 1;

// do {
//    note = lireFloat($"\t- Merci de saisir la note {compteur} (sur /20): ");
//    if (note == 999) {  compteur--;  break;  }
//    else if ((note < 0) || (note > 20)) {
//       couleur("rouge");
//       print("\t  Erreur de saisie, la note est sur 20!\n");
//       couleur("blanc");
//    } else {
//       if (note > noteMax) noteMax = note;
//       if (note < noteMin) noteMin = note;
//       noteSom += note;
//       compteur ++;
//    }
// } while (true);

// if (compteur == 0) {  couleur("jaune"); print("aucune note n'a été saisi\n\n"); couleur("blanc");  }
// else {
//    couleur("vert");
//    print($"La meilleure note est {noteMax}/20\n");
//    couleur("rouge");
//    print($"La moins bonne note est {noteMin}/20\n");
//    couleur("blanc");
//    print($"La moyenne de{((compteur) == 1 ? " votre note" : $"s {compteur} notes")} est {(noteSom / (compteur)):F1}/20\n\n");
// }

////////////////////////////////////////////////////////////////////////exercice 30
// print("--- Question à choix multiple ---\n");
// string reponse;
// char choix;
// static bool continuer() {
//    do {
//       string reponse = lireString("Un nouvel essai? Oui/Non: ").ToLower();
//       if (reponse == "oui") return true; 
//       else if (reponse == "non") return false;
//       else couleur("jaune"); print("erreur 413: vous devez choisir entre oui et non\n");   couleur("blanc");
//    } while (true);
// }
// print("Quelle est l'instruction qui permet de sortir d'une boucle en C#\n");
// print("\ta) quit\n\tb) continue\n\tc) break\n\td) exit\n\n");
// do {
//    reponse = lireString("Entrez votre réponse: ");
//    choix = char.ToLower(reponse[0]);
//    if (choix == 'a' || choix =='b' || choix == 'd' ) {
//       couleur("rouge");   print("Incorrect!\n");   couleur("blanc");
//       if (continuer()) continue; else break;
//    } 
//    else if (choix == 'c') {
//       couleur("vert");    print("Bravo!!! C'est la bonne réponse\n");  couleur("blanc");
//       break;
//    }
//    else {
//       couleur("jaune");   print("erreur 412: vous devez choisir entre a,b,c,d et rien d'autre\n");   couleur("blanc");
//       if (continuer()) continue; else break;
//    }
// } while (true);
// couleur("blanc");

/////////////////////////////////////////////////////////////////exercice 31
// print("--- Gestion des notes avec menu ---\n\n");
// int choix = 0;
// float noteSom = 0, noteMax = 0, noteMin = 20, noteNbr = 0; 
// int note = 0;
// do {
//    couleur("blanc");
//    print("1---Saisir les notes\n");
//    print("2---La plus grande note\n");
//    print("3---La plus petite note\n");
//    print("4---La moyenne des notes\n");
//    print("0---Quitter\n");
//    while (!lireInt36("Faites votre choix: ", ref choix ));
//    switch (choix) {
//       case 1:  couleur("jaune");
//                print("---- Saisir les notes ----\n");
//                print("(999 pour stopper la saisie)\n");
//                noteMax = 0; noteMin = 20; noteNbr = 0; noteSom = 0;
//                while (true) {
//                   couleur("blanc");
//                   while (!lireInt36($"Merci de saisir la note {noteNbr+1} (sur /20): ", ref note ));
//                   if (note==999) break;
//                   if (note>=0 && note<=20) {
//                     if (note>noteMax) noteMax=note;
//                     if (note<noteMin) noteMin=note;
//                     noteSom += note;
//                     noteNbr++;
//                   } else {
//                     couleur("rouge");
//                     print("Erreur de saisi, la note est sur 20\n");
//                   }
//                }
//                break;
//       case 2:  couleur("vert");
//                print("---- La plus grande note ----\n");
//                print($"La note la plus grande est: {noteMax}/20\n"); 
//                break;
//       case 3:  couleur("rouge");
//                print("---- La plus petite note ----\n");
//                print($"La note la plus petite est: {noteMin}/20\n"); 
//                break;
//       case 4:  couleur("cyan");
//                print("---- La moyenne des notes ----\n");
//                print($"La moyenne est de: {(noteSom / noteNbr):F1}/20\n");
//                break;
//       case 0:  Environment.Exit(0); break;
//       default: couleur("rouge");
//                print("choix possible sont: 0-quitter, 1-saisi, 2-note max, 3-note min, 4-moyenne.\n");
//                break;
//    }
// } while (true);

/////////////////////////////////////////////////////////////////exercice 36
// Console.Clear();
// print ("--- Tableaux des notes ---\n");
// int noteNbr = 0;
// do {
//    if (lireInt36("Combiens de notes comportera le tableau: ", ref noteNbr)) {
//       if (noteNbr >= 0) break;
//       else Erreur ("La négativité n'est pas tolérée dans ce programme\n");  }
//    else Erreur ("Erreur de saisie, merci de saisir un chiffre/nombre\n");
// } while (true);

// if (noteNbr == 0) { print("Tchusss\n\n");  Environment.Exit(0);  }

// print($"\nMerci de saisir {((noteNbr == 1) ? "la note" : $"les {noteNbr} notes")}\n\n");

// int[] note = new int[noteNbr];
// for (int i=0; i<noteNbr; i++) {
//    do {
//       if (lireInt36($"\t-Note {i+1}: ", ref note[i])) {
//          if (note[i]>=0 && note[i]<=20) break;
//          else Erreur ("Les notes doivent être comprise entre 0 et 20\n");  }
//       else Erreur ($"Erreur, merci de saisir un chiffre/nombre pour la note {i+1}\n");
//    } while (true);
// }

// couleur("jaune");
// print("\n--- Liste des notes ---\n");
// couleur("blanc");
// for (int i=0; i<noteNbr; i++) print($"La note {i+1} est de : {note[i],2}/20\n");

// couleur("vert");
// print($"\n--- La note max est : {note.Max()}/20\n");
// couleur("rouge");
// print($"--- La note min est : {note.Min()}/20\n");
// couleur("cyan");
// print($"--- La moyenne est de : {note.Average():F2}/20\n\n");
// couleur("blanc");

// static void Erreur (string message) {
//    Console.ForegroundColor = ConsoleColor.Red;
//    print (message);
//    Console.ForegroundColor = ConsoleColor.White;
// }

static bool lireInt36 (string message, ref int valeur) {
   Console.Write(message);
   return (int.TryParse(Console.ReadLine(), out valeur));
}

/////////////////////////////////////////////////////////exercice 37
// print("--- Énumération du tableau avec un foreach ---\n");
// string[] moi = {"Janvier", "Février", "Mars", "Avril", "Mai", "Juin", "Juillet", "Août", "Septembre", "Octobre", "Novembre", "Décembre"};

// string tabulations = "";
// foreach (string toto in moi) {
//    print($"{tabulations}{toto}\n");
//    tabulations += "\t";
// }

/////////////////////////////////////////////////////////exercice 38
// print("--- Où est passé mon numéros ? ---\n");
// print("Affectation des valeures...\n");
// int marmite = 10; int numero = 0;
// int[] tabloch = new int[marmite];
// Random hazard = new Random();
// for(int i = 0; i<marmite; i++) tabloch[i] = hazard.Next(1, 51);
// numero = tabloch[0];
// affichache(tabloch, numero);
// Array.Sort(tabloch);
// int tutu = affichache(tabloch, numero);
// print($"Le nombre {numero} se trouvait en 1ere position.\n");
// print($"Il se retrouve à la position {tutu+1} après triage");

// static int affichache (int[] toblach, int numero) {
//    int retour = -1;
//    string tabulatasse = "";
//    int index = 0;
//    foreach (int val in toblach) {
//       print($"{tabulatasse}{val}\n");
//       tabulatasse += "  ";
//       if (val == numero) retour = index; else index++;
//    }
//    return retour;
// }

///////////////////////////////////////////////////////////exercice 39
// List<string> tabOrig = new List<string> {"Anthony \"the C# BOSS\" Di Persio", "Corentin", "Jamila", "Mickael", "Wilfried", "Youness", "Fabien", "Meriem", "Olive", "Patrick", "Tarik", "Denis", "Jerome"};
// List<byte> tabOrigGenre = new List<byte> {1, 1, 2, 1, 1, 1, 1, 2, 2, 1, 1, 1, 1};
// List<string> tabDest = new List<string>();
// List<byte> tabDestGenre = new List<byte>();
// int choix = 0;
// int gagnang = 0;
// string idefix = "", panoramix = "";
// Random hazard = new Random();

// do {
//    Console.Clear();
//    couleur("blanc");
//    print("--- Le grand tirage au sort ---\n\n");
//    print("1- Effectuer un tirage\n");
//    print("2- Voir la liste des personnes déjà tirées\n");
//    print("3- Voir la liste des personnes restantes\n");
//    print("0- Quitter\n");
//    while(!lireInt36("Faites votre choix: ", ref choix));
//    switch (choix) {
//       case 1:  if (tabOrig.Count == 0) { 
//                   couleur("jaune");
//                   print("Le grand tirage recommence, tout le monde gagne, faite vos jeux.\n");
//                   couleur("blanc");
//                   tabOrig = tabDest;
//                   tabOrigGenre = tabDestGenre;
//                   tabDest = new List<string>();
//                   tabDestGenre = new List<byte>();
//                   attendre();
//                   break;
//                }
//                gagnang = hazard.Next(0, tabOrig.Count);
//                if (tabOrigGenre[gagnang] == 2) {  idefix = "se gagnante"; panoramix = "**";  }
//                if (tabOrigGenre[gagnang] == 1) {  idefix = "x gagnant"; panoramix = "";  }
//                couleur("vert");
//                print($"{panoramix}****************************{asterix(tabOrig[gagnang].Length)}\n");
//                print($"* L'heureu{idefix} est : {tabOrig[gagnang]} *\n");
//                print($"{panoramix}****************************{asterix(tabOrig[gagnang].Length)}\n");
//                couleur("blanc");
//                tabDest.Add(tabOrig[gagnang]);
//                tabDestGenre.Add(tabOrigGenre[gagnang]);
//                tabOrig.RemoveAt(gagnang);
//                tabOrigGenre.RemoveAt(gagnang);
//                attendre();
//                break;
//       case 2:  couleur("rouge");
//                print("***********************************\n");
//                print($"* Liste des personnes déjà tirés: *\n");
//                print("***********************************\n");
//                couleur("blanc");
//                if (tabDest.Count == 0) print("personne ne s'est encore fait tirer.\n");
//                else M2iChampions(tabDest);
//                print($"total:{tabDest.Count}\n");
//                attendre(); 
//                break;
//       case 3:  couleur("cyan");
//                print("****************************************\n");
//                print($"* N'ont pas encore fait de correction: *\n");
//                print("****************************************\n");
//                couleur("blanc");
//                if (tabOrig.Count == 0) print("il n'ya plus personne ici, c'est vide est froid.\n");
//                else M2iChampions(tabOrig);
//                print($"total:{tabOrig.Count}\n");
//                attendre(); 
//                break;
//       case 0: Environment.Exit(0); break;
//       default : couleur("rouge"); 
//                print("Erreur 404 - votre choix n'est pas au menu.\n");
//                couleur("blanc");
//                attendre(); 
//                break;
//    }
// } while (true);

// static void M2iChampions (List<string> tabloche) {
//    string unDentTaChion = "";
//    foreach(string val in tabloche) {
//       print($"{unDentTaChion}{val}\n");
//       unDentTaChion += "  ";
//    }
// }
// static string asterix (int obelix){
//    string retour = "";
//    for (int i=0; i<obelix; i++) retour += "*";
//    return retour;
// }


///////////////////////////////////////////////////////////////////////// exo regex
string agePatron = @"^[1-9]{1,2}$";
string ageNetPatran = "";
string courrielPatron = @"^([a-z0-9\.]+)@([a-z0-9\.]+)$";
string courrielNetPatron = @"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$";
string telPatron = @"^([0-9]{2}(\.|\s|\-)?){4}[0-9]{2}$";
string telNetPatron = @"^([+33|0]+)(\s|\.|\-)?([1-9]{1})(\.|\s|\-)?([0-9]{2}(\.|\s|\-)?){4}$";

// if (MailRegex ("toto.titi@free.fr")) print ("courriel corrext\n"); else print ("courriel INCORREXT\n");
// if (AgeRegex ("11")) print ("age correct\n"); else print ("age INCORRECT\n");
// if (TelRegex ("06.41.76 4403")) print ("téléphone correct\n"); else print ("téléphone INCORRECT\n");
string testoto = "06 41 76-44.03";
print (testoto); print ("\n");
print (FormatTel(testoto));     // +33 6 41 76 44 03
print ("\n");

bool MailRegex (string toto){  return Regex.IsMatch(toto, courrielPatron);  }

bool TelRegex (string toto){  return Regex.IsMatch(toto, telPatron);  }

bool AgeRegex (string toto){  return Regex.IsMatch(toto, agePatron);  }

string FormatTel (string toto){
   List<(string pat, string rep)> titi = new List<(string pat, string rep)> {(@"[\.\-]+", " "), (@"^(0|33)", "+33 "),  (@"\s+", " ")};
   foreach (var S in titi) toto = Regex.Replace(toto, S.pat, S.rep);
   return toto;
}





/////////////////////////////////////////// test class
// toto concombre = new toto();
// concombre.afficheProut();
// concombre.prout = "ton geulle";
// concombre.afficheProut();
// class toto {
//    public string prout = "-";
//    public void afficheProut() {
//       Console.WriteLine(prout);
//    }
// }








