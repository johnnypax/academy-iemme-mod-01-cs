using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ASP_WEB_Logger.Controllers
{
    public class StudenteController : Controller
    {
        private readonly ILogger _logger;

        public StudenteController(ILogger<StudenteController> log)
        {
            _logger = log;
        }

        public IActionResult Index()
        {
            //_logger.LogInformation("QUalcuno ha visitato la index");

            try
            {
                //...
                throw new Exception("Errore di esecuzione");
            } catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return View();
        }
    }
}
