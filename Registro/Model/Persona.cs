using System.ComponentModel.DataAnnotations;

namespace Registro.Model
{
     public class Persona
     {
          [Key]

          public int PersonaId { get; set; }

          [Required(ErrorMessage = "La nombre de la persona es requerido")]
          public string? Nombre { get; set; }

          [Required(ErrorMessage = "El numero de telefono es requerido")]
          public double Telefono { get; set; }

          [Required(ErrorMessage = "El numero de celular es requerido")]
          public double Celular { get; set; }

          public string? Email { get; set; }

          public string? Direccion { get; set; }
  
     
          
          public  DateTime FechaNacimiento { get; set; }= DateTime.Now;

          [Range(1,int.MaxValue,ErrorMessage ="El selecionar una ocupacion")]

           public int OcupacionId { get; set; }

     }
}