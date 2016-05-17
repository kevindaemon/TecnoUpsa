using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaltationSistemas.Areas.Docente.Services
{
    public class DocenteList : List<Domain.Docente>
    {
        //Singleton
        private static DocenteList instance;
        private DocenteList() { }
        public static DocenteList GetInstance()
        {
            if (instance == null)
            {
                instance = new DocenteList();
                var Docentes = new DocenteDBAdapter().Docentes;
                foreach (var Docente in Docentes)
                {
                    var DocenteDomain = new Domain.Docente();
                    DocenteDomain.Registro = Docente.Registro;
                    DocenteDomain.Nombre = Docente.Nombre;
                    DocenteDomain.Apellido = Docente.Apellido;
                    DocenteDomain.Correo = Docente.Correo;
                    DocenteDomain.Telefono = Docente.Telefono;

                    instance.Add(DocenteDomain);
                }
            }

            return instance;


        }
        public Domain.Docente GetByRegistro(Int32 Registro)
        {
            var x = instance.Where(i => i.Registro == Registro).FirstOrDefault();
            return x;
        }
        public void Update(Domain.Docente DocenteDomain)
        {
            var x = GetByRegistro(DocenteDomain.Registro);
            if (x == null)
            {
                throw new Exception("Registro no encontrado");
            }

            x.Nombre = DocenteDomain.Nombre;
            x.Apellido = DocenteDomain.Apellido;
            x.Correo = DocenteDomain.Correo;
            x.Telefono = DocenteDomain.Telefono;

        }
        public void Delete(Domain.Docente DocenteDomain)
        {
            var x = instance.Where(i => i.Registro == DocenteDomain.Registro).FirstOrDefault();
            instance.Remove(x);
        }
        public void SaveChanges()
        {
            var DbAdapter = new DocenteDBAdapter();
            foreach (var Docente in instance)
            {

                var Entity = DbAdapter.GetByRegistro(Docente.Registro);
                if (Entity == null)
                {
                    Entity = new Entities.Docente();
                    Entity.Registro = Docente.Registro;
                    Entity.Nombre = Docente.Nombre;
                    Entity.Apellido = Docente.Apellido;
                    Entity.Telefono = Docente.Telefono;
                    Entity.Correo = Docente.Correo;
                    DbAdapter.Insert(Entity);

                }

                Entity.Nombre = Docente.Nombre;
                Entity.Apellido = Docente.Apellido;
                Entity.Telefono = Docente.Telefono;
                Entity.Correo = Docente.Correo;
                DbAdapter.Update(Entity);


            }
            var Entities = DbAdapter.Docentes;
            foreach (var entitie in Entities)
            {
                var DocenteDomain = instance.GetByRegistro(entitie.Registro);
                if (DocenteDomain == null)
                {
                    DbAdapter.Delete(entitie);
                }
            }
        }
    }
}