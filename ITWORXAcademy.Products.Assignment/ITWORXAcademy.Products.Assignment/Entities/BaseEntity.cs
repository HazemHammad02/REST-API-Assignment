using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITWORXAcademy.Products.Assignment.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            ID = Guid.NewGuid();
        }
        public Guid ID { get; set; }
    }
}
