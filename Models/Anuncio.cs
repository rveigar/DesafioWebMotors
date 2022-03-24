using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;

namespace DesafioWebMotors.Models
{
    [Table("tb_AnuncioWebmotors")]
    public class Anuncio
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [MaxLength(45)]
        [Column("marca")]
        public string Marca { get; set; }

        [Required]
        [MaxLength(45)]
        [Column("modelo")]
        public string Modelo { get; set; }

        [Required]
        [MaxLength(45)]
        [Column("versao")]

        public string Versao { get; set; }

        [Required]
        [Column("ano")]
        public int Ano { get; set; }

        [Required]
        [Column("quilometragem")]
        public int Quilometragem { get; set; }
        [Required]
        [Column("observacao")]
        public string Observacao { get; set; }

       
    }
}
