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

        [ForeignKey("Lobby")]
        [AllowNull]
        [DefaultValue(0)]
        public int LobbyId { get; set; }
        [AllowNull]
        [DefaultValue(null)]
        public Lobby Lobby { get; set; }
    }
}
