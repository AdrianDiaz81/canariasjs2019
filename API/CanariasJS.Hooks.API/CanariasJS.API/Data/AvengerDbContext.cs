using CanariasJS.Hooks.API.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CanariasJS.Hooks.API.Data
{
    public class AvengerDbContext : DbContext
    {
        public DbSet<Avengers> Avenger { get; set; }

        public AvengerDbContext(DbContextOptions<AvengerDbContext> options) : base(options)
        {
            this.Database.EnsureCreated();
            this.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var dataCustomer = JObject.Parse(File.ReadAllText(@"./Data/avengers.json"));
            var customerCollection = (JArray)dataCustomer["d"];
            IEnumerable<Avengers> avengersCollection = customerCollection.ToObject<IList<Avengers>>();
            modelBuilder.Entity<Avengers>().HasData(avengersCollection);
        }
    }
}
