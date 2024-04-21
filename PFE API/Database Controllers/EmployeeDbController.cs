using PFE_API.Model;

namespace PFE_API
{
    public class EmployeeDbController
    {
        public static void Insert(Employee employee)
        {
            using (var db = new DBcontext())
            {
                db.Employees.Add(employee);
                db.SaveChanges();
            }
        }

        public static void Delete(Employee employee)
        {
            using (var db = new DBcontext())
            {
                db.Employees.Remove(employee);
                db.SaveChanges();
            }
        }

        public static void Update(Employee employee)
        {
            using (var db = new DBcontext())
            {
                db.Employees.Update(employee);
                db.SaveChanges();
            }
        }

        public static IEnumerable<Employee> GetEmployees()
        {
            var db = new DBcontext();
            var employees = db.Employees.ToList();
            return employees;
        }

        public static Employee GetEmployeeById(string matricule)
        {
            var db = new DBcontext();
            var employee = db.Employees.Find(matricule);
            return employee;
        }

        public static IEnumerable<Employee> GetEmployeesByEquipe(int idEquipe)
        {
            var db = new DBcontext();
            var employees = db.Employees.Where(e => e.IDEquipe == idEquipe).ToList();
            return employees;
        }
    }
}
