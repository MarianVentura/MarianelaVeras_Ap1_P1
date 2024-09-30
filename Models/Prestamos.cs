using System.ComponentModel.DataAnnotations;

namespace MarianelaVeras_Ap1_P1.Models;

public class Prestamos
{
    [Key]
    public int PrestamoId { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    public string? Deudor {  get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    public string? Concepto { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    public decimal Monto { get; set; }


}
