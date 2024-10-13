using System.ComponentModel.DataAnnotations;

namespace MarianelaVeras_Ap1_P1.Models
{
    public class Deudores
    {
        [Key]
        public int DeudorId { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public string? Nombres {  get; set; }
    }
}
