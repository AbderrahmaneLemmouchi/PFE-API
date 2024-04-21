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
            DateTime dateNaissance,
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
            string? idResponsable)
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
                DateNaissance = dateNaissance.ToUniversalTime(),
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
                IDResponsable = idResponsable
            };

            EmployeeDbController.Insert(employee);
            return Ok();
        }
    }
}
