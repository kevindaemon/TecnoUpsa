using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaltationSistemas.Areas.Docente.Services
{
    
        public class DocenteDBAdapter
        {

        private Data.DBContext context;

        public DocenteDBAdapter()
        {
            this.context = new Data.DBContext();
        }
        public DocenteDBAdapter(Data.DBContext context)
        {
            this.context = context;
        }
        public IEnumerable<Entities.Docente> Docentes
        {
            get
            {
                return context.Docentes.ToArray();
            }
        }

        public Entities.Docente GetById(Object id)
        {
            return context.Docentes.Find(id);
        }
        public Entities.Docente GetByRegistro(Int32 Reg)
        {
            return context.Docentes.Where(i => i.Registro == Reg).FirstOrDefault();
        }
        public Entities.Docente Insert(Entities.Docente entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entity = context.Docentes.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public void Update(Entities.Docente entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.SaveChanges();

        }
        public void Delete(Entities.Docente entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Docentes.Remove(entity);
            context.SaveChanges();

        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}