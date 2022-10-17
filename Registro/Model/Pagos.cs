using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Registro.Model
{
     public class Pagos
     {
       [Key]

       public int PagoId { get; set; }

       public DateTime Fecha { get; set; }
       
       public int PersonaId { get; set; }
 
       [ForeignKey("OrdenId")]

       public virtual List<PagosDetalle> Detalles { get; set; } = new List<PagosDetalle>();
     
       [Required(ErrorMessage = "El concepto es requerido")]

        public string? Concepto { get; set; }
          
        public double Monto { get; set; }
   
     }
     public class PagosDetalle { 

          public int Id { get; set; }

          public int PagoId { get; set; }

          public int PrestamoId { get; set; }

          public int ValorPagado{ get; set; }
          
      }
}