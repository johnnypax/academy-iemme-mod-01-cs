using DB_lez05_libreria_task.Models;
using DB_lez05_libreria_task.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_lez05_libreria_task.DAL
{
    internal class UtenteDAL : IDal<Utente>
    {
        private static UtenteDAL? instance;

        public static UtenteDAL getInstance()
        {
            if (instance == null)
                instance = new UtenteDAL();

            return instance;
        }

        private UtenteDAL() { } 

        public bool Delete(Utente t)
        {
            bool riuscito = false;

            using (SqlConnection con = new SqlConnection(Config.getInstance().getConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE Utente SET deleted = CURRENT_TIMESTAMP WHERE utenteID = @id AND deleted IS NULL";
                cmd.Parameters.AddWithValue("@id", t.Id);

                try
                {
                    con.Open();

                    if (cmd.ExecuteNonQuery() > 0)
                        riuscito = true;
                }
                catch (Exception ex) { Console.WriteLine($"Utente non trovato \n\n{ex}"); }
                finally { con.Close(); }
            }

            return riuscito;

        }

        public List<Utente> GetAll()
        {
            throw new NotImplementedException();
        }

        public Utente? GetById(int id)
        {
            Utente? ute = null;

            using (SqlConnection con = new SqlConnection(Config.getInstance().getConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT utenteID, nome, cognome, email, codiceUtente FROM Utente WHERE utenteID = @id AND deleted IS NULL";
                cmd.Parameters.AddWithValue("@id", id);
                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();

                    ute = new Utente()
                    {
                        Id = Convert.ToInt32(reader[0]),
                        Nome = reader[1].ToString(),
                        Cognome = reader[2].ToString(),
                        Email = reader[3].ToString(),
                        Codice = reader[4].ToString(),
                        ElencoPrestiti = PrestitoDAL.getInstance().GetByUtenteId(id),
                    };

                }
                catch (Exception ex) { Console.WriteLine($"Utente non trovato \n\n{ex}"); }
                finally { con.Close(); }
            }

            return ute;
        }

        public bool Insert(Utente t)
        {
            throw new NotImplementedException();
        }

        public bool Update(Utente t)
        {
            throw new NotImplementedException();
        }

        public Utente? GetByIdParziale(int id)
        {
            Utente? ute = null;

            using (SqlConnection con = new SqlConnection(Config.getInstance().getConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT utenteID, nome, cognome, email, codiceUtente FROM Utente WHERE utenteID = @id AND deleted IS NULL";
                cmd.Parameters.AddWithValue("@id", id);
                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();

                    ute = new Utente()
                    {
                        Id = Convert.ToInt32(reader[0]),
                        Nome = reader[1].ToString(),
                        Cognome = reader[2].ToString(),
                        Email = reader[3].ToString(),
                        Codice = reader[4].ToString(),
                    };

                    con.Close();
                }
                catch (Exception ex) { Console.WriteLine($"Utente non trovato \n\n{ex}"); }
                finally { con.Close(); }
            }

            return ute;
        }
    }
}
