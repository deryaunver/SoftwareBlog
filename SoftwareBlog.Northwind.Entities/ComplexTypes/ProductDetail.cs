using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareBlog.Core.Entity;

namespace SoftwareBlog.Northwind.Entities.ComplexTypes
{
    public  class ProductDetail:IEntity
    {
        public virtual int  ProductID { get; set; }
        public virtual string ProductName { get; set; }
        public virtual string CategoryName { get; set; }
    }
}
