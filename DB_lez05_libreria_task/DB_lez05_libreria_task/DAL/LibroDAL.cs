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
    internal class LibroDAL : IDal<Libro>
    {
        private static LibroDAL? instance;

        public static LibroDAL getInstance()
        {
            if (instance == null)
                instance = new LibroDAL();

            return instance;
        }

        private LibroDAL() { }
        public bool Delete(Libro t)
        {
            throw new NotImplementedException();
        }

        public List<Libro> GetAll()
        {
            throw new NotImplementedException();
        }

        public Libro? GetById(int id)
        {

            Libro? lib = null;

            using (SqlConnection con = new SqlConnection(Config.getInstance().getConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT libroId, titolo, annoPub, isDisponibile, isbn FROM Libro WHERE libroId = @id AND deleted IS NULL";
                cmd.Parameters.AddWithValue("@id", id);
                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();

                    lib = new Libro()
                    {
                        Id = Convert.ToInt32(reader[0]),
                        Titolo = reader[1].ToString(),
                        Anno = Convert.ToInt32(reader[2]),
                        Disp = Convert.ToBoolean(reader[3]),
                        Isbn = reader[4].ToString(),
                        ElencoPrestiti = PrestitoDAL.getInstance().GetByLibroId(
                            Convert.ToInt32(reader[0]))
                    };

                    con.Close();
                }
                catch (Exception ex) { Console.WriteLine($"Libro non trovato \n\n{ex}"); }
                finally { con.Close(); }
            }

            return lib;
        }

        public bool Insert(Libro t)
        {
            throw new NotImplementedException();
        }

        public bool Update(Libro t)
        {
            throw new NotImplementedException();
        }

        public Libro? GetByIdParziale(int id)
        {

            Libro? lib = null;

            using (SqlConnection con = new SqlConnection(Config.getInstance().getConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT libroId, titolo, annoPub, isDisponibile, isbn FROM Libro WHERE libroId = @id AND deleted IS NULL";
                cmd.Parameters.AddWithValue("@id", id);
                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();

                    lib = new Libro()
                    {
                        Id = Convert.ToInt32(reader[0]),
                        Titolo = reader[1].ToString(),
                        Anno = Convert.ToInt32(reader[2]),
                        Disp = Convert.ToBoolean(reader[3]),
                        Isbn = reader[4].ToString()
                    };

                    con.Close();
                }
                catch (Exception ex) { Console.WriteLine($"Libro non trovato \n\n{ex}"); }
                finally { con.Close(); }
            }

            return lib;
        }
    }
}
