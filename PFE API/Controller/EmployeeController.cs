using Microsoft.AspNetCore.Mvc;
using PFE_API.Model;

namespace PFE_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        [HttpGet("GetEmployees")]
        public IActionResult GetEmployees()
        {
            return Ok(EmployeeDbController.GetEmployees());
        }

        [HttpPost]
        public IActionResult InsertEmployee(
                string matricule,
                string nss,
                string nom,
                string prenom,
                string? prenom2,
                string nomArabe,
                string prenomArabe,
                string? prenom2Arabe,
                DateOnly dateNaissance,
                string? nomJeuneFille,
                string? nomJeuneFilleArabe,
                string lieuNaissance,
                string paysNaissance,
                string wilayaNaissance,
                string communeNaissance,
                string sexe,
                string titre,
                string situationFamiliale,
                string nationalites,
                string telephone,
                string? mobile,
                string email,
                int reliquat,
                bool isResponsable,
                int idEquipe,
                string? idResponsable,
                DateOnly dateEntre,
                DateOnly? dateSortie,
                int nbAnneeExperienceInterne,
                int nbAnneeExperienceExterne,
                int? nbEnfant
            )
        {
            var employee = new Employee
            {
                Matricule = matricule,
                NSS = nss,
                Nom = nom,
                Prenom = prenom,
                Prenom2 = prenom2,
                NomArabe = nomArabe,
                PrenomArabe = prenomArabe,
                Prenom2Arabe = prenom2Arabe,
                DateNaissance = dateNaissance,
                NomJeuneFille = nomJeuneFille,
                NomJeuneFilleArabe = nomJeuneFilleArabe,
                LieuNaissance = lieuNaissance,
                PaysNaissance = paysNaissance,
                WilayaNaissance = wilayaNaissance,
                CommuneNaissance = communeNaissance,
                Sexe = sexe,
                Titre = titre,
                SituationFamiliale = situationFamiliale,
                Nationalites = nationalites,
                Telephone = telephone,
                Mobile = mobile,
                Email = email,
                Photo = new byte[] { /* photo byte array */ },
                Reliquat = reliquat,
                IsResponsable = isResponsable,
                IDEquipe = idEquipe,
                IDResponsable = idResponsable,
                DateEntre = dateEntre,
                DateSortie = dateSortie,
                NbAnneeExperienceInterne = nbAnneeExperienceInterne,
                NbAnneeExperienceExterne = nbAnneeExperienceExterne,
                NbEnfant = nbEnfant
            };

            EmployeeDbController.Insert(employee);
            return Ok();
        }

        [HttpGet("GetByID")]
        public IActionResult GetByID(string id)
        {
            return Ok(EmployeeDbController.GetEmployeeById(id));
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            if (EmployeeDbController.Delete(id))
            {
                return Ok();
            }
            return NotFound();
        }


    }

    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetContacts(string mat)
        {
            return Ok(ContactDbController.GetContactsByEmployee(mat));
        }

        [HttpPost]
        public IActionResult InsertContact(
                       string matriculeEmp,
                                  string type,
                                             string valeur
                   )
        {
            var contact = new Contact
            {
                MatriculeEmp = matriculeEmp,
                Type = type,
                Valeur = valeur
            };

            try
            {
                ContactDbController.Insert(contact);
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }

        [HttpDelete]
        public IActionResult DeleteContact(string mat, string type, string valeur)
        {
            if (ContactDbController.Delete(mat, type, valeur))
            {
                return Ok();
            }
            return NotFound();
        }


    }
}
