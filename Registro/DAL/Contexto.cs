using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Registro.Model;

namespace Registro.Data{
public class Contexto : IdentityDbContext
{
    public DbSet<Ocupaciones> Ocupaciones { get; set; }

    public DbSet<Persona> Persona { get; set; }

     public DbSet<Prestamos> Prestamos { get; set; }

       public DbSet<Pagos> Pagos { get; set; }

    public Contexto(DbContextOptions<Contexto> options) : base(options)
    {
    }

}
}
 