using System.ComponentModel.DataAnnotations;

namespace DesafioWebMotors.Models
{
    public class Marca
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

    }
}
