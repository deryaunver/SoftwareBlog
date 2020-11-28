using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using SoftwareBlog.Northwind.Entities.Concrete;

namespace SoftwareBlog.Northwind.DataAccess.Concrete.NHibernate.Mappings
{
     public class ProductMap:ClassMap<Product>
    {
        public ProductMap()
        {
            Table(@"Products");

            LazyLoad();

            Id(x => x.ProductID).Column("ProductID");

            Map(x => x.ProductName).Column("ProductName");
            Map(x => x.UnitPrice).Column("UnitPrice");
            Map(x => x.QuantityPerUnit).Column("QuantityPerUnit");
            



        }
    }
}
