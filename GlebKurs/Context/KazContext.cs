using ClassLibrary;
using Microsoft.EntityFrameworkCore;

namespace GlebKurs.Context
{
    public class KazContext: DbContext
    {
        public DbSet<Client> Client { get; set; }
        public DbSet<Manager> Manager { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Service> Service { get; set; }
        public KazContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=kazdb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Set the default schema
            builder.HasDefaultSchema(Fillial.kaz.ToString());
            builder.Entity<Manager>().HasData(
                new Manager[]
                {
                    new Manager() {Id =1, Name = "Анатолий Викторович", Fillial = Fillial.kaz.ToString()}
                });
            builder.Entity<Service>().HasData(
                new Service[]
                {
                    new Service() {Id=1, Name = "Замена комплектующих", Price=1000},
                    new Service() {Id=2, Name = "Диагностика", Price= 2000},
                    new Service() {Id=3, Name = "Установка ПО", Price = 10000}
                });
            builder.Entity<Client>().HasData(
                new Client[]
                {
                    new Client() { Id=1, FirstName ="Abdula", LastName="Lahman", Address = "Bagdat", Email="ajshjska@hmail.com", Phone="+9457394342"}
                }
            );

            //Continue with the call./Migrate
            base.OnModelCreating(builder);
        }
    }
}
