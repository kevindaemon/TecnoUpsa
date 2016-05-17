using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaltationSistemas.Areas.Docente.Models
{
    public class Docente
    {
        public Int32 Id { get; set; }

        public Int32 Registro { get; set; }

        public String Nombre { get; set; }

        public String Apellido { get; set; }

        public String Telefono { get; set; }

        public String Correo { get; set; }

    }
}