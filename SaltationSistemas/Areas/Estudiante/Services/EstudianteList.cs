using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaltationSistemas.Areas.Estudiante.Services
{
    public class EstudianteList:List<Domain.Estudiante>
    {
        //Singleton
        private static EstudianteList instance;
        private EstudianteList() { }
        public static EstudianteList GetInstance()
        {
            if (instance == null)
            {
                instance = new EstudianteList();
                var Estudiantes = new EstudianteDBAdapter().Estudiantes;
                foreach (var Estudiante in Estudiantes)
                {
                    var EstudianteDomain = new Domain.Estudiante();
                    EstudianteDomain.Registro = Estudiante.Registro;
                    EstudianteDomain.Nombre = Estudiante.Nombre;
                    EstudianteDomain.Apellido = Estudiante.Apellido;
                    EstudianteDomain.Correo = Estudiante.Correo;
                    EstudianteDomain.Telefono = Estudiante.Telefono;

                    instance.Add(EstudianteDomain);
                }
            }

            return instance;
            
            
        }
        public Domain.Estudiante GetByRegistro(Int32 Registro)
        {
            var x = instance.Where(i => i.Registro == Registro).FirstOrDefault();
            return x;
        }
        public void Update(Domain.Estudiante EstudianteDomain)
        {
            var x = GetByRegistro(EstudianteDomain.Registro);
            if (x == null)
            {
                throw new Exception("Registro no encontrado");
            }
            
            x.Nombre = EstudianteDomain.Nombre;
            x.Apellido = EstudianteDomain.Apellido;
            x.Correo = EstudianteDomain.Correo;
            x.Telefono = EstudianteDomain.Telefono;

        }
        public void Delete(Domain.Estudiante EstudianteDomain)
        {
            var x = instance.Where(i => i.Registro == EstudianteDomain.Registro).FirstOrDefault();
            instance.Remove(x);
        }
        public void SaveChanges()
        {
            var DbAdapter = new EstudianteDBAdapter();
            foreach(var Estudiante in instance)
            {
                
               var Entity= DbAdapter.GetByRegistro(Estudiante.Registro);
                if (Entity == null)
                {
                    Entity = new Entities.Estudiante();
                    Entity.Registro = Estudiante.Registro;
                    Entity.Nombre = Estudiante.Nombre;
                    Entity.Apellido = Estudiante.Apellido;
                    Entity.Telefono = Estudiante.Telefono;
                    Entity.Correo = Estudiante.Correo;
                    DbAdapter.Insert(Entity);

                }

                Entity.Nombre = Estudiante.Nombre;
                Entity.Apellido = Estudiante.Apellido;
                Entity.Telefono = Estudiante.Telefono;
                Entity.Correo = Estudiante.Correo;
                DbAdapter.Update(Entity);


            }
            var Entities = DbAdapter.Estudiantes;
            foreach (var entitie in Entities)
            {
                var EstudianteDomain = instance.GetByRegistro(entitie.Registro);
                if (EstudianteDomain == null)
                {
                    DbAdapter.Delete(entitie);
                }
            }
        }
    }
}