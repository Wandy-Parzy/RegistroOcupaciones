using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Registro.DAL;
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

          public bool Existe(int PersonaId)
          {
               return _contexto.Persona.Any(o => o.PersonaId == PersonaId);
          }

          private bool Insertar(Persona persona)
          {
               _contexto.Persona.Add(persona);
               return _contexto.SaveChanges() > 0;
          }

          private bool Modificar(Persona persona)
          {
               _contexto.Entry(persona).State = EntityState.Modified;
               return _contexto.SaveChanges() > 0;
          }

          public bool Guardar(Persona persona)
          {
               if (!Existe(persona.PersonaId))
                    return this.Insertar(persona);
               else
                    return this.Modificar(persona);
          }

          public bool Eliminar(Persona persona)
          {
               _contexto.Entry(persona).State = EntityState.Deleted;
               return _contexto.SaveChanges() > 0;
          }

          public Persona? Buscar(int personaId)
          {
               return _contexto.Persona
                       .Where(o => o.PersonaId == personaId)
                       .AsNoTracking()
                       .SingleOrDefault();

          }
          
          public List<Persona> GetList(Expression<Func<Persona, bool>> Criterio)
          {
               return _contexto.Persona
                   .AsNoTracking()
                   .Where(Criterio)
                   .ToList();
          }
         public List<Ocupaciones> GetOcupaciones(Expression<Func<Ocupaciones, bool>> Criterio){
            return _contexto.Ocupaciones
                .AsNoTracking()
                .Where(Criterio)
                .ToList();
        }

     }
}