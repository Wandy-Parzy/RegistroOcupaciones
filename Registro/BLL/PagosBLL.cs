using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Registro.DAL;
using  Registro.Model;

namespace Registro.BLL
{
     public class PagosBLL
     {
          private Contexto _contexto;

          public PagosBLL(Contexto contexto)
          {
               _contexto = contexto;
          }
                    public bool Existe(int PagosId)
          {
               return _contexto.Pagos.Any(o => o.PagosId == PagosId);
          }

          private bool Insertar(Pagos pagos)
          {
               _contexto.Pagos.Add(pagos);
               return _contexto.SaveChanges() > 0;
          }

          private bool Modificar(Pagos pagos)
          {
               _contexto.Entry(pagos).State = EntityState.Modified;
               return _contexto.SaveChanges() > 0;
          }

          public bool Guardar(Pagos pagos)
          {
               if (!Existe(pagos.PagosId))
                    return this.Insertar(pagos);
               else
                    return this.Modificar(pagos);
          }

          public bool Eliminar(Pagos pagos)
          {
               _contexto.Entry(pagos).State = EntityState.Deleted;
               return _contexto.SaveChanges() > 0;
          }

             public bool Editar(Pagos Pagos)
          {
               if (!Existe(Pagos.PagosId))
                    return this.Insertar(Pagos);
               else
                    return this.Modificar(Pagos);
          }

          public Pagos? Buscar(int pagos)
          {
               return _contexto.Pagos
                       .Where(o => o.PagosId == pagos)
                       .AsNoTracking()
                       .SingleOrDefault();

          }

          public List<Pagos> GetList(Expression<Func<Pagos, bool>> Criterio)
          {
               return _contexto.Pagos
                   .AsNoTracking()
                   .Where(Criterio)
                   .ToList();
          }
          

     }
}