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
    public decimal Monto { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    public int DeudorId { get; set; }

    [ForeignKey("DeudorId")]
    public Deudores? Deudor { get; set; }

    public List<CobroDetalles> CobroDetalles { get; set; } = new List<CobroDetalles>();  

}
