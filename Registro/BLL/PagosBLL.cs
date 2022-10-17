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
                    public bool Existe(int PagoId)
          {
               return _contexto.Pagos.Any(o => o.PagoId == PagoId);
          }

          private bool Insertar(Pagos pago)
          {
               _contexto.Pagos.Add(pago);
               return _contexto.SaveChanges() > 0;
          }

          private bool Modificar(Pagos pago)
          {
               _contexto.Entry(pago).State = EntityState.Modified;
               return _contexto.SaveChanges() > 0;
          }

          public bool Guardar(Pagos pago)
          {
               if (!Existe(pago.PagoId))
                    return this.Insertar(pago);
               else
                    return this.Modificar(pago);
          }

          public bool Eliminar(Pagos pago)
          {
               _contexto.Entry(pago).State = EntityState.Deleted;
               return _contexto.SaveChanges() > 0;
          }

             public bool Editar(Pagos Pagos)
          {
               if (!Existe(Pagos.PagoId))
                    return this.Insertar(Pagos);
               else
                    return this.Modificar(Pagos);
          }

          public Pagos? Buscar(int pago)
          {
               return _contexto.Pagos
                       .Where(o => o.PagoId == pago)
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