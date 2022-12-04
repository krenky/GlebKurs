using ClassLibrary;
using Microsoft.EntityFrameworkCore;

namespace GlebKurs.Context
{
    public class CheContext: DbContext
    {
        public DbSet<Client> Client { get; set; }
        public DbSet<Manager> Manager { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Service> Service { get; set; }
        public CheContext()
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
            builder.HasDefaultSchema(Fillial.che.ToString());
            builder.Entity<Manager>().HasData(
                new Manager[]
                {
                    new Manager() { Name = "Чепурнов Виталий", Fillial = Fillial.che}
                });

            //Continue with the call./Migrate
            base.OnModelCreating(builder);
        }
    }
}
