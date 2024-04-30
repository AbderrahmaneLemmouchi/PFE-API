using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using PFE_API.Model;

namespace PFE_API.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class DemandeController : ControllerBase
    {
        [HttpGet("GetDemandesByEmp")]
        public IActionResult GetDemandesByEmp(string Emp)
        {
            return Ok(DemandeDbController.GetDemandes());
        }

        [HttpGet("GetDemandesByType")]
        public IActionResult GetDemandesByType(TypeDemande type)
        {
            return Ok(DemandeDbController.GetDemandesByType(type));
        }

        [HttpPost("Insert")]
        public IActionResult InsertDemande(string matEmp, TypeDemande type, DateTime? dateDebut, DateTime? dateFin, string? commentaire, TypeDocument? typeDocument)
        {
            var demande = new Demande()
            {
                MatriculeEmp = matEmp,
                Type = type,
                DateCreation = DateTime.UtcNow,
            };
            switch (type)
            {
                case TypeDemande.Conge:
                    demande.DateDebut = dateDebut?.ToUniversalTime();
                    demande.DateFin = dateFin?.ToUniversalTime();
                    demande.Commentaire = commentaire;
                    break;
                case TypeDemande.Absence:
                    demande.DateDebut = dateDebut?.ToUniversalTime();
                    demande.DateFin = dateFin?.ToUniversalTime();
                    demande.Commentaire = commentaire;
                    break;
                case TypeDemande.Document:
                    demande.TypeDoc = typeDocument;
                    break;
                //TODO: case TypeDemande.ChangementInfo:
                default:
                    return BadRequest("Type de demande inconnu OU non implementer");

            }
            try
            {
            DemandeDbController.Insert(demande);
            return Ok();

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateEtat(int id, EtatDemande newEtat)
        {
            var demande = DemandeDbController.GetDemandeById(id);
            demande.EtatActuel = newEtat;
            DemandeDbController.Update(demande);
            return Ok();
        }
    }
}
