using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Registro.Model;
using Registro.DAL;

namespace Registro.BLL
{
public class OcupacionesBLL
{
    private Contexto _contexto;
    public OcupacionesBLL(Contexto contexto)
    {
        _contexto = contexto;
    }

    public bool Guardar(Ocupaciones ocupacion)
    {
        if (!Existe(ocupacion.OcupacionId))
            return Insertar(ocupacion);
        else
            return Modificar(ocupacion);
    }

    public bool Existe(int ocupacionId)
    {
        return _contexto.Ocupaciones.Any(o => o.OcupacionId == ocupacionId);
    }

    private bool Insertar(Ocupaciones ocupacion)
    {
        _contexto.Ocupaciones.Add(ocupacion);
        int cantidad = _contexto.SaveChanges();
        return cantidad > 0;
    }

    private bool Modificar(Ocupaciones ocupacion)
    {
        _contexto.Entry(ocupacion).State = EntityState.Modified;
        int cantidad = _contexto.SaveChanges();
        return cantidad > 0;
    }

       public bool Editar(Ocupaciones ocupacion){
            if (!Existe(ocupacion.OcupacionId))
                return this.Insertar(ocupacion);
            else
                return this.Modificar(ocupacion);
        }

    public Ocupaciones Buscar(int ocupacionId)
    {
        var ocupacion = _contexto.Ocupaciones.Find(ocupacionId);

        return ocupacion; 
    }

    public List<Ocupaciones> GetOcupaciones()
    {
        return _contexto.Ocupaciones.ToList();
    }
     public bool Eliminar(Ocupaciones ocupacion){
            _contexto.Entry(ocupacion).State = EntityState.Deleted;
            return _contexto.SaveChanges() > 0;
        }

}
}