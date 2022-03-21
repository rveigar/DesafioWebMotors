using System.ComponentModel.DataAnnotations;

namespace DesafioWebMotors.Models
{
    public class Modelo

    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int MakeId { get; set; } 

    }
}
