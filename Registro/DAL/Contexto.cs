using Microsoft.EntityFrameworkCore;
using Registro.Model;
using Registro.DAL;

namespace Registro.DAL{
public class Contexto : DbContext
{
    public DbSet<Ocupaciones> Ocupaciones { get; set; }

    public Contexto(DbContextOptions<Contexto> options) : base(options)
    {
    }

}
}
 