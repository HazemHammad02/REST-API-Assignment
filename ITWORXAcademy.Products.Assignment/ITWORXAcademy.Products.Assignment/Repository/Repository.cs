using ITWORXAcademy.Products.Assignment.Entities;
using ITWORXAcademy.Products.Assignment.Entities.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITWORXAcademy.Products.Assignment.Repository
{
    public class Repository<T> : IRepository<T> where T:BaseEntity 
    {
        private readonly ProductContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;
        public Repository(ProductContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }
        public T Get(Guid id)
        {
            return entities.SingleOrDefault(s => s.ID == id);
        }
        public IEnumerable<T> GetFilterByField(Func<T,bool> predict)
        {
            return entities.Where(predict)?.ToList();
        }
        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
