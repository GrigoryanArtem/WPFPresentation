using API.Model.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API.Model
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Something> Something { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Something>().Property(s => s.Id).IsRequired();
            modelBuilder.Entity<Something>().Property(p => p.CreatedDateUTC)
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Throw);
        }
    }
}
