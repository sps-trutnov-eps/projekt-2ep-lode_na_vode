using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LodeNaVode.Models
{
    public class Player
    {
        [Key]
        public string ID { get; set; }
        [Required]
    }
}
