using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaltationSistemas.Areas.Estudiante.Services
{
    public class EstudianteDBAdapter
    {
        private Data.DBContext context;

        public EstudianteDBAdapter()
        {
            this.context = new Data.DBContext();
        }
        public EstudianteDBAdapter(Data.DBContext context)
        {
            this.context = context;
        }
        public IEnumerable<Entities.Estudiante> Estudiantes
        {
            get
            {
                return context.Estudiantes.ToArray();
            }
        }

        public Entities.Estudiante GetById(Object id)
        {
            return context.Estudiantes.Find(id);
        }
        public Entities.Estudiante GetByRegistro(Int32 Reg)
        {
            return context.Estudiantes.Where(i => i.Registro == Reg).FirstOrDefault();
        }
        public Entities.Estudiante Insert(Entities.Estudiante entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entity = context.Estudiantes.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public void Update(Entities.Estudiante entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.SaveChanges();

        }
        public void Delete(Entities.Estudiante entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Estudiantes.Remove(entity);
            context.SaveChanges();

        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}