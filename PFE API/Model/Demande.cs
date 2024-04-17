namespace PFE_API.Model
{
    public class Demande
    {
        public int ID { get; set; }
        public string MatriculeEmp { get; set; }
        public TypeDemande Type { get; set; }
        public DateTime DateCreation { get; set; }
        public EtatDemande EtatActuel { get; set; }
        public TypeDocument? TypeDoc { get; set; }
        public DateTime? DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public string? Commentaire { get; set; }
    

        public Demande(string matriculeEmp)
        {
            MatriculeEmp = matriculeEmp;
            DateCreation = DateTime.Now;
            EtatActuel = EtatDemande.EnAttente;
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
