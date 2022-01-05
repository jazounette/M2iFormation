// See https://aka.ms/new-console-template for more information
using POO.Classes;
using UtilitaireJC;

/////////////////////////////////////////////////////exemple poo
// Voiture voitureDeNico = new Voiture();
// voitureDeNico.Model = "Fiat Uno";
// voitureDeNico.Couleur= "Bleu";
// voitureDeNico.Reservoir = 55;
// voitureDeNico.Autonomie = 270_000;

// Voiture voitureDeSophie = new Voiture("Peugeot 306", "rouge", 60, 300_000);

// afficherVoiture("Nicolas", voitureDeNico);
// afficherVoiture("Sophie", voitureDeSophie);

// Console.WriteLine(voitureDeNico.Demaree);
// voitureDeNico.Demarrer();
// Console.WriteLine(voitureDeNico.Demaree);
// voitureDeNico.Demarrer();

// voitureDeNico.Klaxxon("Pouet!!!! Pouet!!!!! Pouet!!!!....");
// voitureDeSophie.Klaxxon("Reuuuuuuu............."); 

// static void afficherVoiture (string prenom, Voiture v){
//    Console.WriteLine($"--- la voiture de {prenom} ---");
//    Console.WriteLine($"model: {v.Model}");
//    Console.WriteLine($"couleur: {v.Couleur}");
//    Console.WriteLine($"capacité reservoir: {v.Reservoir}L");
//    Console.WriteLine($"autonomie: {v.Autonomie}km");
// }


///////////////////////////////////////////////////TP01 (classechaise)
// Chaise[] chaiseType = new Chaise[99];
// string[] chaiseNom = new string[99];
// string[] chaiseGenre = new string[99];

// int chaiseMax = 5;

// chaiseType[0] = new Chaise(4, "marron", "cuir");    chaiseNom[0] = "Fauteuil";      chaiseGenre[0] = "un";
// chaiseType[1] = new Chaise(3, "jaune", "métal");    chaiseNom[1] = "Tabouret";      chaiseGenre[1] = "un";
// chaiseType[2] = new Chaise(4, "or", "or");          chaiseNom[2] = "Trône de Capatékanawak"; chaiseGenre[2] = "le";
// chaiseType[3] = new Chaise(1, "gris", "plastique"); chaiseNom[3] = "Strapontin";
// chaiseType[4] = new Chaise(5, "noir", "aluminium"); chaiseNom[4] = "Herman Miller"; chaiseGenre[4] = "une";

// string bistoukette = "";
// string tirette = "", clochette = "", titre = "Affichage d'un nouvel objet", titre2 = "---------------------------";
// int tailleDe = 0, titreL = titre.Length+1;
// Konzolo.Affiche($"\n{titreL}\n");
// for (int i=0; i<chaiseMax; i++) {
//    bistoukette = $"je suis {chaiseGenre[i]} {chaiseNom[i]}, j'ai {chaiseType[i].NbPied} pied{((chaiseType[i].NbPied) == 1 ? "" : "s")}, je suis de couleur {chaiseType[i].Couleur}, et je suis fais en {chaiseType[i].Material}\n";
//    // bistoukette = "1234567890123456789012345678901234567890\n";
//    tailleDe = bistoukette.Length;
//    clochette = (tailleDe%2 == 0) ? "" : "-";
//    tirette = "";
//    for (int j=1; j<((tailleDe-titreL)/2); j++) tirette += "-";
//    Konzolo.Affiche($"{tirette} {titre} {tirette}{clochette}\n");
//    Konzolo.Affiche($"{bistoukette}");
//    Konzolo.Affiche($"{tirette}-{titre2}-{tirette}{clochette}\n\n");
// }

// Console.WriteLine(chaiseType[1]);

///////////////////////////////////////////////////TP02 (classesalarie)
// Salarie[] esclave = new Salarie[99];
// // string[] nom = {"Raoul Martinez", "Rantanplan", "Gaston Lagaffe", "Stroumph Grognon", "Clark \"S\" Kent"};
// // float[] salaire = {2500, 3300, 1500, 1900, 0};

// Startup[] titi = {
//    new Startup("Martinez", "Raoul", "de", 2500),
//    new Startup("Rantanplan", "chien", "du", 3300),
//    new Startup("Lagaffe", "Gaston", "de", 1500),
//    new Startup("Grognon", "Strounph", "du", 1900),
//    new Startup("Kent", "\"S\"", "Clark", 0)    };

// for (int i = 0; i<titi.Length; i++) {
//    esclave[i] = new Salarie(0, 0, 0, titi[i].nom, titi[i].prenom, titi[i].salaire);
//    Konzolo.Affiche($"{esclave[i].AfficherSalaire(titi[i].prepos)}Euro\n");
//    Konzolo.Couleur("cyan");
//    Konzolo.Affiche($"--------------------compteur:{Salarie.Compteur}\n\n");
//    Konzolo.Couleur("blanc");
// }
// Konzolo.Affiche($"le montant total des salaire de ma petite startup est de: {Salarie.SalaireSom}Euro\n");

// // float budgetEsclave = 0;
// // for (int i=0; i<(Salarie.Compteur-1); i++) budgetEsclave += esclave[i].Salaire;
// // print($"le montant total des salaire de ma petite startup est de: {budgetEsclave}Euro\n");

// // Salarie.Compteur = 0;
// Salarie.ResetCompteur();
// Konzolo.Affiche($"nouveau compteur vaut {Salarie.Compteur} tout le monde est viré!!!\n");
// Konzolo.Affiche($"{esclave[0]}");

// struct Startup  {
//    public string nom;
//    public string prenom;
//    public string prepos;
//    public float salaire;

//    public Startup(string nom, string prenom, string prepos, float salaire)
//    {
//       this.nom = nom;
//       this.prenom = prenom;
//       this.prepos = prepos;
//       this.salaire = salaire;
//    }
// }

///////////////////////////////////////////////////////////////TP (hors série)
// Personne[] desGens = { new Personne("M.", "Stroumph", "Grognon", 55, "06.41.72.44.03"),
//                      new Personne(),
//                      new Personne("Mme.", "Bernadette", "Chirac", 118, "06.45.32.15.89"),
//                      new Personne("Pappin", "Jean-Pierre")
// };

// foreach (Personne val in desGens) Konzolo.Affiche($"{val}\n");

///////////////////////////////////////////////////////////////TP03 (le jeu du pendu)
// char choix = ' ';
// string s = "";//le, les
// LePendu.MotGenerator();
// LePendu.GenererMasque();
// LePendu.NbEssai = 10;
// int combien = 0;
// do {
//    Console.Clear();
//    Konzolo.Affiche("--- Le jeu du Pendu ---\n", "blanc");
//    Konzolo.Affiche($"Le mot à trouver: {LePendu.Masque.ToUpper()}\n");
//    Konzolo.Affiche($"Il vous reste {LePendu.NbEssai} essai{((LePendu.NbEssai==1) ? "" : "s")}\n");
//    LePendu.DessineMoiUnPendu();
//    do {
//       while (!Konzolo.LireChar("Veuillez saisir une lettre: ", ref choix));
//       if (choix == '0') Konzolo.Affiche($"{LePendu.MotATrouve}\n");/////testrichage
//       if (choix >= 'a' && choix <= 'z') break;
//    } while (true);

//    if (LePendu.CharStack(choix)) {
//       s = (LePendu.LettreID==1) ? "" : "s";
//       Konzolo.Affiche($"Cette lettre à déjà était joué. lettre{s} déjà jouée{s}: ", "cyan");
//       foreach(char c in LePendu.Lettre) Konzolo.Affiche($"{char.ToUpper(c)}");
//       Konzolo.Affiche("\n");      }
//    else if (LePendu.TestChar(choix, ref combien)) {
//       Konzolo.Affiche($"Bravo vous avez trouvé {combien} lettre{((combien==1) ? "" : "s")}\n", "jaune");   }
//    else {  Konzolo.Affiche("Cette lettre n'est pas présente dans le mot\n", "rouge");  LePendu.NbEssai--;  } 

//    LePendu.GenererMasque();

//    if (LePendu.TestWin()) {
//       Konzolo.Affiche("\nC'EST GAGNÉ!!!!\n", "vert"); 
//       Konzolo.Affiche($"Le mot à trouver était: {LePendu.MotATrouve.ToUpper()}\n\n");
//       Konzolo.Couleur("blanc");
//       Environment.Exit(0);   }
//    else if (LePendu.NbEssai == 0) {
//       Konzolo.Affiche("\nC'EST PERDU!!!!\n", "rouge");
//       Konzolo.Affiche("vous êtes pendu haut et court\n");
//       Konzolo.Affiche($"Le mot à trouver était: {LePendu.MotATrouve.ToUpper()}\n\n");
//       Konzolo.Couleur("blanc");
//       LePendu.DessineMoiUnPendu();
//       Environment.Exit(1);   }

//    Konzolo.Couleur("blanc");
//    Konzolo.Attendre();
// } while (true);

////////////////////////////////////////////////////////////TPX1 (la banque peu populaire)
// Compte[] clienTest = new Compte[99];
// clienTest[0] = new Compte(new Client("rodriguez", "raoul", "06.12.33.80.75"));
// clienTest[1] = new Compte(new Client("fabre", "denize", "06.22.33.44.55"));

// // Konzolo.Affiche($"{clienTest[0].Numéro}\n");
// // Konzolo.Affiche($"{clienTest[1].Numéro}\n");

// clienTest[0].Opération(1111.11F);
// clienTest[0].Opération(-222.1234F);
// clienTest[0].Opération(333F);
// clienTest[0].Opération(-11);
// clienTest[1].Opération(3333);
// clienTest[1].Opération(-444);
// clienTest[1].Opération(-55);


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
//       case 6: Environment.Exit(0); break;
//       default: Konzolo.Affiche("ya rien à voir ici, circulé\n"); break;
//    }

// } while(true);

///////////////////////////////////////////////////TP04 (ClasseSalarieHéritage)
SalariéHéritage[] esclave = new SalariéHéritage[99];
// string[] nom = {"Raoul Martinez", "Rantanplan", "Gaston Lagaffe", "Stroumph Grognon", "Clark \"S\" Kent"};
// float[] salaire = {2500, 3300, 1500, 1900, 0};

Startup[] titi = {
   new Startup("Martinez", "Raoul", 2400),
   new Startup("Rantanplan", "Chien", 3300),
   new Startup("Lagaffe", "Gaston", 1500.55F),
   new Startup("Grognon", "Strounph", 1900),
   new Startup("Kent", "Clark", 0)    };
for (int i = 0; i<titi.Length; i++) esclave[i] = new SalariéHéritage(0, 0, 0, titi[i].nom, titi[i].prenom, titi[i].salaire);
esclave[5] = new Commerciale(0, 0, 0, "Jean-Claude", "Convenant", 1700, 5.55F, 97536);


int choix = 0;
string? nom = "  ", prénom = "";     float salaire=0, commission=0, chiffreAff=0;
bool trouvé = false;
while (true) {
   choix = IHMsalarié.MenuPrincipal();
   switch (choix) {
      case 1:
         do {
            choix = IHMsalarié.MenuAjouter();
            if (choix == 1) {
               nom = Konzolo.LireString("nom: ");
               prénom = Konzolo.LireString("prénom: ");
               Konzolo.LireFloat36("salaire: ", ref salaire);
               esclave[SalariéHéritage.Compteur] = new SalariéHéritage(0, 0, 0, nom, prénom, salaire);
               Konzolo.Attendre();
            }
            if (choix == 2) {
               nom = Konzolo.LireString("nom: ");
               prénom = Konzolo.LireString("prénom: ");
               Konzolo.LireFloat36("salaire: ", ref salaire);
               Konzolo.LireFloat36("commission: ", ref commission);
               Konzolo.LireFloat36("chiffre d'affaire: ", ref chiffreAff);
               esclave[SalariéHéritage.Compteur] = new Commerciale(0, 0, 0, nom, prénom, salaire, commission, chiffreAff);
            }
         } while (choix != 0);
         break;
      case 2:
         Console.Clear();
         Konzolo.Affiche($"==== Salaire des employés ====\n\n");
         for (int i = 0; i<SalariéHéritage.Compteur; i++) {  Konzolo.Affiche($"{i+1}- {esclave[i].AfficherSalaire()}\n");   }
         Konzolo.Affiche($"\nnombre d'employés:{SalariéHéritage.Compteur}\n", "cyan");
         Konzolo.Couleur("blanc");
         Konzolo.Affiche($"le montant total des salaire de ma petite entreprise est de: {SalariéHéritage.SalaireSom:F2}E\n\n");
         Konzolo.Attendre();
         break;
      case 3:
         Console.Clear();
         Konzolo.Affiche($"==== Recherche employé par nom ====\n\n");
         nom = Konzolo.LireString("nom/prénom: ").ToLower();
         trouvé = false;
         for (int i=0; i<SalariéHéritage.Compteur; i++) 
            if (esclave[i].Nom.ToLower() == nom  || esclave[i].Prenom.ToLower() == nom) {
               Konzolo.Affiche($"{esclave[i].AfficherSalaire()}\n\n");
               trouvé = true;
               break;    }
         if (!trouvé) Konzolo.Affiche($"Cet esclave ne fait pas parti de notre petite entreprise\n\n");
         Konzolo.Attendre();
         break;
      case 0: Environment.Exit(0); break;
   }
}


// for (int i = 0; i<titi.Length; i++) {
//    esclave[i] = new SalariéHéritage(0, 0, 0, titi[i].nom, titi[i].prenom, titi[i].salaire);
//    Konzolo.Affiche($"{esclave[i].AfficherSalaire(titi[i].prepos)}Euro\n");
//    Konzolo.Affiche($"--------------------compteur:{SalariéHéritage.Compteur}\n\n", "cyan");
//    Konzolo.Couleur("blanc");
// }
// Konzolo.Affiche($"le montant total des salaire de ma petite startup est de: {SalariéHéritage.SalaireSom}Euro\n");

// // float budgetEsclave = 0;
// // for (int i=0; i<(Salarie.Compteur-1); i++) budgetEsclave += esclave[i].Salaire;
// // print($"le montant total des salaire de ma petite startup est de: {budgetEsclave}Euro\n");

// // Salarie.Compteur = 0;
// SalariéHéritage.ResetCompteur();
// Konzolo.Affiche($"nouveau compteur vaut {SalariéHéritage.Compteur} tout le monde est viré!!!\n");
// Konzolo.Affiche($"{esclave[0]}");

struct Startup  {
   public string nom;
   public string prenom;
   public float salaire;

   public Startup(string nom, string prenom, float salaire)
   {
      this.nom = nom;
      this.prenom = prenom;
      this.salaire = salaire;
   }
}


