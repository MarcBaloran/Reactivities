using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) {}
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=reacivities.db");

        public DbSet<Value> Values { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<Value>()
                .HasData (
                    /*  Value will be added when a new migration is run */
                    new Value {Id = 1, Name = "Value 101"},
                    new Value {Id = 2, Name = "Value 102"},
                    new Value {Id = 3, Name = "Value 103"}
                );
        }
    }
}