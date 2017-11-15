using System.ComponentModel.DataAnnotations;

namespace FleeteInvoicing.Entities
{
    public class UniversalCollection
    {
        public int id_universal { get; set; }

        [Display(Name = "Flota")]
        public string uc_fleet { get; set; }

        [Display(Name = "Cuenta")]
        public string uc_account { get; set; }

        [Display(Name = "Clabe")]
        public string uc_clabe { get; set; }

        [Display(Name = "Aba")]
        public string uc_aba { get; set; }

        [Display(Name = "Swift")]
        public string uc_swift { get; set; }

        [Display(Name = "Moneda")]
        public string uc_currency { get; set; }
    }
}