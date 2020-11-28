using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareBlog.Core.DataAccess.NHibernate;
using SoftwareBlog.Northwind.DataAccess.Abstract;
using SoftwareBlog.Northwind.Entities.Concrete;

namespace SoftwareBlog.Northwind.DataAccess.Concrete.NHibernate
{
    public class NhCategoryDal:NhEntityRepositoryBase<Category>,ICategoryDal
    {
        public NhCategoryDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
        }
    }
}
