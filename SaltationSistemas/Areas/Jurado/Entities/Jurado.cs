using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SaltationSistemas.Areas.Jurado.Entities
{
    public class Jurado
    {

        [Key]
        [Column("Id_Jurado")]
        public Int32 Id { get; set; }

        [ForeignKey("Docente")]
        [Column("Id_Docente")]
        public Int32 Id_Docente { get; set; }

        public virtual Areas.Docente.Entities.Docente Docente { get; set; }
        
    }
}