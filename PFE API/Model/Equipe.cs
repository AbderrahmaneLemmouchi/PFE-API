using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFE_API.Model
{
    public class Equipe
    {
        [Key]
        public int IDEquipe { get; set; }
        public string NomEquipe { get; set; }
        [ForeignKey("Employee")]
        public string Responsable { get; set; }
        public string Description { get; set; }

        public int rattache { get; set; }

        public Equipe() // Parameterless constructor
        {
            // Initialize properties with default values if needed
        }

        public Equipe(int iDEquipe, string nomEquipe, string responsable, string description, int rattache)
        {
            IDEquipe = iDEquipe;
            NomEquipe = nomEquipe;
            Responsable = responsable;
            Description = description;
            this.rattache = rattache;
        }

    }
}
