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

        [Required]
        public string PlayerName { get; set; }

        [Required]
        public bool Active { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }

        public int? LobbyId { get; set; }
        virtual public Lobby? Lobby { get; set; }
    }
}
