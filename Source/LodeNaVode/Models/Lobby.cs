using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace LodeNaVode.Models
{
    public class Lobby
    {
        [Key]
        public int LobbyId { get; set; }

        [Required]
        public string Gamemode { get; set; }

        public string? Owner { get; set; }

        [Required]
        public bool Active { get; set; }

        [Required]
        virtual public ICollection<Player> Players { get; set; }
    }
}
