using System.ComponentModel.DataAnnotations;

namespace PFE_API.Model
{
    /// <summary>
    /// Contrat de travail d'un employé
    /// </summary>
    /// <param name="codeContrat"></param>
    /// <param name="matriculeEmp"></param>
    /// <param name="categorieContrat"></param>
    /// <param name="dateDebut"></param>
    /// <param name="dateFin"></param>
    /// <param name="dateFinPeriodeEssai"></param>
    /// <param name="regimeTravail"></param>
    /// <param name="poste"></param>
    /// <param name="actif"></param>
    public class ContratRT(string codeContrat, string matriculeEmp, string categorieContrat, DateTime dateDebut, DateTime? dateFin, DateTime? dateFinPeriodeEssai, string regimeTravail, string poste, bool actif)
    {
        [Key] [Required]
        public string CodeContrat { get; set; } = codeContrat;
        public string MatriculeEmp { get; set; } = matriculeEmp;
        public string CategorieContrat { get; set; } = categorieContrat;
        public DateTime DateDebut { get; set; } = dateDebut;
        public DateTime? DateFin { get; set; } = dateFin;
        public DateTime? DateFinPeriodeEssai { get; set; } = dateFinPeriodeEssai;
        public string RegimeTravail { get; set; } = regimeTravail;
        public string Poste { get; set; } = poste;
        public bool Actif { get; set; } = actif;
    }
}
