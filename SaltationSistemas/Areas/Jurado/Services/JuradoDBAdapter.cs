using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaltationSistemas.Areas.Jurado.Services
{
    public class JuradoDBAdapter
    {
        private Data.DBContext context;

        public JuradoDBAdapter()
        {
            this.context = new Data.DBContext();
        }
        public JuradoDBAdapter(Data.DBContext context)
        {
            this.context = context;
        }
        public IEnumerable<Entities.Jurado> Jurados
        {
            get
            {
                return context.Jurados.ToArray();
            }
        }

        public Entities.Jurado GetById(Object id)
        {
            return context.Jurados.Find(id);
        }
      
        public Entities.Jurado Insert(Entities.Jurado entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entity = context.Jurados.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public void Update(Entities.Jurado entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.SaveChanges();

        }
        public void Delete(Entities.Jurado entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Jurados.Remove(entity);
            context.SaveChanges();

        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}