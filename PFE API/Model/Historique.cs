namespace PFE_API.Model
{
    public class Historique
    {
        public int IDDemande { get; set; }
        public EtatDemande FromEtat { get; set; }
        public EtatDemande ToEtat { get; set; }
        public DateTime Date { get; set; }
        public string Par { get; set; } // Matricule Employé
    }
}
