using System;
using System.ComponentModel.DataAnnotations;

namespace FleeteInvoicing.Entities
{
    public class Expanded
    {
        [Display(Name = "CLIENTE ID")]
        [Required(ErrorMessage = "Cliente ID")]
        [RegularExpression(@"^[M0-9]*$", ErrorMessage = "Solo M y números")]
        public string CUSTID { get; set; }

        public string CORP_CD { get; set; }

        public string CNTC_NO { get; set; }

        [Required(ErrorMessage = "Dirección 1 es requerido.")]
        [RegularExpression(@"^[a-zA-Z0-9\s\.\,]*$", ErrorMessage = "Solo caracteres")]
        [Display(Name = "DIRECCION 1")]
        public string ADDRESS1 { get; set; }

        [Display(Name = "DIRECCION 2")]
        public string ADDRESS2 { get; set; }

        [Display(Name = "DIRECCION 3")]
        public string ADDRESS3 { get; set; }

        [Display(Name = "CIUDAD")]
        [Required(ErrorMessage = "Ciudad es requerido.")]
        [RegularExpression(@"^[a-zA-Z0-9\s\.\,]*$", ErrorMessage = "Solo caracteres")]
        public string CITY { get; set; }

        [Display(Name = "ESTADO")]
        [Required(ErrorMessage = "Estado es requerido.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Solo caracteres")]
        public string STATE { get; set; }

        [Display(Name = "CODIGO POSTAL")]
        [Required(ErrorMessage = "Codigo postal es requerido.")]
        [StringLength(5, ErrorMessage = " {0} debe contener entre {2} a {1} caracteres", MinimumLength = 5)]
        public string ZIP { get; set; }

        [Display(Name = "CLIENTE")]
        [Required(ErrorMessage = "Cliente es requerido.")]
        [RegularExpression(@"^[a-zA-Z0-9\s\.\,]*$", ErrorMessage = "Solo caracteres")]
        public string CUSTNAME { get; set; }

        [Display(Name = "RFC")]
        [Required(ErrorMessage = "RFC es requerido.")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Solo números y caracteres.")]
        [StringLength(13, ErrorMessage = " {0} debe contener entre {2} a {1} caracteres", MinimumLength = 10)]
        public string RFC { get; set; }

        [Display(Name = "FORMA DE PAGO")]
        public string PAYMENT_METHOD_TYPE { get; set; }

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; }
    }
}