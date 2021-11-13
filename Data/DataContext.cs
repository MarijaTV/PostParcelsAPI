using Microsoft.EntityFrameworkCore;
using PostParcelsAPI.Models;

namespace PostParcelsAPI.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Parcel> Parcels { get; set; }
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Post>()
                .HasMany(s => s.Parcels)
                .WithOne();
        }
    }


}
