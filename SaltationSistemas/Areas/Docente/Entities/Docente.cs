using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SaltationSistemas.Areas.Docente.Entities
{
  

        [Table("Docente")]
        public class Docente
        {
            [Key]
            [Column("Id")]
            public Int32 Id { get; set; }

            [Column("Registro")]
            public Int32 Registro { get; set; }

            [Column("Nombre")]
            public String Nombre { get; set; }

            [Column("Apellido")]
            public String Apellido { get; set; }

            [Column("Telefono")]
            public String Telefono { get; set; }

            [Column("Correo")]
            public String Correo { get; set; }
        }
}