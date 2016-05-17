using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaltationSistemas.Areas.Docente.Domain
{
    public abstract class Persona
    {

        public String Nombre { get; set; }

        public String Apellido { get; set; }

        public String Telefono { get; set; }

        public String Correo { get; set; }

    }
}