using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LodeNaVode.Models
{
    public class Lobby
    {
        [Key]
        public string ID { get; set; }
        [Required]
        public string Gamemode { get; set; }
        [Required]
        public string Owner { get; set; }
    }
}
