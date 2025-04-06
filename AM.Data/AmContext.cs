using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.Core.Domaine;
using AM.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AM.Data
{
    internal class AmContext : DbContext
    {

        public DbSet<Flight> flights { get; set; }
        public DbSet<Passenger> passengers { get; set; }
        public DbSet<Plane> planes { get; set; }
        public DbSet<Staff> staffs { get; set; }
        public DbSet<Traveller> travellers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb; Initial Catalog = Airport; Integrated Security = true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new PlaneConfig());
            modelBuilder.ApplyConfiguration(new FlightConfig()); // Appliquer FlightConfig

            //Héritage TPH : Table Passengers avec colonne IsTraveller
            modelBuilder.Entity<Passenger>()
                .HasDiscriminator<int>("IsTraveller")
                .HasValue<Passenger>(0)
                .HasValue<Traveller>(1)
                .HasValue<Staff>(2);

        }










    }
}
