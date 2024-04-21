using PFE_API.Model;

namespace PFE_API.Controller
{
    public class ContratsRTcontroller
    {
        public static void InsertContrat( )
        {
            using (var db = new DBcontext())
            {
                var contratsRT = db.ContratsRT.ToList();
                //insert a new ContratRT
                var contratRT = new ContratRT(
                    "newCode",
                    "newMatricule",
                    "newCategorie",
                    DateTime.UtcNow,
                    DateTime.UtcNow.AddYears(1),
                    DateTime.UtcNow.AddDays(30),
                    "newRegime",
                    "newPoste",
                    true
                );
                db.ContratsRT.Add(contratRT);
                db.SaveChanges();

            }


            // Get all ContratsRT
        }

        public static IEnumerable<ContratRT> GetContratsRT()
        {
            var db = new DBcontext();
            var contratsRT = db.ContratsRT.ToList();
            return contratsRT;
        }

    }
}
