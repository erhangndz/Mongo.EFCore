using Microsoft.EntityFrameworkCore;
using Mongo.WebUI.Entities;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;

namespace Mongo.WebUI.Context
{
    public class MongoContext:DbContext
    {

        public MongoContext(DbContextOptions options) : base(options) { }
       
     



        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(x => x.ToCollection("categories"));
            modelBuilder.Entity<Product>(x => x.ToCollection("products"));
        }




    }
}
