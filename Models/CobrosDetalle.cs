using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarianelaVeras_Ap1_P1.Models;

public class CobrosDetalle
{
    [Key]
    public int DetalleId { get; set; }

    [ForeignKey("Cobros")]
    public int CobroId { get; set; }

    [ForeignKey("Prestamos")]
    public int PrestamoId { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    public decimal ValorCobrado { get; set; }

    public Cobros? Cobro { get; set; }
    public Prestamos? Prestamo { get; set; }
}
