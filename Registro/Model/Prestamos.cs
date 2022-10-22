using System.ComponentModel.DataAnnotations;

namespace Registro.Model
{
     public class Prestamos
     {
          [Key]

      
          public int PrestamoId { get; set; }

          [Required(ErrorMessage = "Favor de ingresar la fecha de inicio.")]
          public DateTime Fecha { get; set; } = DateTime.Now;

          [Required(ErrorMessage = "Favor de ingresar la fecha de vencimiento.")]
          public DateTime Vence { get; set; }

          [Range(1, 200000000)]
          [Required(ErrorMessage = "Favor de ingresar el monto")]
          public double Monto { get; set; }

          [Required(ErrorMessage = "El concepto es requerido")]

          public string? Concepto { get; set; }

          public double Balance { get; set; }
  
          [Required(ErrorMessage = "Favor Selecccionar una pesona")]

           public int PersonaId { get; set; }

     }
}