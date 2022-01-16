namespace SQL.Classes;
using MySql.Data.MySqlClient;
using UtilitaireJC;


internal static class DBM {
   static MySqlConnection conne;

   public static void InitDBM() {
   string chaineDeConne = "server=localhost;database=m2iformation;uid=root;pwd=toto;";
   conne = new MySqlConnection(chaineDeConne);
   try{  conne.Open();     Konzolo.Affiche($"tout marche bien base de donnée ! \n");   conne.Close();   }
   catch (Exception ex){   Konzolo.Affiche($"croustonne? ici base de donnée, ya un problème!!!\n{ex}\n");   }
   }
}

