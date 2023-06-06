using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel;

namespace LodeNaVode.Models
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }

        [Required]
        public string PlayerCookie { get; set; }

        public int? LobbyId { get; set; }
        public Lobby? Lobby { get; set; }
    }
}
