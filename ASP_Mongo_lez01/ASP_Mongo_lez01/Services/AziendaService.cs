using ASP_Mongo_lez01.Models;
using ASP_Mongo_lez01.Repos;

namespace ASP_Mongo_lez01.Services
{
    public class AziendaService
    {
        private readonly AziendaRepository _repo;

        public AziendaService(AziendaRepository repo)
        {
            _repo = repo;
        }

        public bool Inserimento(ImpiegatoDTO objDto)
        {
            Impiegato imp = new Impiegato()
            {
                Nominativo = objDto.Nom,
                Matricola = objDto.Mat,
                Dipartimento = objDto.Dip,
                DataAssunzione = objDto.Dat
            };

            return _repo.Insert(imp);
        }

        public List<ImpiegatoDTO> Restituisci()
        {
            List<ImpiegatoDTO> elenco = new List<ImpiegatoDTO>(); 
            foreach(Impiegato imp in _repo.GetAll())
            {
                elenco.Add(
                    new ImpiegatoDTO() { 
                        Nom = imp.Nominativo, 
                        Mat = imp.Matricola, 
                        Dip = imp.Dipartimento, 
                        Dat = imp.DataAssunzione 
                    });
            }
            return elenco;
        }

        public ImpiegatoDTO? RestituisciImpiegato(ImpiegatoDTO objDto)
        {
            Impiegato? temp = _repo.GetByMatricola(objDto.Mat);
            if(temp != null)
            {
                return new ImpiegatoDTO()
                {
                    Nom = temp.Nominativo,
                    Mat = temp.Matricola,
                    Dip = temp.Dipartimento,
                    Dat = temp.DataAssunzione
                };
            }

            return null;
        }

        public bool EliminaImpiegato(ImpiegatoDTO objDto)
        {
            return _repo.Delete(new Impiegato() { Matricola = objDto.Mat });
        }

        public bool ModificaImpiegato(ImpiegatoDTO objDto)
        {
            return _repo.Update(new Impiegato()
            {
                Nominativo = objDto.Nom,
                Matricola = objDto.Mat,
                Dipartimento = objDto.Dip,
                DataAssunzione = objDto.Dat
            });
        }
    }
}
