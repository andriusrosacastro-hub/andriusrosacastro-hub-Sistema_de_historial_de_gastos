using System.ComponentModel.DataAnnotations;

namespace Sistemade_de_hsitorial_de_gastos.Models
{
    public class Gasto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(200, ErrorMessage = "La descripción no puede exceder 200 caracteres")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "El monto es obligatorio")]
        [Range(0.01, 999999.99, ErrorMessage = "El monto debe ser entre 0.01 y 999,999.99")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "La categoría es obligatoria")]
        [StringLength(100, ErrorMessage = "La categoría no puede exceder 100 caracteres")]
        [Display(Name = "Categoría")]
        public string Categoria { get; set; } = string.Empty;
    }
}