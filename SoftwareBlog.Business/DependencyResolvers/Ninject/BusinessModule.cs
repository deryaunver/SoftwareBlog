using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using SoftwareBlog.Business.Abstract;
using SoftwareBlog.Business.Concrete.Manager;
using SoftwareBlog.Core.DataAccess;
using SoftwareBlog.Core.DataAccess.EntityFramework;
using SoftwareBlog.Core.DataAccess.NHibernate;
using SoftwareBlog.Northwind.DataAccess.Abstract;
using SoftwareBlog.Northwind.DataAccess.Concrete.EntityFramework;
using SoftwareBlog.Northwind.DataAccess.Concrete.NHibernate.Helper;

namespace SoftwareBlog.Business.DependencyResolvers.Ninject
{
   public  class BusinessModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>();


            //STANDART OLANLAR
            Bind(typeof(IQueryableRepository<>)).To(typeof(EfQueryableRepository<>));
            Bind<DbContext>().To<NorthwindContext>();
            Bind<NHibernateHelper>().To<SqlServerHelper>();
        }
    }
}
