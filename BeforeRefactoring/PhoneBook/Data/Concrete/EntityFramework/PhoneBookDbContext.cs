using Entities.Concrete;
using Microsoft.EntityFrameworkCore; 

namespace Data.Concrete.EntityFramework
{
    public class PhoneBookDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=PhoneBookDb;Trusted_Connection=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        public DbSet<Person> Person { get; set; }
        public DbSet<PhoneType> PhoneType { get; set; }
        public DbSet<Phone> Phone { get; set; }
        public DbSet<Department> Department { get; set; } 
    }
}