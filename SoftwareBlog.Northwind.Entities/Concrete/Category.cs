using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareBlog.Core.Entity;

namespace SoftwareBlog.Northwind.Entities.Concrete
{
     public class Category:IEntity
    {
        public virtual int CategoryID { get; set; }
        public virtual string CategoryName { get; set; }
    }
}
