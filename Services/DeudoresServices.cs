using Microsoft.EntityFrameworkCore;
using MarianelaVeras_Ap1_P1.DAL;
using MarianelaVeras_Ap1_P1.Models;
using System.Linq.Expressions;  

namespace MarianelaVeras_Ap1_P1.Services;

public class DeudoresServices
{
    private readonly Contexto _contexto;

    public DeudoresServices(Contexto contexto)
    {
        _contexto = contexto;
    }   

    public async Task<List<Deudores>> Listar()
    {
        return await _contexto.Deudores.AsNoTracking().ToListAsync();
    }
}
