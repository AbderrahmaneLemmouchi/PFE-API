using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using PFE_API.Model;
using System.Security.Claims;

namespace PFE_API.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class DemandeController : ControllerBase
    {
        [HttpGet("GetDemandesByEmp")]
        public IActionResult GetDemandesByEmp(string Emp)
        {
            return Ok(DemandeDbController.GetDemandesByEmployee(Emp));
        }

        [HttpGet("GetDemandesByType")]
        public IActionResult GetDemandesByType(TypeDemande type)
        {
            return Ok(DemandeDbController.GetDemandesByType(type));
        }

        [HttpPost("Insert")]
        [Authorize]
        public IActionResult InsertDemande(TypeDemande type, DateOnly? dateDebut, DateOnly? dateFin, string? commentaire, TypeDocument? typeDocument,
            TypeConge? typeConge, bool? isRemeneree, DateOnly? JourRecup, TypeImportance importance)
        {

            //get the user's matricule
            var email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var matricule = EmployeeDbController.GetEmployeeByEmail(email).Matricule;

            var demande = new Demande()
            {
                MatriculeEmp = matricule,
                Type = type,
                DateCreation = DateTime.UtcNow,
                EtatActuel = EtatDemande.EnAttente,
                Importance = importance
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
                    demande.IsRemuneree = isRemeneree;
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

        [Authorize]
        [HttpPut]
        public IActionResult UpdateEtat(int id, EtatDemande newEtat)
        {
            var demande = DemandeDbController.GetDemandeById(id);
            demande.EtatActuel = newEtat;

            var email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var matricule = EmployeeDbController.GetEmployeeByEmail(email).Matricule;
            DemandeDbController.Update(demande, matricule);
            return Ok();
        }

        [HttpGet("GetTypeDocuments")]
        public IActionResult GetTypeDocuments()
        {
            List<dynamic> list = [];
            foreach (TypeDocument type in Enum.GetValues(typeof(TypeDocument)))
            {
                list.Add(new { id = (int)type, name = type.ToString() });
            }

            return Ok(list);
        }

        [HttpGet("GetTypeConges")]
        public IActionResult GetTypeConges()
        {
            List<dynamic> list = [];
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

        [HttpGet("GetTypeImportances")]
        public IActionResult GetTypeImportances()
        {
            List<dynamic> list = [];
            foreach (TypeImportance type in Enum.GetValues(typeof(TypeImportance)))
            {
                list.Add(new { id = (int)type, name = type.ToString() });
            }

            return Ok(list);
        }

    }
}
