namespace POO.Classes;
using UtilitaireJC;
using Newtonsoft.Json;


internal static class IHM {

   static (string type, string coul)[] typeCTexte = {("", "") , ("Gratuit", "jaune"), ("Épargne", "magenta"), ("Payant", "rouge")};

   public static int Menu(){
      int choix = -1;
      Konzolo.Affiche("***** Banque Peu Populaire *****\n\n");
      Konzolo.Affiche("1-Créer un compte bancaire\n");
      Konzolo.Affiche("2-Déposer de l'argent\n");
      Konzolo.Affiche("3-Retirer de l'argent\n");
      Konzolo.Affiche("4-Afficher un compte bancaire\n");
      Konzolo.Affiche("5-Liste des comptes bancaire\n");
      Konzolo.Affiche("6-Calcul d'intérêts\n");
      Konzolo.Affiche("0-Quitter\n\n");
      do {
         while (!Konzolo.LireInt36("Entrez votre choix: ", ref choix));
         if (choix >=0 && choix <=6)  return choix;  else Konzolo.Affiche("ce choix n'est pas au menu\n");
      } while (true);
   }

   public static void CalculInterets(Compte[] client){
      int choix = -1;
      Console.Clear();
      Konzolo.Affiche("***** Calcul des intérêts *****\n");
      bool jaiTrouvéChef;
      do {
         Konzolo.Couleur("blanc");
         while (!Konzolo.LireInt36("\nNuméro du compte (-1 pour revenir au menu): ", ref choix));
         if (choix == -1) break;
         jaiTrouvéChef = false;
         for (int i=0; i<Compte.Nombre; i++)  {
            if (choix == client[i].Numéro)  {
               jaiTrouvéChef = true;
               if (client[i].Client.Type == 2) {
                  Konzolo.Affiche($"Taux d'intérêt pour ce compte: {client[i].Client.Taux}%\n");
                  Konzolo.Affiche($"Solde du compte: {client[i].Solde}\n");
                  client[i].Opération(client[i].Solde * client[i].Client.Taux / 100);
                  Konzolo.Affiche($"Nouveau solde: {client[i].Solde}\n");        }
               else Konzolo.Affiche($"ce compte n'est pas un compte épargne\n");
               break;
            }
         }
         if (!jaiTrouvéChef) Konzolo.Affiche("Ce numéro de compte n'est pas valide, j'appelle les gendarmes.\n", "jaune");
      } while (true);
   }

   public static void ListeCompte(Compte[] client) {
      string nomprénom;
      Console.Clear();
      Konzolo.Affiche($"***** Liste des comptes Bancaire *****\n\n");
      for (int i=0; i<Compte.Nombre; i++)   {
         nomprénom = client[i].Client.Nom + ", " + client[i].Client.Prénom;
         Konzolo.Affiche($"{i+1,3}-  {client[i].Numéro}", "gris");
         Konzolo.Affiche($"{typeCTexte[client[i].Client.Type].type,9}", typeCTexte[client[i].Client.Type].coul);
         Konzolo.Affiche($"{nomprénom,24}{client[i].Client.Tel,18}", "gris");
         Konzolo.Affiche($"{client[i].Solde,10:0.00}\n", "vert");     }
      Konzolo.Couleur("blanc");    Konzolo.Affiche($"\n");    Konzolo.Attendre();
   }

   public static void AfficherCompte(Compte[] client) {
      int choix = -1;
      Console.Clear();
      Konzolo.Affiche("***** Afficher un compte *****\n");
      bool jaiTrouvéChef;
      do {
         Konzolo.Couleur("blanc");
         while (!Konzolo.LireInt36("\nNuméro du compte (-1 pour revenir au menu): ", ref choix));
         if (choix == -1) break;
         jaiTrouvéChef = false;
         for (int i=0; i<Compte.Nombre; i++)  {
            if (choix == client[i].Numéro)  {
               jaiTrouvéChef = true;
               Konzolo.Affiche($"{client[i].Client.Nom}, {client[i].Client.Prénom} - Téléphone:{client[i].Client.Tel}\n", "cyan");
               Konzolo.Affiche($"Compte {typeCTexte[client[i].Client.Type].type}\n", typeCTexte[client[i].Client.Type].coul);
               Konzolo.Affiche($"\t\t\t\tSolde:{client[i].Solde:00.00}\n", "vert");
               Konzolo.Affiche("Liste des Opérations:\n", "cyan");
               client[i].ListOpé();
               break;
            }
         }
         if (!jaiTrouvéChef) Konzolo.Affiche("Ce numéro de compte n'est pas valide, j'appelle les gendarmes.\n", "jaune");
      } while (true);
   }

   public static bool Opération(string typeOpé, Compte[] client){
      if (  !((typeOpé == "retrait") || (typeOpé == "dépot")) ) return false;
      string courgette = "";
      if (typeOpé == "dépot")  courgette = "Déposer";
      if (typeOpé == "retrait")  courgette = "Retirer";

      int choixA = -1;
      float credRet = -1;
      bool jaiTrouvéChef, opéRéussi;

      Console.Clear();
      Konzolo.Affiche($"***** {courgette} de l'argent *****\n");
      do {
         Konzolo.Couleur("blanc");
         while (!Konzolo.LireInt36("\nNuméro du compte (-1 pour revenir au menu): ", ref choixA));
         if (choixA == -1) break;
         jaiTrouvéChef = false; opéRéussi = false;
         for (int i=0; i<Compte.Nombre; i++)  {
            if (choixA == client[i].Numéro)  {
               jaiTrouvéChef = true;
               while (!Konzolo.LireFloat36($"Merci de saisir le montant du {typeOpé}: ", ref credRet));
               if (credRet < 0) break;
               if (typeOpé == "retrait") credRet *= -1;////s'il s'agit d'un retrait, le choix doit être négatif /// un dépot négatif équivau un retrait et visa verso
               if (client[i].Opération(credRet)) opéRéussi=true;
               break;
            }
         }
         if (!jaiTrouvéChef) {  Konzolo.Affiche("Ce numéro de compte n'est pas valide, j'appelle les gendarmes.\n", "jaune"); }
         else if (opéRéussi)  {  Konzolo.Affiche($"\n{typeOpé} réussi\n\n", "vert"); break;  }
         else  {  Konzolo.Affiche($"\nl'opération de {typeOpé} à échoué\n\n", "rouge"); break;  }
      } while (true);

      Konzolo.Couleur("blanc");
      Konzolo.Attendre();
      return false;
   }

   public static bool NouveauClient(Compte[] compte) {
      string? nom, prénom, téléfoune;// le ? est pour héviter les warnings à cause de retour possible de valeur nul
      int typeCompte = -1;
      float taux = -1;
      Console.Clear();
      Konzolo.Affiche("***** Création d'un nouveau compte *****\n\n");
      nom = Konzolo.LireString("Le nom du client: ");
      prénom = Konzolo.LireString("Le prénom du client: ");
      téléfoune = Konzolo.LireString("Le téléphone du client: ");
      bool unTourGratuit = true;
      do {
         while (!Konzolo.LireInt36("Type du compte (1-gratuit, 2-épargne, 3-Payant): ", ref typeCompte));
         switch (typeCompte) {
            case 1: taux = 1; unTourGratuit=false; break;
            case 2: while (!Konzolo.LireFloat36("Taux d'épargne de ce compte: ", ref taux)); unTourGratuit=false;   break;
            case 3: while (!Konzolo.LireFloat36("Coût Opération pour ce compte: ", ref taux)); unTourGratuit=false;   break;
            default: Konzolo.Affiche("ce choix n'est pas au menu\n"); break;
         }
      } while (unTourGratuit);
      compte[Compte.Nombre] = new Compte(new Client(nom, prénom, téléfoune, (sbyte)typeCompte, taux ));
      Konzolo.Couleur("vert");
      Konzolo.Affiche($"\nCompte bien crée voici le numéro de compte: {compte[Compte.Nombre-1].Numéro}\n\n");
      Konzolo.Couleur("blanc");

      Konzolo.Attendre();
      return false;
   }

   public static void Quitter(Compte[] compte){
      StreamWriter écriteur = new StreamWriter("CompteBancaire.json");
      // écriteur.WriteLine(JsonConvert.SerializeObject(compte)); 
      for(int i=0; i<Compte.Nombre; i++) {
         écriteur.WriteLine(JsonConvert.SerializeObject(compte[i]));
         écriteur.WriteLine(JsonConvert.SerializeObject(compte[i].Client));
         écriteur.WriteLine(JsonConvert.SerializeObject(compte[i].Operation));
      }
      écriteur.Close();

      Environment.Exit(0);
   
   }


}