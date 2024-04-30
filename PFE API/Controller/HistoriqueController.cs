using Microsoft.AspNetCore.Mvc;

namespace PFE_API.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class HistoriqueController : ControllerBase
    {
        [HttpGet("GetHistorique")]
        public IActionResult GetHistoriqueDemande(int id)
        {
            return Ok(HistoriqueDbController.GetHistoriqueDemande(id));
        }
    }
}
