using DB_lez01_introduzione.Models;
using System.Data.SqlClient;

namespace DB_lez01_introduzione
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string credenziali = "Server=BOOK-N57JVKH6HJ\\SQLEXPRESS;Database=acc_lez24_citta;User Id=academy;Password=academy!;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=false";

            #region Elenco Citta
            //List<Citta> elenco = new List<Citta>();

            //using (SqlConnection connessione = new SqlConnection(credenziali))
            //{
            //    string query = "SELECT cittaID, nome, prov FROM Citta";
            //    SqlCommand comando = new SqlCommand(query, connessione);

            //    connessione.Open();

            //    SqlDataReader reader = comando.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        //Console.WriteLine($"{reader[0]} {reader[1]} {reader[2]}");

            //        Citta citta = new Citta() { 
            //            Id = Convert.ToInt32(reader[0]),
            //            Nome = reader[1].ToString(),
            //            Provincia = reader[2].ToString(),
            //        };

            //        elenco.Add(citta);
            //    }

            //    connessione.Close();
            //}

            //foreach (Citta cit in elenco)
            //{
            //    Console.WriteLine($"{cit.Nome} {cit.Provincia} {cit.Id}");
            //}
            #endregion

            #region Controlla username
            //string username = "' OR 1=1 OR '' = '";     //Esempio di SQL Injection
            //string password = "passwrdo";

            //using (SqlConnection connessione = new SqlConnection(credenziali))
            //{
            //    string query = $"SELECT userID, usern, passw " +
            //        $"FROM Utenti " +
            //        $"WHERE usern = '{username}' AND passw = '{password}'";

            //    SqlCommand comando = new SqlCommand(query, connessione);

            //    connessione.Open();

            //    SqlDataReader reader = comando.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        Console.WriteLine($"{reader[0]} {reader[1]} {reader[2]}");
            //    }

            //    connessione.Close();
            //}
            #endregion

            #region Inserisci Citta
            string nome = "Pineto";
            string prov = "PE";

            using (SqlConnection con = new SqlConnection(credenziali))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO Citta(nome, prov) VALUES (@nomeCitta, @provCitta)";
                cmd.Parameters.AddWithValue("@nomeCitta", nome);
                cmd.Parameters.AddWithValue("@provCitta", prov);

                try
                {
                    con.Open();
                    int affRows = cmd.ExecuteNonQuery();
                    if (affRows > 0)
                        Console.WriteLine("STAPPO, inserimento ok!");
                    else
                        Console.WriteLine("Errore di inserimento");

                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine($"ERRORE, violazione vincolo! {sqlEx.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                } finally 
                {
                    Console.WriteLine("Connessione chiusa!");
                    con.Close(); 
                }
                
            }
            #endregion
        }
    }
}
