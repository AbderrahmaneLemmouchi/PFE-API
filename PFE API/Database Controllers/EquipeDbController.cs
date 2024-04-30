using PFE_API.Model;

namespace PFE_API.Database_Controllers
{
    public class EquipeDbController
    {
        public static void Insert(Equipe equipe)
        {
            using var db = new DBcontext();
            db.Equipes.Add(equipe);
            db.SaveChanges();
        }

        public static void Delete(int idEquipe)
        {
            using var db = new DBcontext();
            var equipe = db.Equipes.Find(idEquipe);
            _ = db.Equipes.Remove(equipe);
            db.SaveChanges();
        }

        public static void Update(Equipe equipe)
        {
            using var db = new DBcontext();
            db.Equipes.Update(equipe);
            db.SaveChanges();
        }

        public static IEnumerable<Equipe> GetEquipes()
        {
            var db = new DBcontext();
            var equipes = db.Equipes.ToList();
            return equipes;
        }

        public static Equipe GetEquipeById(int idEquipe)
        {
            var db = new DBcontext();
            var equipe = db.Equipes.Find(idEquipe);
            return equipe;
        }
    }
}
