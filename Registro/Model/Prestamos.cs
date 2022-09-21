using System.ComponentModel.DataAnnotations;

namespace Registro.Model
{
     public class Prestamos
     {
          [Key]

          [Required(ErrorMessage = "El ID no puede ser cero")]
          public int PrestamoId { get; set; }

          public DateTime Fecha { get; set; } = DateTime.Now;

          public DateTime Vence { get; set; }

          
          public double Monto { get; set; }

          public string? Concepto { get; set; }

          public double Balance { get; set; }
  

           [Required(ErrorMessage = "El ID no puede ser cero")]

           public int PersonaID { get; set; }

     }
}