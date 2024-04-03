using ASP_lez02_EF_libreria.Models;
using ASP_lez02_EF_libreria.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ASP_lez02_EF_libreria.Controllers
{
    [ApiController]
    [Route("api/libri")]
    public class LibroController : Controller
    {
        [HttpGet]
        public IActionResult ElencoLibri()          //https://localhost:7071/api/libri
        {
            return Ok( LibroRepo.getInstance().GetAll() );
        }

        [HttpGet("{valCodice}")]
        public IActionResult DettaglioLibro(string valCodice)   
        {
            Libro? lib = LibroRepo.getInstance().GetByCodice(valCodice);
            if(lib is not null) 
                return Ok( lib );

            return NotFound();
        }

        [HttpPost]
        public IActionResult InserisciLibro(Libro objLib)
        {
            if (LibroRepo.getInstance().insert(objLib))
                return Ok();

            return BadRequest();
        }

        //[HttpDelete("{varId}")]                           //Pericolosa ;(
        private IActionResult EliminaLibro(int varId)
        {
            if (LibroRepo.getInstance().delete(varId))
                return Ok();

            return BadRequest();
        }

        //TODO: Elimina per codice

        [HttpDelete("codice/{varCodice}"), HttpPost("codice/{varCodice}")]
        public IActionResult EliminaPerCodiceLibro(string varCodice)
        {
            Libro? lib = LibroRepo.getInstance().GetByCodice(varCodice);
            if(lib is null)
                return BadRequest();

            return EliminaLibro(lib.LibroId);
        }

        [HttpPut]
        public IActionResult ModificaLibro(Libro objLib)
        {
            if(LibroRepo.getInstance().update(objLib))
                return Ok();

            return BadRequest();
        }

    }
}
