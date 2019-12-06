using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCrud.Models.ViewModels
{
    public class PersonaViewModel
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
    }
}