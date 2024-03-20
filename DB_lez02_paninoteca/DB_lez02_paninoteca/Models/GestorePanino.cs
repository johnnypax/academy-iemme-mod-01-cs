using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_lez02_paninoteca.Models
{
    internal class GestorePanino
    {
        private string connString = "Server=BOOK-N57JVKH6HJ\\SQLEXPRESS;Database=acc_lez25_paninoteca;User Id=academy;Password=academy!;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=false";

        public List<Panino> Elenco { get; set; } = new List<Panino>();

        /// <summary>
        /// Inserimento del panino tramite oggetto
        /// </summary>
        /// <param name="pan">Oggetto panino</param>
        /// <returns></returns>
        public bool insert(Panino pan)
        {
            bool risultato = false;

            using (SqlConnection con = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO panino (nome, descrizione, prezzo, vegan) VALUES (@nome, @descrizione, @prezzo, @vegan)";
                cmd.Parameters.AddWithValue("nome", pan.Nome);
                cmd.Parameters.AddWithValue("descrizione", pan.Descrizione);
                cmd.Parameters.AddWithValue("prezzo", pan.Prezzo);
                cmd.Parameters.AddWithValue("vegan", pan.IsVegan);

                try
                {
                    con.Open();

                    if (cmd.ExecuteNonQuery() > 0)
                        risultato = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                } finally { 
                    con.Close(); 
                }
            }

            return risultato;
        }
        public List<Panino> findAll()
        {
            List<Panino> elenco = new List<Panino> ();

            using (SqlConnection con = new SqlConnection(connString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT paninoID, nome, descrizione, prezzo, vegan FROM Panino";

                try
                {
                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        elenco.Add(new Panino()
                        {
                            ID = Convert.ToInt32(reader["paninoID"]),
                            Nome = reader["nome"].ToString(),
                            Descrizione = reader["descrizione"].ToString(),
                            Prezzo = Convert.ToDouble(reader["prezzo"]),
                            IsVegan = Convert.ToBoolean(reader["vegan"])
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }

            return elenco;
        }
    }
}
