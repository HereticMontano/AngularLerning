using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using Repository.Entity;

namespace Repository
{
    public class GalleryDbContext : DbContext
    {
        public GalleryDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Gallery> Gallery { get; init; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<Gallery>().ToCollection("galleries");
        }
    }
}
