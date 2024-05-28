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

        public static bool IsPresent(string mat, DateOnly date)
        {
            using var db = new DBcontext();
            var Demandes =  DemandeDbController.GetDemandesByEmployee(mat).Where(d=> d.DateDebut >= date && (d.Type == TypeDemande.Conge || d.Type == TypeDemande.Absence) && d.EtatActuel == EtatDemande.Acceptee);
            return Demandes.Any();
        }

    }

    public class ContactDbController
    {
        public static void Insert(Contact contact)
        {
            using var db = new DBcontext();
            var employee = EmployeeDbController.GetEmployeeById(contact.MatriculeEmp) ?? throw new Exception("Employee not found");
            db.Contacts.Add(contact);
            db.SaveChanges();
        }

        public static bool Delete(string mat, string type, string valeur)
        {
            using var db = new DBcontext();
            var contact = db.Contacts.Find(mat, type, valeur);
            if (contact == null)
            {
                return false;
            }
            db.Contacts.Remove(contact);
            db.SaveChanges();
            return true;
        }

        public static Contact GetContact(string mat, string type, string valeur)
        {
            using var db = new DBcontext();
            var contact = db.Contacts.Find(mat, type, valeur);
            return contact;
        }

        public static IEnumerable<Contact> GetContactsByEmployee(string mat)
        {
            using var db = new DBcontext();
            var contacts = db.Contacts.Where(c => c.MatriculeEmp == mat).ToList();
            return contacts;
        }
        
    }
}
