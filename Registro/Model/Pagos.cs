using System.ComponentModel.DataAnnotations;

namespace Registro.Model
{
     public class Pagos
     {
       [Key]

       public int PagosId { get; set; }

       public DateTime Fecha { get; set; } 
       public int PersonaId { get; set; }

       [Required(ErrorMessage = "El concepto es requerido")]

        public string? Concepto { get; set; }
          
        public double Monto { get; set; }
   
        

     }
}