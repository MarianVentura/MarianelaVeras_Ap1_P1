using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarianelaVeras_Ap1_P1.Models;

public class Cobros
{
    [Key]
    public int CobroId { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    public DateTime Fecha { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor que cero.")]
    
    public decimal Monto { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    public int DeudorId { get; set; }

    [ForeignKey("DeudorId")]

    public Deudores? Deudor { get; set; }

    public List<CobrosDetalle> CobroDetalles { get; set; } = new List<CobrosDetalle>();  

}
