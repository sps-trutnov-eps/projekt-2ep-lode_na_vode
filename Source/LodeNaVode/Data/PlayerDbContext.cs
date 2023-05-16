using LodeNaVode.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LodeNaVode.Data
{
    public class PlayerDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }

        public PlayerDbContext(DbContextOptions<PlayerDbContext> options) : base(options) { }
    }
}
