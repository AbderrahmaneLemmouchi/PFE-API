using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFE_API.Model
{
    public class Demande
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string MatriculeEmp { get; set; }
        [EnumDataType(typeof(TypeDemande))]
        public TypeDemande Type { get; set; }
        public DateTime DateCreation { get; set; }
        [EnumDataType(typeof(EtatDemande))]
        public EtatDemande EtatActuel { get; set; }
        [EnumDataType(typeof(TypeDocument))]
        public TypeDocument? TypeDoc { get; set; }
        public DateTime? DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public string? Commentaire { get; set; }
        public Employee? NouvelleInformation { get; set; }
    
        /// <summary>
        /// Constructeur pour une demande de congé ou d'absence
        /// </summary>
        /// <param name="matriculeEmp">
        /// Matricule de l'employé qui fait la demande
        /// </param>
        /// <param name="type">
        /// Congé ou absence
        /// </param>
        /// <param name="dateDebut">
        /// Date de début du congé
        /// </param>
        /// <param name="dateFin">
        /// Date de fin du congé
        /// </param>
        /// <param name="commentaire">
        /// Commentaire de l'employé
        /// </param>
        public Demande(string matriculeEmp, TypeDemande type, DateTime dateDebut, DateTime dateFin, string commentaire)
        {
            MatriculeEmp = matriculeEmp;
            Type = type;
            DateCreation = DateTime.Now;
            EtatActuel = EtatDemande.EnAttente;
            DateDebut = dateDebut;
            DateFin = dateFin;
            Commentaire = commentaire;
        }

        /// <summary>
        /// Constructeur pour une demande d'un document
        /// </summary>
        /// <param name="matriculeEmp">
        /// Matricule de l'employé qui fait la demande
        /// </param>
        /// <param name="document">
        /// Le document demandé
        /// </param>
        public Demande(string matriculeEmp, TypeDocument document)
        {
            MatriculeEmp = matriculeEmp;
            Type = TypeDemande.Document;
            DateCreation = DateTime.Now;
            EtatActuel = EtatDemande.EnAttente;
            TypeDoc = document;
        }

        /// <summary>
        /// Constructeur pour une demande de changement d'information
        /// </summary>
        /// <param name="matriculeEmp">
        /// matricule de l'employé qui fait la demande
        /// </param>
        /// <param name="nv">
        /// Nouvelles informations de l'employé
        /// </param>
        public Demande(string matriculeEmp, Employee nv)
        {
            MatriculeEmp = matriculeEmp;
            Type = TypeDemande.ChangementInfo;
            DateCreation = DateTime.Now;
            EtatActuel = EtatDemande.EnAttente;
            NouvelleInformation = nv;
        }

        public Demande()
        {
            
        }

    }

    public enum TypeDemande
    {
        Conge,
        Absence,
        ChangementInfo,
        Document
    }

    public enum EtatDemande
    {
        EnAttente,
        Acceptee,
        Refusee,
        Annulee
    }

    public enum TypeDocument
    {
        DemandeDeConge,
        TitreDeConge,
        AutorisationAbsence,
        DemandeFormation,
        AttestationTravail,
        AttestationTravailEtSalaires,
        ReleverEmoluments,
        BulletinPaie,
        AttestationAffiliationCNAS,
        // Add more as needed...
    }

}
