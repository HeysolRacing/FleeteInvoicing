using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FleeteInvoicing.Entities
{
    public class RolesMap
    {
        public string IdRole { get; set; }

        [Display(Name = "Rol")]
        [Required(ErrorMessage = "Rol es requerido.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Solo caracteres")]
        public string Name { get; set; }
    }
}