using ITWORXAcademy.Products.Assignment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITWORXAcademy.Products.Assignment.Repository
{
    public interface IRepository<T> where T :BaseEntity
    {
        IEnumerable<T> GetAll();
        void Insert(T entity);
        T Get(Guid id);
        IEnumerable<T> GetFilterByField(Func<T, bool> predict);
        void Update(T entity);
    }
}
