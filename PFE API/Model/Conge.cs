using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFE_API.Model
{
    public class Conge
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string MatriculeEmp { get; set; }
        [ForeignKey("Exercice")]
        public int IDExercice { get; set; }
        public DateOnly DateDebut { get; set; }
        public DateOnly DateFin { get; set; }

        public Conge() { }

        public Conge(int iD, string matriculeEmp, int iDExercice, DateOnly dateDebut, DateOnly dateFin)
        {
            ID = iD;
            MatriculeEmp = matriculeEmp;
            IDExercice = iDExercice;
            DateDebut = dateDebut;
            DateFin = dateFin;
        }
    }

    public class Exercice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int Annee { get; set; }
        public DateOnly DateDebut { get; set; }
        public DateOnly DateFin { get; set; }

        public Exercice() { }

        public Exercice(int iD, int annee, DateOnly dateDebut, DateOnly dateFin)
        {
            ID = iD;
            Annee = annee;
            DateDebut = dateDebut;
            DateFin = dateFin;
        }
    }
}
