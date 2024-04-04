using API_TEST_1.Models;
using API_TEST_1.Repos;
using Microsoft.AspNetCore.Mvc;

namespace API_TEST_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibroController : ControllerBase
    {
        private readonly IService<Libro> _service;

        public LibroController(IService<Libro> service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<LibroDTO>> Get()
        {
            return Ok(_service.GetAll());
        }

        // Aggiungi qui i metodi POST, PUT, DELETE...
    }
}
