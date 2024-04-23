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

        public static bool Delete(string mat)
        {
            using (var db = new DBcontext())
            {
                var employee = db.Employees.Find(mat);
                if (employee == null)
                {
                    return false;
                }
                db.Employees.Remove(employee);
                db.SaveChanges();
            }
            return true;
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

        public static IEnumerable<Employee> GetEmployeesByResponsable(string idResponsable)
        {
            var db = new DBcontext();
            var employees = db.Employees.Where(e => e.IDResponsable == idResponsable).ToList();
            return employees;
        }

        public static IEnumerable<Employee> GetEmployeesTreeFromResponsable(string idResponsable)
        {
            var db = new DBcontext();
            var employees = db.Employees.Where(e => e.IDResponsable == idResponsable).ToList();
            foreach (var employee in employees)
            {
                employees.AddRange(GetEmployeesTreeFromResponsable(employee.Matricule));
            }
            return employees;
        }
    }
}
