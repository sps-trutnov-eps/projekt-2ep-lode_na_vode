using LodeNaVode.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LodeNaVode.Data
{
    public class LobbyDbContext : DbContext
    {
        public DbSet<Lobby> Lobbies { get; set; }

        public LobbyDbContext(DbContextOptions<LobbyDbContext> options) : base(options) { }
    }
}
