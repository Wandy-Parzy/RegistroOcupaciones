using System.ComponentModel.DataAnnotations;

namespace Registro.Model
{
     public class Persona
     {
          [Key]

          public int PersonaId { get; set; }

          [Required(ErrorMessage = "La nombre de la persona es requerido")]
          public string? Nombre { get; set; }

          public double Telefono { get; set; }

          public double Celular { get; set; }

          public string? Email { get; set; }

          public string? Direccion { get; set; }
  
          public double Balance { get; set; }
          
          public  DateTime FechaNacimiento { get; set; }

          [Required(ErrorMessage = "El id de una ocupacion es requerido")]     
          public int OcupacionId { get; set; }

     }
}