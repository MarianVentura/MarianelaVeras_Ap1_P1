using MarianelaVeras_Ap1_P1.DAL;
using MarianelaVeras_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace MarianelaVeras_Ap1_P1.Services
{
    public class CobroDetallesServices
    {
        private readonly Contexto _contexto;

        public CobroDetallesServices(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Existe(int cobroDetalleId)
        {
            return await _contexto.CobroDetalles.AnyAsync(cd => cd.DetalleId == cobroDetalleId);
        }

        private async Task<bool> Insertar(CobrosDetalle cobroDetalle)
        {
            _contexto.CobroDetalles.Add(cobroDetalle);
            return await _contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(CobrosDetalle cobroDetalle)
        {
            _contexto.CobroDetalles.Update(cobroDetalle);
            var modificado = await _contexto.SaveChangesAsync() > 0;

            _contexto.Entry(cobroDetalle).State = EntityState.Detached;

            return modificado;
        }

        public async Task<bool> Guardar(CobrosDetalle cobroDetalle)
        {
            if (!await Existe(cobroDetalle.DetalleId))
                return await Insertar(cobroDetalle);
            else
                return await Modificar(cobroDetalle);
        }

        public async Task<bool> Eliminar(int id)
        {
            var eliminarCobroDetalle = await _contexto.CobroDetalles
                .Where(cd => cd.DetalleId == id)
                .ExecuteDeleteAsync();

            return eliminarCobroDetalle > 0;
        }

        public async Task<CobrosDetalle?> Buscar(int id)
        {
            return await _contexto.CobroDetalles
                .AsNoTracking()
                .Include(cd => cd.Cobro)
                .Include(cd => cd.Prestamo)
                .FirstOrDefaultAsync(cd => cd.DetalleId == id);
        }

        public async Task<List<CobrosDetalle>> Listar(Expression<Func<CobrosDetalle, bool>> criterio)
        {
            return await _contexto.CobroDetalles
                .AsNoTracking()
                .Include(cd => cd.Cobro)
                .Include(cd => cd.Prestamo)
                .Where(criterio)
                .ToListAsync();
        }

        public async Task<List<Deudores>> ObtenerDeudores()
        {
            return await _contexto.Deudores.ToListAsync();
        }

        public async Task<List<Prestamos>> ObtenerPrestamo()
        {
            return await _contexto.Prestamos.ToListAsync(); 
        }
    }
}
