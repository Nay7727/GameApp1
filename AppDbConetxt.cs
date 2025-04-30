using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Friends)
                .WithMany();

            modelBuilder.Entity<User>()
                .HasMany(u => u.Games)
                .WithMany(g => g.Users);

            modelBuilder.Entity<Game>()
                .HasMany(g => g.Genres)
                .WithMany(gr => gr.Games);
        }
    }
}
