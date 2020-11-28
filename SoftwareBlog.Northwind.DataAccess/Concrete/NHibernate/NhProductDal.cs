using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareBlog.Core.DataAccess.NHibernate;
using SoftwareBlog.Northwind.DataAccess.Abstract;
using SoftwareBlog.Northwind.Entities.ComplexTypes;
using SoftwareBlog.Northwind.Entities.Concrete;

namespace SoftwareBlog.Northwind.DataAccess.Concrete.NHibernate
{
   public class NhProductDal:NhEntityRepositoryBase<Product>,IProductDal
   {
       private NHibernateHelper _nHibernateHelper;
        public NhProductDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
            _nHibernateHelper = nHibernateHelper;
        }


        public List<ProductDetail> GetProductDetails()
        {
            using (var session = _nHibernateHelper.OpenSession())
            {
                var result = from p in session.Query<Product>()
                    join c in session.Query<Category>() on p.CategoryID equals c.CategoryID
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
