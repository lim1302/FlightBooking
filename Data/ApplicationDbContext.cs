using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UkraineAirline.Models;

namespace UkraineAirline.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Flight> Flight { get; set; }
        public DbSet<Passenger> Passenger { get; set; }
        public DbSet<Booking> Booking { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Flight>().ToTable("Flight");
            builder.Entity<Passenger>().ToTable("Passenger");
            builder.Entity<Booking>().ToTable("Booking");
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }

    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Flight.Any())
            {
                return;   // DB has been seeded
            }

            var flights = new Flight[]
            {

                new Flight
                {
                    FlightNo = "PM1011",Origin="Pais",Destination="Mariupol",
                    Departure = DateTime.Parse("2017-11-02 15:00"),Arrival=DateTime.Parse("2017-11-02 17:30"),
                },
                new Flight
                {
                    FlightNo = "BM1071",Origin="Berlin",Destination="Mariupol",
                    Departure = DateTime.Parse("2017-11-02 15:00"),Arrival=DateTime.Parse("2017-11-02 17:30"),
                },
                new Flight
                {
                    FlightNo = "VO1008",Origin="Vienna",Destination="Odessa",
                    Departure = DateTime.Parse("2017-11-02 11:00"),Arrival=DateTime.Parse("2017-11-02 13:30"),
                },
                new Flight
                {
                    FlightNo = "RO1013",Origin="Riga",Destination="Odessa",
                    Departure = DateTime.Parse("2017-11-02 12:00"),Arrival=DateTime.Parse("2017-11-02 14:30"),
                },
                new Flight
                {
                    FlightNo = "AO1015",Origin="Amsterdam",Destination="Odessa",
                    Departure = DateTime.Parse("2017-11-02 15:00"),Arrival=DateTime.Parse("2017-11-02 17:30"),
                },
                new Flight
                {
                    FlightNo = "OK1016",Origin="Odessa",Destination="Kharkiv",
                    Departure = DateTime.Parse("2017-11-02 15:00"),Arrival=DateTime.Parse("2017-11-02 17:30"),
                },
                new Flight
                {
                    FlightNo = "VR1017",Origin="Vienna",Destination="Riga",
                    Departure = DateTime.Parse("2017-11-02 19:00"),Arrival=DateTime.Parse("2017-11-02 21:30"),
                },
                new Flight
                {
                    FlightNo = "KK1018",Origin="Kiev",Destination="Kharkiv",
                    Departure = DateTime.Parse("2017-11-02 20:00"),Arrival=DateTime.Parse("2017-11-02 22:30"),
                },
                new Flight
                {
                    FlightNo = "LO1102",Origin="Lviv",Destination="Odessa",
                    Departure = DateTime.Parse("2017-11-02 10:00"),Arrival=DateTime.Parse("2017-11-02 12:30"),
                },           
                new Flight
                {
                    FlightNo = "OV1104",Origin="Odessa",Destination="Vilnius",
                    Departure = DateTime.Parse("2017-11-02 13:00"),Arrival=DateTime.Parse("2017-11-02 15:30"),
                }
            };
            foreach (Flight f in flights)
            {
                context.Flight.Add(f);
            }
            context.SaveChanges();
        }
    }
}
