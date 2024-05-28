using Microsoft.EntityFrameworkCore;
using PFE_API.Model;

namespace PFE_API
{
    public class DBcontext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Demande> Demandes { get; set; }
        public DbSet<Equipe> Equipes { get; set; }
        public DbSet<ContratRT> ContratsRT { get; set; }
        public DbSet<Historique> Historiques { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Conge> Conges { get; set; }
        public DbSet<Exercice> Exercices { get; set; }
        public DbSet<User> Users { get; set; }

        // Add other DbSets for your other models...

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=testing;Username=postgres;Password=abdou0000");
        }
    }
}
