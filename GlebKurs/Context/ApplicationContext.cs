using ClassLibrary;
using Microsoft.EntityFrameworkCore;

namespace GlebKurs.Context
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Client> Client { get; set; }
        public DbSet<Manager> Manager { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Service> Service { get; set; }

        public Fillial CurrentFillial { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        public ApplicationContext(Fillial currentFillial)
        {
            Database.EnsureCreated();
            CurrentFillial = currentFillial;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=49153;Database=postgres;Username=postgres;Password=postgrespw");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Set the default schema
            builder.HasDefaultSchema(CurrentFillial.ToString());

            //Continue with the call./Migrate
            base.OnModelCreating(builder);
        }
    }
}
