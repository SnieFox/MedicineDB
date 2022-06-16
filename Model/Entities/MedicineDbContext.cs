using MedicineDB.Entity.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineDB.Model.Entities
{
    internal class MedicineDbContext : DbContext
    {
        //public MedicineDbContext(DbContextOptions<MedicineDbContext> options)
        //   : base(options)
        //{
        //    Database.EnsureCreated();
        //}



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-O510GJE\SQLEXPRESS;Database=MedicineDB;Trusted_Connection=True;");
        }
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

                entity.Property(e => e.Surname).IsRequired();
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Patronymic).IsRequired();
                entity.Property(e => e.LocationID).IsRequired();
                entity.Property(e => e.SpecialityID).IsRequired();
                entity.Property(e => e.WorkplaceID).IsRequired();
            });

            modelBuilder.Entity<Speciality>(entity =>
            {
                entity.ToTable("Speciality");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Specialty).IsRequired();

                entity.HasMany(e => e.Employee)
                    .WithOne(e => e.Speciality)
                    .HasForeignKey(e => e.Id);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CountryID).IsRequired();
                entity.Property(e => e.CityID).IsRequired();

                entity.HasMany(e => e.Employee)
                    .WithOne(e => e.Location)
                    .HasForeignKey(e => e.Id);

                entity.HasMany(e => e.Workplace)
                    .WithOne(e => e.Location)
                    .HasForeignKey(e => e.Id);
            });

            modelBuilder.Entity<Workplace>(entity =>
            {
                entity.ToTable("Workplace");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.LocationID).IsRequired();

                entity.HasMany(e => e.Employee)
                    .WithOne(e => e.Workplace)
                    .HasForeignKey(e => e.Id);

            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CityName).IsRequired();

                entity.HasMany(e => e.Location)
                    .WithOne(e => e.City)
                    .HasForeignKey(e => e.Id);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CountyName).IsRequired();

                entity.HasMany(e => e.Location)
                    .WithOne(e => e.Country)
                    .HasForeignKey(e => e.Id);
            });
        }
    }
}
