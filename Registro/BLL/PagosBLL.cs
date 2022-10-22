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
                bool paso = false;

               try
               {  
                    if (_contexto.Pagos.Add(pago) != null)
                         paso = _contexto.SaveChanges() > 0;
               }
               catch (Exception)
               {
                    throw;
               }

               return paso;
          }

          private bool Modificar(Pagos pago)
          {
                bool paso = false;

               try
               {
                    _contexto.Database.ExecuteSqlRaw($"DELETE FROM PagosDetalles WHERE PrestamoId={pago.PagoId}");

                    foreach (var Anterior in pago.Detalles)
                    {
                    _contexto.Entry(Anterior).State = EntityState.Added;
                    }

                    _contexto.Entry(pago).State = EntityState.Modified;

                    paso = _contexto.SaveChanges() > 0;
               }
               catch (Exception)
               {
                    throw;
               }
               return paso;
          }

          public bool Guardar(Pagos pago)
          {
               if (!Existe(pago.PagoId))
                    return this.Insertar(pago);
               else
                    return this.Modificar(pago);
          }

          public bool Eliminar(int Id)
          {
            bool paso = false;

               try
               {
                    var pago = _contexto.Pagos.Find(Id);

                    if (pago != null)
                    {
                    _contexto.Pagos.Remove(pago);
                    paso = _contexto.SaveChanges() > 0;
                    }
               }
               catch (Exception)
               {
                    throw;
               }

               return paso;
          }

             public bool Editar(Pagos Pago)
          {
               if (!Existe(Pago.PagoId))
                    return this.Insertar(Pago);
               else
                    return this.Modificar(Pago);
          }

          public Pagos? Buscar(int Id)
          {
             Pagos pago;
               
               try
               {
                    pago = _contexto.Pagos.Include(x => x.Detalles).Where(c => c.PagoId == Id).SingleOrDefault();
               }
               catch (Exception)
               {
                    throw;
               }

               return pago;

          }

          public List<Pagos> GetList(Expression<Func<Pagos, bool>> Criterio)
          {
              List<Pagos> lista = new List<Pagos>();

               try
               {
                    lista = _contexto.Pagos.Where(Criterio).ToList();
               }
               catch (Exception)
               {
                    throw;
               }

               return lista;
          }
          

     }
}