using API_TEST_1.Models;
using API_TEST_1.Repos;
using Microsoft.AspNetCore.Mvc;

namespace API_TEST_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibroController : ControllerBase
    {
        private readonly IRepository<Libro> _repository;

        public LibroController(IRepository<Libro> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Libro>> Get()
        {
            return Ok(_repository.GetAll());
        }

        // Aggiungi qui i metodi POST, PUT, DELETE...
    }
}
