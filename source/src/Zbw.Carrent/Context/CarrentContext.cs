namespace Zbw.Carrent.Context
{
    using Microsoft.EntityFrameworkCore;

    using Zbw.Carrent.CarManagement.Domain;
    using Zbw.Carrent.CustomerManagement.Domain;
    using Zbw.Carrent.ReservationManagement.Domain;

    public class CarrentContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarBrand> CarBrands { get; set; }
        public DbSet<CarCategory> CarCategories { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<RentalContract> RentalContracts { get; set; }

        public CarrentContext(DbContextOptions<CarrentContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>();
            modelBuilder.Entity<CarBrand>();
            modelBuilder.Entity<CarCategory>();
            modelBuilder.Entity<CarModel>();
            modelBuilder.Entity<Reservation>();
            modelBuilder.Entity<Customer>();
            modelBuilder.Entity<RentalContract>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
