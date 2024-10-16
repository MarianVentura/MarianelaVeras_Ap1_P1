using MarianelaVeras_Ap1_P1.Components;
using MarianelaVeras_Ap1_P1.DAL;
using Microsoft.EntityFrameworkCore;
using MarianelaVeras_Ap1_P1.Models;
using MarianelaVeras_Ap1_P1.Services;


namespace MarianelaVeras_Ap1_P1;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        //Obtenemos el ConStr para usarlo en el contexto
        var ConStr = builder.Configuration.GetConnectionString("ConStr");

        //Agregamos el contexto al builder con el ConStr
        builder.Services.AddDbContext<Contexto>(Options => Options.UseSqlite(ConStr));

        builder.Services.AddScoped<PrestamosServices>();
        builder.Services.AddScoped<DeudoresServices>();
        builder.Services.AddScoped<CobrosServices>();
        builder.Services.AddScoped<CobrosDetalleServices>();

        builder.Services.AddBlazorBootstrap();



        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error", createScopeForErrors: true);
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();
    }
}
