using CarExchange.Infrastructure.Data.Models;
using CarExchange.Infrastructure.InitialSeed;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarExchange.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Feature> Features { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Car>()
                .HasKey(x => x.Id);

            builder.Entity<Feature>()
                .HasKey(x => x.Id);

            builder.Entity<IdentityUserLogin<string>>()
                .HasKey(x => x.UserId);

            builder.Entity<IdentityUserRole<string>>()
                .HasKey(x => new { x.RoleId, x.UserId });

            builder.Entity<IdentityRole>()
                .HasKey(x => x.Id);

            builder.Entity<IdentityUser>()
                .HasKey(x => x.Id);

            builder.Entity<IdentityUserToken<string>>()
                .HasKey(x => x.UserId);

            builder.UseSerialColumns();

            builder.ApplyConfiguration(new InitialDbConfiguration<Feature>(@"Seed/car-features.json"));
        }

    }
}