using MagicCarRentAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace MagicCarRentAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Car> Cars { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<CarClientJournal> ClientJournals { get; set; }
    public DbSet<Discount> Discounts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Car>().HasData(
            new Car()
            {
                Id = 1,
                Brand = "Toyota",
                Model = "Mark II",
                Year = 1995,
                CarColor = Car.Color.Black,
                Cost = 2000
            },
            new Car()
            {   
                Id = 2,
                Brand = "Honda",
                Model = "Civic",
                Year = 2010,
                CarColor = Car.Color.White,
                Cost = 2200
            },
            new Car()
            {
                Id = 3,
                Brand = "Ford",
                Model = "Mustang",
                Year = 2015,
                CarColor = Car.Color.Red,
                Cost = 5000
            },
            new Car()
            {
                Id = 4,
                Brand = "Chevrolet",
                Model = "Camaro",
                Year = 2018,
                CarColor = Car.Color.Yellow,
                Cost = 7000
            },
            new Car()
            {
                Id = 5,
                Brand = "BMW",
                Model = "M5",
                Year = 2020,
                CarColor = Car.Color.Blue,
                Cost = 6000
            });

        modelBuilder.Entity<Client>().HasData(
            new Client()
            {
                Id = 1,
                Name = "John",
                Lastname = "Doe"
            },
            new Client()
            {
                Id = 2,
                Name = "Alice",
                Lastname = "Smith"
            },
            new Client()
            {
                Id = 3,
                Name = "Michael",
                Lastname = "Johnson"
            },
            new Client()
            {
                Id = 4,
                Name = "Emily",
                Lastname = "Brown"
            },
            new Client()
            {
                Id = 5,
                Name = "David",
                Lastname = "Wilson"
            });
        modelBuilder.Entity<Discount>().HasData(
            new Discount()
            {
                Id = 1,
                DiscountName = "Скидка 1-й уровень",
                DiscountRate = 0.05
            },
            new Discount()
            {
                Id = 2,
                DiscountName = "Скидка 2-й уровень",
                DiscountRate = 0.10
            },
            new Discount()
            {
                Id = 3,
                DiscountName = "Скидка 3-й уровень",
                DiscountRate = 0.15
            },
            new Discount()
            {
                Id = 4,
                DiscountName = "Скидка 4-й уровень",
                DiscountRate = 0.20
            },
            new Discount()
            {
                Id = 5,
                DiscountName = "Скидка 5-й уровень",
                DiscountRate = 0.25
            });

    }
}
