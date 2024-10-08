using MarianelaVeras_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;

namespace MarianelaVeras_Ap1_P1.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<Prestamos> Prestamos { get; set; }
    public DbSet<Deudores> Deudores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Prestamos>()
            .HasOne(p => p.Deudor)
            .WithMany()
            .HasForeignKey(p => p.DeudorId);

        modelBuilder.Entity<Deudores>().HasData(
            new Deudores { DeudorId = 1, Nombres = "Unohana Retsu" },
            new Deudores { DeudorId = 2, Nombres = "Kurosaki Ichigo" },
            new Deudores { DeudorId = 3, Nombres = "Zaraki Kenpachii" },
            new Deudores { DeudorId = 4, Nombres = "Roronoa Zoro"},
            new Deudores { DeudorId = 5, Nombres = "Monkey D. Luffy"},
            new Deudores { DeudorId = 6, Nombres = "Soul King Brook"},
            new Deudores { DeudorId = 7, Nombres = "Uzumaki Naruto"},
            new Deudores { DeudorId = 8, Nombres = "Uchiha Sasuke"},
            new Deudores { DeudorId = 9, Nombres = "Hatake Kakashi"},
            new Deudores { DeudorId = 10, Nombres = "Haruno Sakura"}
            );
    }
}


