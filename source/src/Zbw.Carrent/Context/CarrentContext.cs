namespace Zbw.Carrent.Context
{
    using Microsoft.EntityFrameworkCore;

    using Zbw.Carrent.CarManagement.Domain;
    using Zbw.Carrent.CustomerManagement.Domain;
    using Zbw.Carrent.ReservationManagement.Domain;

    public class CarrentContext : DbContext
    {
        public DbSet<CarBrand> CarBrands { get; set; }
        public DbSet<CarCategory> CarCategories { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Car> Cars { get; set; }
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
            modelBuilder.Entity<CarBrand>().HasKey(x => x.Id);
            var carCategory = modelBuilder.Entity<CarCategory>();
            carCategory.HasKey(x => x.Id);
            carCategory.Property(x => x.DailyFee).HasPrecision(10, 2);
            modelBuilder.Entity<CarModel>().HasKey(x => x.Id);
            modelBuilder.Entity<Reservation>().Property(x => x.TotalCost).HasPrecision(8, 2);
            modelBuilder.Entity<Customer>();
            modelBuilder.Entity<RentalContract>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
