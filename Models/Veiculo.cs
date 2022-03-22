using System.ComponentModel.DataAnnotations;

namespace DesafioWebMotors.Models
{
    public class Veiculo
   
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Version { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public int Km { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int YarModel { get; set; }
        [Required]
        public int YearFab { get; set; }
        [Required]
        public string Color { get; set; }


    }
}
