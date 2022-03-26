using Core.Models;
using Microsoft.EntityFrameworkCore;


namespace Data
{
    public class MyDBContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Incident> Incidents { get; set; }

        public MyDBContext(DbContextOptions<MyDBContext> options):base(options)
        {

        }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasIndex(a => a.Name)
                .IsUnique(true);

            modelBuilder.Entity<Contact>()
                .HasIndex(c => c.Email)
                .IsUnique(true);

            base.OnModelCreating(modelBuilder);
        }
    }
}
