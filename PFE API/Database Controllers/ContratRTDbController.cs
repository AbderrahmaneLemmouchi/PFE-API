using PFE_API.Model;

namespace PFE_API
{
    public class ContratRTDbController
    {
        /// <summary>
        /// Insert a new ContratRT
        /// </summary>
        /// <param name="contratRT">
        /// The ContratRT to insert
        /// </param>
        /// <returns>True if the employee exists</returns>
        public static bool InsertContrat(ContratRT contratRT)
        {
            using var db = new DBcontext();
            var emp = db.Employees.Find(contratRT.MatriculeEmp);
            if (emp == null)
            {
                return false;
            }
            db.ContratsRT.Add(contratRT);
            db.SaveChanges();
            return true;
        }

        public static void DeleteContrat(ContratRT contratRT)
        {
            using var db = new DBcontext();
            db.ContratsRT.Remove(contratRT);
            db.SaveChanges();
        }

        public static void UpdateContrat(ContratRT contratRT)
        {
            using var db = new DBcontext();
            db.ContratsRT.Update(contratRT);
            db.SaveChanges();
        }

        public static IEnumerable<ContratRT> GetContratsRT()
        {
            var db = new DBcontext();
            var contratsRT = db.ContratsRT.ToList();
            return contratsRT;
        }

        public static ContratRT GetContratRTById(string code)
        {
            var db = new DBcontext();
            var contratRT = db.ContratsRT.Find(code);
            return contratRT;
        }
    }
}
