using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFE_API.Model
{
    public class Historique
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [ForeignKey("Demande")]
        public int IDDemande { get; set; }
        [EnumDataType(typeof(EtatDemande))]
        public EtatDemande FromEtat { get; set; }
        [EnumDataType(typeof(EtatDemande))]
        public EtatDemande ToEtat { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("Employee")]
        public string Par { get; set; } // Matricule Employé
    }
}
