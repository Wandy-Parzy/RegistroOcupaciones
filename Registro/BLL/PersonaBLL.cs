using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Registro.Data;
using  Registro.Model;

namespace Registro.BLL
{
       public class PersonaBLL
     {
          private Contexto _contexto;

          public PersonaBLL(Contexto contexto)
          {
               _contexto = contexto;
          }

         public async Task<bool> Existe(int personaId)
        {
            return  await _contexto.Persona.AnyAsync(o => o.PersonaId == personaId);
        }

          private async Task<bool> Insertar(Persona persona)
          {
             await _contexto.Persona.AddAsync(persona);
               int cantidad = await _contexto.SaveChangesAsync();
               return cantidad > 0;
          }    

          private async Task<bool> Modificar(Persona persona)
          {
               _contexto.Entry(persona).State = EntityState.Modified;
               return await _contexto.SaveChangesAsync() > 0;
          }

          public async Task<bool>  Guardar(Persona persona)
          {
               if (!await Existe(persona.PersonaId))
                    return await this.Insertar(persona);
               else
                    return await this.Modificar(persona);
          }

          public async Task<bool> Eliminar(Persona persona){
     
               _contexto.Entry(persona).State = EntityState.Deleted;
               return  await _contexto.SaveChangesAsync() > 0;
     }

          public  async Task<Persona?> Buscar(int personaId)
          {
               return await _contexto.Persona
                    .Where(o=> o.PersonaId == personaId)
                    .AsNoTracking()
                    .SingleOrDefaultAsync();

          }

          public async Task<List<Persona>> GetPersonas(Expression<Func<Persona, bool>> Criterio)
          {
               return await _contexto.Persona
                   .AsNoTracking()
                   .Where(Criterio)
                   .ToListAsync();
          }
         public async Task<List<Ocupaciones>> GetOcupaciones(Expression<Func<Ocupaciones, bool>> Criterio){
            return await _contexto.Ocupaciones
                .AsNoTracking()
                .Where(Criterio)
                .ToListAsync();
      }

     }
}