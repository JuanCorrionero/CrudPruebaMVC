using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCrud.Models.ViewModels
{
    public class NuevoPersonaViewModel
    {

            public long Id { get; set; }
            [Required]
            [StringLength(50)]
            [Display(Name = "Nombre")]
            public string Nombre { get; set; }
            [Required]
            [StringLength(50)]
            [EmailAddress]
            [Display(Name = "Correo electronico")]
            public string Correo { get; set; }
  
    }
}