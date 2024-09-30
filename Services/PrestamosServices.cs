using MarianelaVeras_Ap1_P1.DAL;
using MarianelaVeras_Ap1_P1.Models; 
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MarianelaVeras_Ap1_P1.Services;

    public class PrestamosServices
    {
        private readonly Contexto _contexto;

        public PrestamosServices(Contexto contexto)
        {
            _contexto = contexto;
        }
    
    
        public async Task<bool> Existe(int prestamoId)
        {
            return await _contexto.Prestamos.AnyAsync(p => p.PrestamoId == prestamoId);
        }

        
        private async Task<bool> Insertar(Prestamos prestamo)
        {
            _contexto.Prestamos.Add(prestamo);
            return await _contexto.SaveChangesAsync() > 0;
        }

        
        private async Task<bool> Modificar(Prestamos prestamo)
        {
            _contexto.Prestamos.Update(prestamo);
            var modificado = await _contexto.SaveChangesAsync() > 0;

            _contexto.Entry(prestamo).State = EntityState.Detached;

            return modificado;
        }

        
        public async Task<bool> Guardar(Prestamos prestamo)
        {
            if (!await Existe(prestamo.PrestamoId))
                return await Insertar(prestamo);
            else
                return await Modificar(prestamo);
        }

        
        public async Task<bool> Eliminar(int id)
        {
            var eliminarPrestamo = await _contexto.Prestamos
                .Where(p => p.PrestamoId == id)
                .ExecuteDeleteAsync();

            return eliminarPrestamo > 0;
        }

      
        public async Task<Prestamos?> Buscar(int id)
        {
            return await _contexto.Prestamos
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.PrestamoId == id);
        }

     
        public async Task<List<Prestamos>> Listar(Expression<Func<Prestamos, bool>> criterio)
        {
            return await _contexto.Prestamos
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }

