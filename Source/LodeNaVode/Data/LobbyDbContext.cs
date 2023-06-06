using LodeNaVode.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LodeNaVode.Data
{
    public class LobbyDbContext : DbContext
    {
        public DbSet<Lobby> Lobbies { get; set; }
        public DbSet<Player> Players { get; set; }

        public LobbyDbContext(DbContextOptions<LobbyDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lobby>()
                .HasMany(l => l.Players)
                .WithOne(p => p.Lobby)
                .HasForeignKey(p => p.LobbyId)
                .IsRequired(false);
        }
    }
}
