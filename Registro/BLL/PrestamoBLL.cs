using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Registro.Data;
using  Registro.Model;

namespace Registro.BLL
{
     public class PrestamoBLL
     {
          private Contexto _contexto;

          public PrestamoBLL(Contexto contexto)
          {
               _contexto = contexto;
          }

          public async Task<bool> Existe(int PrestamosId)
          {
               return await _contexto.Prestamos.AnyAsync(o => o.PrestamoId == PrestamosId);
          }

          private async Task<bool>  Insertar(Prestamos prestamos)
          {
             await _contexto.Prestamos.AddAsync(prestamos);
            
            var personas = await _contexto.Persona.FindAsync(prestamos.PersonaId);
            personas.Balance += prestamos.Monto;
            
            int cantidad = await _contexto.SaveChangesAsync();
            
            return cantidad > 0;
          }

          private async Task<bool> Modificar(Prestamos prestamoActual)
          {
               //descontar el monto anterior
               var prestamoAnterior = await _contexto.Prestamos
                .Where(p => p.PrestamoId == prestamoActual.PrestamoId)
                .AsNoTracking()
                .SingleOrDefaultAsync();

            var personaAnterior = await _contexto.Persona.FindAsync(prestamoAnterior.PersonaId);
            personaAnterior.Balance -= prestamoAnterior.Monto;

            _contexto.Entry(prestamoActual).State = EntityState.Modified;
            
            //descontar el monto nuevo
            var persona = await _contexto.Persona.FindAsync(prestamoActual.PersonaId);
            persona.Balance += prestamoActual.Monto;

            return await _contexto.SaveChangesAsync() > 0;
          }

          public async Task<bool> Eliminar(Prestamos prestamos)
          {
               var persona = await _contexto.Persona.FindAsync(prestamos.PersonaId);
               persona.Balance -= prestamos.Monto;
            
               _contexto.Entry(prestamos).State = EntityState.Deleted;
               return await _contexto.SaveChangesAsync() > 0;
          }

          public async Task<bool> Guardar(Prestamos prestamo)
          {
               var existe = await Existe(prestamo.PrestamoId);

                if (!existe)
                  return await this.Insertar(prestamo);
                else
                  return await this.Modificar(prestamo);
           }

          public async Task<Prestamos?> Buscar(int prestamoId)
          {
               return await _contexto.Prestamos
                       .Where(o => o.PrestamoId == prestamoId)
                       .AsNoTracking()
                       .SingleOrDefaultAsync();

          }

          public async Task<List<Prestamos>> GetPrestamos(Expression<Func<Prestamos, bool>> Criterio)
          {
               return await _contexto.Prestamos
                   .AsNoTracking()
                   .Where(Criterio)
                   .ToListAsync();
          }
          
          
     }
}