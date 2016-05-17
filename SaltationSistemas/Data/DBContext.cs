using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SaltationSistemas.Data
{
    public class DBContext:DbContext 
    {
        public
        DBContext():base ("DBConection")
        { }
        
        public DbSet<Areas.Estudiante.Entities.Estudiante> Estudiantes {get; set;}

        public DbSet<Areas.Docente.Entities.Docente> Docentes { get; set; }

        public DbSet<Areas.Jurado.Entities.Jurado> Jurados { get; set; }

    }
}