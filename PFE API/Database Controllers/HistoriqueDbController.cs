using PFE_API.Model;

namespace PFE_API
{
    public class HistoriqueDbController
    {
        public static void Insert(Historique historique)
        {
            using (var db = new DBcontext())
            {
                db.Historiques.Add(historique);
                db.SaveChanges();
            }
        }

        public static void Delete(Historique historique)
        {
            using (var db = new DBcontext())
            {
                db.Historiques.Remove(historique);
                db.SaveChanges();
            }
        }

        public static void Update(Historique historique)
        {
            using (var db = new DBcontext())
            {
                db.Historiques.Update(historique);
                db.SaveChanges();
            }
        }

        public static IEnumerable<Historique> GetHistoriques()
        {
            var db = new DBcontext();
            var historiques = db.Historiques.ToList();
            return historiques;
        }

        public static Historique GetHistoriqueById(int id)
        {
            var db = new DBcontext();
            var historique = db.Historiques.Find(id);
            return historique;
        }

        public static IEnumerable<Historique> GetHistoriqueDemande(int idDemande)
        {
            var db = new DBcontext();
            var historiques = db.Historiques.Where(h => h.IDDemande == idDemande).ToList();
            return historiques;
        }
    }
}
