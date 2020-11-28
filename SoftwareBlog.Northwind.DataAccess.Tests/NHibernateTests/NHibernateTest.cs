using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftwareBlog.Northwind.DataAccess.Concrete.EntityFramework;
using SoftwareBlog.Northwind.DataAccess.Concrete.NHibernate;
using SoftwareBlog.Northwind.DataAccess.Concrete.NHibernate.Helper;

namespace SoftwareBlog.Northwind.DataAccess.Tests.NHibernateTests
{
    [TestClass]
    public class NHibernateTest
    {
        [TestMethod]
        public void Get_all_returns_all_products()
        {
            NhProductDal productDal= new NhProductDal(new SqlServerHelper());
            var result = productDal.GetList();
            Assert.AreEqual(79, result.Count);
        }
        [TestMethod]
        public void Get_all_parameters_returns_filtered_all_products()
        {
            NhProductDal productDal = new NhProductDal(new SqlServerHelper());
            var result = productDal.GetList(p=>p.ProductName.Contains("ab"));
            Assert.AreEqual(4, result.Count);
        }
    }
}
