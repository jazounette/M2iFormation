using UtilitaireJC;
// using System.Data.SqlClient;
using MySql.Data.MySqlClient;
// using System;
// using System.Text;


string connetionString = null;
MySqlConnection cnn ;
connetionString = "server=localhost;database=m2iformation;uid=root;pwd=toto;";
cnn = new MySqlConnection(connetionString);
try{
      cnn.Open();
      Konzolo.Affiche($"Connection Open ! \n");
}
catch (Exception ex){
   Konzolo.Affiche($"Can not open connection ! \n");
}

      MySqlCommand cmd = cnn.CreateCommand();
      cmd.CommandText = "select * from business;";
      MySqlDataReader reader = cmd.ExecuteReader();

while (reader.Read()){
   Console.WriteLine($"{reader.GetString(0)} - {reader.GetString(1)} - {reader.GetString(2)} - {reader.GetString(3)}\n");
   //  reader.ToString();
}
      cnn.Close();


// MySql.Data.MySqlClient.MySqlConnection dbConn = new MySql.Data.MySqlClient.MySqlConnection("Persist Security Info=False;server=localhost;database=notas;uid=root;password=" + dbpwd);
// try
// {
//     dbConn.Open();                
// } catch (Exception erro) {
//     MessageBox.Show("Erro" + erro);
//     this.Close();
// }



















// SqlConnection conn = new SqlConnection();
// conn.ConnectionString =
//   "Data Source=localhost;" +
//   "Initial Catalog=m2iformation;" +
//   "User id=root;" +
//   "Password=toto;";
// conn.Open();
// connetionString = "Data Source=localhost;Initial Catalog=<Name of the Database>;User ID=root;Password=";


//   "Data Source=ServerName;" +
//   "Initial Catalog=DataBaseName;" +
//   "User id=UserName;" +
//   "Password=Secret;";               m2iformation

   // $db = new  PDO ("mysql: host=localhost; dbname=medoc", "root", "toto");

   //  builder.DataSource = "<your_server.database.windows.net>"; 
   //  builder.UserID = "<your_username>";            
   //  builder.Password = "<your_password>";     
   //  builder.InitialCatalog = "<your_database>";


   //  SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

   //  builder.DataSource = "localhost"; 
   //  builder.UserID = "root";            
   //  builder.Password = "toto";     
   //  builder.InitialCatalog = "m2iformation";

   //  using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
   //  {
   //      Console.WriteLine("\nQuery data example:");
   //      Console.WriteLine("=========================================\n");
         
   //      connection.Open();       

      //   String sql = "SELECT name, collation_name FROM sys.databases";

      //   using (SqlCommand command = new SqlCommand(sql, connection))
      //   {
      //       using (SqlDataReader reader = command.ExecuteReader())
      //       {
      //           while (reader.Read())
      //           {
      //               Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
      //           }
      //       }
      //   }                    
   //  }
// Console.WriteLine("\nDone. Press enter.");
// Console.ReadLine(); 







//   <ItemGroup>
//       <PackageReference Include="System.Data.SqlClient" Version="4.6.0" />
//   </ItemGroup>






