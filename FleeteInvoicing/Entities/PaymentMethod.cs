using System.ComponentModel.DataAnnotations;

namespace FleeteInvoicing.Entities
{
    public class PaymentMethod
    {
        [Display(Name = "FORMA PAGO")]
        [Required(ErrorMessage = "Forma de pago es requerido.")]
        [RegularExpression("^[a-zA-Z0-9 ]*", ErrorMessage = "Solo números y caracteres.")]
        [StringLength(2, ErrorMessage = "Forma de pago {0} debe contener entre {2} a {1} caracteres", MinimumLength = 2)]
        public string paymentMethodTypeCode { get; set; }

        [Display(Name = "DESCRIPCION")]
        [RegularExpression(@"^[a-zA-Z ]*", ErrorMessage = "Solo caracteres")]
        [Required(ErrorMessage = "Descripcion es requerido.")]
        public string paymentMethodDesc { get; set; }

    }
}