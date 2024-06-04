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
        public DateOnly? DateDebut { get; set; }
        public DateOnly? DateFin { get; set; }
        public TypeConge? TypeConge { get; set; }
        public DateOnly? JourRecup { get; set; }
        public bool? IsRemuneree { get; set; }
        public string? Commentaire { get; set; }
        public Employee? NouvelleInformation { get; set; }
        //[Url]
        public string? LienVersJustification { get; set; }
        [EnumDataType(typeof(TypeImportance))]
        public TypeImportance Importance { get; set; }
        
    
        /// <summary>
        /// Constructeur pour une demande de congé
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
        public Demande(string matriculeEmp, TypeImportance importance , TypeDemande type, DateOnly dateDebut, DateOnly dateFin, string commentaire, TypeConge typeConge) //TODO: Add justification
        {
            MatriculeEmp = matriculeEmp;
            Type = type;
            DateCreation = DateTime.UtcNow;
            EtatActuel = EtatDemande.EnAttente;
            DateDebut = dateDebut;
            DateFin = dateFin;
            Commentaire = commentaire;
            TypeConge = typeConge;
            Importance = importance;
        }

        /// <summary>
        /// Constructeur pour une demande d'absence avec récupération
        /// </summary>
        /// <param name="matriculeEmp">
        /// Matricule de l'employé qui fait la demande
        /// </param>
        /// <param name="type">
        /// Type de la demande (absence)
        /// </param>
        /// <param name="dateDebut">
        /// Date de début de l'absence
        /// </param>
        /// <param name="dateFin">
        /// Date de fin de l'absence
        /// </param>
        /// <param name="commentaire">
        /// Commentaire de l'employé
        /// </param>
        /// <param name="jourRecup">
        /// Jour de récupération
        /// </param>
        public Demande(string matriculeEmp, TypeImportance importance, TypeDemande type, DateOnly dateDebut, DateOnly dateFin, string commentaire, DateOnly? jourRecup, bool isRemeneree) //TODO: Add justification
        {
            MatriculeEmp = matriculeEmp;
            Type = type;
            DateCreation = DateTime.UtcNow;
            EtatActuel = EtatDemande.EnAttente;
            DateDebut = dateDebut;
            DateFin = dateFin;
            Commentaire = commentaire;
            IsRemuneree = isRemeneree;
            if (isRemeneree)
            {
                JourRecup = jourRecup;
            }
            Importance = importance;
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
        public Demande(string matriculeEmp, TypeImportance importance, TypeDocument document)
        {
            MatriculeEmp = matriculeEmp;
            Type = TypeDemande.Document;
            DateCreation = DateTime.UtcNow;
            EtatActuel = EtatDemande.EnAttente;
            TypeDoc = document;
            Importance = importance;
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
        public Demande(string matriculeEmp, TypeImportance importance, Employee nv)
        {
            MatriculeEmp = matriculeEmp;
            Type = TypeDemande.ChangementInfo;
            DateCreation = DateTime.UtcNow;
            EtatActuel = EtatDemande.EnAttente;
            NouvelleInformation = nv;
            Importance = importance;
        }

        public Demande()
        {
            DateCreation = DateTime.UtcNow;
        }

    }

    public enum TypeConge
    {
        Annuel,
        Exceptionnel,
        Maladie,
        SansSolde,
        Reliquat,
        Maternite,
        Paternite,
        Mariage,
        Deuil,
        Naissance,
        Autre
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

    public enum TypeImportance
    {
        Faible,
        Moyenne,
        Haute
    }

}
