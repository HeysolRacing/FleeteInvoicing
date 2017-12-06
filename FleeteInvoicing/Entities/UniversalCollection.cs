using System.ComponentModel.DataAnnotations;

namespace FleeteInvoicing.Entities
{
    public class UniversalCollection
    {
        public int id_universal { get; set; }

        [Display(Name = "Flota")]
        [Required(ErrorMessage = "FLEET es requerido.")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Solo numeros y caracteres.")]
        [StringLength(10, ErrorMessage = "FLEET {0} debe contener entre {2} a {1} caracteres", MinimumLength = 4)]
        public string uc_fleet { get; set; }

        [Display(Name = "Cuenta")]
        [Required(ErrorMessage = "CUENTA es requerido.")]
        [StringLength(30, ErrorMessage = "CUENTA {0} debe contener entre {2} a {1} caracteres", MinimumLength = 12)]
        public string uc_account { get; set; }

        [Display(Name = "Clabe")]
        [Required(ErrorMessage = "CLABE es requerido.")]
        [StringLength(30, ErrorMessage = "CLABE {0} debe contener entre {2} a {1} caracteres", MinimumLength = 18)]
        public string uc_clabe { get; set; }

        [Display(Name = "Aba")]
        public string uc_aba { get; set; }

        [Display(Name = "Swift")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Solo caracteres")]
        public string uc_swift { get; set; }

        [Display(Name = "Moneda")]
        [Required(ErrorMessage = "MONEDA es requerido.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Solo caracteres")]
        [StringLength(5, ErrorMessage = "MONEDA {0} debe contener entre {2} a {1} caracteres", MinimumLength = 3)]
        public string uc_currency { get; set; }
    }
}