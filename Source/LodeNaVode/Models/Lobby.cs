using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace LodeNaVode.Models
{
    public class Lobby
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Required]
        public string Gamemode { get; set; }

        [Required]
        public string Owner { get; set; }

        [Required]
        public List<int> Players { get; set; }
    }

    public class Player
    {
        public int PlayerId { get; set; }

        [ForeignKey("Lobby")]
        public int Id { get; set; }
        public Lobby Lobby { get; set; }
    }
}
