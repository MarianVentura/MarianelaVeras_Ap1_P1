﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarianelaVeras_Ap1_P1.Models;

public class Prestamos
{
    [Key]
    public int PrestamoId { get; set; }
    
    [Required(ErrorMessage = "Campo Obligatorio")]
    public string? Concepto { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    public decimal Monto { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    public decimal Balance { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    public int DeudorId { get; set; }

    [ForeignKey("DeudorId")]
    public Deudores? Deudor { get; set; }

    public List<CobrosDetalle> CobroDetalles { get; set; } = new List<CobrosDetalle>();

}
