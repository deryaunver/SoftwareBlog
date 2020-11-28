using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareBlog.Core.DataAccess.EntityFramework;
using SoftwareBlog.Northwind.DataAccess.Abstract;
using SoftwareBlog.Northwind.Entities.Concrete;

namespace SoftwareBlog.Northwind.DataAccess.Concrete.EntityFramework
{
   public class EfCategoryDal:EfEntityRepositoryBase<Category,NorthwindContext>,ICategoryDal
    {
    }
}
