using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using MarianelaVeras_Ap1_P1.DAL;
using MarianelaVeras_Ap1_P1.Models;

namespace MarianelaVeras_Ap1_P1.Services
{
    public class CobrosServices
    {
        private readonly Contexto _contexto;

        public CobrosServices(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Existe(int cobroId)
        {
            return await _contexto.Cobros.AnyAsync(c => c.CobroId == cobroId);
        }

        private async Task<bool> Insertar(Cobros cobro)
        {
            _contexto.Cobros.Add(cobro);
            return await _contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Cobros cobro)
        {
            _contexto.Cobros.Update(cobro);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(Cobros cobro)
        {
            if (!await Existe(cobro.CobroId))
                return await Insertar(cobro);
            else
                return await Modificar(cobro);
        }

        public async Task<bool> Eliminar(int id)
        {
            var eliminarCobro = await _contexto.Cobros
                .Where(c => c.CobroId == id)
                .ExecuteDeleteAsync();

            return eliminarCobro > 0;
        }

        public async Task<Cobros?> Buscar(int id)
        {
            return await _contexto.Cobros
                .Include(c => c.Deudor)
                .Include(c => c.CobroDetalles)
                    .ThenInclude(cd => cd.Prestamo)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CobroId == id);
        }

        public async Task<List<Cobros>> Listar(Expression<Func<Cobros, bool>> criterio)
        {
            return await _contexto.Cobros
                .Include(c => c.Deudor)
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

        public async Task<List<Deudores>> ObtenerDeudores()
        {
            return await _contexto.Deudores.ToListAsync();
        }

        public async Task<List<Prestamos>> ObtenerPrestamos()
        {
            return await _contexto.Prestamos.ToListAsync();
        }

        public async Task<List<Prestamos>> ObtenerPrestamosPorDeudor(int deudorId)
        {
            return await _contexto.Prestamos
                .Where(p => p.DeudorId == deudorId)
                .ToListAsync();
        }
        public async Task<Prestamos> ObtenerPrestamoPorId(int prestamoId)
        {
            return await _contexto.Prestamos.FindAsync(prestamoId);
        }
    }

}
