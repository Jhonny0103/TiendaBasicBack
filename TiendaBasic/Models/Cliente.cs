using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaBasic.Models
{
    [Table("CLIENTE")]
    public class Cliente
    {
        [Key]
        [Column("IdCliente")]
        public int IdCliente { get; set; }
        [Column("Nombre")]
        public string Nombre { get; set; }
        [Column("Apellido")]
        public string Apellido { get; set; }
        [Column("Telefono")]
        public int Telefono { get; set; }
        [Column("Email")]
        public string Email { get; set; }
        [Column("EsActivo")]
        public int EsActivo { get; set; }
        [Column("FechaCreado")]
        public DateTime FechaCreado { get; set; }
    }
}
