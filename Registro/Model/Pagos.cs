using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Registro.Model
{
     public class Pagos
     {
      [Key]
        public int PagoId { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "La Persona es Obligatoria")]
        public int PersonaId { get; set; }

        [Required(ErrorMessage = "El Concepto es Obligatoria")]
        public string? Concepto { get; set; }

        public double Monto { get; set; }

        [ForeignKey("PagoId")]
        public virtual List<PagosDetalle> Detalle { get; set; } = new List<PagosDetalle>();
     }
}