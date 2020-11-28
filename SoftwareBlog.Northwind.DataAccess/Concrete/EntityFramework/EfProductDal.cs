using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareBlog.Core.DataAccess.EntityFramework;
using SoftwareBlog.Northwind.DataAccess.Abstract;
using SoftwareBlog.Northwind.Entities.ComplexTypes;
using SoftwareBlog.Northwind.Entities.Concrete;

namespace SoftwareBlog.Northwind.DataAccess.Concrete.EntityFramework
{
   public class EfProductDal:EfEntityRepositoryBase<Product,NorthwindContext>,IProductDal
    {
        public List<ProductDetail> GetProductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products
                    join c in context.Categories on p.CategoryID equals c.CategoryID
                    select new ProductDetail
                    {
                        ProductID = p.ProductID,
                        ProductName = p.ProductName,
                        CategoryName = c.CategoryName
                    };
                return result.ToList();
            }
        }
    }
}
