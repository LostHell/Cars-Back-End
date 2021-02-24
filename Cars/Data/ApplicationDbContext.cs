using Cars.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cars.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public DbSet<Car> Cars { get; set; }

        public DbSet<Extra> Extras { get; set; }

        public DbSet<Image> Images { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //  builder.Entity<Car>()
            //      .HasMany(x => x.Extras)
            //      .WithOne(x => x.Car)
            //      .HasForeignKey(x => x.Id)
            //      .OnDelete(DeleteBehavior.Restrict);

            //  builder.Entity<Extra>()
            //      .HasOne(x => x.Car)
            //      .WithMany(x => x.Extras)
            //      .HasForeignKey(x=>x.Id)
            //      .OnDelete(DeleteBehavior.Restrict);
        }
    }
}