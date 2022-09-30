using System;
using System.Collections.Generic;

#nullable disable

namespace API_PRUEBA_TECNICA_CRUD_REACT.Models
{
    public partial class Contacto
    {
        public int IdContacto { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
    }
}
