using System.ComponentModel.DataAnnotations;

namespace Registro.Model
{
    public class Ocupaciones
    {

        [Key]
        public int OcupacionId { get; set; }

        [Required(ErrorMessage = "La descripcion es requerida")]
        public string? Descripcion { get; set; }

        [Range(minimum : 100, maximum:100000, ErrorMessage = "El salario debe ser mayor a 100")]
        public double Salario  { get; set; }
    }
}
