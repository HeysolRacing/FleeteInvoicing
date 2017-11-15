using System.ComponentModel.DataAnnotations;

namespace FleeteInvoicing.Entities
{
    public class PaymentMethod
    {
        [Display(Name = "Payment Method")]
        public int paymentMethodTypeId { get; set; }

        [Display(Name = "Payment Method Code")]
        public string paymentMethodTypeCode { get; set; }

        [Display(Name = "Descripcion")]
        public string paymentMethodDesc { get; set; }
    }
}