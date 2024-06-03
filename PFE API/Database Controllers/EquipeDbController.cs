using PFE_API.Model;

namespace PFE_API.Database_Controllers
{
    public class EquipeDbController
    {
        private static Equipe team;

        public static void Insert(int id,

            string nom,
            string resp,
            int rattachee)
        {

            team = new Equipe(id, nom, resp, "yo", rattachee );
            using var db = new DBcontext();
            db.Equipes.Add(team);
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
