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
    internal class PrestitoDAL : IDal<Prestito>
    {
        private static PrestitoDAL? instance;

        public static PrestitoDAL getInstance()
        {
            if (instance == null)
                instance = new PrestitoDAL();

            return instance;
        }

        private PrestitoDAL() { }
        public bool Delete(Prestito t)
        {
            throw new NotImplementedException();
        }

        public List<Prestito> GetAll()
        {
            throw new NotImplementedException();
        }

        public Prestito? GetById(int id)
        {
            Prestito? pre = null;

            using (SqlConnection con = new SqlConnection(Config.getInstance().getConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT prestitoID, dataPrestito, dataRitorno, utenteRIF, libroRIF, codicePrestito FROM Prestito WHERE prestitoID = @id AND deleted IS NULL";
                cmd.Parameters.AddWithValue("@id", id);
                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();

                    pre = new Prestito()
                    {
                        Id = Convert.ToInt32(reader["prestitoID"]),
                        //Inizio = Convert.ToDateTime(reader["dataPrestito"]),
                        //Fine = Convert.ToDateTime(reader["dataRitorno"]),
                        Codice = reader["codicePrestito"].ToString(),
                        LibroCoinvolto = LibroDAL.getInstance().GetByIdParziale(
                                Convert.ToInt32(reader["libroRIF"])),
                        UtenteCoinvolto = UtenteDAL.getInstance().GetByIdParziale(
                                Convert.ToInt32(reader["utenteRIF"]))
                    };

                    con.Close();
                }
                catch (Exception ex) { Console.WriteLine($"Prestito non trovato \n\n{ex}"); }
                finally { con.Close(); }
            }

            return pre;
        }

        public bool Insert(Prestito t)
        {
            throw new NotImplementedException();
        }

        public bool Update(Prestito t)
        {
            throw new NotImplementedException();
        }

        public List<Prestito> GetByUtenteId(int id)
        {
            List<Prestito> elenco = new List<Prestito> ();

            using (SqlConnection con = new SqlConnection(Config.getInstance().getConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT prestitoID, dataPrestito, dataRitorno, codicePrestito, libroRIF FROM Prestito WHERE utenteRIF = @id AND deleted IS NULL";
                cmd.Parameters.AddWithValue("@id", id);
                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        elenco.Add(new Prestito()
                        {
                            Id = Convert.ToInt32(reader["prestitoID"]),
                            //Inizio = Convert.ToDateTime(reader["dataPrestito"]),
                            //Fine = Convert.ToDateTime(reader["dataRitorno"]),
                            Codice = reader["codicePrestito"].ToString(),
                            LibroCoinvolto = LibroDAL.getInstance().GetById(
                                Convert.ToInt32(reader["libroRIF"]))
                        });

                    }


                    con.Close();
                }
                catch (Exception ex) { Console.WriteLine($"Prestito non trovato \n\n{ex}"); }
                finally { con.Close(); }
            }

            return elenco;
        }

        public List<Prestito> GetByLibroId(int id)
        {
            List<Prestito> elenco = new List<Prestito>();

            using (SqlConnection con = new SqlConnection(Config.getInstance().getConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT prestitoID, dataPrestito, dataRitorno, codicePrestito, utenteRIF FROM Prestito WHERE libroRIF = @id AND deleted IS NULL";
                cmd.Parameters.AddWithValue("@id", id);
                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        elenco.Add(new Prestito()
                        {
                            Id = Convert.ToInt32(reader["prestitoID"]),
                            //Inizio = Convert.ToDateTime(reader["dataPrestito"]),
                            //Fine = Convert.ToDateTime(reader["dataRitorno"]),
                            Codice = reader["codicePrestito"].ToString(),
                            UtenteCoinvolto = UtenteDAL.getInstance().GetById(
                                Convert.ToInt32(reader["utenteRIF"]))
                        });

                    }


                    con.Close();
                }
                catch (Exception ex) { Console.WriteLine($"Prestito non trovato \n\n{ex}"); }
                finally { con.Close(); }
            }

            return elenco;
        }
    }
}
