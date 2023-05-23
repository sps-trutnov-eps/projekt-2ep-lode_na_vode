using LodeNaVode.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LodeNaVode.Data
{
    public class LobbyDbContext : DbContext
    {
        public DbSet<Lobby> Test { get; set; }

        public LobbyDbContext(DbContextOptions<LobbyDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasOne(p => p.Lobby)
                .WithMany(c => c.Players)
                .HasForeignKey(p => p.Id);
        }
    }
}
