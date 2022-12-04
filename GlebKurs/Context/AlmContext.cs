using ClassLibrary;
using Microsoft.EntityFrameworkCore;

namespace GlebKurs.Context
{
    public class AlmContext: DbContext
    {
        public DbSet<Client> Client { get; set; }
        public DbSet<Manager> Manager { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Service> Service { get; set; }
        public AlmContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=49153;Database=postgres;Username=postgres;Password=postgrespw");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Set the default schema
            builder.HasDefaultSchema(Fillial.alm.ToString());

            builder.Entity<Manager>().HasData(
                new Manager[]
                {
                    new Manager() { Name = "Глеб Глебович", Fillial = Fillial.alm}
                });

            //Continue with the call./Migrate
            base.OnModelCreating(builder);
        }
    }
}
