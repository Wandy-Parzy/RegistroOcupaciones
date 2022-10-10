using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Registro.DAL;
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

          public bool Existe(int PrestamosId)
          {
               return _contexto.Prestamos.Any(o => o.PrestamoId == PrestamosId);
          }

          private bool Insertar(Prestamos prestamos)
          {
               _contexto.Prestamos.Add(prestamos);
               return _contexto.SaveChanges() > 0;
          }

          private bool Modificar(Prestamos prestamos)
          {
               _contexto.Entry(prestamos).State = EntityState.Modified;
               return _contexto.SaveChanges() > 0;
          }

          public bool Guardar(Prestamos prestamos)
          {
               if (!Existe(prestamos.PrestamoId))
                    return this.Insertar(prestamos);
               else
                    return this.Modificar(prestamos);
          }

          public bool Eliminar(Prestamos prestamos)
          {
               _contexto.Entry(prestamos).State = EntityState.Deleted;
               return _contexto.SaveChanges() > 0;
          }

          public Prestamos? Buscar(int prestamoId)
          {
               return _contexto.Prestamos
                       .Where(o => o.PrestamoId == prestamoId)
                       .AsNoTracking()
                       .SingleOrDefault();

          }

          public List<Prestamos> GetList(Expression<Func<Prestamos, bool>> Criterio)
          {
               return _contexto.Prestamos
                   .AsNoTracking()
                   .Where(Criterio)
                   .ToList();
          }
          
         public List<Persona> GetPersonas(Expression<Func<Persona, bool>> Criterio){
            return _contexto.Persona
                .AsNoTracking()
                .Where(Criterio)
                .ToList();
        }
     }
}