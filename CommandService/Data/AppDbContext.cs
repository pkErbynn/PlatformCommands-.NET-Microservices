using CommandService.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Command> Commands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Platform>()
                .HasMany(p => p.Commands)   //  Has " ICollection<Command> Commands { get; set; }"  inside Platform model
                .WithOne(p => p.Platform!)      // //  With each Command, having 1 Platform
                .HasForeignKey(p => p.PlatformId);  // and each Has "public int PlatformId { get; set; } "  inside Command model

            modelBuilder
                .Entity<Command>()
                .HasOne(p => p.Platform)    //  Has "public Platform Platform { get; set; }"  inside Command model
                .WithMany(p => p.Commands)  // With each Platform, having many Commands
                .HasForeignKey(p => p.PlatformId);   // commond foreign key
        }
    }
}
