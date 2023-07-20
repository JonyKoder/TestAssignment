using Application.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entityframeworkcore
{
    public class ApplicationDbContext : DbContext
    {
        private IConfiguration Configuration { get; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("TestDb");

        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Здесь настраивается модель данных

        }

        //private void SeedData(ModelBuilder modelBuilder)
        //{
        //    var random = new Random();
        //    var cities = new List<string> { "City 1", "City 2", "City 3", "City 4", "City 5" };
        //    var states = new List<string> { "State 1", "State 2", "State 3", "State 4", "State 5" };
        //    var addresses = new List<string> { "Address 1", "Address 2", "Address 3", "Address 4", "Address 5" };

        //    for (int i = 1; i <= 10; i++)
        //    {
        //        modelBuilder.Entity<Company>().HasData(
        //            new Company
        //            {
        //                Id = i,
        //                CompanyName = $"Company {i}",
        //                City = cities[random.Next(cities.Count)],
        //                Address = addresses[random.Next(addresses.Count)],
        //                State = states[random.Next(states.Count)],
        //                Phone = $"{random.Next(1000000, 9999999)}"
        //            }
        //        );
        //    }
      
        //}
    }
}
