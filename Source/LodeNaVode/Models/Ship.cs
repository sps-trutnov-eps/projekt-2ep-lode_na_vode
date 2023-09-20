using System.ComponentModel.DataAnnotations;

namespace LodeNaVode.Models
{
    public class Ship
    {
        [Key]
        public int ShipId { get; set; }

        [Required]
        public JmenoLode ShipClass { get; set; }

        public int? PlayerId { get; set; }
        virtual public Player? Player { get; set; }
    }
}
