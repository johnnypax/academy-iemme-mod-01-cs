using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_TEST_1.Services
{

        public class LibroService : IService<LibroService>
        {
            private readonly IRepository<Libro> _repository;

            public LibroService(IRepository<Libro> repo)
            {
                _repository = repo;
            }

            public IEnumerable<LibroDTO> GetAllLibri()
            {
                var libri = _libroRepository.GetAll();

                // Conversione manuale da Libro a LibroDTO
                return libri.Select(libro => new LibroDTO
                {
                    Id = libro.Id,
                    Titolo = libro.Titolo
                    // Mappa qui altre proprietà necessarie
                }).ToList();
            }

        //public IEnumerable<Libro> GetAll()
        //{
        //    // Qui potresti aggiungere logica di business, come ordinamento, filtraggio, ecc.
        //    return _repository.GetAll();
        //}

        public Libro GetById(int id)
            {
                // Potrebbe includere logica per gestire studenti non trovati, ecc.
                return _repository.Get(id);
            }

            public void Create(Libro t)
            {
                // Qui potresti inserire validazione o altre logiche prima di creare lo studente
                _repository.Create(student);
            }

            public void Update(Libro t)
            {
                // Aggiungi qui eventuali controlli o logiche specifiche prima dell'update
                _repository.Update(student);
            }

            public void Delete(int id)
            {
                // Potresti verificare l'esistenza dello studente prima di procedere con l'eliminazione
                _repository.Delete(id);
            }
        }
}
