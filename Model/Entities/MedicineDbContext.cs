using MedicineDB.Entity.Tables;
using Microsoft.EntityFrameworkCore;

namespace MedicineDB.Model.Entities
{
    internal class MedicineDbContext : DbContext
    {
        //public MedicineDbContext(DbContextOptions<MedicineDbContext> options)
        //   : base(options)
        //{
        //    Database.EnsureCreated();
        //}

        //public MedicineDbContext()
        //   : base()
        //{
        //    Database.EnsureCreated();
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-63ASIAM;Database=MedicineDB;Trusted_Connection=True;");
        }

        // Settings for PostgreSql
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql(@"Server=localhost;Port=5432;Database=OhorodnikDb;User Id=postgres;Password=postgres");
        //}

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Speciality> Specialities { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Workplace> Workplaces { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Surname).IsRequired();
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Patronymic).IsRequired();

                entity.HasOne(e => e.Speciality)
                   .WithMany(e => e.Employees)
                   .HasForeignKey(e => e.SpecialityID);

                //entity.HasOne(e => e.Location)
                //   .WithMany(e => e.Employees)
                //   .HasForeignKey(e => e.LocationID);

                entity.HasOne(e => e.Workplace)
                   .WithMany(e => e.Employees)
                   .HasForeignKey(e => e.WorkplaceID);
            });

            modelBuilder.Entity<Speciality>(entity =>
            {
                entity.ToTable("Speciality");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Specialty).IsRequired();
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(e => e.Country)
                    .WithMany(e => e.Locations)
                    .HasForeignKey(e => e.CountryID);

                entity.HasOne(e => e.City)
                    .WithMany(e => e.Locations)
                    .HasForeignKey(e => e.CityID);
            });

            modelBuilder.Entity<Workplace>(entity =>
            {
                entity.ToTable("Workplace");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired();

                //entity.HasOne(e => e.Location)
                //    .WithMany(e => e.Workplaces)
                //    .HasForeignKey(e => e.LocationID);

            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.CityName).IsRequired();
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.CountyName).IsRequired();
            });
        }
    }
}
