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
        public IActionResult InsertDemande(string matEmp, TypeDemande type, DateOnly? dateDebut, DateOnly? dateFin, string? commentaire, TypeDocument? typeDocument, 
            TypeConge? typeConge, bool? isRemeneree, DateOnly? JourRecup)
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
                    demande.DateDebut = dateDebut;
                    demande.DateFin = dateFin;
                    demande.Commentaire = commentaire;
                    demande.TypeConge = typeConge;
                    break;
                case TypeDemande.Absence:
                    demande.DateDebut = dateDebut;
                    demande.DateFin = dateFin;
                    demande.Commentaire = commentaire;
                    demande.JourRecup = JourRecup;
                    demande.IsRemuneree = isRemeneree ?? false;
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

        [HttpGet("GetTypeDocuments")]
        public IActionResult GetTypeDocuments()
        {
            List<dynamic> list = new List<dynamic>();
            foreach (TypeDocument type in Enum.GetValues(typeof(TypeDocument)))
            {
                list.Add(new { id = (int)type, name = type.ToString() });
            }

            return Ok(list);
        }

        [HttpGet("GetTypeConges")]
        public IActionResult GetTypeConges()
        {
            List<dynamic> list = new List<dynamic>();
            foreach (TypeConge type in Enum.GetValues(typeof(TypeConge)))
            {
                list.Add(new { id = (int)type, name = type.ToString() });
            }

            return Ok(list);
        }

        [HttpGet("GetTypeDemandes")]
        public IActionResult GetTypeDemandes()
        {
            List<dynamic> list = [];
            foreach (TypeDemande type in Enum.GetValues(typeof(TypeDemande)))
            {
                list.Add(new { id = (int)type, name = type.ToString() });
            }

            return Ok(list);
        }


    }
}
