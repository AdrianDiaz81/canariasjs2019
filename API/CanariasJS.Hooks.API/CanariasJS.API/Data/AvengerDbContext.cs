using CanariasJS.API.Model;
using CanariasJS.Hooks.API.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace CanariasJS.Hooks.API.Data
{
    public class AvengerDbContext : DbContext
    {
       
        public DbSet<Avengers> Avenger { get; set; }
       
        public DbSet<Patxaran> Patxaran { get; set; }


        public AvengerDbContext(DbContextOptions<AvengerDbContext> options) : base(options)
        {
            this.Database.EnsureCreated();
            this.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var dataPatxaran = JObject.Parse(File.ReadAllText(@"./Data/patxaran.json"));
            var patxaranCollection = (JArray)dataPatxaran["d"];
            IEnumerable<Patxaran> patxaransCollection = patxaranCollection.ToObject<IList<Patxaran>>();
            modelBuilder.Entity<Patxaran>().HasData(patxaransCollection);

            var dataCustomer = JObject.Parse(File.ReadAllText(@"./Data/avengers.json"));
            var customerCollection = (JArray)dataCustomer["d"];
            IEnumerable<Avengers> avengersCollection = customerCollection.ToObject<IList<Avengers>>();
            modelBuilder.Entity<Avengers>().HasData(avengersCollection);



        }
    }
}
