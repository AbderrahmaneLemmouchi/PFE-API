using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PFE_API.Database_Controllers;
using PFE_API.DTO;
using PFE_API.Model;
using System.Security.Claims;

namespace PFE_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        [Authorize(Roles = "RH")]//(Roles = "RH,Resposable")]
        [HttpGet("GetEmployees")]
        public IActionResult GetEmployees()
        {
            return Ok(EmployeeDbController.GetEmployees());
        }

        [HttpPost]
        //[Authorize(Roles = "RH")]
        public IActionResult InsertEmployee(
                string matricule,
                string nss,
                string nom,
                string prenom,
                string? prenom2,
                string nomArabe,
                string prenomArabe,
                string? prenom2Arabe,
                DateTime dateNaissance,
                string? nomJeuneFille,
                string? nomJeuneFilleArabe,
                string lieuNaissance,
                string paysNaissance,
                string wilayaNaissance,
                string communeNaissance,
                TypeSexe sexe,
                TypeTitre titre,
                TypeSituationFamiliale situationFamiliale,
                string nationalites,
                int reliquat,
                bool isResponsable,
                int idEquipe,
                string? idResponsable,
                DateTime dateEntre,
                //DateTime? dateSortie,
                int nbAnneeExperienceInterne,
                int nbAnneeExperienceExterne,
                int? nbEnfant,
                string email,
                string password,
                string role
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
                DateNaissance = DateOnly.FromDateTime(dateNaissance),
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
                LinkToPhoto = "",
                Reliquat = reliquat,
                IsResponsable = isResponsable,
                IDEquipe = idEquipe,
                IDResponsable = idResponsable,
                DateEntre = DateOnly.FromDateTime(dateEntre),
                //DateSortie = DateOnly.FromDateTime(dateSortie),
                NbAnneeExperienceInterne = nbAnneeExperienceInterne,
                NbAnneeExperienceExterne = nbAnneeExperienceExterne,
                NbEnfant = nbEnfant,
                Email = email
            };

            var user = new User(email, password, role);

            if (EmployeeDbController.GetEmployeeByEmail(email) != null)
            {
                return BadRequest("Email already exists");
            }

            EmployeeDbController.Insert(employee);
            LoginDbController.Register(user);
            return Ok();
        }

        [Authorize]
        [HttpPost("GetMe")]
        public IActionResult GetByEmail()
        {
            var email = User.Claims.Where(c => c.Type == ClaimTypes.Email).Select(c => c.Value).FirstOrDefault();
            var employee = EmployeeDbController.GetEmployeeByEmail(email);
            var result = EmployeeDTO.FromEmployee(employee);
            return Ok(result);
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

        [HttpGet("GetEmployeeScore")]
        public IActionResult GetEmployeeScore(string mat)
        {
            return Ok(EmployeeDbController.GetScore(mat));
        }

        [HttpPost("UpdateEmployeeScore")]
        public IActionResult UpdateEmployeeScore(string mat, int score)
        {
            EmployeeDbController.UpdateScore(mat, score);
            return Ok();
        }

        [HttpGet("isEmployeePresent")]
        public IActionResult IsEmployeePresent(string mat, DateTime date)
        {
            return Ok(EmployeeDbController.IsPresent(mat, DateOnly.FromDateTime(date)));
        }

        [HttpGet("GetEmployeesByEquipe")]
        public IActionResult GetEmployeesByEquipe(int idEquipe)
        {
            return Ok(EmployeeDbController.GetEmployeesByEquipe(idEquipe));
        }

        [HttpGet("GetEmployeesByResponsable")]
        public IActionResult GetEmployeesByResponsable(string idResponsable)
        {
            return Ok(EmployeeDbController.GetEmployeesByResponsable(idResponsable));
        }



        [HttpGet("GetSexe")]
        public IActionResult GetSexe()
        {
            return Ok(Enum.GetValues(typeof(TypeSexe)).Cast<TypeSexe>().Select(v => new { id = (int)v, name = v.ToString() }));
        }

        [HttpGet("GetTitre")]
        public IActionResult GetTitre()
        {
            return Ok(Enum.GetValues(typeof(TypeTitre)).Cast<TypeTitre>().Select(v => new { id = (int)v, name = v.ToString() }));
        }

        [HttpGet("GetSituationFamiliale")]
        public IActionResult GetSituationFamiliale()
        {
            return Ok(Enum.GetValues(typeof(TypeSituationFamiliale)).Cast<TypeSituationFamiliale>().Select(v => new { id = (int)v, name = v.ToString() }));
        }

        [Authorize()]
        [HttpGet("Test")]
        public IActionResult Test()
        {
            var email = User.Claims.Where(c => c.Type == ClaimTypes.Email).Select(c => new { c.Value }).FirstOrDefault();
            var roleClaims = User.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();
            return Ok(roleClaims);
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
