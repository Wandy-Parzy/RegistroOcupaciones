using System.ComponentModel.DataAnnotations;

namespace Registro.Model
{
    public class PagosDetalle
    {

        [Key]
        public int Id { get; set; }

        public int PagoId { get; set; }
        
        public int PrestamoId { get; set; }

        [Range(minimum: 0.01, maximum: 1000000000000, ErrorMessage = "Indique el valor a pagar")]
        public double ValorPagado { get; set; }

        public PagosDetalle()
          {
               Id = 0;
               PagoId = 0;
               PrestamoId = 0;
               ValorPagado = 0;
          }

        public PagosDetalle(int id, int pagoId, int prestamoId, double valorPagado)

          {
               Id = id;
               PagoId = pagoId;
               PrestamoId = prestamoId;
               ValorPagado = valorPagado;
          }

    }
}
