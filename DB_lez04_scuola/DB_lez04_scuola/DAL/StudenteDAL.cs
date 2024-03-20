using DB_lez04_scuola.Models;
using DB_lez04_scuola.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_lez04_scuola.DAL
{
    internal class StudenteDAL : IDal<Studente>
    {
        private static StudenteDAL? istanza;

        public static StudenteDAL getIstanza()
        {
            if(istanza == null)
                istanza = new StudenteDAL();

            return istanza;
        }

        private StudenteDAL() { }   

        public bool Delete(Studente t)
        {
            throw new NotImplementedException();
        }

        public List<Studente> GetAll()
        {
            throw new NotImplementedException();
        }

        public Studente GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Studente t)
        {
            bool risultato = false;

            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {
                SqlCommand sqlCommand = con.CreateCommand();
                sqlCommand.CommandText = "INSERT INTO Studente(nominativo, matricola) VALUES (@valNom, @valMat)";
                sqlCommand.Parameters.AddWithValue("@valNom", t.Nominativo);
                sqlCommand.Parameters.AddWithValue("@valMat", t.Matricola);

                try
                {
                    con.Open();
                    if (sqlCommand.ExecuteNonQuery() > 0)
                        risultato = true;
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

            return risultato;
        }

        public bool Update(Studente t)
        {
            throw new NotImplementedException();
        }
    }
}
