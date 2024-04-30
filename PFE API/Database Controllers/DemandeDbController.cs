using PFE_API.Model;

namespace PFE_API
{
    public class DemandeDbController
    {
        public static void Insert(Demande demande)
        {
            using var db = new DBcontext();
            _ = db.Employees.Find(demande.MatriculeEmp) ?? throw new Exception("Employee not found");
            db.Demandes.Add(demande);
            db.SaveChanges();
        }

        public static void Delete(Demande demande)
        {
            using var db = new DBcontext();
            db.Demandes.Remove(demande);
            db.SaveChanges();
        }

        public static void Update(Demande demande)
        {
            using var db = new DBcontext();
            var temp = GetDemandeById(demande.ID);
            Historique historique = new()
            {
                IDDemande = demande.ID,
                FromEtat = temp.EtatActuel,
                ToEtat = demande.EtatActuel,
                Date = DateTime.UtcNow,
                Par = demande.MatriculeEmp
                //TODO: Add the matricule of the employee who made the change
            };
            HistoriqueDbController.Insert(historique);
            db.Demandes.Update(demande);
            db.SaveChanges();
        }

        public static IEnumerable<Demande> GetDemandes()
        {
            var db = new DBcontext();
            var demandes = db.Demandes.ToList();
            return demandes;
        }

        public static Demande GetDemandeById(int code)
        {
            var db = new DBcontext();
            var demande = db.Demandes.Find(code);
            return demande;
        }

        public static IEnumerable<Demande> GetDemandesByEmployee(string matricule)
        {
            var db = new DBcontext();
            var demandes = db.Demandes.Where(d => d.MatriculeEmp == matricule).ToList();
            return demandes;
        }

        public static IEnumerable<Demande> GetDemandesAbsence()
        {
            var db = new DBcontext();
            var demandes = db.Demandes.Where(d => d.Type == TypeDemande.Absence).ToList();
            return demandes;
        }

        public static IEnumerable<Demande> GetDemandesConge()
        {
            var db = new DBcontext();
            var demandes = db.Demandes.Where(d => d.Type == TypeDemande.Conge).ToList();
            return demandes;
        }

        public static IEnumerable<Demande> GetDemandesDocument()
        {
            var db = new DBcontext();
            var demandes = db.Demandes.Where(d => d.Type == TypeDemande.Document).ToList();
            return demandes;
        }

        public static IEnumerable<Demande> GetDemandesChangementInfo()
        {
            var db = new DBcontext();
            var demandes = db.Demandes.Where(d => d.Type == TypeDemande.ChangementInfo).ToList();
            return demandes;
        }

        public static IEnumerable<Demande> GetDemandesByType(TypeDemande type)
        {
            switch (type)
            {
                case TypeDemande.Conge:
                    return GetDemandesConge();
                case TypeDemande.Absence:
                    return GetDemandesAbsence();
                case TypeDemande.ChangementInfo:
                    return GetDemandesChangementInfo();
                case TypeDemande.Document:
                    return GetDemandesDocument();
                default:   
                    return null;
            }
        }

        public static IEnumerable<Demande> GetDemandesEnAttente()
        {
            var db = new DBcontext();
            var demandes = db.Demandes.Where(d => d.EtatActuel == EtatDemande.EnAttente).ToList();
            return demandes;
        }

        public static IEnumerable<Demande> GetDemandesAcceptee()
        {
            var db = new DBcontext();
            var demandes = db.Demandes.Where(d => d.EtatActuel == EtatDemande.Acceptee).ToList();
            return demandes;
        }


    }
}
